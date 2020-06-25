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

namespace UserModule_PROAV_DVCTRL
{
    public class UserModuleClass_PROAV_DVCTRL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput POWERON;
        Crestron.Logos.SplusObjects.DigitalInput POWEROFF;
        Crestron.Logos.SplusObjects.DigitalInput RESETPROGRESS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> INPUT;
        Crestron.Logos.SplusObjects.DigitalOutput POWERONOUT;
        Crestron.Logos.SplusObjects.DigitalOutput POWEROFFOUT;
        Crestron.Logos.SplusObjects.DigitalOutput PROGRESSFB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> INPUTOUT;
        Crestron.Logos.SplusObjects.AnalogOutput PROGRESS__POUND__;
        UShortParameter PWRDELAY;
        ushort PWR = 0;
        ushort COUNTER = 0;
        private void PROGRESSRESET (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 110;
            PROGRESS__POUND__  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 111;
            PROGRESSFB  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void PROGRESSSTART (  SplusExecutionContext __context__ ) 
            { 
            ushort INCREMENT = 0;
            
            
            __context__.SourceCodeLine = 118;
            PROGRESSFB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 120;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( PROGRESS__POUND__  .Value <= 99 ) ) && Functions.TestForTrue ( Functions.BoolToInt (PROGRESSFB  .Value == 1) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 122;
                INCREMENT = (ushort) ( (100 / PWRDELAY  .Value) ) ; 
                __context__.SourceCodeLine = 123;
                PROGRESS__POUND__  .Value = (ushort) ( (PROGRESS__POUND__  .Value + INCREMENT) ) ; 
                __context__.SourceCodeLine = 125;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( PROGRESS__POUND__  .Value >= 100 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 127;
                    PROGRESSRESET (  __context__  ) ; 
                    __context__.SourceCodeLine = 128;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 131;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 120;
                } 
            
            
            }
            
        object POWERON_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 140;
                Functions.Pulse ( 50, POWERONOUT ) ; 
                __context__.SourceCodeLine = 141;
                PWR = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 142;
                PROGRESSSTART (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object POWEROFF_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 147;
            Functions.Pulse ( 50, POWEROFFOUT ) ; 
            __context__.SourceCodeLine = 148;
            PWR = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 149;
            PROGRESSRESET (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object INPUT_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 154;
        if ( Functions.TestForTrue  ( ( PWR)  ) ) 
            { 
            __context__.SourceCodeLine = 156;
            Functions.Pulse ( 50, INPUTOUT [ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )] ) ; 
            } 
        
        __context__.SourceCodeLine = 158;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PWR == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 160;
            Functions.Pulse ( 50, POWERONOUT ) ; 
            __context__.SourceCodeLine = 161;
            PROGRESSSTART (  __context__  ) ; 
            __context__.SourceCodeLine = 162;
            PWR = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 163;
            Functions.Pulse ( 50, INPUTOUT [ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )] ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RESETPROGRESS_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 169;
        PROGRESSRESET (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    POWERON = new Crestron.Logos.SplusObjects.DigitalInput( POWERON__DigitalInput__, this );
    m_DigitalInputList.Add( POWERON__DigitalInput__, POWERON );
    
    POWEROFF = new Crestron.Logos.SplusObjects.DigitalInput( POWEROFF__DigitalInput__, this );
    m_DigitalInputList.Add( POWEROFF__DigitalInput__, POWEROFF );
    
    RESETPROGRESS = new Crestron.Logos.SplusObjects.DigitalInput( RESETPROGRESS__DigitalInput__, this );
    m_DigitalInputList.Add( RESETPROGRESS__DigitalInput__, RESETPROGRESS );
    
    INPUT = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        INPUT[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( INPUT__DigitalInput__ + i, INPUT__DigitalInput__, this );
        m_DigitalInputList.Add( INPUT__DigitalInput__ + i, INPUT[i+1] );
    }
    
    POWERONOUT = new Crestron.Logos.SplusObjects.DigitalOutput( POWERONOUT__DigitalOutput__, this );
    m_DigitalOutputList.Add( POWERONOUT__DigitalOutput__, POWERONOUT );
    
    POWEROFFOUT = new Crestron.Logos.SplusObjects.DigitalOutput( POWEROFFOUT__DigitalOutput__, this );
    m_DigitalOutputList.Add( POWEROFFOUT__DigitalOutput__, POWEROFFOUT );
    
    PROGRESSFB = new Crestron.Logos.SplusObjects.DigitalOutput( PROGRESSFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( PROGRESSFB__DigitalOutput__, PROGRESSFB );
    
    INPUTOUT = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        INPUTOUT[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( INPUTOUT__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( INPUTOUT__DigitalOutput__ + i, INPUTOUT[i+1] );
    }
    
    PROGRESS__POUND__ = new Crestron.Logos.SplusObjects.AnalogOutput( PROGRESS__POUND____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( PROGRESS__POUND____AnalogSerialOutput__, PROGRESS__POUND__ );
    
    PWRDELAY = new UShortParameter( PWRDELAY__Parameter__, this );
    m_ParameterList.Add( PWRDELAY__Parameter__, PWRDELAY );
    
    
    POWERON.OnDigitalPush.Add( new InputChangeHandlerWrapper( POWERON_OnPush_0, false ) );
    POWEROFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( POWEROFF_OnPush_1, false ) );
    for( uint i = 0; i < 10; i++ )
        INPUT[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( INPUT_OnPush_2, false ) );
        
    RESETPROGRESS.OnDigitalPush.Add( new InputChangeHandlerWrapper( RESETPROGRESS_OnPush_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_PROAV_DVCTRL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint POWERON__DigitalInput__ = 0;
const uint POWEROFF__DigitalInput__ = 1;
const uint RESETPROGRESS__DigitalInput__ = 2;
const uint INPUT__DigitalInput__ = 3;
const uint POWERONOUT__DigitalOutput__ = 0;
const uint POWEROFFOUT__DigitalOutput__ = 1;
const uint PROGRESSFB__DigitalOutput__ = 2;
const uint INPUTOUT__DigitalOutput__ = 3;
const uint PROGRESS__POUND____AnalogSerialOutput__ = 0;
const uint PWRDELAY__Parameter__ = 10;

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
