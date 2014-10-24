using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesLeadsManagementSystem.Sales
{
    public partial class frmSelectProduct : Form
    {
        private frmAddUpdateSalesLead baseSalesLeadForm;

        public frmAddUpdateSalesLead BaseSalesLeadForm
        {
            get { return baseSalesLeadForm; }
            set { baseSalesLeadForm = value; }
        }

        public frmSelectProduct()
        {
            InitializeComponent();
            cmbProSearch.SelectedIndex = 0;
            updatecontrols();
        }

        private void updatecontrols()
        {
            System.Console.Write(cmbProSearch.Text);
            dataGridViewselectpro.DataSource = General.DBLink.executeTableQuarry("SELECT * FROM `salesleads`.`product` WHERE `salesleads`.`product`.`" +getColumnName_Product(cmbProSearch.SelectedIndex)+ "` LIKE '%" + txtSerchProduct.Text + "%';");
        }

        private void txtSerchProduct_TextChanged(object sender, EventArgs e)
        {
            updatecontrols();
        }

        private void cmbProSearch_TextChanged(object sender, EventArgs e)
        {
            updatecontrols();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectProduct_Click(object sender, EventArgs e)
        {
            baseSalesLeadForm.updateProductID((int)dataGridViewselectpro.SelectedRows[0].Cells[0].Value);
            this.Hide();
        }


        private string getColumnName_Product(int index)
        {
            
            switch (index)
            {
                case 0:
                    return "ProductName";
                case 1:
                    return "Category";
                case 2:
                    return "InitialPrice";
                case 3:
                    return "ProductDetails";
                default:
                    return null;
            }

        }
    }
}
