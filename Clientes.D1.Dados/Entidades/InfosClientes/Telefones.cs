using Clientes.D1.Comum.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.D1.Dados.Entidades.InfosClientes
{
    public class Telefones : EntidadeBase<object>
    {
        public TipoTelefone Tipo { get; set; }
        public long Telefone { get; set; }
        public string TelefoneFormatado { get; set; }
    }
}
