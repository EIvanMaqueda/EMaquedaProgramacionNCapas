using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAllPais()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = context.PaisGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Pais pais = new ML.Pais();
                            pais.IdPais=obj.IdPais;
                            pais.Nombre=obj.Nombre;
                            result.Objects.Add(pais);
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
    }
}
