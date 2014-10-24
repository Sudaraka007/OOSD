using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SalesLeadsManagementSystem.General;
using MySql.Data.MySqlClient;

namespace SalesLeadsManagementSystem.Security
{
    
    
    /// <summary>
    /// Class for check secure user login with mysql database
    /// </summary>
    class UserLogin
    {
        
        private string username = "";
        private string password = "";                       //User given encrypted password      
        private bool hasPasswordError = false;                      //Error indication
        private string errorMessege = "";
        private Secure userSensitiveData = null;

        //Constuctor
        public UserLogin(string username,string password)
        {
            this.username = username;
            this.password = Cryptography.Encrypt(password);
        }

        
        /// <summary>
        /// check availability of the user in database
        /// </summary>
        /// <returns>ture if user is available.</returns>
        private bool checkUser()
        {
            userSensitiveData = SecureDA.getInstance().readFromDatabase(this.username);


            if (!(userSensitiveData==null))
            {                
                return true;
            }

            return false;
        }

        /// <summary>
        /// check if the password is correct
        /// </summary>
        /// <returns>ture if password is match</returns>
        private bool checkPassword()
        {
            if (String.Compare(password, userSensitiveData.Password) == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Determine the login is acceptable
        /// </summary>
        /// 
        /// <remarks>
        /// Set the error flag and messege if login was faild.
        /// </remarks>
        ///
        /// <returns>True if user can login to the system.Otherwise false</returns>
        public bool Login()
        {
            
            if(this.checkUser())
            {
                if(this.checkPassword())
                {
                    hasPasswordError = false;
                    errorMessege = "";
                    return true;
                }
                else
                {
                    hasPasswordError = true;
                    errorMessege = "Password not matching for user: "+ username +"\r\nDo you want to recover your password?";
                    return false;
                }
            }
            else
            {
                hasPasswordError = false;
                errorMessege = "User not found.";
                return false;
            }
        }

        /// <summary>
        /// Check the error flag
        /// </summary>
        /// <returns>True if login has an error</returns>
        public bool hasLoginError()
        {
            return hasPasswordError;
        }
        /// <summary>
        /// Get the error details
        /// </summary>
        /// <returns>return the error details</returns>
        public string ErrorDetails()
        {
            return errorMessege;
        }

        public void resetPassword()
        {
            frmResetPassword recover = new frmResetPassword(userSensitiveData.Question);
            if(recover.ShowDialog()==System.Windows.Forms.DialogResult.OK )               
            {
                if (Cryptography.Encrypt(recover.Answer).Equals(userSensitiveData.Answer))
                {
                    userSensitiveData.Password = Cryptography.Encrypt("1234");
                    userSensitiveData.update();
                    System.Windows.Forms.MessageBox.Show("Your password is reset to 1234.\r\nUse 1234 to login and change your password.", "Password Recovery", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                    System.Windows.Forms.MessageBox.Show("Your answer is wrong.", "Password Recovery", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);

            }

        }

        

    }
}
