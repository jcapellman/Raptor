using Microsoft.AspNetCore.Mvc.Filters;

using Raptor.PCL.Enums;
using Raptor.WebAPI.Helpers;

namespace Raptor.WebAPI.CustomAttributes {
    public class Cachable : ActionFilterAttribute {
        private readonly WEBAPI_REQUESTS _requestEnum;

        private MemoryCacheHelper _memoryCache;

        public Cachable(WEBAPI_REQUESTS request, object optionalArg = null) {
            _requestEnum = request;
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