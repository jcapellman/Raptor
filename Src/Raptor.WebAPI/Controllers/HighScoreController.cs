using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Raptor.PCL.Common;
using Raptor.PCL.WebAPI.Transports.HighScore;

using Raptor.WebAPI.BusinessLayer.Managers;
using Raptor.WebAPI.BusinessLayer.Settings;

namespace Raptor.WebAPI.Controllers {
    public class HighScoreController : BaseController {
        public HighScoreController(IOptions<GlobalSettings> globalSettings) : base(globalSettings.Value) { }

        [HttpPut]
        public ReturnSet<bool> AddHighScore(HighScoreRequestItem requestItem)
            =>
                ReturnHandler(
                    new HighScoreManager(MANAGER_CONTAINER.GSetings).RecordHighScore(requestItem));
    }
}