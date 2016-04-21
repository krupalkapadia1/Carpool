using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Data.SqlClient;

namespace Carpool
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindListView();
            }
        }

        private void BindListView()
        {
            try
            {
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {                   
                    connection.Open();
                   
                    string query = "SELECT * from ride";

                    // testing
                    OdbcDataAdapter ada = new OdbcDataAdapter(query, connection);
                    try
                    {                        
                        DataTable dt = new DataTable();
                        ada.Fill(dt);
                        RideList.DataSource = dt;
                        RideList.DataBind();
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
        
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (RideList.FindControl("DataPager") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView();
        }

    }
}