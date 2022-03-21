using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using YoutubeDownloader.Common;
using YoutubeDownloader.YoutubeDl;

namespace YoutubeDownloader.WebApi.ApiControllers
{
    
    [Route("api/file")]
    public class FilesController : Controller
    {

        private readonly IYoutubeMetadataService _metadata;

        public FilesController(IYoutubeMetadataService metadata)
        {
            _metadata = metadata;
        }

        [Route("{id}/thumbnail")]
        public ActionResult GetThumbnail(string id)
        {
            byte[] bytes = _metadata.GetThumbnailBytes(
                $"{Constants.DataPath}/{id}/{id}.webp");
            return File(bytes, "image/webp");
        }

    }
}