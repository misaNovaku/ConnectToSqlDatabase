using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectToSqlDatabase
{
    internal class ConnectOnlineShop
    {
        private SqlCommand _command;
        private SqlConnection _connect;
        private SqlDataAdapter _adapt;
        private DataTable _table;
        public void ConnectDatabase()
        {
            string connectString = "Data Source=PROG_LOG-PC;Initial Catalog=E_shop;Integrated Security=True";
            using (_connect = new SqlConnection(connectString))
            {
                _connect.Open();

                _command = new SqlCommand("SELECT jmeno  FROM zakaznici ");
                _command.Connection = _connect;

                _adapt = new SqlDataAdapter(_command);
                _table = new DataTable();
             

                _adapt.Fill(_table);
                foreach (var VARIABLE in _table.TableName)
                {
                    Console.WriteLine(VARIABLE);
                }

                var row = _table.Rows[0]["jmeno"];

                Console.WriteLine(row.ToString());

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConnectOnlineShop connectOnline = new ConnectOnlineShop();
            connectOnline.ConnectDatabase();
            SqlQuerry sql = new SqlQuerry();
            sql.ConnectDb();
        }
    }
}
