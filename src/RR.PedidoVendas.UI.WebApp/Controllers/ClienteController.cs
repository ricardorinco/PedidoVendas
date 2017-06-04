using RR.PedidoVendas.Application.Interfaces;
using RR.PedidoVendas.Application.ViewModels;
using System.Net;
using System.Web.Mvc;

namespace RR.PedidoVendas.UI.WebApp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteAppService clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            this.clienteAppService = clienteAppService;
        }

        public ActionResult Consultar()
        {
            ViewBag.Titulo = "Lista de Clientes";

            return View(clienteAppService.SelecionarTodos());
        }

        public ActionResult Detalhes(int? id)
        {
            ViewBag.Titulo = "Detalhes";

            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteViewModel = clienteAppService.SelecionarPorId(id.Value);

            if (clienteViewModel == null)
                return HttpNotFound();

            return View(clienteViewModel);
        }

        public ActionResult Adicionar()
        {
            ViewBag.Titulo = "Novo Cliente";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(ClienteViewModel clienteViewModel)
        {
            ViewBag.Titulo = "Novo Cliente";

            if (ModelState.IsValid)
            {
                clienteViewModel = clienteAppService.Adicionar(clienteViewModel);

                if (!clienteViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in clienteViewModel.ValidationResult.Erros)
                        ModelState.AddModelError(string.Empty, erro.Message);

                    return View(clienteViewModel);
                }

                return RedirectToAction("Consultar");
            }

            return View(clienteViewModel);
        }

        public ActionResult Editar(int? id)
        {
            ViewBag.Titulo = "Edição de Cliente";

            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);

            var clienteViewModel = clienteAppService.SelecionarPorId(id.Value);

            if (clienteViewModel == null)
                return HttpNotFound();

            return View("Adicionar", clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ClienteViewModel clienteViewModel)
        {
            ViewBag.Titulo = "Edição de Cliente";

            if (ModelState.IsValid)
            {
                clienteViewModel = clienteAppService.Atualizar(clienteViewModel);

                if (!clienteViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in clienteViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(clienteViewModel);
                }

                return RedirectToAction("Consultar");
            }

            return View(clienteViewModel);
        }

        public ActionResult Remover(int? id)
        {
            ViewBag.Titulo = "Deletar Cliente";

            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteViewModel = clienteAppService.SelecionarPorId(id.Value);

            if (clienteViewModel == null)
                return HttpNotFound();

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id)
        {
            clienteAppService.Remover(id);

            return RedirectToAction("Consultar");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                clienteAppService.Dispose();

            base.Dispose(disposing);
        }
    }
}
