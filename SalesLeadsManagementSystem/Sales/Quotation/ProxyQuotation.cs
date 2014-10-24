using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesLeadsManagementSystem.Sales.Quotation
{
    class ProxyQuotation:IQuotation
    {
        private Quotation quotation;

        public ProxyQuotation()
        {
                
        }

        //get quotation byte array (if exist just return other wise call qutation original methord getQutationData )
        public byte[] getQuotationData()
        {
            throw new NotImplementedException();
        }

        public bool create()
        {
            return quotation.create();
        }


        public bool update()
        {
            return quotation.update();
        }

        //pass parameters to the qutation and update this.quotation
        public void setQuotationData()
        {

        }
    }
}
