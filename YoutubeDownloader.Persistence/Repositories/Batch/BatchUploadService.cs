using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeDLSharp.Metadata;
using YoutubeDownloader.Common.Models;
using YoutubeDownloader.Common.ViewModels;
using YoutubeDownloader.YoutubeDl;

namespace YoutubeDownloader.Persistence.Repositories.Batch
{
    public class BatchUploadService : IBatchUploadService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IYoutubeMetadataService _youtubeMetadata;
        private readonly YoutubeDownloaderContext _context;

        public BatchUploadService(IYoutubeMetadataService youtubeMetadata, IVideoRepository videoRepository, YoutubeDownloaderContext context)
        {
            _youtubeMetadata = youtubeMetadata;
            _videoRepository = videoRepository;
            _context = context;
        }

        public BatchUpload CreateBatchUpload(List<string> urls)
        {
            var newBatch = new BatchUpload();
            newBatch.Id = Guid.NewGuid().ToString();
            newBatch.Created = DateTime.Now;
            
            var videoData = GetVideoData(urls);
            
            foreach (var video in videoData)
            {
                var videoMeta = VideoMeta.Build(video);
                var formats = new List<VideoMetaFormat>();
                
                foreach (var format in video.Formats)
                {
                    if (format.Extension != "mp4") continue;
                    if (format.FileSize == 0) continue;
                    
                    formats.Add(VideoMetaFormat.Build(videoMeta.Id, format));
                }

                _context.BatchUploadLinks.Add(new BatchUploadLink()
                {
                    BatchUploadId = newBatch.Id,
                    VideoId = videoMeta.Id
                });
                
                var added = _videoRepository.CreateVideoMeta(videoMeta);
                if (!added.Exists)
                {
                    _videoRepository.CreateVideoFormats(formats);
                }
            }

            _context.BatchUpload.Add(newBatch);
            _context.SaveChanges();
            
            return newBatch;
        }

        public BatchUploadViewModel GetBatchUploadViewModel(string batchId)
        {
            var model = new BatchUploadViewModel();
            model.Upload = _context.BatchUpload.SingleOrDefault(e => e.Id == batchId);

            var videos = new List<VideoMetaViewModel>();
            var videoLinks = _context.BatchUploadLinks
                .Where(e => e.BatchUploadId == batchId)
                .ToList();

            foreach (var videoLink in videoLinks)
            {
                var metaVideo = _videoRepository.FetchVideo(videoLink.VideoId);
                var formats = _videoRepository.FetchVideoFormats(metaVideo.Id);

                var metaViewModel = new VideoMetaViewModel();
                metaViewModel.Formats = formats;
                metaViewModel.Meta = metaVideo;
                videos.Add(metaViewModel);
            }

            model.VideoMetaViewModels = videos;
            return model;
        }


        private List<VideoData> GetVideoData(List<string> urls)
        {
            var allTasks = new List<Task<VideoData>>();
            foreach (var url in urls)
            {
                allTasks.Add(_youtubeMetadata.GetYoutubeMeta(url));
            }
            Task.WaitAll(allTasks.ToArray());
            return allTasks.Select(task => task.Result).ToList();
        }
        
    }
}