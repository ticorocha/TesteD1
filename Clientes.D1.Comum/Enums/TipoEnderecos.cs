using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Clientes.D1.Comum.Enums
{
    public enum TipoEnderecos
    {
        [Description("Residencial")]
        Residencial = 1,
        [Description("Comercial")]
        Comercial = 2,
        [Description("Familiar")]
        Familiar = 3,
        [Description("Outros")]
        Outros = 4
    }
}
