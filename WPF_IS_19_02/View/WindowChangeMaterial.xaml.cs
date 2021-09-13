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
using WPF_IS_19_02.Controllers;
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

            try
            {
                cbTypeMaterial.ItemsSource = ContrillerMaterial.GetMaterialComboBox();
                cbSI.ItemsSource = ContrillerSI.GetSIComboBox();
                cbImage.ItemsSource = ControllerImage.GetImages();

                var sb = (cbSI.ItemsSource as List<string>).
                     Single(x => x == material.Materials.MaterialSI.Name);

                cbSI.SelectedIndex = cbSI.Items.IndexOf(sb) ;



                var sbType = (cbTypeMaterial.ItemsSource as List<string>).
                     Single(x => x == material.Materials.MaterialTypes.Name);

                cbTypeMaterial.SelectedIndex = cbTypeMaterial.Items.IndexOf(sbType);

                cbImage.SelectedIndex = 1;
            }

            catch
            {
                MessageBox.Show("Error db");
            }

        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               if (  ControllerMaterial.ChaneMateril(tbName.Text, tbDescription.Text
                   , tbMinCount.Text, tbPackageCount.Text, tbPriceR.Text, cbImage.SelectedItem,
                   cbSI.SelectedItem, cbTypeMaterial.SelectedItem, Material.Materials))
                {
                    MessageBox.Show("объект  сохранен");
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(MessageBox.Show("Вы уверены что  хотите удалить" , "Удалить  Объект?" ,MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ControllerMaterial.Remove(Material.Materials);
                    MessageBox.Show("Объект  удален");
                }

              
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMaterilSklad windowMaterilSklad = new WindowMaterilSklad();
            windowMaterilSklad.Show();
            this.Close();
        }
    }
}
