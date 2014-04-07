using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoStampaFatture.Model
{
    public enum Pagamento { Bonifico = 1, Contanti = 2, Assegno = 3};

    public class Fattura
    {

        public Fattura()
        {
            Trasporti = new List<Trasporto>();
            Pagamenti = new List<Pagamento>();
        }

        public Int64 Numero { get; set; }
        public DateTime Data { get; set; }

        public String Causale { get; set; }

        public String Intestatario { get; set; }

        public List<Pagamento> Pagamenti { get; set; }

        public List<Trasporto> Trasporti { get; set; }

    }
}
