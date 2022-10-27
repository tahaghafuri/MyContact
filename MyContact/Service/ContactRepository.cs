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
        private string connection = "Data Source=.;Initial Catalog=MyContact;Integrated Security=true";
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(string name, string details)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string query = "Select * From MyContact";
            SqlConnection conn = new SqlConnection(connection);
            SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
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
