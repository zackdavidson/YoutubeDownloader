using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YoutubeDLSharp.Metadata;

namespace YoutubeDownloader.Common.Models
{
    
    [Table("video_meta")]
    public class VideoMeta
    {
        
        /// <summary>
        /// This id will be the youtube's id 
        /// </summary>
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("video_title")]
        public string VideoTitle { get; set; }

        [Column("uploader_name")]
        public string UploaderName { get; set; }

        [Column("duration")]
        public float Duration { get; set; }
        
        /// <summary>
        /// When the current object was created
        /// </summary>
        [Column("meta_created")]
        public DateTime MetaCreated { get; set; }

        /// <summary>
        /// This will say if the video already existed in the database
        /// </summary>
        [NotMapped]
        public bool Exists { get; set; }

        public static VideoMeta Build(VideoData data)
        {
            var meta = new VideoMeta();
            if (data.Duration != null)
            {
                meta.Duration = data.Duration.Value;
            }
            meta.Id = data.ID;
            meta.MetaCreated = DateTime.Now;
            meta.UploaderName = data.Channel;
            meta.VideoTitle = data.Title;
            return meta;
        }

    }
}