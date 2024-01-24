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
            string EmployeInfo = Repository.DB.CheckEmployee(Login.Text, Password.Password);
            if (EmployeInfo == null)
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string[] ArrayEmployeeInfo = EmployeInfo.Split('.');
     
                if (ArrayEmployeeInfo[3] == "Инженер" || ArrayEmployeeInfo[3] == "Главный Инженер")
                {
                    var technic = new Technic(ArrayEmployeeInfo[1] + " " + ArrayEmployeeInfo[2], ArrayEmployeeInfo[3]);
                    technic.Show();
                }
                else
                {
                    var supervisor = new Supervisor();
                    supervisor.Show();
                }
                Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
