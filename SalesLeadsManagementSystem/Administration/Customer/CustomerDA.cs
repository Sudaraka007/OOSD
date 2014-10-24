using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesLeadsManagementSystem.General;
using MySql.Data.MySqlClient;
namespace SalesLeadsManagementSystem.Administration.Customer
{
    class CustomerDA:IDatabaseCommunication<Customer,int>
    {
        private static CustomerDA instance = null;

        private CustomerDA() { }

        public static CustomerDA getInstance()
        {
            if(instance==null)
            {
                instance = new CustomerDA();
            }
            return instance;
        }

        public bool addToDatabase(Customer newCustomer)
        {
            string sqlAddCustomer = "INSERT INTO `salesleads`.`customer` (`CustomerID`, `Name`, `ShortName`, `Address`, `Email`, `PhoneNo`, `AccManager`) VALUES (NULL, '" + newCustomer.Name + "', '" + newCustomer.ShortName + "', '" + newCustomer.Address + "', '" + newCustomer.Email + "', '" + newCustomer.PhoneNo + "', '" + newCustomer.AccountManager + "');";
            DBLink.openConnection();
            bool result = DBLink.executeWriteQuarry(sqlAddCustomer);
            DBLink.closeConnection();
            return result;
        }


        public bool updateToDatabase(Customer existingCustomer)
        {
            string sqlUpdateCustomer = "UPDATE `salesleads`.`customer` SET `Name` = '" + existingCustomer.Name + "', `ShortName` = '" + existingCustomer.ShortName + "', `Address` = '" + existingCustomer.Address + "', `Email` = '" + existingCustomer.Email + "', `PhoneNo` = '" + existingCustomer.PhoneNo + "', `AccManager` = '" + existingCustomer.AccountManager + "' WHERE `customer`.`CustomerID` = " + existingCustomer.CustomerID + ";";
            DBLink.openConnection();
            bool result = DBLink.executeWriteQuarry(sqlUpdateCustomer);
            DBLink.closeConnection();
            return result;
        }

        public  Customer readFromDatabase(int customerID)
        {
            DBLink.openConnection();

            string sqlUser = "SELECT * FROM `salesleads`.`customer` WHERE `CustomerID`='" + customerID + "';";

            MySqlDataReader customerData = DBLink.executeReadQuarry(sqlUser);


            if (customerData.Read())
            {
                Customer existingCustomer = new Customer();
                existingCustomer.CustomerID = customerData.GetInt32(0);
                existingCustomer.Name = customerData.GetString(1);
                existingCustomer.ShortName = customerData.GetString(2);
                existingCustomer.Address = customerData.GetString(3);
                existingCustomer.Email = customerData.GetString(4);
                existingCustomer.PhoneNo = customerData.GetString(5);
                existingCustomer.AccountManager = customerData.GetString(6);

                return existingCustomer;
            }

            return null;
        }




        
    }
}
