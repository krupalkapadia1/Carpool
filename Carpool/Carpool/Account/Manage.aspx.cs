using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using Carpool.Models;
using System.Data.Odbc;
using System.Data;

namespace Carpool.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                           
                if (User.Identity.IsAuthenticated)
                {
                    StatusText.Text = string.Format("Hello {0}!!", User.Identity.GetUserName());                    
                }
                else
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
            LoadList((String)Session["loginuser"]);
        }

        private void LoadList(string username)
        {
            if (Session["usertype"].Equals("driver"))
            {
                ListForDriver(username);
            }
            else
            {
                ListForPassenger(username);
            }
            
        }

        private void ListForDriver(string username)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * from ride "
                        + "WHERE driver='" + username + "'";

                    OdbcDataAdapter ada = new OdbcDataAdapter(query, connection);
                    try
                    {
                        BookingListDriver.Visible = true;
                        DataTable dt = new DataTable();
                        ada.Fill(dt);
                        BookingListDriver.DataSource = dt;
                        BookingListDriver.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("An error occured: " + ex.Message);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occured: " + ex.Message);
            }
        }

        private void ListForPassenger(string username)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * from ride "
                        + "WHERE id IN"
                        + "(SELECT r_id FROM booking WHERE username='" + username + "')";
                
                    OdbcDataAdapter ada = new OdbcDataAdapter(query, connection);
                    try
                    {
                        BookingListPassenger.Visible = true;
                        DataTable dt = new DataTable();
                        ada.Fill(dt);
                        BookingListPassenger.DataSource = dt;
                        BookingListPassenger.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("An error occured: " + ex.Message);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occured: " + ex.Message);
            }
        }

        
    }
}