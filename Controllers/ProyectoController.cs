using App_ventas_ds500.Data;
using App_ventas_ds500.Models;
using Microsoft.AspNetCore.Mvc;

namespace App_ventas_ds500.Controllers
{
    public class ProyectoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProyectoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Proyecto> ListarProyecto = _context.Proyecto;
            return View(ListarProyecto);
        }
    }
}
