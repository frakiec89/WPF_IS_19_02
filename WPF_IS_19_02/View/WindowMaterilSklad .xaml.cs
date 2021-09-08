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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class WindowMaterilSklad : Window
    {
        public WindowMaterilSklad()
        {
            InitializeComponent();

            List<View.ModelView.ViewMaterial> materials = new List<ModelView.ViewMaterial>()
            {
                new ModelView.ViewMaterial(){ Image=@"/Image\image_10.jpeg" , MinCol="Минимальное  количество 2 шт",
                Ostatok = "Остаток: 2 шт", Providers="Поставщики: рога и копыта, Сгк, и еще  кто нибудь" ,
                    NameEndType="Какая то штука | зачем  то нужна"
                },
                 new ModelView.ViewMaterial(){ Image=@"/Image\image_1.jpeg" , MinCol="Минимальное  количество 5 шт",
                Ostatok = "Остаток: 0 шт", Providers="Поставщики: рога и копыта, Сгк, и еще  кто нибудь" ,
                    NameEndType="Какая то штука1 | зачем  то нужна1"
                }
            };

            lbContent.ItemsSource = materials;
        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            View.WindowMenu menu = new WindowMenu();
            menu.Show();
            this.Close();
        }
    }
}
