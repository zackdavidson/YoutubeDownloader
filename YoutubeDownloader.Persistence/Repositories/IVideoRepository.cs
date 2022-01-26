using System.Collections.Generic;
using YoutubeDownloader.Common.Models;

namespace YoutubeDownloader.Persistence.Repositories
{
    public interface IVideoRepository
    {
        
        VideoMeta CreateVideoMeta(VideoMeta video);

        List<VideoMetaFormat> CreateVideoFormats(List<VideoMetaFormat> formats);
        
        List<VideoMetaFormat> FetchVideoFormats(string videoId);

        VideoMeta FetchVideo(string videoId);
        
        

    }
}