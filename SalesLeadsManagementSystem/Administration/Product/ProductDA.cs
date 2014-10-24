using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesLeadsManagementSystem.General;
using MySql.Data.MySqlClient;
namespace SalesLeadsManagementSystem.Administration.Product
{
    class ProductDA:IDatabaseCommunication<Product,int>
    {


        private static ProductDA instance = null;

        private ProductDA() { }

        public static ProductDA getInstance()
        {
            if(instance==null)
            {
                instance = new ProductDA();
            }
            return instance;
        }
        public bool addToDatabase(Product newProduct)
        {
            string sqlAddCustomer = "INSERT INTO `salesleads`.`product` (`ProductID`, `ProductName`, `Category`, `InitialPrice`, `ProductDetails`) VALUES (NULL, '" + newProduct.ProductName + "', '" + newProduct.ProductCategory + "', '" + newProduct.InitialPrice + "', '" + newProduct.ProductDetails + "');";
            DBLink.openConnection();
            bool result = DBLink.executeWriteQuarry(sqlAddCustomer);
            DBLink.closeConnection();
            return result;
        }

        public bool updateToDatabase(Product existingProduct)
        {
            string sqlUpdateCustomer = "UPDATE `salesleads`.`product` SET `ProductName` = '" + existingProduct.ProductName + "', `Category` = '" + existingProduct.ProductCategory + "', `InitialPrice` = '" + existingProduct.InitialPrice + "', `ProductDetails` = '" + existingProduct.ProductDetails + "' WHERE `product`.`ProductID` = " + existingProduct.ProductID + ";";
            DBLink.openConnection();
            bool result = DBLink.executeWriteQuarry(sqlUpdateCustomer);
            DBLink.closeConnection();
            return result;
        }


        public  Product readFromDatabase(int productID)
        {
            DBLink.openConnection();

            string sqlUser = "SELECT * FROM `salesleads`.`product` WHERE `ProductID` = " + productID + ";";

            MySqlDataReader productData = DBLink.executeReadQuarry(sqlUser);


            if (productData.Read())
            {
                Product existingProduct = new Product();
                existingProduct.ProductID = productData.GetInt32(0);
                existingProduct.ProductName = productData.GetString(1);
                existingProduct.ProductCategory = productData.GetString(2);
                existingProduct.InitialPrice = productData.GetDecimal(3);
                existingProduct.ProductDetails = productData.GetString(4);

                return existingProduct;
            }

            return null;
        }

        
    }
}
