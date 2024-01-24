using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using iBlack.Classes;
using System.Collections.ObjectModel;

namespace iBlack
{
    public class DB
    {
       public MySqlConnection Connection { get; private set; }

        public DB()
        {
            string host = "localhost"; // Имя хоста
            string database = "iblack"; // Имя базы данных
            string user = "root"; // Имя пользователя
            string Connect = "Database=" + database + ";Datasource=" + host + ";User=" + user;
            try
            {
                Connection = new MySqlConnection(Connect);
                Connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Возникла ошибка с соединением БД","Ошибка базы данных",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            Repository.DB = this;
        }

        public string CheckEmployee(string Login,string Password)
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                MessageBox.Show("Отстуствует подключение к БД", "Ошибка базы данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
               MySqlCommand  command = new MySqlCommand($"SELECT * FROM employee WHERE Login = '{Login}' AND Password = '{Password}'", Connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                if (reader.HasRows) 
                {
                    reader.Read();
                    return reader.GetValue(0) as string + "." + reader.GetValue(1) as string + "." + reader.GetValue(2) as string + "." + reader.GetValue(3) as string;
                }
                else return null;
    
                }
        }

        public ObservableCollection<Computer> GetComputers()
        {
            var Computers = new ObservableCollection<Computer>();
            MySqlCommand command = new MySqlCommand("SELECT * FROM  data", Connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read()) {
                        var Computer = new Computer((int)reader.GetValue(0), (string)reader.GetValue(8), new Motherboard((string)reader.GetValue(1)), new Videocard { Model = (string)reader.GetValue(4) }, new HardDisk { Model = (string)reader.GetValue(5) },
                         new UnitPower { Model = (string)reader.GetValue(6) }, new RAM { Model = (string)reader.GetValue(3) }, new Processor { Model = (string)reader.GetValue(2) }, new Cabinet { Name = (string)reader.GetValue(7) });
                        Computers.Add(Computer);
                    }
                }
            }
                return Computers;
        } 
    }
}
