using Microsoft.Extensions.Caching.Memory;

using Raptor.PCL.Common;
using Raptor.PCL.Enums;
using Raptor.PCL.WebAPI.Transports.Levels;

using Raptor.WebAPI.BusinessLayer.Managers;
using Raptor.WebAPI.BusinessLayer.Settings;

namespace Raptor.WebAPI.Controllers {
    public class LevelsController : BaseController {
        public LevelsController(GlobalSettings globalSettings, IMemoryCache memoryCache) : base(globalSettings, memoryCache) { }

        public ReturnSet<bool> POST(LevelCreationRequestItem requestItem)
            =>
                ReturnHandler(new LevelManager(MANAGER_CONTAINER.GSetings).CreateUpdate(requestItem),
                    WEBAPI_REQUESTS.LEVELCREATION_UPDATE);        

        public ReturnSet<bool> DELETE(int levelID)
            =>
            ReturnHandler(new LevelManager(MANAGER_CONTAINER.GSetings).Delete(levelID),
                WEBAPI_REQUESTS.LEVELCREATION_DELETE);
    }
}