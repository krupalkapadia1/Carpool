using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Carpool.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Odbc;


namespace Carpool.Account
{
    public partial class Register : System.Web.UI.Page
    {
        
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var user = new IdentityUser(){
                UserName = UserName.Text,
                PhoneNumber = Phone.Text,
                Email = Email.Text
            };
            IdentityResult result = manager.Create(user, Password.Text);

            string fName = FirstName.Text;
            string lName = LastName.Text;
            string type = "";
            if (driver.Checked)
            {
                type = driver.Text;
            } else if (passenger.Checked)
            {
                type = passenger.Text;
            }
            // store username in MySQL db with their first name, last name and user type
            try
            {
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO user (username, firstname, lastname, type) "
                        + "values ('" + UserName.Text + "',"
                        + "'" + fName + "',"
                        + "'" + lName + "',"
                        + "'" + type + "')";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    using (OdbcDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                            Response.Write(dr["name"].ToString() + "<br />");
                        dr.Close();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occured: " + ex.Message);
            }
         

            if (result.Succeeded)
            {
                ErrorMessage.Text = string.Format("Registration succesful!");            
            }
            else
            {                
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }

            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            //var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            //    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else 
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}


        }
    }
}