using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteAcerto.Models;
using TesteAcerto.Repositories;

namespace TesteAcerto.Controllers
{
    [RoutePrefix("api")]
    public class MarvelController : ApiController
    {

        [HttpGet]
        [Route("Busca/{termo}")]
        public Personagem Busca(String termo)
        {
            return PersonagemRepositorio.BuscarPersonagem(termo);
        }

    }
}
