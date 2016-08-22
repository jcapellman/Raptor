using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raptor.WebAPI.DataLayer.Entities.Objects.Tables {
    [Table("Levels")]
    public class Levels : BaseTable {
        public string LevelName { get; set; }

        public string LevelDescription { get; set; }

        public string LevelData { get; set; }

        public Guid UserGUID { get; set; }
    }
}