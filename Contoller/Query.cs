using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace LakesApp.Controller
{
    class Query
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public Query(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();
        }

        public DataTable UpdateLakes()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Lakes", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public int CountLakesByCondition()
        {
            try
            {
                connection.Open();
                command = new OleDbCommand("SELECT COUNT(*) FROM Lakes WHERE Материк = 'Африка' OR Площадь > 8", connection);
                int count = (int)command.ExecuteScalar();
                connection.Close();
                return count;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Ошибка в запросе: " + ex.Message);
                connection.Close();
                return 0;
            }
        }
    }
}