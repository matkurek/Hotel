using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Rezerwacja
    {
        public int id { get; set; }
        public DateTime dataOd { get; set; }
        public DateTime dataDo { get; set; }
        public int pokojNumer { get; set; }
        public int ileDni { get; set; }
        public int przychod { get; set; }
    }
}
