using Clientes.D1.Comum.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.D1.Web.Models
{
    public class Telefones
    {
        public int Id { get; set; }
        [DisplayName("Tipo do Telefone")]
        public TipoTelefone Tipo { get; set; }
        public long Telefone { get; set; }
        [DisplayName("Número")]
        public string TelefoneFormatado { get; set; }
    }
}
