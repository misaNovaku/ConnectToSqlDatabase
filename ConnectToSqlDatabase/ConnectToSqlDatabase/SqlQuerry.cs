using System;
using System.Data;
using System.Data.SqlClient;

namespace ConnectToSqlDatabase
{
    internal class SqlQuerry
    {
        private SqlCommand _command;
        private SqlConnection _connect;
        private SqlDataAdapter _adapt;
        private DataTable _table;

        public void ConnectDb()
        {
            const string  connctString = "Data Source=PROG_LOG-PC;Initial Catalog=slovnicek;Integrated Security=True";
            using ( _connect = new SqlConnection(connctString))
            {
                _connect.Open();

                _command = new SqlCommand("SELECT * FROM Category");
                _command.Connection = _connect;

                _adapt = new SqlDataAdapter(_command);
                _table = new DataTable();
                _adapt.Fill(_table);

                var row = _table.Rows[0]["Title"];
          
                Console.WriteLine(row.ToString());
               
            }
        }
    }
}