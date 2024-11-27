using App_ventas_ds500.Data;
using App_ventas_ds500.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace App_ventas_ds500.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Listar()
        {
            String cad_sl = "execute sp_listar_cliente";
            List<Cliente> arr_cliente = _context.Cliente.FromSqlRaw(cad_sl).ToList();
            return Json(new { data = arr_cliente });
        }
        [HttpGet]
        public JsonResult Consultar(String codigo_cliente)
        {
            String cad_sql = "execute sp_consultar_cliente @codigo_cliente";

            Cliente cliente = new Cliente();
            cliente = _context.Cliente.FromSqlRaw(cad_sql, new SqlParameter("@codigo_cliente", codigo_cliente)).ToList().FirstOrDefault();
            return Json(cliente);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Cliente cliente)
        {
            bool rpta = true;
            try
            {
                Cliente tmp_cliente = null;
                tmp_cliente = (from per in _context.Cliente
                               where per.codigo_cliente == cliente.codigo_cliente
                               select per).FirstOrDefault();
                if (tmp_cliente == null)
                {
                    _context.Cliente.Add(cliente);
                    _context.SaveChanges();
                }
                else
                {
                    tmp_cliente.tipo_cliente = cliente.tipo_cliente;
                    tmp_cliente.nombre_cliente = cliente.nombre_cliente;
                    tmp_cliente.tipo_documento = cliente.tipo_documento;
                    tmp_cliente.nro_documento = cliente.nro_documento;
                    tmp_cliente.telefono = cliente.telefono;
                    tmp_cliente.email = cliente.email;
                    tmp_cliente.direccion = cliente.direccion;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                rpta = false;
            }
            return Json(new { resultado = rpta });
        }

        [HttpPost]
        public JsonResult Borrar(String codigo_cliente)
        {
            bool rpta = true;
            try
            {
                Cliente cliente = _context.Cliente.FirstOrDefault(per => per.codigo_cliente == codigo_cliente);
                if (cliente != null)
                {
                    _context.Cliente.Remove(cliente);
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Cliente no encontrado: " + codigo_cliente);
                    rpta = false;
                }
            }
            catch (Exception ex)
            {
                rpta = false;
                Console.WriteLine(ex.Message);
            }
            return Json(new { resultado = rpta });
        }
    }
}
