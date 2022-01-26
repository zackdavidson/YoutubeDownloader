using System.Collections.Generic;
using System.Linq;
using YoutubeDownloader.Common.Models;

namespace YoutubeDownloader.Persistence.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly YoutubeDownloaderContext _context;

        public VideoRepository(YoutubeDownloaderContext context)
        {
            _context = context;
        }

        public VideoMeta CreateVideoMeta(VideoMeta video)
        {
            var exists = _context.VideoMetas.SingleOrDefault(e => e.Id == video.Id);
            if (exists != null)
            {
                exists.Exists = true;
                return exists;
            }
            
            var result = _context.VideoMetas.Add(video).Entity;
            _context.SaveChanges();
            return result;
        }

        public List<VideoMetaFormat> CreateVideoFormats(List<VideoMetaFormat> formats)
        {
            _context.VideoMetaFormats.AddRange(formats);
            _context.SaveChanges();
            return formats;
        }

        public List<VideoMetaFormat> FetchVideoFormats(string videoId)
        {
            var results = _context.VideoMetaFormats
                .Where(e => e.VideoId == videoId)
                .ToList();
            return results;
        }

        public VideoMeta FetchVideo(string videoId)
        {
            var video = _context.VideoMetas.SingleOrDefault(e => e.Id == videoId);
            return video;
        }
    }
}