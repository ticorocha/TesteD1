using Clientes.D1.Dados.Entidades.InfosClientes;
using Microsoft.EntityFrameworkCore;

namespace Clientes.D1.Dados
{
    public interface IContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Enderecos> Enderecos { get; set; }
        DbSet<RedesSociais> RedesSociais { get; set; }
        DbSet<Telefones> Telefones { get; set; }
    }
}
