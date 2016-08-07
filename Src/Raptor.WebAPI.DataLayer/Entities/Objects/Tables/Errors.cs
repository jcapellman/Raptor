using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raptor.WebAPI.DataLayer.Entities.Objects.Tables {
    [Table("Errors")]
    public class Errors {
        [Key]
        public int ID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        public string Source { get; set; }

        public string Exception { get; set; }

        public int PlatformID { get; set; }
    }
}