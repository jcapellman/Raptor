using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

using Raptor.PCL.Enums;

using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.Helpers;

namespace Raptor.WebAPI.CustomAttributes {
    public class Cachable : ActionFilterAttribute {
        private readonly WEBAPI_REQUESTS _requestEnum;

        private readonly MemoryCacheHelper _memoryCache;

        public Cachable(WEBAPI_REQUESTS requestEnum, IOptions<GlobalSettings> globalSettings, IMemoryCache memoryCache) {
            _requestEnum = requestEnum;
            _memoryCache = new MemoryCacheHelper(memoryCache);
        }
        
        public override void OnActionExecuting(ActionExecutingContext context) {
            if (!_memoryCache.ContainsKey(_requestEnum)) {
                return;
            }

            // todo handle returning the cache item

            base.OnActionExecuting(context);
        }
    }
}