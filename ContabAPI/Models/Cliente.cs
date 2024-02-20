using System;
using System.Collections.Generic;

namespace ContabAPI.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            DeclaracoesFinanceiras = new HashSet<DeclaracoesFinanceira>();
            TransacoesFinanceiras = new HashSet<TransacoesFinanceira>();
        }

        public int IdCliente { get; set; }
        public string? NomeCliente { get; set; }
        public string? TipoCliente { get; set; }
        public int? TelefoneCliente { get; set; }
        public string? EnderecoCliente { get; set; }

        public virtual ICollection<DeclaracoesFinanceira> DeclaracoesFinanceiras { get; set; }
        public virtual ICollection<TransacoesFinanceira> TransacoesFinanceiras { get; set; }
    }
}
