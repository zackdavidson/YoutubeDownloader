using System;

namespace YoutubeDownloader.Persistence.Redis
{
    public interface IRedisService
    {
        public T Get<T>(string key);
        
        public bool Set(string key, object value, TimeSpan expire);
        
        public bool Set(string key, object value);
        
    }
}