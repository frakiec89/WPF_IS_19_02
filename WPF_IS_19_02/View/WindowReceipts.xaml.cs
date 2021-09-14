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

namespace WPF_IS_19_02.View
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class WindowReceipts : Window
    {
        public WindowReceipts()
        {
            InitializeComponent();
           
            this.Loaded += WindowReceipts_Loaded;

        }

        private void WindowReceipts_Loaded(object sender, RoutedEventArgs e)
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
            this.Title = "Поставки  на  склад";
            cbMaterial.ItemsSource = ControllerMaterial.GetViewMaterial();
            cbProvider.ItemsSource = ControlerProvider.GetListProvider();


        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMenu menu = new WindowMenu();
            menu.Show();
            this.Close();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbMaterial.SelectedItem == null)
            {
                MessageBox.Show("Укажите материал"); return;
            }

            if (cbProvider.SelectedItem == null)
            {
                MessageBox.Show("Укажите поставщика"); return;
            }

            var materrial = cbMaterial.SelectedItem as View.ModelView.ViewMaterial;
            var provider = cbProvider.SelectedItem as DB.Suppliers;




            if ( string.IsNullOrWhiteSpace(tbCount.Text))
            {
                MessageBox.Show("Укажите кол-во"); return;
            }


            try
            {
                ControlerReceipts.Add(materrial, provider, Convert.ToInt32(tbCount.Text));
                MessageBox.Show("Поставка прошла");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }
    }
}
