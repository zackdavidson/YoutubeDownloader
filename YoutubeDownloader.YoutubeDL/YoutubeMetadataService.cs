using System.Threading.Tasks;
using YoutubeDLSharp;
using YoutubeDLSharp.Metadata;
using YoutubeDownloader.Common;

namespace YoutubeDownloader.YoutubeDl
{
    public class YoutubeMetadataService : IYoutubeMetadataService
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


        public async Task DownloadThumbnail(string thumbnailUrl, string videoId)
        {
            //TODO: check an image already exists
            
            // Get a stream of the thumbail data
        }
    }
}