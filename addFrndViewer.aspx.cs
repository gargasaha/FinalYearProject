using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class addFrndViewer : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        SqlDataReader sqlDataReader;
        SqlCommand sqlCommand;
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);

            Page.MaintainScrollPositionOnPostBack = true;
            
            ds.SelectCommand = "listFromAddFriend " + Session["Fid"].ToString();
        }
        protected void vw(object sender, EventArgs e)
        {
            Response.Write("<script>alert('hii')</script>");
        }
        protected void cr(object sender, EventArgs e)
        {

            sqlConnection.Open();
            string Fid = Session["Fid"].ToString();

            sqlCommand = new SqlCommand("insert into FriendRequest values('" + Fid.ToString() + "','" + ((Button)sender).CssClass + "')", sqlConnection);
            sqlCommand.ExecuteNonQuery();

            Session["RFid"] = null;
            sqlConnection.Close();
            Response.Redirect("addFrndViewer.aspx");
            sqlConnection.Close();
        }


        protected void tm1_Tick(object sender, EventArgs e)
        {
            //this.RaisePostBackEvent(tm1, "");
            dl.DataBind();
        }

        
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('hii')</script>");
            Session["VFid"] = ((Button)sender).CssClass;
        }
    }
}