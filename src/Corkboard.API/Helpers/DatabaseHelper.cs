using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Corkboard.API.Helpers
{
    public static class DatabaseHelper
    {
        private static string connectionString = "server=localhost;uid=gatech;database=cb_db;pwd=gatechpassword";
        private static MySqlConnection sqlConnection;

        public static MySqlConnection ConnectToDB()
        {
            if (sqlConnection == null)
            {
                try
                {
                    sqlConnection = new MySqlConnection(connectionString);
                    sqlConnection.Open();
                }
                catch (Exception e)
                {
                    throw new Exception("Could not connect to database.");
                }

            }

            return sqlConnection;
        }

        public static DataTable ExecuteQuery(string sqlQuery)
        {
            var connection = ConnectToDB();
            var command = new MySqlCommand(sqlQuery, connection);
            var dataAdapter = new MySqlDataAdapter(command);
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
            return dataTable.Rows[rowIndex].GetValueInRow(columnName);
        }

        /// <summary>
        /// Gets the value in a data table.
        /// </summary>
        /// <param name="dataRow">Data row to get the value from.</param>
        /// <param name="columnName">The name of the column to get the value in.</param>
        public static string GetValueInRow(this DataRow dataRow, string columnName)
        {
            var value = dataRow[columnName];
            if (dataRow == null)
            {
                return string.Empty;
            }

            return value.ToString();
        }

        /// <summary>
        /// Gets the value in all the rows of a data table.
        /// </summary>
        /// <param name="dataRow">Data row to get the values from.</param>
        /// <param name="columnName">The name of the column to get the value in.</param>
        public static List<string> GetValueInRows(this DataRowCollection rows, string columnName)
        {
            var values = new List<string>();
            foreach (DataRow row in rows)
            {
                values.Add(GetValueInRow(row, columnName));
            }

            return values;
        }
    }
}