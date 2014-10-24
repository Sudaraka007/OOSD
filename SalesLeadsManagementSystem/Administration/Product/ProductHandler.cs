using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesLeadsManagementSystem.Administration.Product
{
    class ProductHandler
    {

        private frmProduct viewProduct;
        private Product modelProduct;

        public ProductHandler(frmProduct view,Product model)
        {
            this.viewProduct = view;
            this.viewProduct.ProductHandler = this;
            this.modelProduct = model;
        }


        public void newProduct()
        {  
            modelProduct.ProductName = viewProduct.ProductSalesName.Text;
            modelProduct.ProductCategory = viewProduct.ProductCategory.Text;
            modelProduct.InitialPrice = Decimal.Parse(viewProduct.InitialPrice.Text);
            modelProduct.ProductDetails = viewProduct.ProductDetails.Text;
            modelProduct.create();
        }

        public void updateProduct()
        {
            
            modelProduct.ProductID = viewProduct.SelectedProductID;
            modelProduct.ProductName = viewProduct.ProductSalesName.Text;
            modelProduct.ProductCategory = viewProduct.ProductCategory.Text;
            modelProduct.InitialPrice = Decimal.Parse(viewProduct.InitialPrice.Text);
            modelProduct.ProductDetails = viewProduct.ProductDetails.Text;
            modelProduct.update();
        }

        public void viewProductData(int productID)
        {
            modelProduct = ProductDA.getInstance().readFromDatabase(productID);

            if (modelProduct != null)
            {
                viewProduct.ProductSalesName.Text = modelProduct.ProductName;
                viewProduct.ProductCategory.Text = modelProduct.ProductCategory;
                viewProduct.InitialPrice.Text = modelProduct.InitialPrice.ToString();
                viewProduct.ProductDetails.Text = modelProduct.ProductDetails;
                
            }
            else
            {
                //MessageBox.Show("No Product with ID " + this.selectedProductID);
                //this.Close();
            }
        }

        public System.Data.DataView getAllProducts()
        {
            return General.DBLink.executeTableQuarry("SELECT * FROM `salesleads`.`product`;");
        }
    }
}
