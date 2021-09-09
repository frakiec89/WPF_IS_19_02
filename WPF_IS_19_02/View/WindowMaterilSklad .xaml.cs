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
        private int actualList = 1;
        private int actualMax;

        private List<View.ModelView.ViewMaterial> content = new List<ModelView.ViewMaterial>();

        public WindowMaterilSklad()
        {
            InitializeComponent();

            try
            {
                content = GetContent();
                lbContent.ItemsSource = content;
                DinamicStakBytton(content.Count);
                actualMax = spButtons.Children.Count - 2;
                var s = WindosMaterialService.IntMin(actualList);
                RefreshContent(s, WindosMaterialService.CountContent(s, content.Count));
                labelList.Content = $"лист {actualList}";

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


        private void  DinamicStakBytton( int count )
        {
            int countButton = WindosMaterialService.GetCountButton(count);
            spButtons.Children.Add(CreateButtun("btDown", "<<", btDown_Ckick)); // Добавил первую кнопку 
            
            for (int i = 0; i < WindosMaterialService.GetCountButton(count); i++) // генерация кнопок
            {
                spButtons.Children.Add(CreateButtun($"btNext{i}",  $"{i+1}", btNext_Ckick)); // Добавил первую кнопку 
            }
            spButtons.Children.Add(CreateButtun("btUp", ">>", btUp_Ckick)); // Добавил первую кнопку 
        }

        private void btDown_Ckick ( object Sender , RoutedEventArgs e)
        {
            if(actualList>1)
            {
                actualList--;
                var s =  WindosMaterialService.IntMin(actualList);
                RefreshContent(s, WindosMaterialService.CountContent(s, content.Count));
            }
        }

        private void RefreshContent(int start, int  end)
        {
            var s = content.GetRange(start, end);
            lbContent.ItemsSource = s;
            labelList.Content = $"лист {actualList}";
        }

        private void btUp_Ckick(object Sender, RoutedEventArgs e)
        {
            if (actualList <actualMax  )
            {
                actualList++;
                var s = WindosMaterialService.IntMin(actualList);
                RefreshContent(s, WindosMaterialService.CountContent(s,content.Count));
            }
        }

        private void btNext_Ckick(object Sender, RoutedEventArgs e)
        {
            var but = e.OriginalSource as Button;
            actualList = Convert.ToInt32(but.Content.ToString());
            var s = WindosMaterialService.IntMin(actualList);
            RefreshContent(s, WindosMaterialService.CountContent(s, content.Count));


        }


        private Button CreateButtun (string name , string content,  RoutedEventHandler  action )
        {
           var b = new Button() { Name = name, Content = content , Margin= new Thickness(5) };
            b.Background = new SolidColorBrush(Color.FromArgb(255, 255, 193, 193));
            b.HorizontalAlignment = HorizontalAlignment.Center;
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

        public static int  IntMin (int list)
        {
            return (list * 15)  -15;
        }

        public static int CountContent (int  start , int Maxcount)
        {
            int rez = Maxcount - start;

            if (rez >= 15)
                return 15;
            else
            {
              return  rez;
            }
        }

    }
}
