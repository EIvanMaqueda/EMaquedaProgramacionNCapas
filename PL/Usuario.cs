using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace PL
{
    public class Usuario
    {      
        public static void Menu() {

            int op=0;
            while (op != 6)
            {
                Console.WriteLine("Introduzca la accion que desee realizar:" + "\n" +
                    "1.-Agregar" + "\n" + "2.-Actualizar" + "\n" + "3.-Eliminar" + "\n" + "4.-Buscar"+
                    "\n"+"5.-Buscar Todos"+"\n"+"6.-Salir");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Get();
                        break;
                        
                    case 5: 
                        GetAll();
                        break;

                    case 6:
                        break;
                    
                    default:
                        break;
                }
            }
        }
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese su User Name");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingrese el Nombre del Usuario");
            usuario.Nombre= Console.ReadLine();
            Console.WriteLine("Ingrese el Apellido Paterno del Usuario");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el Apellido Materno del Usuario");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el email del usuario");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña:");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingrese su fecha de naciminto yyyy-mm-dd");
            usuario.FechaNacimiento =Console.ReadLine();
            Console.WriteLine("Ingrese el sexo del usuario \n H.-Hombre \n M.-Mujer");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingrese el Numero de Telefono del Usuario");
            usuario.NumeroTelefono = Console.ReadLine();
            Console.WriteLine("Ingrese el Celular del usuario");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingrese el CURP del Usuario");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("Ingrese el rol del usuario: \n 1.-Programador \n 2.-Traine");
            usuario.Rol=new ML.Rol();
            usuario.Rol.IdRol=byte.Parse(Console.ReadLine());
            //ML.Result result=BL.Usuario.Add(usuario);//sqlserver
            //ML.Result result = BL.Usuario.AddSP(usuario);//stored procedure
            //ML.Result result = BL.Usuario.AddEF(usuario);//entity framework
            ML.Result result = BL.Usuario.AddLINQ(usuario);
            
            Console.WriteLine(result.Message);
            Console.ReadKey();

            


        }
        public static void Update() 
        { 
            ML.Usuario usuario=new ML.Usuario();
            Console.WriteLine("Ingrese el Id del usuario que desea actualizar");
            int Id=int.Parse(Console.ReadLine());
            usuario=BL.Usuario.Get(Id);
            if (usuario.IdUsuario==0)
            {
                Console.WriteLine("Usuario no encontrado en la base de datos");
            }
            else
            {
                Console.WriteLine("Ingrese su User Name");
                usuario.UserName = Console.ReadLine();
                Console.WriteLine("Ingrese el Nombre del Usuario");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el Apellido Paterno del Usuario");
                usuario.ApellidoPaterno = Console.ReadLine();
                Console.WriteLine("Ingrese el Apellido Materno del Usuario");
                usuario.ApellidoMaterno = Console.ReadLine();
                Console.WriteLine("Ingrese el email del usuario");
                usuario.Email = Console.ReadLine();
                Console.WriteLine("Ingrese su contraseña:");
                usuario.Password = Console.ReadLine();
                Console.WriteLine("Ingrese su fecha de naciminto yyyy-mm-dd");
                usuario.FechaNacimiento =Console.ReadLine();
                Console.WriteLine("Ingrese el sexo del usuario \n H.-Hombre \n M.-Mujer");
                usuario.Sexo = Console.ReadLine();
                Console.WriteLine("Ingrese el Numero de Telefono del Usuario");
                usuario.NumeroTelefono = Console.ReadLine();
                Console.WriteLine("Ingrese el Celular del usuario");
                usuario.Celular = Console.ReadLine();
                Console.WriteLine("Ingrese el CURP del Usuario");
                usuario.CURP = Console.ReadLine();
                Console.WriteLine("Ingrese el rol del usuario: \n 1.-Programador \n 2.-Traine");
                usuario.Rol = new ML.Rol();
                usuario.Rol.IdRol = byte.Parse(Console.ReadLine());
                //ML.Result result=BL.Usuario.Update(usuario);//sqlserver
                //ML.Result result = BL.Usuario.UpdateSP(usuario);//stored procedure
                //ML.Result result=BL.Usuario.UpdateEF(usuario);//entity framework

                ML.Result result = BL.Usuario.UpdateLINQ(usuario);
                Console.WriteLine(result.Message);
                
            }
            Console.ReadKey();
        }
        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el id del usuario que desea eliminar");
            int Id = int.Parse(Console.ReadLine());
            //ML.Result result=BL.Usuario.Delete(Id);//sqlserver
            //ML.Result result = BL.Usuario.DeleteSP(Id);//stored procedure
            //ML.Result result = BL.Usuario.DeleteEF(Id);//identity framework
            ML.Result result = BL.Usuario.DelateLINQ(Id);
            
            Console.WriteLine(result.Message);
            Console.ReadKey();

            
           
        }
        public static void Get() 
        {
            Console.WriteLine("Ingrese el id del usuario que desea buscar");
            int Id = int.Parse(Console.ReadLine());
            //ML.Usuario usuario=new ML.Usuario();
            //ML.Usuario usuario=BL.Usuario.Get(Id);//conssulta sql
            //ML.Result result = BL.Usuario.GetById(Id);//stored procedure
            //ML.Result result=BL.Usuario.GetByIdEF(Id);//entity framework
            ML.Result result = BL.Usuario.GetByIdLINQ(Id);
            //result.Object = usuario;
            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;

                    Console.WriteLine("Idusuario: " + usuario.IdUsuario);
                    Console.WriteLine("User Name: " + usuario.UserName);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("Password: " + usuario.Password);
                    Console.WriteLine("Fecha de Nacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Numero de Telefono: " + usuario.NumeroTelefono);
                    Console.WriteLine("Numero de Celular: " + usuario.Celular);
                    Console.WriteLine("CURP: " + usuario.CURP);
                    Console.WriteLine("Cargo: " + usuario.Rol.Nombre + "\n");

            }
            else {
                Console.WriteLine("Usuario no encontrado");
            }

            Console.ReadKey();

        }
        public static void GetAll()
        {
            //ML.Result result= BL.Usuario.GetAll();//stored procedure

            ML.Result result = BL.Usuario.GetAllEF();//entity framework
            //ML.Result result = BL.Usuario.GetAllLINQ();
            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("Idusuario: " + usuario.IdUsuario);
                    Console.WriteLine("User Name: " + usuario.UserName);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("Password: " + usuario.Password);
                    Console.WriteLine("Fecha de Nacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Numero de Telefono: " + usuario.NumeroTelefono);
                    Console.WriteLine("Numero de Celular: " + usuario.Celular);
                    Console.WriteLine("CURP: " + usuario.CURP);
                    Console.WriteLine("Cargo: "+usuario.Rol.Nombre);
                    Console.WriteLine("----------------------------------------------");

                }
            }
            Console.WriteLine("\n");
            Console.ReadKey();

        }


    }
}
