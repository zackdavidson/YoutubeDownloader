namespace YoutubeDownloader.Common
{
    public static class Constants
    {
        /// <summary>
        /// This will contain all the folders and videos
        /// </summary>
        public const string DataPath = "/home/optimum/yt-dl/";
        public const string YoutubeDlPath = "";
        
        public const string YoutubeLinkValidatorRegex =
            @"(?:https?:\/\/)?(?:www\.)?youtu\.?be(?:\.com)?\/?.*(?:watch|embed)?(?:.*v=|v\/|\/)([\w\-_]+)\&?";
    }
}