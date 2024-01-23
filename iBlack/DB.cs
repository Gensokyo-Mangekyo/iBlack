using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
            Connection = new MySqlConnection(Connect);
            Connection.Open();
            Repository.DB = this;
        }

        public string CheckEmployee(string Login,string Password)
        {
               MySqlCommand  command = new MySqlCommand($"SELECT * FROM employee WHERE Login = '{Login}' AND Password = '{Password}'", Connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                if (reader.HasRows) 
                {
                    reader.Read();
                    return reader.GetValue(3) as string;
                }
                else return null;
    
                }
        }
    }
}
