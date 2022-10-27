using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyContact.Repository
{
    internal interface IContactRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int id);
        bool Insert(string name, string details);
        bool Update(int id, string name, string details);
        bool Delete(int id);
    }
}
