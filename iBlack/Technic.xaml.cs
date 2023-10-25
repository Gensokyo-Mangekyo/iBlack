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
        new Computer(1,"Усиков",new Motherboard("MSI"),new Videocard { Model = "RTX" },new HardDisk { Model = "Samsung" },
            new UnitPower { Model="Мощный сочный" },new RAM { Model = "HyperX" },new Processor { Model = "Intel Core I5" }, new Cabinet { Name = "Учительский" })
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
