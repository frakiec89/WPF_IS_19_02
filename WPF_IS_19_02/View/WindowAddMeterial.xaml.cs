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

namespace WPF_IS_19_02.View
{
    /// <summary>
    /// Логика взаимодействия для WindowAddMeterial.xaml
    /// </summary>
    public partial class WindowAddMeterial : Window
    {
        public WindowAddMeterial()
        {
            InitializeComponent();
            this.Loaded += WindowAddMeterial_Loaded;
        }

        private void WindowAddMeterial_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Run();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Run()
        {
            cbTypeMaterial.ItemsSource = ContrillerMaterial.GetMaterialComboBox();
            cbSI.ItemsSource = ContrillerSI.GetSIComboBox();
            cbImage.ItemsSource = ControllerImage.GetImages();
        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMaterilSklad windowMaterilSklad = new WindowMaterilSklad();
            windowMaterilSklad.Show();
            this.Close();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            #region Валидация
            if (string.IsNullOrWhiteSpace(  tbName.Text))
            {
                MessageBox.Show("Имя не заданно");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbPriceR.Text))
            {
                MessageBox.Show("Укажите цену");
                return;
            }

            try
            {
                double p = Convert.ToDouble(tbPriceR.Text);
                if(p<0)
                {
                    MessageBox.Show("Цена  не  может  быть  отрицательной");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Укажите правильный формат цены");
                return;
            }


            if (string.IsNullOrWhiteSpace(tbPackageCount.Text))
            {
                MessageBox.Show("Укажите Кол-во  в пачке");
                return;
            }

            try
            {
                int  count = Convert.ToInt32(tbPackageCount.Text);
                if (count < 0)
                {
                    MessageBox.Show("кол-во  в пачке  не  может  быть  отрицательной");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Укажите правильный формат кол-ва в  пачке");
                return;
            }

            if(cbSI.SelectedIndex<0)
            {
                MessageBox.Show("Выберете ед измерения");
                return;
            }



            #endregion

           try
           {
               if ( ControllerMaterial.AddMateril(tbName.Text, tbDescription.Text
                    , tbMinCount.Text, tbPackageCount.Text, tbPriceR.Text, cbImage.SelectedItem,
                    cbSI.SelectedItem, cbTypeMaterial.SelectedItem
                    ))
                {
                    MessageBox.Show("Объект  добавлен в  БД");
                }
               else
                {
                    MessageBox.Show("Объект не   добавлен в  БД");
                }
           }
           catch (Exception ex)
           {
                MessageBox.Show("Ошибка добавления в  бд");
            }
        }
    }
}
