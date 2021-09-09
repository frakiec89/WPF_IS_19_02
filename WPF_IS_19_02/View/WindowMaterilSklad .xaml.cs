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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class WindowMaterilSklad : Window
    {
        private List<View.ModelView.ViewMaterial> content = new List<ModelView.ViewMaterial>();

        public WindowMaterilSklad()
        {
            InitializeComponent();

            try
            {
               content = GetContent();
                lbContent.ItemsSource = content;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<ViewMaterial> GetContent()
        {
            try
            {
                return ControllerMaterial.GetViewMaterial();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMenu menu = new WindowMenu();
            menu.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("Объект не  найден");
        }


        private void DinamicStakBytton( int count )
        {
            int countButton = WindosMaterialService.GetCountButton(count); 
            



        }


        private Button CreateButtun (string name , string content,  RoutedEventHandler  action )
        {
           var b = new Button() { Name = name, Content = content };
            b.Click+=action ;
            return b;
        }

        
    }

    public class WindosMaterialService
    {
        public static int GetCountButton(int count)
        {
            if (count % 15 == 0)
            {
                return count / 15;
            }
            else
            {
                return count / 15 + 1;
            }
        }
    }
}
