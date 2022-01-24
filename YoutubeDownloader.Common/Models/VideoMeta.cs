using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YoutubeDownloader.Common.Models
{
    [Table("video_meta")]
    public class VideoMeta
    {
        [Key]
        [Column("meta")]
        private string Id { get; set; }

        [Column("video_title")]
        private string VideoTitle { get; set; }

        [Column("uploader_name")]
        private string UploaderName { get; set; }

        [Column("duration")]
        private float Duration { get; set; }


    }
}