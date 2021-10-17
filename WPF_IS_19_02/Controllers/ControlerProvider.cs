using System;
using System.Collections.Generic;
using System.Linq;

namespace WPF_IS_19_02.View
{
    internal class ControlerProvider
    {
        internal static void Add(string name, string inn, string  rating, string typeProvider, DateTime? selectedDate)
        {
            try
            {
                var prov = new DB.Suppliers();
                prov.Name = name;
                prov.INN = inn;
                prov.RatingNumber = Convert.ToInt32(rating);
                prov.Id_SupplierType = ConrtrollersTypeCompany.GetTupeId(typeProvider);
                 if (selectedDate != null)
                {
                    prov.DateStartWork = selectedDate.ToString();
                }


                DB.dEntities entities = App.dEntities;
                entities.Suppliers.Add(prov);
                entities.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        internal static List<DB.Suppliers> GetListProvider()
        {
            try
            {
                DB.dEntities entities = App.dEntities;
                return entities.Suppliers.ToList();
             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}