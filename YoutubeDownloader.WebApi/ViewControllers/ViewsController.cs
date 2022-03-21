using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoutubeDownloader.Persistence.Repositories.Batch;
using YoutubeDownloader.WebApi.Models;

namespace YoutubeDownloader.WebApi.Controllers
{
    public class ViewsController : Controller
    {
        private readonly ILogger<ViewsController> _logger;
        private readonly IBatchUploadService _batchUploadService;

        public ViewsController(ILogger<ViewsController> logger, IBatchUploadService batchUploadService)
        {
            _logger = logger;
            _batchUploadService = batchUploadService;
        }

        [HttpGet]
        [Route("/")]
        [Route("/home")]
        public IActionResult Home()
        {
            return View("~/Views/Layouts/Home/Home.cshtml");
        }


        [HttpGet]
        [Route("batch/{id}")]
        public IActionResult Batch(string id)
        {
            var data = _batchUploadService.GetBatchUploadViewModel(id);
            return View("~/Views/Layouts/Batch/BatchUpload.cshtml", data);
        }
        
        
    }
}