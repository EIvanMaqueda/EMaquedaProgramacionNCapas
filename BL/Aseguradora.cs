using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result AddAseguradoraEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    int query = context.AseguradoraAdd(aseguradora.Nombre, aseguradora.Usuario.IdUsuario);

                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Message = "Aseguradora Agregada Correctamente";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error al ingresar la aseguradora: " + ex.Message;
            }
            return result;
        }

        public static ML.Result UpdateAseguradoraEF(ML.Aseguradora aseguradora)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    int query = context.AseguradoraUpdate(aseguradora.IdAseguradora,aseguradora.Nombre,aseguradora.Usuario.IdUsuario);
                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Message = "Aseguradora Actualizada Correctamente";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error al actualizar la Aseguradora: " + ex.Message;

            }
            return result;

        }

        public static ML.Result DeleteAseguradoraEF(int id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    int query = context.AseguradoraDelete(id);
                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Aseguradora Borrada de la base de datos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error: " + ex.Message;

            }
            return result;
        }



        public static ML.Result GetAllAseguradoraEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = obj.IdAseguradora;
                            aseguradora.Nombre= obj.Nombre;
                            aseguradora.FechaCreacion = obj.FechaCreacion.Value;
                            aseguradora.FechaModificacion = obj.FechaModificacion.Value;

                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = obj.IdUsuario.Value;
                            aseguradora.Usuario.Nombre = obj.NombreUsuario;
                            aseguradora.Usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            aseguradora.Usuario.ApellidoMaterno= obj.ApellidoMaterno;
                            result.Objects.Add(aseguradora);
                        }
                    
                    
                    }
                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error: " + ex.Message;

            }
            return result;
        }

        public static ML.Result GetByIdAseguradoraEF(int id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraGetById(id).FirstOrDefault();

                    if (query != null)
                    {


                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora = query.IdAseguradora;
                        aseguradora.Nombre = query.Nombre;
                        aseguradora.FechaCreacion = query.FechaCreacion.Value;
                        aseguradora.FechaModificacion = query.FechaModificacion.Value;

                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = query.IdUsuario.Value;
                        result.Object = aseguradora;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error usuario no enecontrado: " + ex.Message;

            }
            return result;
        }


        public static ML.Result GetAllAseguradoraLINQ()
        {
            Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = (from aseguradoraLINQ in context.Aseguradoras
                                 select new
                                 {
                                     IdAseguradora= aseguradoraLINQ.IdAseguradora,
                                     Nombre=aseguradoraLINQ.Nombre,
                                     FechaCreacion=aseguradoraLINQ.FechaCreacion,
                                     FechaModificacion=aseguradoraLINQ.FechaModificacion,
                                     IdUsuario=aseguradoraLINQ.Usuario.IdUsuario
                                 });
                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Aseguradora aseguradora= new ML.Aseguradora();
                            aseguradora.IdAseguradora=obj.IdAseguradora;
                            aseguradora.Nombre=obj.Nombre;
                            //aseguradora.FechaCreacion =obj.FechaCreacion;
                            //
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = obj.IdUsuario;
                            result.Objects.Add(aseguradora);
                        }
                        result.Message = "Aseguradora creada exitosammente con LINQ";
                        result.Correct = true;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error: " + ex.Message;

            }
            return result;

        }

        public static ML.Result GetByIdAseguradoraLINQ(int id)
        {
            Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = (from aseguradoraLINQ in context.Aseguradoras
                                 where aseguradoraLINQ.IdAseguradora == id
                                 select new
                                 {
                                     IdAseguradora = aseguradoraLINQ.IdAseguradora,
                                     Nombre = aseguradoraLINQ.Nombre,
                                     FechaCreacion = aseguradoraLINQ.FechaCreacion,
                                     FechaModificacion = aseguradoraLINQ.FechaModificacion,
                                     IdUsuario = aseguradoraLINQ.Usuario.IdUsuario
                                 }).FirstOrDefault();
                    result.Object = query;

                    if (query != null)
                    {
                       
                       ML.Aseguradora aseguradora= new ML.Aseguradora();
                        aseguradora.IdAseguradora = query.IdAseguradora;
                        aseguradora.Nombre = query.Nombre;

                        aseguradora.Usuario=new ML.Usuario();   
                        aseguradora.Usuario.IdUsuario = query.IdUsuario;
                        result.Object = aseguradora;
                     
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error: " + ex.Message;

            }
            return result;

        }

        public static ML.Result AddAseguradoraLINQ(ML.Aseguradora aseguradora)
        {
            Result result = new Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    DL_EF.Aseguradora aseguradoraDL = new DL_EF.Aseguradora();

                    aseguradoraDL.Nombre = aseguradora.Nombre;
                    aseguradora.FechaCreacion=DateTime.Now;
                    aseguradora.FechaModificacion=DateTime.Now;
                    aseguradoraDL.IdUsuario = aseguradora.Usuario.IdUsuario;
                    context.Aseguradoras.Add(aseguradoraDL);
                    context.SaveChanges();
                }
                result.Correct = true;
                result.Message = "Aseguradora agregada correctamente con LINQ";

            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error: " + ex.Message;
            }
            return result;
        }

        public static ML.Result UpdateAseguradoraLINQ(ML.Aseguradora aseguradora)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = (from aseguradoraLINQ in context.Aseguradoras
                                 where aseguradoraLINQ.IdAseguradora == aseguradora.IdAseguradora
                                 select aseguradoraLINQ).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = aseguradora.Nombre;
                        query.IdUsuario = aseguradora.Usuario.IdUsuario;
                        context.SaveChanges();
                        result.Correct = true;
                        result.Message = "Aseguradora Actualizada correctamente con linq";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error: " + ex.Message;
            }
            return result;
        }

      
    }
}
