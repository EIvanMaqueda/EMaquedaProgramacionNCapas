using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Aseguradora
    {
        public static void Menu2()
        {

            int op = 0;
            while (op != 6)
            {
                Console.WriteLine("MENU ASEGURADORA \n Introduzca la accion que desee realizar:" + "\n" +
                    "1.-Agregar" + "\n" + "2.-Actualizar" + "\n" + "3.-Eliminar" + "\n" + "4.-Buscar" +
                    "\n" + "5.-Buscar Todos" + "\n" + "6.-Salir");
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
            ML.Aseguradora aseguradora=new ML.Aseguradora();
            Console.WriteLine("Ingrese el nombre de la aseguradora:");
            aseguradora.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Id del Usuario");
            aseguradora.Usuario=new ML.Usuario();
            aseguradora.Usuario.IdUsuario = int.Parse(Console.ReadLine());
            //ML.Result result = BL.Aseguradora.AddAseguradoraEF(aseguradora);//ef
            ML.Result result= BL.Aseguradora.AddAseguradoraLINQ(aseguradora);
            Console.WriteLine(result.Message);
            Console.ReadKey();

        }
        public static void Update()
        {

            ML.Aseguradora aseguradora = new ML.Aseguradora();
            Console.WriteLine("Ingrese el id de la aseguradora:");
            aseguradora.IdAseguradora = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre de la aseguradora:");
            aseguradora.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Id del Usuario");
            aseguradora.Usuario = new ML.Usuario();
            aseguradora.Usuario.IdUsuario = int.Parse(Console.ReadLine());
            ML.Result result = BL.Aseguradora.UpdateAseguradoraEF(aseguradora);
            Console.WriteLine(result.Message);
            Console.ReadKey();
        }

        public static void Get()
        {
            Console.WriteLine("Ingrese el id de la aseguradora que desea buscar");
            int Id = int.Parse(Console.ReadLine());
            ML.Result result = BL.Aseguradora.GetByIdAseguradoraEF(Id);
            //result.Object = usuario;
            if (result.Correct)
            {
                ML.Aseguradora aseguradora = (ML.Aseguradora)result.Object;

                Console.WriteLine("Idaseguradora: " + aseguradora.IdAseguradora);
                Console.WriteLine("Nombre: " + aseguradora.Nombre);
                Console.WriteLine("Fecha de Creacion: " + aseguradora.FechaCreacion);
                Console.WriteLine("Fecha de actulizacion: " + aseguradora.FechaModificacion);
                Console.WriteLine("IdUsuario: " + aseguradora.Usuario.IdUsuario);
                Console.WriteLine("----------------------------------------------");

            }
            else
            {
                Console.WriteLine("Usuario no encontrado");
            }

            Console.ReadKey();

        }
        public static void GetAll()
        {
            //ML.Result result= BL.Usuario.GetAll();//stored procedure

            //ML.Result result = BL.Usuario.GetAllEF();//entity framework
            ML.Result result = BL.Aseguradora.GetAllAseguradoraEF();
            if (result.Correct)
            {
                foreach (ML.Aseguradora aseguradora in result.Objects)
                {
                    Console.WriteLine("Idaseguradora: " + aseguradora.IdAseguradora);
                    Console.WriteLine("Nombre: "+aseguradora.Nombre);
                    Console.WriteLine("Fecha de Creacion: "+aseguradora.FechaCreacion);
                    Console.WriteLine("Fecha de actulizacion: "+aseguradora.FechaModificacion);
                    Console.WriteLine("IdUsuario: "+aseguradora.Usuario.IdUsuario);
                    Console.WriteLine("----------------------------------------------");

                }
            }
            Console.WriteLine("\n");
            Console.ReadKey();

        }
    }
}
