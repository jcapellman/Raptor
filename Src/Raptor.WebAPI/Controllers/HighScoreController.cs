using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

using Raptor.PCL.Common;
using Raptor.PCL.Enums;
using Raptor.PCL.WebAPI.Transports.HighScore;

using Raptor.WebAPI.BusinessLayer.Managers;
using Raptor.WebAPI.BusinessLayer.Settings;

namespace Raptor.WebAPI.Controllers {
    public class HighScoreController : BaseController {
        public HighScoreController(IOptions<GlobalSettings> globalSettings, IMemoryCache memoryCache) : base(globalSettings.Value, memoryCache) { }

        [HttpPut]
        public ReturnSet<bool> AddHighScore(HighScoreRequestItem requestItem)
            =>
                ReturnHandler(
                    new HighScoreManager(MANAGER_CONTAINER.GSetings).RecordHighScore(requestItem), WebAPIRequests.HIGHSCORE_ADD);
    }
}