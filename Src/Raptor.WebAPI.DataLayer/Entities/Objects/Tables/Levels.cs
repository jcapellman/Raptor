using System;

namespace Raptor.WebAPI.DataLayer.Entities.Objects.Tables {
    public class Levels : BaseTable {
        public string LevelName { get; set; }

        public string LevelDescription { get; set; }

        public string LevelData { get; set; }

        public Guid UserGUID { get; set; }
    }
}