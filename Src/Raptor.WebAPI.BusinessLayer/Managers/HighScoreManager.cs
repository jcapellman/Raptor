using System.Collections.Generic;

using Raptor.PCL.Common;
using Raptor.PCL.WebAPI.Transports.HighScore;

using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.DataLayer.Entities;
using Raptor.WebAPI.DataLayer.Entities.Objects.Tables;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class HighScoreManager : BaseManager {
        public HighScoreManager(GlobalSettings gSettings) : base(gSettings) { }

        public ReturnSet<List<HighScoreListResponseItem>> GetScores(int levelID) {
            using (var eFactory = new EntityFactory(DatabaseConnection)) {
                return new ReturnSet<List<HighScoreListResponseItem>>();
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