using System;
using System.Linq;
using System.Windows;
using WPF_IS_19_02.View;

namespace WPF_IS_19_02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            tbName.Text = "Frakiec89"; // todo не забыть  убрать 
            tbPass.Text = "123";// todo не забыть  убрать 


        }
        private void btGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = Authentication.AuthenticationUser(tbName.Text, tbPass.Text);
                App.User = user;
                View.WindowMenu menu = new View.WindowMenu();
                ///  MessageBox.Show("Добро пожаловать " + user.Name); // todo не забыть  убрать

                menu.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            View.WindowAddMeterial windowAddMeterial = new WindowAddMeterial();
            windowAddMeterial.Show();
            this.Close();
        }
    }

    public class Authentication
    {
        public  static DB.User AuthenticationUser (string login , string password)
        {
            try
            {
                DB.dEntities entities = new DB.dEntities();
                var user = entities.User.Single(x => x.Login == login && x.Password == password);
                if (user != null)
                {
                    DB.Logs logs = new DB.Logs() { UserLogin = user.Login, Date = DateTime.Now };
                    entities.Logs.Add(logs);
                    entities.SaveChanges();
                    return user;
                }
                else throw new Exception($"пользователь не найден\r ");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка авторизации \r {ex.Message}");
            }
        }
    }
}