﻿using Microsoft.AspNetCore.Mvc;
using App_ventas_ds500.Data;
using App_ventas_ds500.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace App_ventas_ds500.Controllers
{
    public class PersonalController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        

        public PersonalController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult Listar()
        {
            String cad_sql = "exec sp_listar_personal";

            List<Personal> arr_personal = _context.Personal.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = arr_personal });
        }

        [HttpGet]
        public JsonResult Consultar(String dni)
        {
            String cad_sql = "exec sp_consultar_personal @dni";
            Personal personal = new Personal();

            personal = _context.Personal.FromSqlRaw(cad_sql, new SqlParameter("@dni", dni)).ToList().FirstOrDefault();

            return Json(personal);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Personal personal)
        {
            bool rpta = true;

            try
            {
                Personal tmp_personal = null;

                tmp_personal = (from per in _context.Personal where per.dni == personal.dni select per).FirstOrDefault();            

                if (tmp_personal == null)
                {
                    _context.Personal.Add(personal);
                    _context.SaveChanges();
                }
                else
                {
                    tmp_personal.ap_paterno = personal.ap_paterno;
                    tmp_personal.ap_materno = personal.ap_materno;
                    tmp_personal.nombre = personal.nombre;
                    tmp_personal.genero = personal.genero;
                    tmp_personal.fecha_nacimiento = personal.fecha_nacimiento;
                    tmp_personal.sueldo = personal.sueldo;

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                rpta= false;
            } 
            return Json(new {resultado = rpta});
        }

        public JsonResult Borrar(String dni)
        {
            bool rpta = true;

            try
            {
                Personal personal = new Personal();

                personal = (from per in _context.Personal where per.dni == dni select per).FirstOrDefault();
                _context.Personal.Remove(personal);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                rpta= false;
            }

            return Json(new { resultado = rpta });
        }

        public IActionResult Index()
        {
            //IEnumerable<Personal> ListarPersonal = _context.Personal;
            return View();
        }
    }
}
