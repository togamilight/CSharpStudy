using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace ADO.Net练习 {
    class Program {
        static void Main(string[] args) {
            string connStr = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string commText = "insert into DateTable(Date) values (@Date)";
            SqlCommand comm = new SqlCommand(commText, conn);
            comm.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
