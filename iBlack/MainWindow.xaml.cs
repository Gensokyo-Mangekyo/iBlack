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

namespace iBlack
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login.Text) || Login.Text == "" || string.IsNullOrWhiteSpace(Login.Text) || Login.Text == "")
            {
                MessageBox.Show("Заполните все поля для входа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string TitleJob = Repository.DB.CheckEmployee(Login.Text, Password.Password);
            if (!string.IsNullOrEmpty(TitleJob))
            {
                if (TitleJob == "Инженер" || TitleJob == "Главный Инженер")
                {
                    var technic = new Technic();
                    technic.Show();
                }
                else
                {
                    var supervisor = new Supervisor();
                    supervisor.Show();
                }
                Close();
            }
            else MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
