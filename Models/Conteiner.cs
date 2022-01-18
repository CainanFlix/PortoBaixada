using System;

namespace PortoBaixada.Models
{

    public class Conteiner
    {
        public int ID {get; set;}

        public string NomeCliente { get; set; }

        public string Codigo { get; set; }

        public string Tipo { get; set; }

        public string Status { get; set; }

        public string Categoria { get; set; }
        public string TipoMovimentacao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

    }
}