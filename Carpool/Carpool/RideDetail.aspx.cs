using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Data;


namespace Carpool
{
    public partial class RideDetail : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = this.Request.QueryString["id"];
            string username = this.Request.QueryString["username"];
            DisplayRideDetails(id);
            DisplayCarDetails(username);            
        }

        protected void DisplayRideDetails(string id)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT id, startingpoint, destination, date, time, driver, currentBook from ride where id=" + id;

                    // testing
                    OdbcDataAdapter ada = new OdbcDataAdapter(query, connection);
                    try
                    {
                        DataTable dt = new DataTable();
                        ada.Fill(dt);
                        RideDetailsView.DataSource = dt;
                        RideDetailsView.DataBind();
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
        
        protected void DisplayCarDetails(string username)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT type, capacity FROM car "
                        + "WHERE id="
                        + "(SELECT car_id FROM user WHERE username='" + username + "')";
                    
                    OdbcDataAdapter ada = new OdbcDataAdapter(query, connection);
                    try
                    {
                        DataTable dt = new DataTable();
                        ada.Fill(dt);
                        CarDetailsView.DataSource = dt;
                        CarDetailsView.DataBind();
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

        public void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        public void BookRide(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {                                             
                    if (Session["usertype"].Equals("driver"))
                    {
                        ErrorMessage.Text = "Oooops, this page is for passenger users only.";
                    }
                    else
                    {
                        SaveBooking(this.Request.QueryString["id"], (String)Session["loginUser"]);

                        IncrementCurrBooking(this.Request.QueryString["id"]);

                        Response.Redirect("~/ConfirmPassenger.aspx");
                    }
                    
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }                               
        }

        protected void IncrementCurrBooking(string id)
        {
            int current = 0;
            try
            {
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();                    
                    string query = "SELECT currentBook from ride "
                            + "WHERE id=" + id;                            
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    using (OdbcDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                            current = Int32.Parse(dr[0].ToString());
                        dr.Close();
                    }

                    connection.Close();
                }

                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();
                    //int r_id = Int32.Parse(rideId);
                    current++;
                    string query = "UPDATE ride "
                        + "SET currentBook=" + current
                        + " WHERE id=" + id;

                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    using (OdbcDataReader dr = command.ExecuteReader())

                    connection.Close();
                    UpdateBooking.Instance().Update(id, current.ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occured: " + ex.Message);
            }
        }

        protected void SaveBooking(string rideId, string passenger)
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();
                    //int r_id = Int32.Parse(rideId);
                    string query = "INSERT INTO booking (r_id, username) "
                        + "values (" + rideId + ","
                        + "'" + passenger + "')";
                        
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    using (OdbcDataReader dr = command.ExecuteReader())

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