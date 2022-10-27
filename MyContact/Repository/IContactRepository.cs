using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContact.Repository
{
    internal interface IContactRepository
    {
        bool Insert(string name,string details);
    }
}
