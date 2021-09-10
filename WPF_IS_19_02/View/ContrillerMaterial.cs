using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WPF_IS_19_02.View
{
    internal class ContrillerMaterial
    {
        internal static List<string> GetMaterial()
        {

            List<string> types = new List<string>();
            try
            {
                DB.dEntities entities = new DB.dEntities() ;
                types = entities.MaterialTypes.Select(x => x.Name).ToList();
                ;
                types.OrderBy(x=>x);
                types.Insert(0, "Без Фильтра");
                return types;
            }
            catch
            {
                throw new Exception("Error DB");
            }
        }

        internal static List<string> GetMaterialComboBox()
        {

            List<string> types = new List<string>();
            try
            {
                DB.dEntities entities = new DB.dEntities();
                types = entities.MaterialTypes.Select(x => x.Name).ToList();
                ;
                types.OrderBy(x => x);
                return types;
            }
            catch
            {
                throw new Exception("Error DB");
            }
        }
    }
}