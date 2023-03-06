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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuzBD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static Dictionary<string, string> users = new Dictionary<string, string>();
        public static bool us = true;
        public static string name;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                users.Add("admin", "admin");
                if (users.ContainsKey(Login.Text) && Password.Password == users[Login.Text])
                {
                    if (Login.Text == "admin")
                        us = false;
                    else
                        us = true;
                    name = Login.Text;
                    Window1 window1 = new Window1();
                    window1.Show();
                    this.Close();
                    users.Remove("admin");
                }
                else
                    MessageBox.Show("Логин или пароль неверны...", "Может очепятка?", MessageBoxButton.OK, MessageBoxImage.Error);
                users.Remove("admin");
            }
            catch (Exception)
            {
                MessageBox.Show(".", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Login.Text.Length < 5 && Password.Password.Length < 5)
                {
                    MessageBox.Show("Длина логина и пароля не должна быть короче 5 символов", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (!users.ContainsKey(Login.Text) && Login.Text != "admin")
                {
                    users.Add(Login.Text, Password.Password);
                    MessageBox.Show("Новая учетная запись!", "Успех!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Данная учетная запись уже есть!", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(".", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
