using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace WPF_IS_19_02.View
{
    internal class ConrtrollersTypeCompany
    {
        internal static List<string> GetTupe()
        {
            try
            {
                DB.dEntities entities = App.dEntities;
                return entities.SupplierTypes.Select(x=>x.Name).ToList();
            }
            catch
            {
                throw new Exception("Error db");
            }
         
        }

        internal static int GetTupeId(string typeProvider)
        {
            try
            {
                DB.dEntities entities = App.dEntities;
                return entities.SupplierTypes.Single(x => x.Name == typeProvider).Id;
            }
            catch
            {
                throw new Exception("Error db");
            }
        }
    }
}