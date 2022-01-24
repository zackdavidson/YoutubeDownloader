namespace YoutubeDownloader.Processor
{
    public class YoutubeDownload
    {
        /// <summary>
        /// The path to the youtube DL
        /// </summary>
        private readonly YoutubeDownloaderConfig Config;
        
        /// <summary>
        /// The processor
        /// </summary>
        private readonly AbstractYoutubeProcessor Processor;
        
        public YoutubeDownload(YoutubeDownloaderConfig config)
        {
            Config = config;
            Processor = new YoutubeVideoProcessor(Config);
        }

        public void GetVideoMetadata(string url)
        {
            Processor.FetchVideoQuality(url);
        }
        
        
        
    }
}