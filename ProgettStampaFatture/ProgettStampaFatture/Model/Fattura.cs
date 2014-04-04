using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoStampaFatture.Model
{
    public class Fattura
    {

        public Fattura()
        {
            Trasporti = new List<Trasporto>();
        }

        public Int64 Numero { get; set; }
        public DateTime Data { get; set; }

        public String Causale { get; set; }

        public String Intestatario { get; set; }

        public List<Trasporto> Trasporti { get; set; }

    }
}
