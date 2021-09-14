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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class WindowProvider : Window
    {
        public WindowProvider()
        {
            InitializeComponent();
           
            this.Loaded += WindowProvider_Loaded;
        }

        private void WindowProvider_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Run()
        {
            this.Title = "Добавить поставщика";
            for (int i = 1; i < 101; i++)
            {
                cbRating.Items.Add(i);
            }

            cbType.ItemsSource = ConrtrollersTypeCompany.GetTupe();
        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMenu menu = new WindowMenu();
            menu.Show();
            this.Close();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty( tbName.Text))
                {
                    MessageBox.Show("Укажите имя"); 
                    return;
                }

                if (string.IsNullOrEmpty(tbINN.Text) && tbINN.Text.Length<=10 )
                {
                    MessageBox.Show("Укажите правильный  Инн");
                    return;
                }

                if (cbRating.SelectedItem == null)
                {
                    MessageBox.Show("укажите рейтинг");
                    return;
                }

                if (cbType.SelectedItem == null)
                {
                    MessageBox.Show("укажите тип компании");
                    return;
                }

                if (calendarDateStartWork.SelectedDate== null)
                {
                    MessageBox.Show("укажите дату");
                    return;
                }


                ControlerProvider.Add(tbName.Text, tbINN.Text, cbRating.SelectedItem.ToString(),
               cbType.SelectedItem.ToString(),
               calendarDateStartWork.SelectedDate);
                MessageBox.Show("поставщик добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
