using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoStampaFatture.Model
{
    public class Trasporto
    {
        public String Bolla { get; set; }

        [Display(Name = "Pr.")]
        public String Provincia { get; set; }

        public DateTime Data { get; set; }
        
        [Display(Name="Valore Trasporto")]
        public float ValoreTrasporto { get; set; }


        [Display(Name = "%Nolo")]
        public float PercentualeNolo { get; set; }

        public float Imponibile { get; set; }

        [Display(Name = "%IVA")]
        public float PercentualeIVA { get; set; }

        [Display(Name = "Importo IVA")]
        public float ImportoIVA { get; set; }

        [Display(Name = "Totale Corrispettivo")]
        public float TotaleCorrispettivo { get; set; }





    }
}
