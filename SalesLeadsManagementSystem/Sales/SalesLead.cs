using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesLeadsManagementSystem.Administration.User;
using SalesLeadsManagementSystem.Administration.Customer;
using SalesLeadsManagementSystem.Administration.Product;
using System.Collections;


namespace SalesLeadsManagementSystem.Sales
{
    class SalesLead
    {

        private int salesID;
       
        private string revenueType;
        private decimal monthlyRevenue;
        private bool hadTest = false;
        private decimal projectRevenue;
        private decimal projectPaid;      
        private byte[] purchaseOrderData=null;       
        private string customerFeedBack;
        private decimal discount;
        private string notes;
        private List<Quotation.ProxyQuotation> quotations;
        private Activity[] salesActivities;
        private User accountManager;
        private Customer customer;
        private Product product;        

        #region SalesLeadProperties

        public int SalesID
        {
            get { return salesID; }
            set { salesID = value; }
        }
        
        internal User AccountManager
        {
            get { return accountManager; }
            set { accountManager = value; }
        }
        internal Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        internal Product Product
        {
            get { return product; }
            set { product = value; }
        }
        
        public string RevenueType
        {
            get { return revenueType; }
            set { revenueType = value; }
        }       
        public decimal MonthlyRevenue
        {
            get { return monthlyRevenue; }
            set { monthlyRevenue = value; }
        }
        public bool HadTest
        {
            get { return hadTest; }
            set { hadTest = value; }
        }       
        public decimal ProjectRevenue
        {
            get { return projectRevenue; }
            set { projectRevenue = value; }
        }      
        public decimal ProjectPaid
        {
            get { return projectPaid; }
            set { projectPaid = value; }
        }       
       
        public byte[] PurchaseOrderData
        {
            get { return purchaseOrderData; }
            set { purchaseOrderData = value; }
        }       
        
        public string CustomerFeedBack
        {
            get { return customerFeedBack; }
            set { customerFeedBack = value; }
        }       
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        

        #endregion

        public SalesLead(Customer customer,Product product,User accManager)
        {
            this.customer = customer;
            this.product = product;
            this.accountManager = accManager;
            salesActivities = new Activity[7];

            for (int i = 0; i < salesActivities.Length; i++)
            {
                salesActivities[i] = new Activity((ActivityType)i);
            }

            quotations=new List<Quotation.ProxyQuotation>();
            
        }

        public Activity getSalesActivity(ActivityType type)
        {
            int index =(int)type;
            return salesActivities[index];
        }

        public bool create()
        {
            return SalesLeadDA.getInstance().addToDatabase(this);
        }

        public bool update()
        {
            return SalesLeadDA.getInstance().updateToDatabase(this);
        }



        public string[] quotationIDToArray(int salesLeadsID)
        {
            return SalesLeadDA.getInstance().quotationIDToArray(salesLeadsID);
        }


        /// <summary>
        /// return all salesLeadsID's of a specific customer
        /// </summary>
        /// <param name="SalesLeadsID"></param>
        /// <returns></returns>
        public int[] returnSalesLeadsArrayForCustomer(int CustomerID)
        {
            return SalesLeadDA.getInstance().returnSalesLeadsArrayForCustomer(CustomerID);
        }
        /// <summary>
        /// has to return all salesLeadsID of a specific Product
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public int[] returnSalesLeadsIDArrayForProducts(int ProductID)
        {

            return SalesLeadDA.getInstance().returnSalesLeadsIDArrayForProducts(ProductID);
        }

        
    }
}
