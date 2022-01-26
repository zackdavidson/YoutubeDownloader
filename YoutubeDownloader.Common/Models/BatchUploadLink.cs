using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YoutubeDownloader.Common.Models
{
    [Table("batch_upload_link")]
    public class BatchUploadLink
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("batch_upload_id")]
        public string BatchUploadId { get; set; }

        [Column("video_id")]
        public string VideoId { get; set; }

    }
}