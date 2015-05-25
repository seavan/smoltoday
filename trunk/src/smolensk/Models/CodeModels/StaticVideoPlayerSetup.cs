namespace smolensk.Models
{
    public class StaticVideoPlayerSetup : PlayerSetup
    {
        /* public StaticVideoPlayerSetup(videos video)
        {
            Provider = PlayerProvider.ppDefault;
            File = video.GetFile();
            Thumb = video.GetThumb();
            Streamer = "lighttpd";
            WideScreen = video.widescreen > 0;
        } */
    }

    public class LiveVideoPlayerSetup : PlayerSetup
    {
        public LiveVideoPlayerSetup(string _streamer, string _file)
        {
            Provider = PlayerProvider.ppRtmp;
            File = _file;
            //Thumb = video.GetThumb();
            Streamer = _streamer;
        }
    }
}