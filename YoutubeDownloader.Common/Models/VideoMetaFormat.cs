using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YoutubeDLSharp.Metadata;

namespace YoutubeDownloader.Common.Models
{
    
    [Table("video_meta_format")]
    public class VideoMetaFormat
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("video_id")]
        public string VideoId { get; set; }

        [Column("file_type")]
        public string FileType { get; set; }

        [Column("video_quality")]
        public string Quality { get; set; }

        [Column("file_size")]
        public long FileSize { get; set; }

        [Column("format_id")]
        public string FormatId { get; set; }

        public static VideoMetaFormat Build(string videoId, FormatData d)
        {
            var format = new VideoMetaFormat();
            format.Quality = d.FormatNote;
            format.FormatId = d.FormatId;
            if (d.FileSize != null)
            {
                format.FileSize = (long) d.FileSize;
            }
            format.VideoId = videoId;
            format.FileType = d.Extension;
            return format;
        }
        
    }
}