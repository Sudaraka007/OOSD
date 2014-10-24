using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesLeadsManagementSystem.General;
namespace SalesLeadsManagementSystem.Sales.Quotation
{
    class QuotationDA:IDatabaseCommunication<Quotation,int>
    {
         private static QuotationDA instance = null;

        private QuotationDA() { }

        public static QuotationDA getInstance()
        {
            if(instance==null)
            {
                instance = new QuotationDA();
            }
            return instance;
        }

        public bool addToDatabase(Quotation newQuotation)
        {
            throw new NotImplementedException();
        }

        public bool updateToDatabase(Quotation existingQuotation)
        {
            throw new NotImplementedException();
        }



        public Quotation readFromDatabase(int QuotationID)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataView readAllQuotations(int salesID)
        {
            return General.DBLink.executeTableQuarry("SELECT `QuatationID`,`SalesLeadsID`,`QuatationDate`,`QuotationStatus` FROM `quatation` WHERE `SalesLeadsID`=" + salesID.ToString());
        }
    }
}
