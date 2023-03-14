using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]
        public ActionResult GetAll()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form(int? idEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            return View(empleado);
        }
    }
}