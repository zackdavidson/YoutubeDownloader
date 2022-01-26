using System.Threading.Tasks;
using YoutubeDLSharp.Metadata;

namespace YoutubeDownloader.YoutubeDl
{
    public interface IYoutubeMetadataService
    {
        public Task<VideoData> GetYoutubeMeta(string url);

        public Task DownloadThumbnail(string thumbnailUrl, string videoId);
    }
}