using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAllAseguradoraEF();
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            if (result.Correct)
            {
                aseguradora.Aseguradoras = result.Objects;
                return View(aseguradora);
            }
            else
            {
                return View("Modal");
            }

        }
        [HttpGet]
        public ActionResult Form(int? idAseguradora) {
            ML.Result resultUsuarios = BL.Usuario.GetAllEF();
            ML.Aseguradora aseguradora= new ML.Aseguradora();
            aseguradora.Usuario=new ML.Usuario();
            if (resultUsuarios.Correct)
            {
                aseguradora.Usuario.Usuarios= resultUsuarios.Objects;
            }
            if (idAseguradora == null)
            {
                return View(aseguradora);
            }
            else
            {
                ML.Result result = BL.Aseguradora.GetByIdAseguradoraEF(idAseguradora.Value);
                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object;
                    aseguradora.Usuario.Usuarios= resultUsuarios.Objects;
                    return View(aseguradora);
                }
                else
                {
                    return View("Modal");
                }
            }

        }


        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)//agregar metodoef
        {
            ML.Result result = new ML.Result();

            if (aseguradora.IdAseguradora == 0)
            {
                result = BL.Aseguradora.AddAseguradoraEF(aseguradora);
                ViewBag.Message = result.Message;
                return View("Modal");
            }
            else
            {
                result = BL.Aseguradora.UpdateAseguradoraEF(aseguradora);
                ViewBag.Message = result.Message;
                return View("Modal");
            }

        }

        [HttpGet]
        public ActionResult Delete(int idAseguradora) { 
            ML.Result result = new ML.Result();
            result = BL.Aseguradora.DeleteAseguradoraEF(idAseguradora);
            ViewBag.Message = result.Message;
            return View("Modal");
        }
    }
}