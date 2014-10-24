using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesLeadsManagementSystem.General;

namespace SalesLeadsManagementSystem.Sales.Comment
{
    class CommentDA:IDatabaseCommunication<CommentDA,int>
    {


        private static CommentDA instance = null;

        private CommentDA() { }

        public static CommentDA getInstance()
        {
            if(instance==null)
            {
                instance = new CommentDA();
            }
            return instance;
        }

        public bool addToDatabase(CommentDA newComment)
        {
            throw new NotImplementedException();
        }

        public bool updateToDatabase(CommentDA existingComment)
        {
            throw new NotImplementedException();
        }

        public CommentDA readFromDatabase(int CommentID)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataView readAllComments(int salesID)
        {
            return General.DBLink.executeTableQuarry("SELECT .....=" + salesID.ToString());
        }
    }
}
