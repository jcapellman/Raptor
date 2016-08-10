using Raptor.PCL.Common;
using Raptor.PCL.WebAPI.Transports.HighScore;

using Raptor.WebAPI.BusinessLayer.Settings;
using Raptor.WebAPI.DataLayer.Entities;

namespace Raptor.WebAPI.BusinessLayer.Managers {
    public class HighScoreManager : BaseManager {
        public HighScoreManager(GlobalSettings gSettings) : base(gSettings) { }

        public ReturnSet<bool> RecordHighScore(HighScoreRequestItem requestItem) {
            using (var eFactory = new EntityFactory(DatabaseConnection)) {
                var highScore = eFactory.HighScores.Create();

                highScore.HighScore = requestItem.HighScore;
                highScore.LevelID = requestItem.LevelID;
                highScore.Username = requestItem.Username;

                eFactory.HighScores.Add(highScore);
                eFactory.SaveChanges();

                return new ReturnSet<bool>(true);
            }
        }
    }
}