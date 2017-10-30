using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace 连接MySQL {
    class Program {
        static void Main(string[] args) {
            string mySql_conn_str = "server=localhost;port=3306;uid=root;password=root;database=test";
            MySqlConnection conn = new MySqlConnection(mySql_conn_str);
            conn.Open();

            //MySqlDataAdapter adp = new MySqlDataAdapter("select * from music", conn);
            //DataSet ds = new DataSet();
            //adp.Fill(ds, "music");

            //MySqlCommand command = conn.CreateCommand();
            //command.CommandText = "select * from music";
            MySqlCommand command = new MySqlCommand("select * from music", conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                if (reader.HasRows) {
                    Console.WriteLine("music_id:" + reader.GetString("music_id") + " musicName:" + reader.GetString("musicName"));
                }
            }
            reader.Close();
            conn.Close();
            Console.ReadKey();
        }
    }
}
