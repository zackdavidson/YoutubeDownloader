using System.Threading.Tasks;
using YoutubeDLSharp.Metadata;

namespace YoutubeDownloader.Persistence.YoutubeDl
{
    public interface IYoutubeVideoService
    {
        public Task<VideoData> GetYoutubeMeta(string url);
    }
}