using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteAcerto.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public bool PossuiHistorias { get; set; }
        public String Foto { get; set; }
    }
}