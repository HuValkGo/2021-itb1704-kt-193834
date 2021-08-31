using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ITB1704Application.Model
{
    public class RouteStop 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RouteId{ get; set; }
        public int OrderNo { get; set; }
        public string StopName { get; set; }

    }
}
