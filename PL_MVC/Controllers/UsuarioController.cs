using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAllEF(); //EF
            ML.Usuario usuario = new ML.Usuario();
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpGet]
        public ActionResult Form(int? idUsuario)
        {
            ML.Result resultrol = BL.Rol.GetAllRol();
            ML.Result resultpais = BL.Pais.GetAllPais();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            if (resultrol.Correct && resultpais.Correct)//validacion para ver si paises y roles bienen llenos
            {

                usuario.Rol.Roles = resultrol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultpais.Objects;
            }
            if (idUsuario == null)//agregar
            {
                return View(usuario);//enviar usuario
            }
            else//actualizar
            {
                ML.Result result = BL.Usuario.GetByIdEF(idUsuario.Value);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    usuario.Rol.Roles = resultrol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultpais.Objects;
                    ML.Result resultestado = BL.Estado.EstadoGetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    ML.Result resultMunicipio = BL.Municipio.MunicipioGetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    ML.Result resultColonia = BL.Colonia.ColoniaGetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultestado.Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                    usuario.Direccion.Colonia.Colonias = resultColonia.Objects;
                    return View(usuario);
                }
                else
                {
                    ViewBag.Message = result.Message;
                    return View("Modal");
                }

            }
        }

        [HttpPost]

        public ActionResult Form(ML.Usuario usuario)
        {
           HttpPostedFileBase file = Request.Files["fuImage"];
            if (file != null)
            {
                byte[] imagen = ConvertToBytes(file);
                usuario.Imagen = Convert.ToBase64String(imagen);
            }
            ML.Result result = new ML.Result();
            if (usuario.IdUsuario == 0)
            {
                result = BL.Usuario.AddEF(usuario);
                ViewBag.Message = result.Message;
                return View("Modal");
            }
            else
            {
                result = BL.Usuario.UpdateEF(usuario);
                ViewBag.Message = result.Message;
                return View("Modal");
            }

        }

        [HttpGet]
        public ActionResult Delete(int? idUsuario) {
            if (idUsuario == null)
            {
                return View();
            }
            else
            {
                ML.Result result = BL.Usuario.DeleteEF(idUsuario.Value);

                if (result.Correct)
                {
                    ViewBag.Message = "Usuario eliminado correctamente";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "Error al eliminar al usuario";
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public JsonResult EstadoGetByIdPais(int idPais)
        {
            ML.Result result = BL.Estado.EstadoGetByIdPais(idPais);
            return Json(result.Objects);
        }

        [HttpPost]
        public JsonResult MunicipioGetByIdEstado(int idEstado)
        {
            ML.Result result = BL.Municipio.MunicipioGetByIdEstado(idEstado);
            return Json(result.Objects);
        }


        [HttpPost]
        public JsonResult ColoniaGetByIdMunicipio(int idMunicipio)
        {
            ML.Result result = BL.Colonia.ColoniaGetByIdMunicipio(idMunicipio);
            return Json(result.Objects);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase foto) {

            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(foto.InputStream);
            data = reader.ReadBytes((int)foto.ContentLength);
            return data;

        }

    }
}