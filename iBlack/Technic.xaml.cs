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
    /// Логика взаимодействия для Technic.xaml
    /// </summary>
    public partial class Technic : Window
    {

        public ObservableCollection<Computer> Computers = null;

        public Technic(string User,string Role)
        {
            InitializeComponent();
            Computers = Repository.DB.GetComputers();
            Welcome.Text = User;
            ComputersGrid.ItemsSource = Computers;
            Repository.TableCompters = Computers;
            StackPanel stackPanel = new StackPanel();
            for (int i = 0; i < 3; i++)
            {
                StackPanel stackPanel2 = new StackPanel();
                stackPanel2.Orientation = Orientation.Horizontal;
                TextBlock authorLabel = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 25,
                    Foreground = Brushes.Black,
                    FontWeight = FontWeights.ExtraBold,
                    Text = "Автор"
                };
                TextBlock authorName = new TextBlock
                {
                    Margin = new Thickness(10, 3, 10, 0),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.Black,
                    Name = "Author",
                    Text = "Андрей"
                };
                TextBlock themeLabel = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 25,
                    Foreground = Brushes.Black,
                    FontWeight = FontWeights.ExtraBold,
                    Text = "Тема отчёта"
                };
                TextBlock themeText = new TextBlock
                {
                    Margin = new Thickness(10, 3, 10, 0),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.Black,
                    Text = "АААА"
                };
                stackPanel2.Children.Add(authorLabel);
                stackPanel2.Children.Add(authorName);
                stackPanel2.Children.Add(themeLabel);
                stackPanel2.Children.Add(themeText);
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = stackPanel2;
                Lstbox.Items.Add(listBoxItem);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var TableData = new TableData();
            TableData.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Lstbox.SelectedItem == null)
                return;
           var Item = Lstbox.SelectedItem as ListBoxItem;
           var StackPanel = Item.Content as StackPanel;
            foreach (var item in StackPanel.Children)
            {
                if (item is TextBlock textBlock)
                {
                    if (textBlock.Name == "Author")
                    {
                        var Otchet = new Otchet(textBlock.Text);
                        Otchet.ShowDialog();
                        break;
                    }
                }
            }
        }
    }
}
