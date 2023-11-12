using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Services;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendedor _servicoVendedor;
        private readonly ServicoDepartamento _servicoDepartamento;

        public VendedoresController(ServicoVendedor servicoVendedor, ServicoDepartamento servicoDepartamento)
        {
            _servicoVendedor = servicoVendedor;
            _servicoDepartamento = servicoDepartamento;
        }

        public IActionResult Index()
        {
            var list = _servicoVendedor.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _servicoDepartamento.FindAll();
            var viewModel = new VendedorFormulario
            {
                Departamentos = departamentos
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _servicoVendedor.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _servicoVendedor.FindById(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _servicoVendedor.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (null == id)
                return NotFound();
            
            var obj = _servicoVendedor.FindById(id.Value);

            if (null == obj)
                return NotFound();

            return View(obj);
        }
    }
}
