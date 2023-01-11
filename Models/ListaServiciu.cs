using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace SalonInfrumusetare.Models
{
    public class ListaServiciu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(ListaServiciu))]
       public int ListaServiciuID { get; set; }
        [ForeignKey(typeof(Serviciu))]
        public int ServiciuID { get; set; }
        [ForeignKey(typeof(TipServiciu))]
        public int TipServiciuID { get; set; }
    }
}

