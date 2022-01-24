using System;
using System.Threading.Tasks;
using YoutubeDLSharp;
using YoutubeDLSharp.Metadata;
using YoutubeDownloader.Common;

namespace YoutubeDownloader.Persistence.YoutubeDl
{
    public class YoutubeVideoService : IYoutubeVideoService
    {
        public async Task<VideoData> GetYoutubeMeta(string url)
        {
            var youtubeDl = new YoutubeDL();
            youtubeDl.OutputFolder = "/home/optimum/yt-dl/";
            youtubeDl.FFmpegPath = $"{Constants.DataPath}ffmpeg";
            youtubeDl.YoutubeDLPath = $"{Constants.DataPath}youtube-dl";
            await youtubeDl.SetMaxNumberOfProcesses(8);
            var here = await youtubeDl.RunVideoDataFetch(url);
            return here.Data;
        }
    }
}