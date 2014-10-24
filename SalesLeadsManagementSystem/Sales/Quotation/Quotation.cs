using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesLeadsManagementSystem.Sales.Quotation
{
    class Quotation:IQuotation
    {
        private int quotationID = 0;
        private int salesleadID = 0;
        private DateTime quotationDate;
        private string quotationStatus = "";
        private byte[] quotationData = null;


        public bool create()
        {
            return QuotationDA.getInstance().addToDatabase(this);
        }

        public bool update()
        {
            return QuotationDA.getInstance().updateToDatabase(this);
        }



        public byte[] getQuotationData()
        {
            throw new NotImplementedException();
        }
    }
}
