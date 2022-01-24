namespace YoutubeDownloader.Processor
{
    public class YoutubeDownloaderConfig
    {
        
        public string YoutubeDlPath { get; set; }
        public string OutputPath { get; set; }
        
        /// <summary>
        /// Creates the id folders and stores anything within
        /// </summary>
        public bool CreateIdFolders { get; set; } = true;
    }
}