using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.D1.Web.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("Data Nascimento")]
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        [DisplayName("CPF")]
        public string CPFFormatado { get; set; }
        public string RG { get; set; }
        public RedesSociais RedesSociais { get; set; }

        public List<Telefones> Telefones { get; set; }
        public List<Enderecos> Enderecos { get; set; }

        public Clientes()
        {
            RedesSociais = new RedesSociais();
            Telefones = new List<Telefones>();
            Enderecos = new List<Enderecos>();
        }
    }
}
