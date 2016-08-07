using Microsoft.AspNetCore.Mvc;

using Raptor.PCL.Common;

using Raptor.WebAPI.Containers;
using Raptor.WebAPI.Helpers;
using Raptor.WebAPI.Settings;

namespace Raptor.WebAPI.Controllers {
    [Route("api/[controller]")]
    public class BaseController : Controller {
        protected GlobalSettings _globalSettings;
        
        public ManagerContainer MANAGER_CONTAINER => new ManagerContainer { GSetings = _globalSettings };

        public BaseController(GlobalSettings globalSettings) {
            _globalSettings = globalSettings;
        }

        public ReturnSet<T> ReturnHandler<T>(ReturnSet<T> obj) {
            if (obj.HasError) {
                ExceptionHandler.HandleException(typeof(T).Namespace, obj.ExceptionMessage);
            }

            return obj;
        } 
    }
}