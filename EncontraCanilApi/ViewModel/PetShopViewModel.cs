using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncontraCanilApi.ViewModel
{
    public class PetShopViewModel
    {
        public string Nome { get; set; }
        public double Distancia { get; set; }
        public double PrecoCaoPequenoDiaUtil { get; set; }
        public double PrecoCaoGrandeDiaUtil { get; set; }
        public double PrecoCaoPequenoFinalSemana { get; set; }
        public double PrecoCaoGrandeFinalSemana { get; set; }
        public double PrecoBanho { get; set; }
    }
}
