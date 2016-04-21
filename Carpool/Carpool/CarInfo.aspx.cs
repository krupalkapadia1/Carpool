using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carpool
{
    public partial class CarInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarFacade facade = CarFacade.Instance();

            if (!IsPostBack)
            {                
                if (User.Identity.IsAuthenticated)
                {                                      
                    if(facade.UserCar((String)Session["username"]) != null)
                    {
                        ShowCarInfo.Visible = true;
                        ShowCarType.Text = string.Format(facade.UserCar((String)Session["username"]).Type);
                        ShowCapacity.Text = string.Format(facade.UserCar((String)Session["username"]).Capacity.ToString());
                        ShowLicense.Text = string.Format(facade.UserCar((String)Session["username"]).License);
                    }
                    else
                    {
                        EditCarInfo.Visible = true;
                    }                                                        

                }
                else
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
        }

        public void ConfirmRide(object sender, EventArgs e)
        {            
            // set car to the ride, add the new car into DB
            if (EditCarInfo.Visible)
            {
                CarFacade.Instance().AddCar(CarType.Text, Int32.Parse(Capacity.Text), LicenseNumber.Text);
            }
            else
            {
                CarFacade.Instance().AddCar();
            }
            
            // add the car into the ride object, store the ride into DB
            RideFacade.Instance().ConfirmRide();
            Response.Redirect("~/Confirm.aspx");
        }
    }
}