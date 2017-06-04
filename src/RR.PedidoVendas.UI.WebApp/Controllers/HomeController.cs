using RR.PedidoVendas.Application.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace RR.PedidoVendas.UI.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoAppService produtoAppService;

        public HomeController(IProdutoAppService produtoAppService)
        {
            this.produtoAppService = produtoAppService;
        }

        public ActionResult Index()
        {
            var produtos = produtoAppService.SelecionarTodos();

            return View(produtos.OrderByDescending(p => p.Id).Take(5));
        }

        public ActionResult Sobre()
        {
            ViewBag.Titulo = "Sobre: Ricardo Rinco";

            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.Titulo = "Contato";
            ViewBag.Message = "Ricardo Rinco";

            return View();
        }
    }
}