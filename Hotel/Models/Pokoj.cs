using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Pokoj
    {
        public int Numer { get; set; }
        public string Rodzaj { get; set; }
        public int Cena { get; set; }
        public string DodatkoweInformacje { get; set; }
    }
}
