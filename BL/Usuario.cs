using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var context = new SqlConnection(DL.Conexion.Getconection()))
                {
                    string query = "INSERT INTO Usuario (Nombre,ApellidoPaterno,ApellidoMaterno,NumeroTelefono) VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno,@NumeroTelefono)";
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = context;
                        cmd.CommandText = query;
                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("NumeroTelefono", SqlDbType.VarChar);
                        collection[3].Value = usuario.NumeroTelefono;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "usuario agregado correctamente";
                        }


                    }
                }
                {


                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.Message = "Ocurrio un problema al ingresar el usario: " + ex;
            }
            return result;
        }
        public static ML.Result  Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var context = new SqlConnection(DL.Conexion.Getconection()))
                {
                    string query = "UPDATE [Usuario] SET [Nombre] = @Nombre,[ApellidoPaterno] =@ApellidoPaterno ,[ApellidoMaterno] =@ApellidoMaterno ,[NumeroTelefono] =@NumeroTelefono WHERE IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand()){ 
                    
                        cmd.Connection= context;
                        cmd.CommandText = query;
                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;
                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;
                        collection[2]=new SqlParameter("ApellidoMaterno",SqlDbType.VarChar);
                        collection[2].Value=usuario.ApellidoMaterno;
                        collection[3] = new SqlParameter("NumeroTelefono", SqlDbType.VarChar);
                        collection[3].Value = usuario.NumeroTelefono;
                        collection[4] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[4].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int rowsaffected = cmd.ExecuteNonQuery();
                        if (rowsaffected >0)
                        {
                            result.Correct=true;
                            result.Message = "Usuario Actualizado Correctamente";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.Message = "Error al actualizar el usuario: " + ex;
                
            }
            return result;
        }
        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var context = new SqlConnection(DL.Conexion.Getconection()))
                {
                    string query = "DELETE FROM [Usuario] WHERE IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "Usuario eliminado con exito";

                        }
                        else
                        {

                            result.Correct = false;
                            result.Message = "Error al eliminar el usuario";
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.Message = "Error al eliminar el usuario: " + ex;
            }
            return result;
        }

        public static ML.Usuario Get(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            using (var context = new SqlConnection(DL.Conexion.Getconection()))
            {
                string query = "SELECT [IdUsuario],[IdRol],[UserName],[Nombre],[ApellidoPaterno],[ApellidoMaterno]," +
                    "[Email],[Password],[FechaNacimiento],[Sexo],[Telefono],[Celular],[CURP],[Imagen]  FROM [Usuario] WHERE IdUsuario=@IdUsuario";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = context;
                    cmd.CommandText = query;
                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = IdUsuario;
                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        usuario.IdUsuario = int.Parse(reader["IdUsuario"].ToString());
                        /*usuario.UserName = reader["username"].ToString();
                        usuario.Nombre = reader["Nombre"].ToString();
                        usuario.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                        usuario.ApellidoMaterno = reader["Apellidomaterno"].ToString();
                        usuario.Email= reader["Email"].ToString();
                        usuario.Password=
                        usuario.NumeroTelefono = reader["NumeroTelefono"].ToString();*/
                    }
                    else
                    {

                    }
                }
                return usuario;
            }
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context=new SqlConnection(DL.Conexion.Getconection()))
                {
                    string query= "UsuarioGetAll";
                    using (SqlCommand cmd=new SqlCommand())
                    {
                        cmd.CommandText= query;
                        cmd.Connection= context;
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dataTable=new DataTable();
                        SqlDataAdapter sqlDataAdapter= new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count >0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in dataTable.Rows)
                            {
                                ML.Usuario usuario= new ML.Usuario();
                                usuario.IdUsuario =(int)row[0];
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno= row[3].ToString(); 
                                usuario.NumeroTelefono= row[4].ToString();

                                result.Objects.Add(usuario);
                            }
                        }
                        result.Correct=true;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return result;

        }

        public static ML.Result GetById(int Id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Getconection()))
                {
                    string query = "UsuarioGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = Id;
                        cmd.Parameters.AddRange(collection);

                        DataTable dataTable = new DataTable();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                        {
                            DataRow row = dataTable.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = (int)row[0];
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.NumeroTelefono = row[4].ToString();

                            result.Object = usuario;
                            
                        }
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return result;

        }

        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var context = new SqlConnection(DL.Conexion.Getconection()))
                {
                    string query = "UsuarioAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("NumeroTelefono", SqlDbType.VarChar);
                        collection[3].Value = usuario.NumeroTelefono;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "usuario agregado correctamente";
                        }


                    }
                }
                {


                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.Message = "Ocurrio un problema al ingresar el usario: " + ex;
            }
            return result;
        }

        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var context = new SqlConnection(DL.Conexion.Getconection()))
                {
                    string query = "UsuarioUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;
                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;
                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;
                        collection[3] = new SqlParameter("NumeroTelefono", SqlDbType.VarChar);
                        collection[3].Value = usuario.NumeroTelefono;
                        collection[4] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[4].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int rowsaffected = cmd.ExecuteNonQuery();
                        if (rowsaffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "Usuario Actualizado Correctamente";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error al actualizar el usuario: " + ex;

            }
            return result;
        }

        public static ML.Result DeleteSP(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (var context = new SqlConnection(DL.Conexion.Getconection()))
                {
                    string query = "UsuarioDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "Usuario eliminado con exito";

                        }
                        else
                        {

                            result.Correct = false;
                            result.Message = "Error al eliminar el usuario";
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.Message = "Error al eliminar el usuario: " + ex;
            }
            return result;
        }


        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    int query = context.UsuarioAdd(usuario.Rol.IdRol,usuario.UserName,usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno,
                        usuario.Email,usuario.Password,usuario.FechaNacimiento,usuario.Sexo,usuario.NumeroTelefono,usuario.Celular,usuario.CURP,usuario.Direccion.Calle,
                        usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia,usuario.Imagen);

                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Message = "Usuario Agregado Correctamente";
                    }

                    //result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message ="Error al ingresar al usuario: "+ ex.Message;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Usuario usuario) {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context =new DL_EF.EMaquedaProgramacionNCapasEntities() )
                {
                    int query = context.UsuarioUpdate(usuario.Rol.IdRol, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                        usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.NumeroTelefono, usuario.Celular, usuario.CURP, usuario.IdUsuario,
                        usuario.Direccion.Calle,usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia,usuario.Imagen);
                    if (query>=1)
                    {
                        result.Correct = true;
                        result.Message = "Usuario Actualizado Correctamente";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error al actualizar el usuario: " + ex.Message;
                
            }
            return result;
        
        }

        public static ML.Result DeleteEF(int id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context=new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    int query = context.UsuarioDelete(id);
                    if (query>0)
                    {
                        result.Correct = true;
                        result.Message = "Usuario Borrado de la base de datos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error: "+ex.Message;
                
            }
            return result;
        }

        public static ML.Result GetAllEF(){
        ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context =new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetAll().ToList();

                    if (query!=null)
                    {
                        result.Objects= new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno= obj.ApellidoMaterno;
                            usuario.Nombre=obj.Nombre;
                            usuario.Email=obj.Email;
                            usuario.Password=obj.Password;
                            usuario.FechaNacimiento=obj.FechaNacimiento.ToString("dd/MM/yyyy");
                            usuario.Sexo=obj.Sexo;
                            usuario.NumeroTelefono=obj.Telefono;
                            usuario.Celular=obj.Celular;
                            usuario.CURP=obj.CURP;
                            usuario.NombreCompleto = obj.Nombre + " " + obj.ApellidoPaterno + " " + obj.ApellidoMaterno;
                            usuario.Imagen = obj.Imagen;

                            usuario.Rol=new ML.Rol();
                            usuario.Rol.IdRol= obj.IdRol.Value;
                            usuario.Rol.Nombre = obj.Cargo;
                            usuario.Direccion = new ML.Direccion();

                            usuario.Direccion.IdDireccion = obj.IdDireccion.Value;
                            usuario.Direccion.Calle = obj.Calle;
                            usuario.Direccion.NumeroInterior = obj.NumeroInterior;
                            usuario.Direccion.NumeroExterior = obj.NumeroExterior;

                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = obj.IdColonia.Value;
                            usuario.Direccion.Colonia.Nombre = obj.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = obj.CodigoPostal;

                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio.Value;
                            usuario.Direccion.Colonia.Municipio.Nombre = obj.NombreMunicipio;

                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre=obj.NombreEstado;

                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.NombrePais;

                            result.Objects.Add(usuario);
                        }
                    }
                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message="Error: "+ex.Message;
                
            }
        return result;
        }

        public static ML.Result GetByIdEF(int id) { 
        ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context=new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetById(id).FirstOrDefault();

                    if (query!=null) { 
                    ML.Usuario usuario=new ML.Usuario();
                        
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Nombre = query.Nombre;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString("dd/MM/yyyy");
                        usuario.Sexo = query.Sexo;
                        usuario.NumeroTelefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;
                        usuario.Imagen = query.Imagen;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;
                        usuario.Rol.Nombre = query.Cargo;

                        usuario.Direccion=new ML.Direccion();
                        usuario.Direccion.IdDireccion = query.IdDireccion.Value;
                        usuario.Direccion.Calle=query.Calle;
                        usuario.Direccion.NumeroInterior=query.NumeroInterior;
                        usuario.Direccion.NumeroExterior=query.NumeroExterior;

                        usuario.Direccion.Colonia=new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = query.IdColonia.Value;
                        usuario.Direccion.Colonia.Nombre = query.NombreColonia;

                        usuario.Direccion.Colonia.Municipio=new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Nombre = query.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado=new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado=query.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre=query.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.NombrePais;


                        result.Object= usuario;
                    }
                    result.Correct = true;
                }
                
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Error usuario no enecontrado: "+ex.Message;
             
            }
        return result;
        }


        public static ML.Result GetAllLINQ() { 
            Result result= new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context=new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = (from usuarioLINQ in context.Usuarios
                                 join rolLINQ in context.Rols on usuarioLINQ.IdRol equals rolLINQ.IdRol
                                 select new {
                                     IdUsuario = usuarioLINQ.IdUsuario,
                                     UserName = usuarioLINQ.UserName,
                                     ApellidoPaterno = usuarioLINQ.ApellidoPaterno,
                                     ApellidoMaterno = usuarioLINQ.ApellidoMaterno,
                                     Nombre = usuarioLINQ.Nombre,
                                     Email = usuarioLINQ.Email,
                                     Password = usuarioLINQ.Password,
                                     FechaNacimiento = usuarioLINQ.FechaNacimiento,
                                     Sexo = usuarioLINQ.Sexo,
                                     NumeroTelefono = usuarioLINQ.Telefono,
                                     Celular = usuarioLINQ.Celular,
                                     CURP = usuarioLINQ.CURP,
                                     IdRol = usuarioLINQ.Rol.IdRol,
                                     Cargo = usuarioLINQ.Rol.Nombre
                });
                    result.Objects = new List<object>();

                    if (query!=null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Nombre = obj.Nombre;
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Password;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                            usuario.Sexo = obj.Sexo;
                            usuario.NumeroTelefono = obj.NumeroTelefono;
                            usuario.Celular = obj.Celular;
                            usuario.CURP = obj.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol;
                            usuario.Rol.Nombre = obj.Cargo;
                            result.Objects.Add(usuario);
                        }
                        result.Correct=true;
                        result.Message = "Usuario Actualizado correctamente \n";
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

        public static ML.Result GetByIdLINQ(int id)
        {
            Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = (from usuarioLINQ in context.Usuarios
                                 join rolLINQ in context.Rols on usuarioLINQ.IdRol equals rolLINQ.IdRol
                                 where usuarioLINQ.IdUsuario== id
                                 select new
                                 {
                                     IdUsuario = usuarioLINQ.IdUsuario,
                                     UserName = usuarioLINQ.UserName,
                                     ApellidoPaterno = usuarioLINQ.ApellidoPaterno,
                                     ApellidoMaterno = usuarioLINQ.ApellidoMaterno,
                                     Nombre = usuarioLINQ.Nombre,
                                     Email = usuarioLINQ.Email,
                                     Password = usuarioLINQ.Password,
                                     FechaNacimiento = usuarioLINQ.FechaNacimiento,
                                     Sexo = usuarioLINQ.Sexo,
                                     NumeroTelefono = usuarioLINQ.Telefono,
                                     Celular = usuarioLINQ.Celular,
                                     CURP = usuarioLINQ.CURP,
                                     IdRol = usuarioLINQ.Rol.IdRol,
                                     Cargo = usuarioLINQ.Rol.Nombre
                                 }).FirstOrDefault();
                    result.Object = query;

                    if (query != null)
                    {
                        //foreach (var obj in query)
                        //{
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = query.IdUsuario;
                            usuario.UserName = query.UserName;
                            usuario.ApellidoPaterno = query.ApellidoPaterno;
                            usuario.ApellidoMaterno = query.ApellidoMaterno;
                            usuario.Nombre = query.Nombre;
                            usuario.Email = query.Email;
                            usuario.Password = query.Password;
                            usuario.FechaNacimiento = query.FechaNacimiento.ToString();
                            usuario.Sexo = query.Sexo;
                            usuario.NumeroTelefono = query.NumeroTelefono;
                            usuario.Celular = query.Celular;
                            usuario.CURP = query.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = query.IdRol;
                            usuario.Rol.Nombre = query.Cargo;
                            result.Object = usuario;
                            //result.Objects.Add(usuario);
                        //}
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

        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();


                    usuarioDL.IdUsuario = usuario.IdUsuario;
                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioDL.Sexo = usuario.Sexo;
                    usuarioDL.Telefono = usuario.NumeroTelefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.CURP = usuario.CURP;

                    //usuario.Rol = new ML.Rol();
                    usuarioDL.IdRol = usuario.Rol.IdRol;
                    context.Usuarios.Add(usuarioDL);
                    context.SaveChanges();
                }
                result.Correct=true;
                result.Message = "Usuario agregado correctamente con LINQ";
             
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Message ="Error: "+ ex.Message;
            }
            return result;
        }

        public static ML.Result UpdateLINQ(ML.Usuario usuario) { 
        
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context=new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = (from usuarioLINQ in context.Usuarios
                                 where usuarioLINQ.IdUsuario == usuario.IdUsuario
                                 select usuarioLINQ).SingleOrDefault();

                    if (query!=null)
                    {
                        query.IdUsuario = usuario.IdUsuario;
                        query.UserName= usuario.UserName;
                        query.Nombre= usuario.Nombre;
                        query.ApellidoPaterno=usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.Email= usuario.Email;
                        query.Password= usuario.Password;
                        query.FechaNacimiento =DateTime.Parse(usuario.FechaNacimiento);
                        query.Sexo= usuario.Sexo;
                        query.Telefono = usuario.NumeroTelefono;
                        query.Celular= usuario.Celular;
                        query.CURP= usuario.CURP;
                        context.SaveChanges();
                        result.Correct=true;
                        result.Message = "Usuario Actualizado correctamente con linq";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message="Error: "+ex.Message;
            }
            return result;
        }

        public static ML.Result DelateLINQ(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = (from usarioLINQ in context.Usuarios
                                 where usarioLINQ.IdUsuario == idUsuario
                                 select usarioLINQ).First();
                    context.Usuarios.Remove(query);
                    context.SaveChanges();
                    result.Correct = true;
                    result.Message = "Usuario elmiminado de la base de datos usando linq";
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