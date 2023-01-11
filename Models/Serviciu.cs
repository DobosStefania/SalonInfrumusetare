using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SalonInfrumusetare.Models
{
    public class Serviciu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Required,StringLength(150,MinimumLength =3)]
        [Display(Name ="Tip serviciu infrumusetare")]
        public string Tip_serviciu { get; set; }
        public string Personalul { get; set; }
        [Range(1,300)]
        
        public decimal Price { get; set; }
        public List<ListaServiciu> ListaServiciu { get; internal set; }
    }
}
