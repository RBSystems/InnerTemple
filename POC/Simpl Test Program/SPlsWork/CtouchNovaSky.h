namespace CtouchNovaSky;
        // class declarations
         class Ctouch;
     class Ctouch 
    {
        // class delegates
        delegate SIMPLSHARPSTRING_FUNCTION StringReturn ( SIMPLSHARPSTRING dataTx_ );
        delegate INTEGER_FUNCTION UshortReturn ( INTEGER value_ );

        // class events

        // class functions
        FUNCTION SourceInfoOn ();
        FUNCTION SourceInfoOff ();
        FUNCTION Poll ();
        FUNCTION DeviceRx ( STRING data_ );
        FUNCTION Initialise ( STRING id_ );
        FUNCTION EnableDebug ( INTEGER state_ );
        FUNCTION PowerOn ();
        FUNCTION PowerOff ();
        FUNCTION BackLightOn ();
        FUNCTION BackLightOff ();
        FUNCTION VolumeControl ( SIGNED_LONG_INTEGER level_ );
        FUNCTION MuteOn ();
        FUNCTION MuteOff ();
        FUNCTION Hdmi1 ();
        FUNCTION Hdmi2 ();
        FUNCTION Hdmi3 ();
        FUNCTION Hdmi4 ();
        FUNCTION Dp ();
        FUNCTION Vga1 ();
        FUNCTION InsidePc ();
        FUNCTION RkAndroid ();
        FUNCTION Home ();
        FUNCTION KeyLockOn ();
        FUNCTION KeyLockOff ();
        FUNCTION PictureModeDynamic ();
        FUNCTION PictureModeStandard ();
        FUNCTION PictureModeSoft ();
        FUNCTION PictureModeUser ();
        FUNCTION PictureModeWriting ();
        FUNCTION SoundModeStandard ();
        FUNCTION SoundModeMusic ();
        FUNCTION SoundModeMovie ();
        FUNCTION SoundModeSport ();
        FUNCTION SoundModeUser ();
        FUNCTION FreezeControlOn ();
        FUNCTION FreezeControlOff ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty StringReturn DeviceTx;
        DelegateProperty UshortReturn PowerFb;
        DelegateProperty UshortReturn BackLightFb;
        DelegateProperty UshortReturn VolumeLevelFb;
        DelegateProperty UshortReturn MuteFb;
        DelegateProperty UshortReturn Hdmi1Fb;
        DelegateProperty UshortReturn Hdmi2Fb;
        DelegateProperty UshortReturn Hdmi3Fb;
        DelegateProperty UshortReturn Hdmi4Fb;
        DelegateProperty UshortReturn DpFb;
        DelegateProperty UshortReturn Vga1Fb;
        DelegateProperty UshortReturn InsidePcFb;
        DelegateProperty UshortReturn HomeFb;
        DelegateProperty UshortReturn KeyLockFb;
        DelegateProperty UshortReturn PictureModeDynamicFb;
        DelegateProperty UshortReturn PictureModeStandardFb;
        DelegateProperty UshortReturn PictureModeSoftFb;
        DelegateProperty UshortReturn PictureModeUserFb;
        DelegateProperty UshortReturn PictureModeWritingFb;
        DelegateProperty UshortReturn SoundModeStandardFb;
        DelegateProperty UshortReturn SoundModeMusicFb;
        DelegateProperty UshortReturn SoundModeMovieFb;
        DelegateProperty UshortReturn SoundModeSportFb;
        DelegateProperty UshortReturn SoundModeUserFb;
        DelegateProperty UshortReturn FreezeControlFb;
        DelegateProperty UshortReturn SourceInfoVisibleFb;
    };

