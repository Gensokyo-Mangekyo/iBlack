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
using iBlack.Classes;

namespace iBlack
{
    /// <summary>
    /// Логика взаимодействия для TableData.xaml
    /// </summary>
    public partial class TableData : Window
    {
        public TableData()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Repository.DB.AddComputer(new Computer(null, Name.Text, new Motherboard(Motherboard.Text), new Videocard { Model = Videocard.Text }, new HardDisk { Model = Disk.Text },
            new UnitPower { Model = Power.Text }, new RAM { Model = RAM.Text}, new Processor { Model = Processor.Text }, new Cabinet { Name = Cabinet.Text }));
            Repository.TableCompters = Repository.DB.GetComputers();
            Close();
        }
    }
}
