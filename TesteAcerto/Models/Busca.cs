using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteAcerto.Models
{
    public class Busca
    {
        public int Id { get; set; }
        public String Termo { get; set; }
        public DateTime Hora { get; set; }
        public int? Personagem { get; set; }

        public static void SalvarBusca(string Termo, int? Personagem = null)
        {
            var busca = new Busca()
            {
                Personagem = Personagem,
                Termo = Termo,
                Hora = DateTime.Now
            };

            try
            {
                using (var ctx = new MarvelContext())
                {
                    ctx.Buscas.Add(busca);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possível salvar no banco. Erro: {ex.Message}");
            }
        }
    }
}