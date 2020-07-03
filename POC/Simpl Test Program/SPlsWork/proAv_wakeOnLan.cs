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

namespace UserModule_PROAV_WAKEONLAN
{
    public class UserModuleClass_PROAV_WAKEONLAN : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SENDWOLPACKET;
        CrestronString MAGICPACKET;
        Crestron.Logos.SplusObjects.StringOutput TODEVICE;
        StringParameter ADDRESSBYTE1;
        StringParameter ADDRESSBYTE2;
        StringParameter ADDRESSBYTE3;
        StringParameter ADDRESSBYTE4;
        StringParameter ADDRESSBYTE5;
        StringParameter ADDRESSBYTE6;
        object SENDWOLPACKET_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 56;
                TODEVICE  .UpdateValue ( MAGICPACKET  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SENDWOLPACKET_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 60;
            Functions.Delay (  (int) ( 50 ) ) ; 
            __context__.SourceCodeLine = 61;
            TODEVICE  .UpdateValue ( ""  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    CrestronString HEADER;
    HEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
    
    CrestronString MACADDRESS;
    MACADDRESS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
    
    CrestronString SUMMEDMACADDRESS;
    SUMMEDMACADDRESS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 69;
        MAGICPACKET  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 70;
        SUMMEDMACADDRESS  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 72;
        HEADER  .UpdateValue ( Functions.Chr (  (int) ( 255 ) ) + Functions.Chr (  (int) ( 255 ) ) + Functions.Chr (  (int) ( 255 ) ) + Functions.Chr (  (int) ( 255 ) ) + Functions.Chr (  (int) ( 255 ) ) + Functions.Chr (  (int) ( 255 ) )  ) ; 
        __context__.SourceCodeLine = 74;
        MACADDRESS  .UpdateValue ( ADDRESSBYTE1 + ADDRESSBYTE2 + ADDRESSBYTE3 + ADDRESSBYTE4 + ADDRESSBYTE5 + ADDRESSBYTE6  ) ; 
        __context__.SourceCodeLine = 77;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)16; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 78;
            SUMMEDMACADDRESS  .UpdateValue ( SUMMEDMACADDRESS + MACADDRESS  ) ; 
            __context__.SourceCodeLine = 77;
            } 
        
        __context__.SourceCodeLine = 81;
        MAGICPACKET  .UpdateValue ( HEADER + SUMMEDMACADDRESS  ) ; 
        
        
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
    MAGICPACKET  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 110, this );
    
    SENDWOLPACKET = new Crestron.Logos.SplusObjects.DigitalInput( SENDWOLPACKET__DigitalInput__, this );
    m_DigitalInputList.Add( SENDWOLPACKET__DigitalInput__, SENDWOLPACKET );
    
    TODEVICE = new Crestron.Logos.SplusObjects.StringOutput( TODEVICE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TODEVICE__AnalogSerialOutput__, TODEVICE );
    
    ADDRESSBYTE1 = new StringParameter( ADDRESSBYTE1__Parameter__, this );
    m_ParameterList.Add( ADDRESSBYTE1__Parameter__, ADDRESSBYTE1 );
    
    ADDRESSBYTE2 = new StringParameter( ADDRESSBYTE2__Parameter__, this );
    m_ParameterList.Add( ADDRESSBYTE2__Parameter__, ADDRESSBYTE2 );
    
    ADDRESSBYTE3 = new StringParameter( ADDRESSBYTE3__Parameter__, this );
    m_ParameterList.Add( ADDRESSBYTE3__Parameter__, ADDRESSBYTE3 );
    
    ADDRESSBYTE4 = new StringParameter( ADDRESSBYTE4__Parameter__, this );
    m_ParameterList.Add( ADDRESSBYTE4__Parameter__, ADDRESSBYTE4 );
    
    ADDRESSBYTE5 = new StringParameter( ADDRESSBYTE5__Parameter__, this );
    m_ParameterList.Add( ADDRESSBYTE5__Parameter__, ADDRESSBYTE5 );
    
    ADDRESSBYTE6 = new StringParameter( ADDRESSBYTE6__Parameter__, this );
    m_ParameterList.Add( ADDRESSBYTE6__Parameter__, ADDRESSBYTE6 );
    
    
    SENDWOLPACKET.OnDigitalPush.Add( new InputChangeHandlerWrapper( SENDWOLPACKET_OnPush_0, false ) );
    SENDWOLPACKET.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SENDWOLPACKET_OnRelease_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_PROAV_WAKEONLAN ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SENDWOLPACKET__DigitalInput__ = 0;
const uint TODEVICE__AnalogSerialOutput__ = 0;
const uint ADDRESSBYTE1__Parameter__ = 10;
const uint ADDRESSBYTE2__Parameter__ = 11;
const uint ADDRESSBYTE3__Parameter__ = 12;
const uint ADDRESSBYTE4__Parameter__ = 13;
const uint ADDRESSBYTE5__Parameter__ = 14;
const uint ADDRESSBYTE6__Parameter__ = 15;

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
