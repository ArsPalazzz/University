using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_8
{
    public class SqlModel
    {
        public static DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("database");
            SqlConnection sqlConnection = new SqlConnection("Data Source=WIN-OLMAANRL9OB;Initial Catalog=University;Persist Security Info=True; ");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
