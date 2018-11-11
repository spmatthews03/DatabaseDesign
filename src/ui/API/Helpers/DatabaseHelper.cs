using System;

using System.Data.SqlClient;
using System.Data;

namespace API.Helpers
{
    public static class DatabaseHelper
    {
        private static string connectionString =  "";
        private static SqlConnection sqlConnection;

        public static SqlConnection ConnectToDB()
        {
            if(sqlConnection == null)
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
            }

            return sqlConnection;
        }

        public static DataTable ExecuteQuery(string sqlQuery)
        {
            var connection = ConnectToDB();
            var command = new SqlCommand(sqlQuery, connection);
            var dataAdapter = new SqlDataAdapter(command);
            var resultDataSet = new DataTable();
            dataAdapter.Fill(resultDataSet);
            return resultDataSet;
        }

        /// <summary>
        /// Gets the value in a data table.
        /// </summary>
        /// <param name="dataTable">Data table to get the value from.</param>
        /// <param name="rowIndex">The row to get the value in.</param>
        /// <param name="columnName">The name of the column to get the value in.</param>
        /// <returns></returns>
        public static string GetValueInTable(this DataTable dataTable, string columnName, int rowIndex = 0)
        {
            return dataTable.Rows[rowIndex][columnName].ToString();
        }
    }
}
