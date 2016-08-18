using System;
using System.ComponentModel.DataAnnotations;

namespace Raptor.WebAPI.DataLayer.Entities.Objects.Tables {
    public class WebAPIRequestLog {
        [Key]
        public int ID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        public int WebAPIRequestID { get; set; }

        public Guid? UserGUID { get; set; }
    }
}