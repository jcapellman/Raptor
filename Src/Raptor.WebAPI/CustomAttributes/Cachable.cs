using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using Raptor.Library.Enums;

using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.Helpers;

namespace Raptor.WebAPI.CustomAttributes {
    public class Cachable : Attribute, IResourceFilter {
        private readonly WEBAPI_REQUESTS _requestEnum;

        private readonly MemoryCacheHelper _memoryCache;

        public Cachable(WEBAPI_REQUESTS requestEnum, IOptions<GlobalSettings> globalSettings, IMemoryCache memoryCache) {
            _requestEnum = requestEnum;
            _memoryCache = new MemoryCacheHelper(memoryCache);
        }

        public void OnResourceExecuting(ResourceExecutingContext context) {
            if (!_memoryCache.ContainsKey(_requestEnum)) {
                return;
            }

            context.Result = new ContentResult() {
                Content = _memoryCache.GetCacheItem<string>(_requestEnum).ReturnValue
            };
        }

        public void OnResourceExecuted(ResourceExecutedContext context) {
            if (_memoryCache.ContainsKey(_requestEnum)) {
                return;
            }

            if (context.Result == null) {
                return;
            }

            var result = JsonConvert.SerializeObject(context.Result);

            if (result != null) {
                _memoryCache.AddCacheItem(_requestEnum, result);
            }
        }
    }
}