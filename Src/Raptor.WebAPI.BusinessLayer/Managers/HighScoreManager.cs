using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Raptor.Library.Common;
using Raptor.Library.WebAPI.Transports.HighScore;

using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.DataLayer.Entities;
using Raptor.WebAPI.DataLayer.Entities.Objects.SPs;
using Raptor.WebAPI.DataLayer.Entities.Objects.Tables;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class HighScoreManager : BaseManager {
        public HighScoreManager(GlobalSettings gSettings) : base(gSettings) { }

        public ReturnSet<List<HighScoreListResponseItem>> GetScores(int levelID) {
            using (var eFactory = new EntityFactory(DatabaseConnection)) {
                var result = eFactory.Set<WEBAPI_getHighScoreListSP>().FromSql("dbo.WEBAPI_getHighScoreListSP @LevelID = {0}", levelID).ToList();

                var response = result.Select(a => new HighScoreListResponseItem {
                    HighScore = a.HighScore,
                    Username = a.Username
                }).ToList();

                return new ReturnSet<List<HighScoreListResponseItem>>(response);
            }
        }

        public ReturnSet<bool> RecordHighScore(HighScoreRequestItem requestItem) {
            using (var eFactory = new EntityFactory(DatabaseConnection)) {
                var highScore = new HighScores {
                    HighScore = requestItem.HighScore,
                    LevelID = requestItem.LevelID,
                    Username = requestItem.Username
                };

                eFactory.HighScores.Add(highScore);
                eFactory.SaveChanges();

                return new ReturnSet<bool>(true);
            }
        }
    }
}