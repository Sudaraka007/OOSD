using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesLeadsManagementSystem.Administration.Product
{
    class Product
    {
        private int productID = 0;
        private string productName = "";
        private string productCategory = "";
        private decimal initialPrice = 0.0m;
        private string productDetails = "";

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }        
        public string ProductCategory
        {
            get { return productCategory; }
            set { productCategory = value; }
        }        
        public decimal InitialPrice
        {
            get { return initialPrice; }
            set { initialPrice = value; }
        }
        public string ProductDetails
        {
            get { return productDetails; }
            set { productDetails = value; }
        }

   

        public bool create()
        {
            return ProductDA.getInstance().addToDatabase(this);
        }

        public bool update()
        {
            return ProductDA.getInstance().updateToDatabase(this);
        }


        
    }
}
