using Microsoft.AspNetCore.Mvc;
using YoutubeDownloader.Persistence.YoutubeDl;

namespace YoutubeDownloader.WebApi.ApiControllers
{
    [Route("api/batch")]
    public class BatchUploadController : Controller
    {

        private readonly IYoutubeVideoService _videoService;

        public BatchUploadController(IYoutubeVideoService videoService)
        {
            _videoService = videoService;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadBatch([FromForm] string urls)
        {
            _videoService.GetYoutubeMeta(urls);
            return Ok();
        }
        
        
    }
}