using Clientes.D1.Comum.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.D1.Web.Models
{
    public class Enderecos
    {
        public int Id { get; set; }
        [DisplayName("Tipo do Endereço")]
        public TipoEnderecos Tipo { get; set; }
        public int CEP { get; set; }
        [DisplayName("Cep")]
        public string CEPFormatado { get; set; }
        [DisplayName("Número")]
        public int? Numero { get; set; } //PSC: Muitos sites são obrigatorios, mas em Brasília por exemplo, não existe número
        public string Complemento { get; set; }
        [DisplayName("Referência")]
        public string Referencia { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
    }
}
