using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RR.PedidoVendas.Application.ViewModels;
using RR.PedidoVendas.Application.Interfaces;

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

        public ActionResult Index()
        {
            ViewBag.Control = "Index";
            ViewBag.Title = "Consulta de Pedidos";

            return View("Consulta", pedidoAppService.SelecionarTodos());
        }

        public ActionResult Consulta()
        {
            ViewBag.Control = "Consulta";
            ViewBag.Title = "Consulta de Pedidos";

            return View(pedidoAppService.SelecionarTodos());
        }

        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(clienteAppService.SelecionarTodos(), "Id", "Nome");
            ViewBag.ProdutoId = new SelectList(produtoAppService.SelecionarTodos(), "Id", "Descricao");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModel pedidoViewModel)
        {
            ViewBag.Title = "Novo Pedido";

            ViewBag.ClienteId = new SelectList(clienteAppService.SelecionarTodos(), "Id", "Nome");
            ViewBag.ProdutoId = new SelectList(produtoAppService.SelecionarTodos(), "Id", "Descricao");

            if (ModelState.IsValid)
            {
                pedidoViewModel = pedidoAppService.Adicionar(pedidoViewModel);

                if (!pedidoViewModel.ValidationResult.IsValid)
                {

                    foreach (var erro in pedidoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return View(pedidoViewModel);
                }

                return RedirectToAction("Index");
            }

            return Json(new { Resultado = pedidoViewModel.Id }, JsonRequestBehavior.AllowGet);
        }

        //// GET: Pedido/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PedidoViewModel pedidoViewModel = db.PedidoViewModels.Find(id);
        //    if (pedidoViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ClienteId = new SelectList(db.ClienteViewModels, "Id", "Nome", pedidoViewModel.ClienteId);
        //    return View(pedidoViewModel);
        //}

        //// POST: Pedido/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,DataEntrega,NumeroControle,ClienteId,ValidationResult")] PedidoViewModel pedidoViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(pedidoViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ClienteId = new SelectList(db.ClienteViewModels, "Id", "Nome", pedidoViewModel.ClienteId);
        //    return View(pedidoViewModel);
        //}

        //// GET: Pedido/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PedidoViewModel pedidoViewModel = db.PedidoViewModels.Find(id);
        //    if (pedidoViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pedidoViewModel);
        //}

        //// POST: Pedido/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    PedidoViewModel pedidoViewModel = db.PedidoViewModels.Find(id);
        //    db.PedidoViewModels.Remove(pedidoViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                pedidoAppService.Dispose();

            base.Dispose(disposing);
        }
    }
}
