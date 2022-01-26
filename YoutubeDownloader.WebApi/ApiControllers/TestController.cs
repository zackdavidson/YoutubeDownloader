using Microsoft.AspNetCore.Mvc;
using YoutubeDownloader.Persistence.Redis;

namespace YoutubeDownloader.WebApi.ApiControllers
{
    
    public class TestController : Controller
    {
        private readonly IRedisService _redis;

        public TestController(IRedisService redis)
        {
            _redis = redis;
        }


        [HttpGet]
        [Route("test1")]
        public ActionResult GetResult1()
        {
            return Ok(_redis.Get<int>("test1"));
        }
        
        [HttpGet]
        [Route("test2")]
        public ActionResult GetResult2()
        {
            return Ok(_redis.Get<int>("test2"));
        }
        
        
        [HttpPost]
        [Route("test1")]
        public ActionResult PostResult1()
        {
            _redis.Set("test1", 30);
            return Ok();
        }
        
        [HttpPost]
        [Route("test2")]
        public ActionResult PostResult2()
        {
            _redis.Set("test2", 30, new(0, 0, 30));
            return Ok();
        }
        
    }
}