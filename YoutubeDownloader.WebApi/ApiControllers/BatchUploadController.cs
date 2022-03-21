using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YoutubeDownloader.Common.Models;
using YoutubeDownloader.Common.ViewModels;
using YoutubeDownloader.Persistence.Repositories.Batch;
using YoutubeDownloader.YoutubeDl;

namespace YoutubeDownloader.WebApi.ApiControllers
{
    [Route("api/batch")]
    public class BatchUploadController : Controller
    {

        private readonly IBatchUploadService _batch;

        public BatchUploadController(IBatchUploadService batch)
        {
            _batch = batch;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<BatchUpload> UploadBatch([FromForm] string urls)
        {
            var urlList = urls.Split(", ");
            var upload = _batch.CreateBatchUpload(urlList.ToList());
            
            return Redirect("/batch/"+upload.Id);
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<BatchUploadViewModel> GetBatch(string id)
        {
            return Ok(_batch.GetBatchUploadViewModel(id));
        }

        
        
    }
}