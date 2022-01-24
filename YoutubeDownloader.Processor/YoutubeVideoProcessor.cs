using System;
using System.Diagnostics;

namespace YoutubeDownloader.Processor
{
    class YoutubeVideoProcessor : AbstractYoutubeProcessor
    {
        
        public override YoutubeProcessResult FetchVideoQuality(string url)
        {
            var proc = new Process 
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $"{Config.YoutubeDlPath}",
                    Arguments = $"-F {url}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                Console.WriteLine("line");
            }
            
            return new YoutubeProcessResult(){};
        }

        public YoutubeVideoProcessor(YoutubeDownloaderConfig config) : base(config)
        {
        }
    }
}