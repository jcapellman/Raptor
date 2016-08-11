using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using Raptor.PCL.Common;

using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.Containers;
using Raptor.WebAPI.Helpers;

namespace Raptor.WebAPI.Controllers {
    [Route("api/[controller]")]
    public class BaseController : Controller {
        protected GlobalSettings _globalSettings;
        
        public ManagerContainer MANAGER_CONTAINER => new ManagerContainer { GSetings = _globalSettings };

        protected IMemoryCache _memoryCache;

        public BaseController(GlobalSettings globalSettings, IMemoryCache memoryCache) {
            _globalSettings = globalSettings;
            _memoryCache = memoryCache;
        }

        public ReturnSet<T> ReturnHandler<T>(ReturnSet<T> obj) {
            if (obj.HasError) {
                ExceptionHandler.HandleException(typeof(T).Namespace, obj.ExceptionMessage);
            }

            return obj;
        }

        public ReturnSet<T> GetCacheItem<T>(string key) {
            var item = _memoryCache.Get<T>(key);

            return item == null ? new ReturnSet<T>($"{key} was not found in cache") : new ReturnSet<T>(item);
        }

        public void AddCacheItem<T>(string key, T obj) {
            _memoryCache.Set(key, obj);
        }

        public void RemoveCacheItem(string key) {
            _memoryCache.Remove(key);
        }
    }
}