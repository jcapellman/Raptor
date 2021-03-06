﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using Raptor.Library.Common;
using Raptor.Library.Enums;

using Raptor.WebAPI.BusinessLayer.Managers;
using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.Containers;
using Raptor.WebAPI.Helpers;

namespace Raptor.WebAPI.Controllers {
    [Route("api/[controller]")]
    public class BaseController : Controller {
        protected GlobalSettings _globalSettings;
        
        public ManagerContainer MANAGER_CONTAINER => new ManagerContainer { GSetings = _globalSettings };

        protected MemoryCacheHelper MemoryCache;
        
        public BaseController(GlobalSettings globalSettings, IMemoryCache memoryCache) {
            _globalSettings = globalSettings;
            MemoryCache = new MemoryCacheHelper(memoryCache);
        }

        public ReturnSet<T> ReturnHandler<T>(ReturnSet<T> obj, WEBAPI_REQUESTS requestEnum) {
            if (obj.HasError) {
                ExceptionHandler.HandleException(typeof(T).Namespace, obj.ExceptionMessage);
            }

            new RequestManager(MANAGER_CONTAINER.GSetings).RecordRequest(requestEnum, null);
            
            return obj;
        }
    }
}