using System;
using System.Collections.Generic;

namespace ContabAPI.Models
{
    public partial class DeclaracoesFinanceira
    {
        public int IdDeclaracao { get; set; }
        public int? IdCliente { get; set; }
        public string? TipoDeclaracao { get; set; }
        public int? DataPreparacao { get; set; }
        public string? ConteudoDeclaracao { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
    }
}
