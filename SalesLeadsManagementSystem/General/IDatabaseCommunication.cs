using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesLeadsManagementSystem.General
{
    interface IDatabaseCommunication<T,KeyType>
    {
         bool addToDatabase(T newT);
         bool updateToDatabase(T existingT);
         T readFromDatabase(KeyType id);
    }
}
