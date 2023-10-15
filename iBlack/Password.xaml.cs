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

namespace iBlack
{
    /// <summary>
    /// Логика взаимодействия для Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        public Password()
        {
            InitializeComponent();
        }
        private string Login = "";
        private string Pass = "";

        public Password(string Login,string Password)
        {
            InitializeComponent();
            this.Login = Login;
            Pass = Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EnteredLogin.Text == Login && EnteredPasword.Password == Pass)
            {
                DialogResult = true;
                Close();
            }
            else MessageBox.Show("Неверный логин или пароль", "Ошибка потверждения", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
