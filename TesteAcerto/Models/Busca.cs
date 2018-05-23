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

    }
}