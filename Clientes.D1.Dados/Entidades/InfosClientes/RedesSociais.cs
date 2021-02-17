using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.D1.Dados.Entidades.InfosClientes
{
    public class RedesSociais : EntidadeBase<object>
    {
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string Instagran { get; set; }
    }
}
