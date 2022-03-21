using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
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
            youtubeDl.YoutubeDLPath = $"{Constants.DataPath}yt-dlp";
            
            await youtubeDl.SetMaxNumberOfProcesses(8);
            var result = await youtubeDl.RunVideoDataFetch(url);
            var videoData = result.Data;
            
            await DownloadThumbnail(videoData.Thumbnail, videoData.ID);
            
            return videoData;
        }


        public async Task DownloadThumbnail(string thumbnailUrl, string videoId)
        {
            var path = Path.Combine(Constants.DataPath, videoId + "/");
            var thumbnailFile = path + videoId + ".webp";
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            if (File.Exists(thumbnailFile))
            {
                return;
            }

            using var webClient = new WebClient();
            byte[] thumbnailBytes = await webClient.DownloadDataTaskAsync(new Uri(thumbnailUrl, UriKind.Absolute));
            await File.WriteAllBytesAsync(thumbnailFile, thumbnailBytes);
        }

        public byte[] GetThumbnailBytes(string fileLocation)
        {
            return File.ReadAllBytes(fileLocation);
        }
    }
}