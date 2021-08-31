using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ITB1704Application.Model
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int DepartureRouteStopId { get; set; }
        public int DestinationRouteStopId { get; set; }
        public double Price { get; set; }

        [JsonIgnore]
        public ICollection<RouteStop> RouteStops { get; set; }

    }
}
