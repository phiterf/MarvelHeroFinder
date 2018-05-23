using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteAcerto.Repositories
{
    public class BuscaRepositorio
    {
        public  static void SalvarBusca(string Termo, int? Personagem = null)
        {
            var busca = new Models.Busca()
            {
                Personagem = Personagem,
                Termo = Termo,
                Hora = DateTime.Now
            };

            using (var ctx = new Models.MarvelContext())
            {
                ctx.Buscas.Add(busca);
                ctx.SaveChanges();
            }
        }
    }
}