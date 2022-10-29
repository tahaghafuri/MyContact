using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyContact
{
    class ContactRepository : IContactRepository
    {
        private string connection = "Data Source=PC\\SQLEXPRESS;Initial Catalog=MyContact;Integrated Security=SSPI";
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(string name, string details)
        {
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                string query = "Insert Into MyContact (Name,Details) Values (@name,@details)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@details", details);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable SelectAll()
        {
            string query = "Select * From MyContact";
            SqlConnection conn = new SqlConnection(connection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, string name, string details)
        {
            throw new NotImplementedException();
        }
    }
}
