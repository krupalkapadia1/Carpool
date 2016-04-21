using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carpool
{
    public partial class RideRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
     
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {                    
                    if (Session["usertype"]!=null)
                    {
                        if (Session["usertype"].Equals("passenger"))
                        {
                            ErrorMessage.Text = "Oooops, this page is for driver users only.";
                        }
                        else if (Session["usertype"].Equals("driver"))
                        {
                            AddRideForm.Visible = true;                                                        
                        }
                    }
                    else
                    {
                        ErrorMessage.Text = "Error occurred.";
                    }                    
                }
                else
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
            }            
        }

        
        public void AddRide(object sender, EventArgs e)
        {
            RideFacade.Instance().SaveRideInSession((String)Session["username"],
                StartingPoint.Text,
                Destination.Text,
                DepartingDate.Text,
                DepartingTime.Text);

            Response.Redirect("~/CarInfo.aspx");
        }
        
    }
}