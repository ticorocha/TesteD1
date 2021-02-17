using Clientes.D1.Comum;
using Clientes.D1.Dados;
using Clientes.D1.Dados.Entidades.InfosClientes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.D1.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly Context _context;

        public ClienteController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("ListarTodos")]
        public async Task<IEnumerable<Cliente>> ListarTodos()
        {
            try
            {
                return await _context.Clientes.Include("Enderecos").Include("RedesSociais").Include("Telefones").ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        [HttpGet]
        [Route("BuscaCliente/{id}")]
        public async Task<Cliente> BuscaCliente(int id)
        {
            try
            {
                return await _context.Clientes.Include("Enderecos").Include("RedesSociais").Include("Telefones").FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {

                throw;
            }            
        }

        [HttpPost]
        [Route("SalvarCliente")]
        public async Task<ObjRetorno> SalvarCliente(Cliente cliente)
        {
            try
            {
                if (cliente.Id == 0)
                    await _context.AddAsync(cliente);
                else
                    _context.Update(cliente);

                await _context.SaveChangesAsync();
                ObjRetorno ret = new ObjRetorno
                {
                    status = 200,
                    mensagem = "Salvo com sucesso.",
                    dados = null
                };
                return ret;
            }
            catch (Exception ex)
            {
                ObjRetorno ret = new ObjRetorno
                {
                    status = 201,
                    mensagem = "Erro: " + ex.Message
                };
                return ret;
            }
        }
    }
}
