using EncontraCanilApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncontraCanilApi.Servicos
{
    public interface IEncontraMelhorOpcaoServico
    {
        SaidaViewModel EncontrarMelhorOpcao(EntradaViewModel entrada);
    }
}
