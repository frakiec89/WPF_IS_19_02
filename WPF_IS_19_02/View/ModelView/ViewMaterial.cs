using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
