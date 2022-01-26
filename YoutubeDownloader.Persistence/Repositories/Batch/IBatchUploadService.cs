using System.Collections.Generic;
using YoutubeDownloader.Common.Models;
using YoutubeDownloader.Common.ViewModels;

namespace YoutubeDownloader.Persistence.Repositories.Batch
{
    public interface IBatchUploadService
    {
        /// <summary>
        /// Creates a batch of uploads
        /// </summary>
        /// <param name="urls">The urls for the videos to get data from</param>
        /// <returns></returns>
        public BatchUpload CreateBatchUpload(List<string> urls);

        public BatchUploadViewModel GetBatchUploadViewModel(string batchId);

    }
}