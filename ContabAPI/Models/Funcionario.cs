using System;
using System.Collections.Generic;

namespace ContabAPI.Models
{
    public partial class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string? NomeFuncionario { get; set; }
        public string? CargoFuncionario { get; set; }
        public int? TelefoneFuncionario { get; set; }
        public string? Departamento { get; set; }
    }
}
