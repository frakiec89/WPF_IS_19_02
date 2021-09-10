using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WPF_IS_19_02.View
{
    internal class ContrillerSI
    {
        /// <summary>
        /// Возвращает  список едениц измерений 
        /// </summary>
        /// <returns>текстовый список</returns>
        internal static List<string> GetSIComboBox()
        {
           try
           {
                DB.dEntities entities = new DB.dEntities();
               return entities.MaterialSI.Select(x => x.Name).OrderBy(x=>x).ToList();
           }
            catch
           {
                throw new Exception("Errod DB");
           }
        }
    }
}