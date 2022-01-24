namespace YoutubeDownloader.Common
{
    public static class Constants
    {
        public const string DataPath = "/home/optimum/yt-dl/";
        public const string YoutubeDlPath = "";
        
        public const string YoutubeLinkValidatorRegex =
            @"(?:https?:\/\/)?(?:www\.)?youtu\.?be(?:\.com)?\/?.*(?:watch|embed)?(?:.*v=|v\/|\/)([\w\-_]+)\&?";
    }
}