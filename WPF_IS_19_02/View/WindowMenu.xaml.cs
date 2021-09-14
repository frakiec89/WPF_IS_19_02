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
using WPF_IS_19_02.DB;

namespace WPF_IS_19_02.View
{
    /// <summary>
    /// Логика взаимодействия для WindowMenu.xaml
    /// </summary>
    public partial class WindowMenu : Window
    {

        public WindowMenu()
        {
            InitializeComponent();
            Title += $"Вход ({App.User.Name}) {App.User.TypeUSer.Name}";
        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
       

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            View.AddImage window = new AddImage();
            window.Show();
            this.Close();
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            View.WindowProvider window = new WindowProvider();
            window.Show();
            this.Close();
        }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            View.WindowReceipts window = new WindowReceipts();
            window.Show();
            this.Close();
        }

        private void btMaterialSklad_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMaterilSklad window = new WindowMaterilSklad();
            window.Show();
            this.Close();
        }
    }
}
