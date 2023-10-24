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
        public ObservableCollection<Computer> Computers = new ObservableCollection<Computer>
{
        new Computer(1,"Кабинет 226 Усиков",new Motherboard() { Model="Мама" })
};

        public Technic()
        {
            InitializeComponent();
            ComputersGrid.ItemsSource = Computers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
