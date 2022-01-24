using System;

namespace YoutubeDownloader.Processor
{
    public abstract class AbstractYoutubeProcessor
    {
        protected readonly YoutubeDownloaderConfig Config;

        protected AbstractYoutubeProcessor(YoutubeDownloaderConfig config)
        {
            Config = config;
        }

        public abstract YoutubeProcessResult FetchVideoQuality(string url);
    }
}