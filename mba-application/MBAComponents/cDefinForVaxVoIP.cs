namespace mba_application.MBAComponents
{
    class cDefinForVaxVoIP
    {
        /////////// QoS PRIORITY ////////////////////

        public const int QOS_PRIORITY_LOWEST = 0;
        public const int QOS_PRIORITY_LOWER = 1;
        public const int QOS_PRIORITY_LOW = 2;
        public const int QOS_PRIORITY_HIGH = 3;
        public const int QOS_PRIORITY_HIGHER = 4;
        public const int QOS_PRIORITY_HIGHEST = 5;

        /////////// VIDEO QUALITY ////////////////////

        public const int VIDEO_QUALITY_LOW = 0;
        public const int VIDEO_QUALITY_STANDARD = 1;
        public const int VIDEO_QUALITY_MEDIUM = 2;
        public const int VIDEO_QUALITY_HIGH = 3;
        public const int VIDEO_QUALITY_MAX = 4;

        /////////// VIDEO CODEC ////////////////////

        public const int VAX_CODEC_H263 = 0;
        public const int VAX_CODEC_H263P = 1;

        /////////// AUDIO CODEC ////////////////////

        public const int VAX_CODEC_GSM610 = 0;
        public const int VAX_CODEC_ILBC = 1;
        public const int VAX_CODEC_G711A = 2;
        public const int VAX_CODEC_G711U = 3;
        public const int VAX_CODEC_G729 = 4;

        /////// SIP CHAT CONTACT STATUS /////////////

        public const int CONTACT_STATUS_ONLINE = 0;
        public const int CONTACT_STATUS_OFFLINE = 1;
        public const int CONTACT_STATUS_AWAY = 2;
        public const int CONTACT_STATUS_ON_PHONE = 3;
        public const int CONTACT_STATUS_BUSY = 4;

        ////// SIP CHAT MESSAGE TYPES ////////////////

        public const int CHAT_MESSAGE_TYPE_PLAIN = 101;
        public const int CHAT_MESSAGE_TYPE_HTML = 102;

    }
}
