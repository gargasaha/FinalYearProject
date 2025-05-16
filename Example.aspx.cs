using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class Example : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ADDRESS"] = "malda";
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            txt.Text = Session["ADDRESS"].ToString();
        }
    }
}