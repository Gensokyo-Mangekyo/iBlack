using iBlack.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;


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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Excel таблица (*.csv)|*.csv"; // Указание фильтра для типов файлов

            bool? result = saveFileDialog.ShowDialog(); // Открыть диалоговое окно

            if (result == true)
            {
                using (var StreamWriter = new StreamWriter(new FileStream(saveFileDialog.FileName, FileMode.Create), Encoding.UTF8))
                {
                    for (int i = 0; i < accounts.Count; i++)
                    {
                        var Builder = new StringBuilder();
                        Builder.Append(accounts[i].Name);
                        Builder.Append(";");
                        Builder.Append(accounts[i].Family);
                        Builder.Append(";");
                        Builder.Append(accounts[i].NamePost);
                        Builder.Append(";");
                        Builder.Append(accounts[i].ReceiptDate);
                        Builder.Append(";");
                        StreamWriter.WriteLine(Builder.ToString());
                    }
                }
            }

           

        }
    }
}
