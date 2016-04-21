using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System;
using System.Threading;



namespace Carpool
{
    internal class RideFacade : Page
    {
        private static RideFacade theInstance;

        protected RideFacade() { }

        public static RideFacade Instance()
        {
            if (theInstance == null)
            {
                theInstance = new RideFacade();
            }
            return theInstance;
        }

        public void SaveRideInSession(string username, string start, string dest, string date, string time)
        {
            Ride ride = new Ride(username, start, dest, date, time);
            Session["Ride"] = ride;
        }

        public void ConfirmRide()
        {
            if(Session["Ride"]!=null)
            {
                Ride ride = (Ride)Session["Ride"];
               
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO ride (driver, startingpoint, destination, date, time) "
                        + "values ('" + ride.Driver + "',"
                        + "'" + ride.StartingPoint + "',"
                        + "'" + ride.Destination + "',"
                        + "'" + ride.Date + "',"
                        + "'" + ride.Time + "')";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    using (OdbcDataReader dr = command.ExecuteReader())

                    connection.Close();                        
                }                   
                
            }
            else
            {
                Response.Write("Your session seems to be expired. Please log in again.");            
            }
        }
    }
}