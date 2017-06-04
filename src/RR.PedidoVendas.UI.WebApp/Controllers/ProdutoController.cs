using RR.PedidoVendas.Application.Interfaces;
using RR.PedidoVendas.Application.ViewModels;
using System.Net;
using System.Web.Mvc;

namespace RR.PedidoVendas.UI.WebApp.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            this.produtoAppService = produtoAppService;
        }

        public ActionResult Consultar()
        {
            ViewBag.Titulo = "Lista de Produtos";

            return View(produtoAppService.SelecionarTodos());
        }

        public ActionResult Detalhes(int? id)
        {
            ViewBag.Titulo = "Detalhes";

            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var produtoViewModel = produtoAppService.SelecionarPorId(id.Value);

            if (produtoViewModel == null)
                return HttpNotFound();

            return View(produtoViewModel);
        }

        public ActionResult Adicionar()
        {
            ViewBag.Titulo = "Novo Produto";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(ProdutoViewModel produtoViewModel)
        {
            ViewBag.Titulo = "Novo Produto";

            if (ModelState.IsValid)
            {
                produtoViewModel = produtoAppService.Adicionar(produtoViewModel);

                if (!produtoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in produtoViewModel.ValidationResult.Erros)
                        ModelState.AddModelError(string.Empty, erro.Message);

                    return View(produtoViewModel);
                }

                return RedirectToAction("Consultar");
            }

            return View(produtoViewModel);
        }

        public ActionResult Editar(int? id)
        {
            ViewBag.Titulo = "Edição de Produto";

            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);

            var produtoViewModel = produtoAppService.SelecionarPorId(id.Value);

            if (produtoViewModel == null)
                return HttpNotFound();

            return View("Adicionar", produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ProdutoViewModel produtoViewModel)
        {
            ViewBag.Titulo = "Edição de Produto";

            if (ModelState.IsValid)
            {
                produtoViewModel = produtoAppService.Atualizar(produtoViewModel);

                if (!produtoViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in produtoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(produtoViewModel);
                }

                return RedirectToAction("Consultar");
            }

            return View(produtoViewModel);
        }

        public ActionResult Remover(int? id)
        {
            ViewBag.Titulo = "Deletar Produto";

            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var produtoViewModel = produtoAppService.SelecionarPorId(id.Value);

            if (produtoViewModel == null)
                return HttpNotFound();

            return View(produtoViewModel);
        }

        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id)
        {
            produtoAppService.Remover(id);

            return RedirectToAction("Consultar");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                produtoAppService.Dispose();

            base.Dispose(disposing);
        }
    }
}
