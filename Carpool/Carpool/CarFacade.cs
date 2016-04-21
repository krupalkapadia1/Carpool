using System;
using System.Web;
using System.Web.UI;
using System.Data.Odbc;

namespace Carpool
{
    internal class CarFacade : Page
    {
        private static CarFacade theInstance;

        protected CarFacade() { }

        public static CarFacade Instance()
        {
            if (theInstance == null)
            {
                theInstance = new CarFacade();
            }
            return theInstance;
        }

        public Car UserCar(string username)
        {
            Car car = new Car();
            try
            {
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * from car "
                        + "WHERE id="
                        + "(SELECT car_id from user WHERE "
                        + "username='" + username + "')";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    using (OdbcDataReader dr = command.ExecuteReader())
                    {  
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                car.Type = dr["type"].ToString();                               
                                car.Capacity = Int32.Parse(dr["capacity"].ToString());
                                car.License = dr["license"].ToString();                                
                            }
                            dr.Close();
                            Session["car"] = car;
                        }
                        else
                        {
                            car = null;
                        }
                                                                      
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occured: " + ex.Message);
            }

            return car;
        }

        public void AddCar()
        {
            Ride ride = (Ride)Session["ride"];
            string username = (String)Session["username"];
            
            if ((Car)Session["car"] != null)
            {
                ride = (Ride)Session["ride"];
                ride.setCar((Car)Session["car"]);
            }
        }

        public void AddCar(string type, int capacity, string license)
        {
            Ride ride = (Ride)Session["ride"];
            string username = (String)Session["username"];
                        
            Car car = new Car(type, capacity, license);                
            try
            {
                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();
                    string carQuery = "INSERT INTO car "
                        + "(type, capacity, license) "
                        + "VALUES "
                        + "('" + type + "'," + capacity.ToString() + ",'" + license + "')";
                    using (OdbcCommand command = new OdbcCommand(carQuery, connection))
                    using (OdbcDataReader dr = command.ExecuteReader())                            

                    connection.Close();
                }                    

                using (OdbcConnection connection = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
                {
                    connection.Open();
                    string driverQuery = "UPDATE user "
                        + "SET car_id="
                        + "(SELECT id FROM car "
                        + "WHERE license='" + license + "') "
                        + "WHERE username='" + username + "'";
                    using (OdbcCommand command = new OdbcCommand(driverQuery, connection))
                    using (OdbcDataReader dr = command.ExecuteReader())

                        connection.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occured: " + ex.Message);
            }

            Session["car"] = car;
            ride.setCar(car);                                        
        }
    }
}