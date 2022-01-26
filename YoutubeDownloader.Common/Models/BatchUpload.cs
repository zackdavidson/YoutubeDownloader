using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YoutubeDownloader.Common.Models
{
    [Table("batch_upload")]
    public class BatchUpload
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("created")]
        public DateTime Created { get; set; }

    }
}