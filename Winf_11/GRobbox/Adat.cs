using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winf_XO
{
    public class Adat
    {


        
        public string NevX { get; set; }
        public string NevO { get; set; }
        public string Nyertes { get; set; }
        public DateTime Ido { get; set; }

        public Adat(string nevX, string nevO, string nyertes, DateTime ido)
        {
            
            NevX = nevX;
            NevO = nevO;
            Nyertes = nyertes;
            Ido = ido;
        }
    }
}
