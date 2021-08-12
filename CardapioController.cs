using Crud.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        [HttpGet]
        public List<Cardapio> ListarCardapio() //mostrando todas as pessoas da lista
        {
            return Constante.ListaCardapio;
        }
    }
}
