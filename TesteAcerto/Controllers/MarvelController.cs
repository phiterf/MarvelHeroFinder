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

        [HttpGet]
        [Route("Historias/{id}-{currentpage}")]
        public object Historias(int id, int currentpage)
        {
            var perpage = 20;
            var (total, historias) = PersonagemRepositorio.BuscarHistorias(id, perpage, currentpage);
            
            //Retornando um objeto anônimo pois Value Tuples retornam as chaves como Item1, Item2, etc.
            return new {
                historias,
                total
            };
        }
    }
}
