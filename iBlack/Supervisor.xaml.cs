using iBlack.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Supervisor.xaml
    /// </summary>
    public partial class Supervisor : Window
    {
      public  ObservableCollection<Account> accounts = new ObservableCollection<Account>
{
    new Account(1,"Егор","Дуранов",Enums.Post.Engineer, DateTime.Parse("1 августа 2023г")),
    new Account(2,"Михаил","Усиков",Enums.Post.Supervisor,DateTime.Parse("6 июля 2021г")) ,
    new Account(3,"Максим","Кружевников",Enums.Post.Technic,DateTime.Parse("5 августа 2022г")) ,
};
        private ObservableCollection<Account> EmployesTable = new ObservableCollection<Account>();



        public Supervisor()
        {
            InitializeComponent();
            AccountsGrid.ItemsSource = accounts;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        List<string> StandartText = new List<string>()
        {
            "Поиск по имени",
            "Поиск по фамилии",
            "Поиск по дате",
            "Имя",
            "Фамилия",
            "Дата поступления",
            "Логин",
        };
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (StandartText.Contains(textBox.Text))
                textBox.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var FilterSearch = new List<Func<Account, bool>>();


            DateTime dateTime = new DateTime();

                if (name.Text != "Поиск по имени")
                FilterSearch.Add(x => x.Name.StartsWith(name.Text));
                if (family.Text != "Поиск по фамилии")
                FilterSearch.Add(x => x.Family.StartsWith(family.Text));
            if (post.SelectedIndex > -1)
                FilterSearch.Add(x => x.NamePost == (string)((ComboBoxItem)post.SelectedItem).Content);
            if (Date.Text != "Поиск по дате")
                    if (DateTime.TryParse(Date.Text, out dateTime))
                    FilterSearch.Add(x => DateTime.Parse(x.ReceiptDate) == DateTime.Parse(Date.Text));
            List<Account> SearchedAccounts = new List<Account>();
            foreach (var item in accounts)
            {
                
                if (FilterSearch.All(x => x.Invoke(item))) {
                    SearchedAccounts.Add(item);
                }
            }
            AccountsGrid.ItemsSource = SearchedAccounts;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            name.Text = "Поиск по имени";
            family.Text = "Поиск по фамилии";
            post.Text = "";
            Date.Text = "Поиск по дате";
            AccountsGrid.ItemsSource = accounts;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string[] Fields = new string[6]
            {
                AddName.Text,
                AddFamiliy.Text,
                AddPost.Text,
                AddDate.Text,
                Login.Text,
                Password.Password,
            };
            foreach (var item in Fields)
            {
                if (string.IsNullOrWhiteSpace(item) || item == "")
                {
                    MessageBox.Show("Одно из полей является пустым", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            if (AddPost.Text == "Руководитель")
            {
                var Password = new Password("Supervisor", "qwerty");
                bool? Result = Password.ShowDialog();
                if (!Result.GetValueOrDefault())
                    return;
            }
            DateTime date = new DateTime();
            if (!DateTime.TryParse(AddDate.Text,out date))
            {
                MessageBox.Show("Неверный формат даты", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (accounts.Any(x => x.Login == Login.Text))
            {
                MessageBox.Show("Такой логин уже существует", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            accounts.Add(new Account(99,AddName.Text,AddFamiliy.Text,AddPost.Text,date));
            MessageBox.Show("Новый сотрудник успешно добавлен", "Успешно");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int index =  AccountsGrid.SelectedIndex;
            if (accounts[index].NamePost == "Руководитель")
            {
                var Password = new Password(accounts[index].Login, accounts[index].Password);
               bool? Result = Password.ShowDialog();
                if (Result.GetValueOrDefault())
                        accounts.Remove(accounts[index]);
            }
            else accounts.Remove(accounts[index]);

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            foreach (var cellInfo in AccountsGrid.SelectedItems)
            {
                if (cellInfo is Account account)
                {
                    EmployesTable.Add(account);
                }
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var Form = new EmployTable(EmployesTable);
            Form.ShowDialog();
        }
    }
}
