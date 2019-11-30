using EncontraCanilApi.Repositorios;
using EncontraCanilApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncontraCanilApi.Servicos
{
    public class EncontraMelhorOpcaoServico : IEncontraMelhorOpcaoServico
    {
        private readonly IRespositorio _repositorio; 
        public EncontraMelhorOpcaoServico(IRespositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public SaidaViewModel EncontrarMelhorOpcao(EntradaViewModel entrada)
        {
            var dia = ObterDiaSemana(entrada.DataBanho);
            var diaUtil = _repositorio.ObterDiasUteis().Contains(dia);

            var valores = CalcularPreco(entrada, diaUtil);
            var valoresOrdenados = valores.OrderBy(pb => pb.PrecoBanho).ToList();
            var saida = new SaidaViewModel();

            if (valoresOrdenados[0].PrecoBanho != valoresOrdenados[1].PrecoBanho)
            {
                saida.Canil = valoresOrdenados[0].Nome;
                saida.Preco = valoresOrdenados[0].PrecoBanho;
            }
            if (valoresOrdenados[0].PrecoBanho == valoresOrdenados[1].PrecoBanho && valoresOrdenados[0].PrecoBanho != valoresOrdenados[2].PrecoBanho)
            {
                var duasMenoresDistancias = new List<double> { valoresOrdenados[0].Distancia, valoresOrdenados[1].Distancia };
                var menorDistancia = duasMenoresDistancias.Min();

                var petShop = valores.FirstOrDefault(ps => ps.Distancia == menorDistancia);

                saida.Canil = petShop.Nome;
                saida.Preco = petShop.PrecoBanho;
            }
            if (valoresOrdenados[0].PrecoBanho == valoresOrdenados[1].PrecoBanho && valoresOrdenados[0].PrecoBanho == valoresOrdenados[2].PrecoBanho)
            {
                var distancas = new List<double> { valoresOrdenados[0].Distancia, valoresOrdenados[1].Distancia, valoresOrdenados[2].Distancia };
                var menorDistancia = distancas.Min();

                var petShop = valores.FirstOrDefault(ps => ps.Distancia == menorDistancia);

                saida.Canil = petShop.Nome;
                saida.Preco = petShop.PrecoBanho;
            }

            return saida;
        }

        public string ObterDiaSemana(DateTime data)
        {
            return new DateTime(data.Year, data.Month, data.Day).DayOfWeek.ToString();
        }

        public List<PetShopViewModel> CalcularPreco(EntradaViewModel entrada, bool diaUtil)
        {
            var petShops = _repositorio.ObterPetShops();

            if (diaUtil)
            {
                foreach (var petShop in petShops)
                    petShop.PrecoBanho = (entrada.QtdCaesGrandes * petShop.PrecoCaoGrandeDiaUtil) + (entrada.QtdCaesPequenos * petShop.PrecoCaoPequenoDiaUtil);
            }
            else
            {
                foreach (var petShop in petShops)
                    petShop.PrecoBanho = (entrada.QtdCaesGrandes * petShop.PrecoCaoGrandeFinalSemana) + (entrada.QtdCaesPequenos * petShop.PrecoCaoPequenoFinalSemana);
            }

            return petShops.ToList();
        }
    }
}
