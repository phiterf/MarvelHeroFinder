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
                BuscaRepositorio.SalvarBusca(termo);
                return null;
            }

            var character = json.data.results[0];
            var personagem = new Personagem()
            {
                Id = character.id,
                Nome = character.name,
                Descricao = character.description,
                Foto = $"{character.thumbnail.path}.{character.thumbnail.extension}",
                Historias = character.stories?.available ?? 0
            };

            BuscaRepositorio.SalvarBusca(termo, personagem.Id);

            return personagem;
        }
    }
}