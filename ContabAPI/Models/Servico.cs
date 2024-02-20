using System;
using System.Collections.Generic;

namespace ContabAPI.Models
{
    public partial class Servico
    {
        public int IdServico { get; set; }
        public string? DescricaoServico { get; set; }
        public decimal? TaxaServico { get; set; }
    }
}
