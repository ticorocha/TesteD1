using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Clientes.D1.Comum.Enums
{
    public enum TipoTelefone
    {
        [Description("Celular")]
        Celular = 1,
        [Description("Comercial")]
        Comercial = 2,
        [Description("Residencial")]
        Residencial = 3,
        [Description("Outros")]
        Outros = 4
    }
}
