using Clientes.D1.Comum;
using Clientes.D1.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Correios.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Clientes.D1.Comum.Enums;

namespace Clientes.D1.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string filtroAtual, string txtFiltro, int? pagina, int? id)
        {
            if (txtFiltro != null)
            {
                pagina = 1;
            }
            else
            {
                txtFiltro = filtroAtual;
            }

            ViewBag.filtroAtual = txtFiltro;

            if (id != null)
            {
                var cliente = await Metodos.CallApiGetMetodo("Cliente", "BuscaCliente", id.ToString());
                var i = JsonConvert.DeserializeObject<Models.Clientes>(cliente.dados);
                ViewBag.Cliente = i;
            }
            else
                ViewBag.Cliente = new Models.Clientes();

            var retorno = await Metodos.CallApiGetMetodo("Cliente", "ListarTodos", "");

            var listaClientes = JsonConvert.DeserializeObject<List<Models.Clientes>>(retorno.dados);

            if (!String.IsNullOrEmpty(txtFiltro))
            {
                listaClientes = listaClientes.Where(s => s.Nome.ToUpper().Contains(txtFiltro.ToUpper())).ToList();
            }

            int tamanhoPagina = 3;
            int paginaAtual = (pagina ?? 1);

            ViewBag.TipoEnderecos = new SelectList(Metodos.GetEnumToDropDown<TipoEnderecos>(), "Key", "Value");
            ViewBag.TipoTelefone = new SelectList(Metodos.GetEnumToDropDown<TipoTelefone>(), "Key", "Value");

            if (listaClientes == null)
                return View(new List<Models.Clientes>().ToPagedList(paginaAtual, tamanhoPagina));

            listaClientes.ForEach(a => a.Enderecos.ForEach(b => b.Endereco = LocalizarCEP(b.CEP.ToString())));

            return View(listaClientes.ToPagedList(paginaAtual, tamanhoPagina));
        }

        public async Task<IActionResult> AddCliente(Models.Clientes cliente)
        {
            cliente.CPFFormatado = cliente.CPF;
            cliente.CPF = String.Join("", System.Text.RegularExpressions.Regex.Split(cliente.CPFFormatado, @"[^\d]"));
            var retorno = await Metodos.CallApiPostMetodo("Cliente", "SalvarCliente", cliente);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string LocalizarCEP(string cep)
        {
            if (!string.IsNullOrWhiteSpace(cep))
            {
                Address endereco = SearchZip.GetAddress(cep);
                if (endereco.Zip != null)
                {
                    return endereco.Street + ", " + endereco.District + ", " + endereco.City + " / " + endereco.State;
                }
                else
                {
                    return "Cep não localizado...";
                }
            }
            else
            {
                return "Informe um CEP válido";
            }
        }
    }
}
