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
    /// Логика взаимодействия для WindowAddMeterial.xaml
    /// </summary>
    public partial class WindowAddMeterial : Window
    {
        public WindowAddMeterial()
        {
            InitializeComponent();
        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMaterilSklad windowMaterilSklad = new WindowMaterilSklad();
            windowMaterilSklad.Show();
            this.Close();
        }
    }
}
