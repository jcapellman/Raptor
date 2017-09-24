using Microsoft.Extensions.Caching.Memory;

using Raptor.Library.Common;
using Raptor.Library.Enums;
using Raptor.Library.WebAPI.Transports.Levels;

using Raptor.WebAPI.BusinessLayer.Managers;
using Raptor.WebAPI.BusinessLayer.Settings;

namespace Raptor.WebAPI.Controllers {
    public class LevelCreationController : BaseController {
        public LevelCreationController(GlobalSettings globalSettings, IMemoryCache memoryCache) : base(globalSettings, memoryCache) { }

        public ReturnSet<bool> POST(LevelCreationUpdateRequestItem requestItem)
            =>
                ReturnHandler(new LevelManager(MANAGER_CONTAINER.GSetings).Update(requestItem),
                    WEBAPI_REQUESTS.LEVELCREATION_UPDATE);

        public ReturnSet<bool> PUT(LevelCreationRequestItem requestItem)
            =>
            ReturnHandler(new LevelManager(MANAGER_CONTAINER.GSetings).Create(requestItem),
                WEBAPI_REQUESTS.LEVELCREATION_CREATE);

        public ReturnSet<LevelResponseItem> GET(int levelID)
            => ReturnHandler(new LevelManager(MANAGER_CONTAINER.GSetings).Get(levelID), WEBAPI_REQUESTS.LEVELCREATION_GET);

        public ReturnSet<bool> DELETE(int levelID)
            =>
            ReturnHandler(new LevelManager(MANAGER_CONTAINER.GSetings).Delete(levelID),
                WEBAPI_REQUESTS.LEVELCREATION_DELETE);
    }
}