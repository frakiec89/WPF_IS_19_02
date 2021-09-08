using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WPF_IS_19_02.View
{
    internal class ControllerMaterial
    {
        public static List<View.ModelView.ViewMaterial> GetViewMaterial()
        {

            try
            {
                DB.dEntities entities = new DB.dEntities();

                var material = entities.Materials.ToList();

                List<View.ModelView.ViewMaterial> views = new List<ModelView.ViewMaterial>();

                foreach (var item in material)
                {
                    views.Add(new ModelView.ViewMaterial(item));
                }

                return views;
            }
            catch
            {
                throw new Exception("Error db");
            }

        }
    }
}