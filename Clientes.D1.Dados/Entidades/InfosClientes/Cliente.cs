using System;
using System.Collections.Generic;

namespace Clientes.D1.Dados.Entidades.InfosClientes
{
    public class Cliente : EntidadeBase<object>
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string CPFFormatado { get; set; }
        public string RG { get; set; }
        public RedesSociais RedesSociais { get; set; }

        public List<Telefones> Telefones { get; set; }
        public List<Enderecos> Enderecos { get; set; }
    }
}
