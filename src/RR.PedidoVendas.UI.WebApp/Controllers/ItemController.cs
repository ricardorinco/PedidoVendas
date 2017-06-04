using RR.PedidoVendas.Application.Interfaces;
using RR.PedidoVendas.Application.ViewModels;
using System.Web.Mvc;

namespace RR.PedidoVendas.UI.WebApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemAppService itemAppService;
        private readonly IProdutoAppService produtoAppService;

        public ItemController(IItemAppService itemAppService, IProdutoAppService produtoAppService)
        {
            this.itemAppService = itemAppService;
            this.produtoAppService = produtoAppService;
        }

        public ActionResult Listar(int pedidoId)
        {
            ViewBag.ProdutoId = new SelectList(produtoAppService.SelecionarTodos(), "Id", "Descricao");

            var itens = itemAppService.SelecionarPorPedidoId(pedidoId);
            ViewBag.Pedido = pedidoId;

            return PartialView(itens);
        }

        public ActionResult Adicionar(decimal quantidade, int produtoId, int pedidoId)
        {
            var itemViewModel = new ItemViewModel
            {
                Quantidade = quantidade,
                ProdutoId = produtoId,
                PedidoId = pedidoId
            };

            itemViewModel = itemAppService.Adicionar(itemViewModel);

            if (!itemViewModel.ValidationResult.IsValid)
            {
                foreach (var erro in itemViewModel.ValidationResult.Erros)
                    ModelState.AddModelError(string.Empty, erro.Message);

                return View(itemViewModel);
            }

            return Json(new { Resultado = itemViewModel.Id }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Remover(int id)
        {
            itemAppService.Remover(id);

            return RedirectToAction("Listar");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                itemAppService.Dispose();
                produtoAppService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
