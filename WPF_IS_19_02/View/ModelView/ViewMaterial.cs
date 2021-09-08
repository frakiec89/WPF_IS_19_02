using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_IS_19_02.DB;

namespace WPF_IS_19_02.View.ModelView
{
    public  class ViewMaterial
    {
        public string Image { get; set; }
        public string NameEndType { get; set; }
        public string Ostatok { get; set; }
        public string MinCol{ get; set; }
        public string Providers { get; set; }
       
        public ViewMaterial()
        {

        }




        public ViewMaterial(DB.Materials materials)
        {
            Image = @"/Image/" + materials.ImagePath;
            NameEndType = $" {materials.MaterialTypes.Name} | {materials.Name}";
            MinCol = $"Минимальное  количество {materials.MinCount} шт.";
            Ostatok = GetOstatoc(materials);
            Providers = GetProviders(materials);
        }

        private string GetProviders(Materials materials)
        {
            throw new NotImplementedException();
        }

        private string GetOstatoc(Materials materials)
        {
            throw new NotImplementedException();
        }
    }
}
