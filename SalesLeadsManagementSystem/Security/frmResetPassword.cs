using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesLeadsManagementSystem.Security
{
    public partial class frmResetPassword : Form
    {
        private string answer;

        public string Answer
        {
            get { return answer; }
            
        }

        public frmResetPassword(string question)
        {
            InitializeComponent();
            this.lblQuestion.Text = question;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.answer = txtAnswer.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
