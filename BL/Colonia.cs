﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {

        public static ML.Result ColoniaGetByIdMunicipio(int idMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EMaquedaProgramacionNCapasEntities context = new DL_EF.EMaquedaProgramacionNCapasEntities())
                {
                    var query = context.ColoniaGetByIdMunicipio(idMunicipio).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Colonia colonia=new ML.Colonia();
                            colonia.IdColonia=obj.IdColonia;
                            colonia.Nombre=obj.Nombre;
                            colonia.CodigoPostal=obj.CodigoPostal;
                            result.Objects.Add(colonia);
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
