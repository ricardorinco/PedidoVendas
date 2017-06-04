using RR.PedidoVendas.Application.Interfaces;
using RR.PedidoVendas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RR.PedidoVendas.UI.WebApp.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoAppService pedidoAppService;
        private readonly IClienteAppService clienteAppService;
        private readonly IProdutoAppService produtoAppService;

        public PedidoController(IPedidoAppService pedidoAppService, IClienteAppService clienteAppService, IProdutoAppService produtoAppService)
        {
            this.pedidoAppService = pedidoAppService;
            this.clienteAppService = clienteAppService;
            this.produtoAppService = produtoAppService;
        }

        public ActionResult Consultar(int? clienteId, int? numeroControle, DateTime? dataEntregaInicial, DateTime? dataEntregaFinal)
        {
            ViewBag.Titulo = "Consulta de Pedidos";

            var clienteViewModel = new List<ClienteViewModel>();
            clienteViewModel.Add(new ClienteViewModel { Id = 0, Nome = "Consumidor" });
            clienteViewModel.AddRange(clienteAppService.SelecionarTodos());

            ViewBag.ClienteId = new SelectList(clienteViewModel, "Id", "Nome");

            if (clienteId.HasValue)
                return View(pedidoAppService.SelecionarPorClienteId(clienteId.Value));

            if (numeroControle.HasValue)
                return View(pedidoAppService.SelecionarPorNumeroControle(numeroControle.Value));

            if (dataEntregaInicial.HasValue && dataEntregaFinal.HasValue)
                return View(pedidoAppService.SelecionarPorDataEntrega(dataEntregaInicial.Value, dataEntregaFinal.Value));

            return View(pedidoAppService.SelecionarTodos());
        }

        public ActionResult Adicionar()
        {
            ViewBag.Titulo = "Novo Pedido";

            ViewBag.ClienteId = new SelectList(clienteAppService.SelecionarTodos(), "Id", "Nome");
            ViewBag.ProdutoId = new SelectList(produtoAppService.SelecionarTodos(), "Id", "Descricao");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(PedidoViewModel pedidoViewModel)
        {
            ViewBag.Titulo = "Novo Pedido";

            ViewBag.ClienteId = new SelectList(clienteAppService.SelecionarTodos(), "Id", "Nome");
            ViewBag.ProdutoId = new SelectList(produtoAppService.SelecionarTodos(), "Id", "Descricao");

            if (ModelState.IsValid)
            {
                pedidoViewModel = pedidoAppService.Adicionar(pedidoViewModel);

                if (!pedidoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in pedidoViewModel.ValidationResult.Erros)
                        ModelState.AddModelError(string.Empty, erro.Message);

                    return View(pedidoViewModel);
                }
            }

            return Json(new { Resultado = pedidoViewModel.Id }, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pedidoAppService.Dispose();
                clienteAppService.Dispose();
                produtoAppService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}