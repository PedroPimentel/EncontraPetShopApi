using EncontraCanilApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncontraCanilApi.Repositorios
{
    public interface IRespositorio
    {
        List<string> ObterDiasUteis();
        IEnumerable<PetShopViewModel> ObterPetShops();
    }
}
