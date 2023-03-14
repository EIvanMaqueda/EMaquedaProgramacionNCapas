using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = context.EmpleadoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.NumeroEmpleado = obj.NumeroEmpleado;
                            empleado.Nombre = obj.EmpleadoNombre;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.Foto = obj.Foto;
                            empleado.NSS = obj.NSS;
                            empleado.RFC = obj.RFC;
                            empleado.Email = obj.EmpleadoEmail;
                            empleado.Telefono = obj.EmpleadoTelefono;
                            empleado.FechaNacimiento = obj.FechaNacimiento.ToString();
                            empleado.FechaIngreso = obj.FechaIngreso.ToString();

                            empleado.Empresa = new ML.Empresa();
                            empleado.Empresa.Nombre = obj.EmpresaNombre;
                            empleado.Empresa.IdEmpresa = obj.IdEmpresa.Value;
                            empleado.Empresa.Telefono = obj.EmpresaTelefono;
                            empleado.Empresa.Email = obj.EmpresaMail;
                            empleado.Empresa.DireccionWeb = obj.DireccionWeb;
                            empleado.Empresa.Logo = obj.Logo;
                            result.Objects.Add(empleado);

                            result.Objects.Add(empleado);
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

        public static ML.Result Add(ML.Empleado empleado) { 
        
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = context.EmpleadoAdd(empleado.NumeroEmpleado,empleado.RFC,empleado.Nombre,empleado.ApellidoPaterno,
                        empleado.ApellidoMaterno,empleado.Email,empleado.Telefono,empleado.FechaNacimiento, empleado.NSS, empleado.FechaIngreso,
                        empleado.Foto,empleado.Empresa.IdEmpresa);
                    if (query >=1)
                    {
                        result.Message = "Usuario Agregado Correctamente";
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

              result.Message ="Error al agregar al empleado: "+ ex.Message;
              result.Correct = false;
            }

            return result;
        }

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context=new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = context.EmpleadoUpdate(empleado.NumeroEmpleado, empleado.RFC, empleado.Nombre, empleado.ApellidoPaterno,
                        empleado.ApellidoMaterno, empleado.Email, empleado.Telefono, empleado.FechaNacimiento, empleado.NSS, empleado.FechaIngreso,
                        empleado.Foto, empleado.Empresa.IdEmpresa, empleado.IdEmpleado);
                    if (query >=1)
                    {
                        result.Message = "Empleasdo actualizado correctamente";
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

               result.Message = "Error: "+ex.Message;
               result.Correct = false;
            }
            return result;
        }

        public static ML.Result Delete(int idEmpleado) 
        { 
            var result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context= new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = context.EmpleadoDelete(idEmpleado);
                    if (query >=1)
                    {
                        result.Message = "Empleado elimnido correctamente";
                        result.Correct=false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Message= "Error: "+ex.Message;
                result.Correct = false;
            }
            return result;
        
        }

        public static ML.Result GetById(int idEmpleado) {
            var result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context=new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query=context.EmpleadoGetById(idEmpleado).FirstOrDefault();
                    if (query != null)
                    {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = query.IdEmpleado;
                            empleado.NumeroEmpleado = query.NumeroEmpleado;
                            empleado.Nombre = query.EmpleadoNombre;
                            empleado.ApellidoMaterno = query.ApellidoMaterno;
                            empleado.ApellidoPaterno = query.ApellidoPaterno;
                            empleado.Foto = query.Foto;
                            empleado.NSS = query.NSS;
                            empleado.RFC = query.RFC;
                            empleado.Email = query.EmpleadoEmail;
                            empleado.Telefono = query.EmpleadoTelefono;
                            empleado.FechaNacimiento = query.FechaNacimiento.ToString();
                            empleado.FechaIngreso = query.FechaIngreso.ToString();

                            empleado.Empresa = new ML.Empresa();
                            empleado.Empresa.Nombre = query.EmpresaNombre;
                            empleado.Empresa.IdEmpresa = query.IdEmpresa.Value;
                            empleado.Empresa.Telefono = query.EmpresaTelefono;
                            empleado.Empresa.Email = query.EmpresaMail;
                            empleado.Empresa.DireccionWeb = query.DireccionWeb;
                            empleado.Empresa.Logo = query.Logo;

                            result.Object=empleado;
                        
                    }
                    result.Correct = true;
                }
            }
            catch (Exception)
            {

                result.Correct=false;
            }
            return result;
        
        }

    }
}

