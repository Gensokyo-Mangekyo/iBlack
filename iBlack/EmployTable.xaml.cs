using iBlack.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для EmployTable.xaml
    /// </summary>
    public partial class EmployTable : Window
    {

        public ObservableCollection<Account> accounts;

        public EmployTable()
        {
            InitializeComponent();
        }

        public EmployTable(ObservableCollection<Account> accounts)
        {
            InitializeComponent();
            this.accounts = accounts;
            AccountsGrid.ItemsSource = accounts;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Collection = AccountsGrid.SelectedItems;
            List<int> indexes = new List<int>();
            foreach (var cellInfo in AccountsGrid.SelectedItems)
            {
                if (cellInfo is Account account)
                {
                    indexes.Add(account.Id);
                }
            }
            foreach (var id in indexes)
            {
                accounts.Remove(accounts.First(x => x.Id == id));
            }
        }
    }
}
