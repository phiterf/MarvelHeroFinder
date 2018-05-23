using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using TesteAcerto.Models;
using TesteAcerto.Utils;

namespace TesteAcerto.Repositories
{
    public static class PersonagemRepositorio
    {
        public static Personagem BuscarPersonagem(String termo)
        {
            dynamic json = MarvelAPI.Call("/characters", new List<GetParam> {
                new GetParam("name", termo)
            });
            if (json.data.results.Count == 0)
            {
                Busca.SalvarBusca(termo);
                return null;
            }

            var character = json.data.results[0];
            var personagem = new Personagem()
            {
                Id = character.id,
                Nome = character.name,
                Descricao = character.description,
                Foto = $"{character.thumbnail.path}.{character.thumbnail.extension}",
                PossuiHistorias = ((character.stories?.available ?? 0) > 0)
            };

            Busca.SalvarBusca(termo, personagem.Id);

            return personagem;
        }

        public static (int total, List<Historia> historias) BuscarHistorias(int id, int perpage, int currentpage)
        {
            dynamic json = MarvelAPI.Call($"/characters/{id}/stories", new List<GetParam> {
                new GetParam("limit", perpage.ToString()),
                new GetParam("offset", ((currentpage - 1) * perpage).ToString())
            });

            var stories = json.data.results;
            var total = Convert.ToInt32(json.data.total);
            var historias = new List<Historia>();
            foreach(dynamic story in stories)
            {
                var historia = new Historia()
                {
                    Id = story.id,
                    Titulo = story.title,
                    Descricao = story.description
                };
                historias.Add(historia);
            }

            return (total, historias);
        }
    }
}