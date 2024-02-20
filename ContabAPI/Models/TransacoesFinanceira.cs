using System;
using System.Collections.Generic;

namespace ContabAPI.Models
{
    public partial class TransacoesFinanceira
    {
        public int IdTransacao { get; set; }
        public int? IdCliente { get; set; }
        public string? TipoTransacao { get; set; }
        public int? DataPreparacao { get; set; }
        public decimal? ValorTransicao { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
    }
}
