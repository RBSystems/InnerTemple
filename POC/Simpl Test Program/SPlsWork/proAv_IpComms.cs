using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_PROAV_IPCOMMS
{
    public class UserModuleClass_PROAV_IPCOMMS : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput DEBUG;
        Crestron.Logos.SplusObjects.DigitalInput RECONNECT;
        Crestron.Logos.SplusObjects.StringInput TX__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput COMMSFB;
        Crestron.Logos.SplusObjects.StringOutput STATUS__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput RX__DOLLAR__;
        SplusTcpClient CLIENT;
        StringParameter IPADDRESS;
        UShortParameter PORT;
        private void CLIENTCONNECT (  SplusExecutionContext __context__ ) 
            { 
            short STATUS = 0;
            
            
            __context__.SourceCodeLine = 110;
            STATUS = (short) ( Functions.SocketConnectClient( CLIENT , IPADDRESS  , (ushort)( PORT  .Value ) , (ushort)( 1 ) ) ) ; 
            __context__.SourceCodeLine = 112;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STATUS < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 112;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 112;
                    Print( "ERROR connecting socket to address {0} on port {1:d}\r\n", IPADDRESS , (short)PORT  .Value) ; 
                    }
                
                __context__.SourceCodeLine = 113;
                STATUS__DOLLAR__  .UpdateValue ( "Status: Disconnected"  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 114;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 114;
                    Print( "Connected socket to address {0} on port {1:d}\r\n", IPADDRESS , (short)PORT  .Value) ; 
                    }
                
                }
            
            
            }
            
        private void CLIENTDISCONNECT (  SplusExecutionContext __context__ ) 
            { 
            short STATUS = 0;
            
            
            __context__.SourceCodeLine = 121;
            STATUS = (short) ( Functions.SocketDisconnectClient( CLIENT ) ) ; 
            __context__.SourceCodeLine = 123;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STATUS < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 123;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 123;
                    Print( "ERROR disconnecting socket to address {0} on port {1:d}\r\n", IPADDRESS , (short)PORT  .Value) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 124;
                    if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                        {
                        __context__.SourceCodeLine = 124;
                        Print( "Disconnected socket to address {0} on port {1:d}\r\n", IPADDRESS , (short)PORT  .Value) ; 
                        }
                    
                    }
                
                }
            
            
            }
            
        object RECONNECT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 134;
                CLIENTDISCONNECT (  __context__  ) ; 
                __context__.SourceCodeLine = 135;
                CLIENTCONNECT (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object CLIENT_OnSocketReceive_1 ( Object __Info__ )
    
        { 
        SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
            
            __context__.SourceCodeLine = 140;
            RX__DOLLAR__  .UpdateValue ( CLIENT .  SocketRxBuf  ) ; 
            __context__.SourceCodeLine = 141;
            Functions.ClearBuffer ( CLIENT .  SocketRxBuf ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SocketInfo__ ); }
        return this;
        
    }
    
object TX__DOLLAR___OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        short STATUS = 0;
        
        
        __context__.SourceCodeLine = 148;
        STATUS = (short) ( Functions.SocketSend( CLIENT , TX__DOLLAR__ ) ) ; 
        __context__.SourceCodeLine = 150;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STATUS < 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 150;
            if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 150;
                Print( "ERROR sending to address {0} on port {1:d}\r\n", IPADDRESS , (short)PORT  .Value) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 151;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 151;
                    Print( "String sent to address {0} on port {1:d} string {2}\r\n", IPADDRESS , (short)PORT  .Value, TX__DOLLAR__ ) ; 
                    }
                
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLIENT_OnSocketConnect_3 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        __context__.SourceCodeLine = 156;
        COMMSFB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 157;
        STATUS__DOLLAR__  .UpdateValue ( "Status: Connected"  ) ; 
        __context__.SourceCodeLine = 158;
        if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 158;
            Print( "Socket Connected to {0} on port  {1:d}\r\n", IPADDRESS , (short)PORT  .Value) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object CLIENT_OnSocketDisconnect_4 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        __context__.SourceCodeLine = 163;
        COMMSFB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 164;
        STATUS__DOLLAR__  .UpdateValue ( "Status: Disconnected"  ) ; 
        __context__.SourceCodeLine = 165;
        if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 165;
            Print( "Socket Disconnected to {0} on port {1:d}\r\n", IPADDRESS , (short)PORT  .Value) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 177;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 178;
        STATUS__DOLLAR__  .UpdateValue ( "Status: Disconnected"  ) ; 
        __context__.SourceCodeLine = 179;
        CLIENTCONNECT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    CLIENT  = new SplusTcpClient ( 1024, this );
    
    DEBUG = new Crestron.Logos.SplusObjects.DigitalInput( DEBUG__DigitalInput__, this );
    m_DigitalInputList.Add( DEBUG__DigitalInput__, DEBUG );
    
    RECONNECT = new Crestron.Logos.SplusObjects.DigitalInput( RECONNECT__DigitalInput__, this );
    m_DigitalInputList.Add( RECONNECT__DigitalInput__, RECONNECT );
    
    COMMSFB = new Crestron.Logos.SplusObjects.DigitalOutput( COMMSFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( COMMSFB__DigitalOutput__, COMMSFB );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( TX__DOLLAR____AnalogSerialInput__, 1000, this );
    m_StringInputList.Add( TX__DOLLAR____AnalogSerialInput__, TX__DOLLAR__ );
    
    STATUS__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( STATUS__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( STATUS__DOLLAR____AnalogSerialOutput__, STATUS__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( RX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( RX__DOLLAR____AnalogSerialOutput__, RX__DOLLAR__ );
    
    PORT = new UShortParameter( PORT__Parameter__, this );
    m_ParameterList.Add( PORT__Parameter__, PORT );
    
    IPADDRESS = new StringParameter( IPADDRESS__Parameter__, this );
    m_ParameterList.Add( IPADDRESS__Parameter__, IPADDRESS );
    
    
    RECONNECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( RECONNECT_OnPush_0, false ) );
    CLIENT.OnSocketReceive.Add( new SocketHandlerWrapper( CLIENT_OnSocketReceive_1, false ) );
    TX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( TX__DOLLAR___OnChange_2, false ) );
    CLIENT.OnSocketConnect.Add( new SocketHandlerWrapper( CLIENT_OnSocketConnect_3, false ) );
    CLIENT.OnSocketDisconnect.Add( new SocketHandlerWrapper( CLIENT_OnSocketDisconnect_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_PROAV_IPCOMMS ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint DEBUG__DigitalInput__ = 0;
const uint RECONNECT__DigitalInput__ = 1;
const uint TX__DOLLAR____AnalogSerialInput__ = 0;
const uint COMMSFB__DigitalOutput__ = 0;
const uint STATUS__DOLLAR____AnalogSerialOutput__ = 0;
const uint RX__DOLLAR____AnalogSerialOutput__ = 1;
const uint IPADDRESS__Parameter__ = 10;
const uint PORT__Parameter__ = 11;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
