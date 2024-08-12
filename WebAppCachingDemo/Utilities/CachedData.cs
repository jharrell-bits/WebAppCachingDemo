using Microsoft.Extensions.Caching.Memory;
using WebAppCachingDemo.Models;

namespace WebAppCachingDemo.Utilities
{
    public class CachedData : ICachedData
    {
        private readonly IMemoryCache _memoryCache;

        private readonly string CacheKeyWidgets = "Widgets";

        public CachedData(IMemoryCache memoryCache) 
        {
            _memoryCache = memoryCache;
        }

        public List<Widget> GetWidgets()
        {
            var result = _memoryCache.Get(CacheKeyWidgets) as List<Widget>;

            if (result == null)
            {
                // load data for the cache; this could be a WebAPI or WCFService call
                result = new List<Widget>()
                {
                    new Widget()
                    {
                        Id = 1,
                        Name = "Widget1",
                        Description = "Widget 1",
                        Price = 1m
                    },
                    new Widget()
                    {
                        Id = 2,
                        Name = "Widget2",
                        Description = "Widget 2",
                        Price = 10m
                    },
                    new Widget()
                    {
                        Id = 3,
                        Name = "Widget3",
                        Description = "Widget 3",
                        Price = 100m
                    }
                };

                // add the data to the cache, in this demo we hardcode the cache to hold the data for 20 minutes
                _memoryCache.Set(CacheKeyWidgets, result, new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.UtcNow.AddMinutes(20)
                });
            }

            return result;
        }
    }
}
