using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System;

namespace Carpool
{
    internal class UpdateBooking : Page
    {
        private static UpdateBooking theInstance;

        protected UpdateBooking() { }

        public static UpdateBooking Instance()
        {
            if (theInstance == null)
            {
                theInstance = new UpdateBooking();
            }
            return theInstance;
        }

        public void Update(string ride_id, string currentBook)
        {
            int capacity = 0;         
            try
            {
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT capacity FROM car "
                            + "WHERE id=(SELECT car_id FROM user WHERE username="
                            + "(SELECT driver FROM ride where id=" + ride_id + ")"
                            + ")";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    using (OdbcDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                            capacity = Int32.Parse(dr[0].ToString());
                        dr.Close();
                    }

                    connection.Close();
                }

                int i = Int32.Parse(currentBook);
                if (Int32.Parse(currentBook) == capacity)
                {
                    using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                    {
                        connection.Open();
                        
                        string query = "UPDATE ride "
                            + "SET isFull=" + 1
                            + " WHERE id=" + ride_id;

                        using (OdbcCommand command = new OdbcCommand(query, connection))
                        using (OdbcDataReader dr = command.ExecuteReader())

                        connection.Close();
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("An error occured: " + ex.Message);
            }
        }
    }
}