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
    new Account(1,"1","2",Enums.Post.Engineer, DateTime.Now),
    new Account(2,"3","4",Enums.Post.Supervisor,DateTime.Now) ,
    new Account(3,"5","6",Enums.Post.Technic,DateTime.Now),
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

        }
    }
}
