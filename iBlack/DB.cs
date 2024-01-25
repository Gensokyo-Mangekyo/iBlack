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

        public void AddComputer(Computer computer)
        {
            var Parameters = new MySqlParameter[8] {
          new MySqlParameter("@name", computer.Name),
            new MySqlParameter("@processor", computer.Processor),
            new MySqlParameter("@motherboard", computer.Motherboard),
             new MySqlParameter("@ram", computer.RAM),
             new MySqlParameter("@unit", computer.UnitPower),
              new MySqlParameter("@disk", computer.HardDisk),
              new MySqlParameter("@videocard", computer.Videocard),
              new MySqlParameter("@cabinet", computer.Cabinet)
            };

            MySqlCommand command = new MySqlCommand($"INSERT INTO `data`(`Motherboard`, `Processor`, `RAM`, `Videocard`, `Disk`, `PowerBlock`, `Cabinet`, `Name`) VALUES (@motherboard,@processor,@ram,@videocard,@disk,@unit,@cabinet,@name)", Connection);
            foreach (var item in Parameters)
            {
                command.Parameters.Add(item);
            }
            int number = command.ExecuteNonQuery();
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

        public List<Classes.Otchet> GetOtchets()
        {
            var Otchets = new List<Classes.Otchet>();
            MySqlCommand command = new MySqlCommand("SELECT * FROM  report", Connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string Name = (string)reader.GetValue(1);
                        string Description = (string)reader.GetValue(2);
                        string Author = "Неизвестный";
                        MySqlCommand command2 = new MySqlCommand($"SELECT * FROM employee WHERE id = {(int)reader.GetValue(3)}", Connection);
                        using (MySqlDataReader reader2 = command2.ExecuteReader())
                        {
                            if (reader2.HasRows)
                            {
                                reader2.Read();
                                Author = reader2.GetValue(1) + " " + reader2.GetValue(2);
                            }
                        }
                        Otchets.Add(new Classes.Otchet(Author,Description,Name));
                    }
                }
            }
                return Otchets;
        }

    }
}
