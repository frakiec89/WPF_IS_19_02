using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_IS_19_02.View.ModelView;

namespace WPF_IS_19_02.View
{
    /// <summary>
    /// Логика взаимодействия для WindowChangeMaterial.xaml
    /// </summary>
    public partial class WindowChangeMaterial : Window
    {
        public ViewMaterial Material { get; }
        public WindowChangeMaterial()
        {
            InitializeComponent();
        }

        public WindowChangeMaterial(ViewMaterial material) :this()
        {
            Material = material;
            tbName.Text = Material.Materials.Name;
            tbMinCount.Text = Material.Materials.MinCount.ToString();
            tbDescription.Text = Material.Materials.Discriptions;
            tbPriceR.Text = Material.Materials.Price.ToString();

            



        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
