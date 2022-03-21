using System.Collections.Generic;
using YoutubeDownloader.Common.Models;

namespace YoutubeDownloader.Common.ViewModels
{
    public class VideoMetaViewModel
    {
        public VideoMeta Meta { get; set; }

        public string ThumbnailLocation => $"/api/file/{Meta.Id}/thumbnail";

        public List<VideoMetaFormat> Formats { get; set; }
    }
}