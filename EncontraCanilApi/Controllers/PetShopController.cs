using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncontraCanilApi.Servicos;
using EncontraCanilApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EncontraCanilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PetShopController : ControllerBase
    {
        private readonly IEncontraMelhorOpcaoServico _encontraMelhorOpcaoServico;
        public PetShopController(IEncontraMelhorOpcaoServico encontraMelhorOpcaoServico)
        {
            _encontraMelhorOpcaoServico = encontraMelhorOpcaoServico;
        }

        [HttpPost]
        [Route("encontrarmelhoropcao")]
        public IActionResult EncontrarMelhorOpcao([FromBody] EntradaViewModel entrada)
        {
            var saida = _encontraMelhorOpcaoServico.EncontrarMelhorOpcao(entrada);

            return new OkObjectResult(new { message = "200 OK", saida });
        }
    }
}