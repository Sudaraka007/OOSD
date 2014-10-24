using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesLeadsManagementSystem.Administration.Customer
{

    class Customer
    {
        private int customerID = 0;
        private string name = "";
        private string shortName = "";
        private string address = "";
        private string email = "";
        private string phoneNo = "";
        private string accountManager = "";
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }     
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
        public string AccountManager
        {
            get { return accountManager; }
            set { accountManager = value; }
        }
        
       
        

        public bool create()
        {
           return CustomerDA.getInstance().addToDatabase(this);
        }


        public bool update()
        {
            return CustomerDA.getInstance().updateToDatabase(this);
        }

        
    }
}
