using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesLeadsManagementSystem.Administration.Customer
{
    class CustomerHandler
    {
        private frmCustomer viewCustomer;
        private Customer modelCustomer;

        public CustomerHandler(frmCustomer view,Customer model)
        {
            this.viewCustomer = view;
            this.viewCustomer.CustomerHandler = this;
            this.modelCustomer = model;
        }


        private void refreshModel()
        {
            //Prefomance update.must impliment all admin use cases
        }

        public void newCustomer()
        {
            modelCustomer.Name = viewCustomer.CustomerName.Text;
            modelCustomer.ShortName = viewCustomer.CustomerShortName.Text;
            modelCustomer.Address = viewCustomer.CustomerAddress.Text;
            modelCustomer.Email = viewCustomer.CustomerEmail.Text;
            modelCustomer.PhoneNo = viewCustomer.CustomerPhone.Text;
            modelCustomer.AccountManager = viewCustomer.CustomerAccManager.Text;
            modelCustomer.create();
        }

        public void updateCustomer()
        {
            modelCustomer.CustomerID = viewCustomer.SelectedCustomerID;
            modelCustomer.Name = viewCustomer.CustomerName.Text;
            modelCustomer.ShortName = viewCustomer.CustomerShortName.Text;
            modelCustomer.Address = viewCustomer.CustomerAddress.Text;
            modelCustomer.Email = viewCustomer.CustomerEmail.Text;
            modelCustomer.PhoneNo = viewCustomer.CustomerPhone.Text;
            modelCustomer.AccountManager = viewCustomer.CustomerAccManager.Text;
            modelCustomer.update();
        }

        public void viewCustomerData(int customerID)
        {
            modelCustomer = CustomerDA.getInstance().readFromDatabase(customerID);

            if (modelCustomer != null)
            {
                viewCustomer.CustomerName.Text = modelCustomer.Name;
                viewCustomer.CustomerShortName.Text = modelCustomer.ShortName;
                viewCustomer.CustomerAddress.Text = modelCustomer.Address;
                viewCustomer.CustomerEmail.Text = modelCustomer.Email;
                viewCustomer.CustomerPhone.Text = modelCustomer.PhoneNo;
                viewCustomer.CustomerAccManager.Text = modelCustomer.AccountManager;
            }
            else
            {
                //MessageBox.Show("No Customer with ID " + this.selectedCustomerID);
                //this.Close();
            }
        }

        public System.Data.DataView getAllCustomers()
        {
            return General.DBLink.executeTableQuarry("SELECT * FROM `salesleads`.`customer`;");
        }
    }
}
