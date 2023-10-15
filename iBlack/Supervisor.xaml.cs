using iBlack.Classes;
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
    /// Логика взаимодействия для Supervisor.xaml
    /// </summary>
    public partial class Supervisor : Window
    {

      public  List<Account> accounts = new List<Account>
{
    new Account(1,"Андрей","Мирошниченко",Enums.Post.Engineer, DateTime.Parse("1 августа 2023г")),
    new Account(2,"Михаил","Усиков",Enums.Post.Supervisor,DateTime.Parse("6 июля 2023г")) ,
    new Account(2,"Максим","Кружевников",Enums.Post.Supervisor,DateTime.Parse("1 августа 2023г")) ,
    new Account(4,"5","6",Enums.Post.Technic,DateTime.Now),
    new Account(5,"5","6",Enums.Post.Technic,DateTime.Now),
    new Account(6,"5","6",Enums.Post.Technic,DateTime.Now),
     new Account(7,"5","6",Enums.Post.Technic,DateTime.Now),
       new Account(8,"5","6",Enums.Post.Technic,DateTime.Now),
        new Account(9,"5","6",Enums.Post.Technic,DateTime.Now),
          new Account(10,"5","6",Enums.Post.Technic,DateTime.Now),
            new Account(11,"5","6",Enums.Post.Technic,DateTime.Now),
                   new Account(12,"5","6",Enums.Post.Technic,DateTime.Now),
                      new Account(13,"5","6",Enums.Post.Technic,DateTime.Now),
                       new Account(13,"8","6",Enums.Post.Technic,DateTime.Now),
};



        public Supervisor()
        {
            InitializeComponent();
            AccountsGrid.ItemsSource = accounts;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name.Text == "Поиск по имени")
                name.Text = "";
        }

        private void family_GotFocus(object sender, RoutedEventArgs e)
        {
            if (family.Text == "Поиск по фамилии")
                family.Text = "";
        }

        private void Date_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Date.Text == "Поиск по дате")
                Date.Text = "";
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
    }
}
