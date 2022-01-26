using System;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace YoutubeDownloader.Persistence.Redis
{
    public class RedisService : IRedisService
    {
        
        private readonly IDatabase _redisServer;

        public RedisService(IConnectionMultiplexer redisServer)
        {
            _redisServer = redisServer.GetDatabase();
        }

        public T Get<T>(string key)
        {
            try
            {
                var value = _redisServer.StringGet(key).ToString();
                return JsonConvert.DeserializeObject<T>(value);
            }
            catch
            {
                return default(T);
            }
        }

        public bool Set(string key, object value, TimeSpan expire)
        {
            try
            {
                return _redisServer.StringSet(key, JsonConvert.SerializeObject(value), expire);
            }
            catch
            {
                return false;
            }
        }
        
        public bool Set(string key, object value)
        {
            try
            {
                return _redisServer.StringSet(key, JsonConvert.SerializeObject(value));
            }
            catch
            {
                return false;
            }
        }
    }
}