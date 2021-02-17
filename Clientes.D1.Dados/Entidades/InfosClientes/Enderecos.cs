using Clientes.D1.Comum.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.D1.Dados.Entidades.InfosClientes
{
    public class Enderecos : EntidadeBase<object>
    {
        public TipoEnderecos Tipo { get; set; }
        public int CEP { get; set; }
        public string CEPFormatado { get; set; }
        public int? Numero { get; set; } //PSC: Muitos sites são obrigatorios, mas em Brasília por exemplo, não existe número
        public string Complemento { get; set; }
        public string Referencia { get; set; }
    }
}
