using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carpool
{
    public partial class ConfirmPassenger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {        
        }

        public void ToMyPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Manage.aspx");
        }



    }
}