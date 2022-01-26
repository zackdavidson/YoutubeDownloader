using System.Collections.Generic;
using YoutubeDownloader.Common.Models;

namespace YoutubeDownloader.Common.ViewModels
{
    public class BatchUploadViewModel
    {
        public BatchUpload Upload { get; set; }
        public List<VideoMetaViewModel> VideoMetaViewModels { get; set; }
    }
}