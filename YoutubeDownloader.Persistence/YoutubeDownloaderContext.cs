using Microsoft.EntityFrameworkCore;
using YoutubeDownloader.Common.Models;

namespace YoutubeDownloader.Persistence
{
    public class YoutubeDownloaderContext : DbContext
    {
        
        public YoutubeDownloaderContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<VideoMeta> VideoMetas { get; set; }

        public DbSet<VideoMetaFormat> VideoMetaFormats { get; set; }
            
        public DbSet<BatchUpload> BatchUpload { get; set; }

        public DbSet<BatchUploadLink> BatchUploadLinks { get; set; }

    }
}