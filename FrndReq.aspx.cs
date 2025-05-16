using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class FrndReq : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Session["fl"] as String))
            {

            }
            else
            {
                if (Session["fl"].ToString().Equals("1"))
                {
                    bd.BackColor = System.Drawing.Color.Black;
                }
            }

            try
            {
                string s = Session["Fid"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.open('signin.aspx')");
            }

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            //Session["Fid"] = "202404221";
            Page.MaintainScrollPositionOnPostBack = true;

            ds.SelectCommand = "listFromfriendRequest " + Session["Fid"].ToString();
        }
        protected void acceptrequest(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            sqlConnection.Open();
            sqlCommand = new SqlCommand("insert into FriendList values ('" + Session["Fid"].ToString() + "','" + btn.CssClass.ToString() + "')", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlCommand = new SqlCommand("delete from FriendRequest where RFid='" + Session["Fid"].ToString() + "' and Fid='" + btn.CssClass.ToString() + "'", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Response.Redirect("FrndReq.aspx");
        }
        protected void rejectrequest(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            sqlConnection.Open();
            sqlCommand = new SqlCommand("delete from FriendRequest where RFid='" + Session["Fid"].ToString() + "' and Fid='" + btn.CssClass.ToString() + "'", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            //Page_Load(sender, e);
            sqlConnection.Close();
            Response.Redirect("FrndReq.aspx");
        }
        protected void tm1_Tick(object sender, EventArgs e)
        {
            //this.RaisePostBackEvent(tm1, "");
            dl.DataBind();
        }
        protected void viewProfile(object sender, EventArgs e) {
            Session["VFid"] = ((Button)sender).CssClass;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Open", "window.open('addFriend.aspx');", true);
        }
    }
}











//requestPanel.Controls.Add(img);
//requestPanel.Controls.Add(lbl1);
//requestPanel.Controls.Add(lbl2);
//requestPanel.Controls.Add(new LiteralControl("<br/>"));
//requestPanel.Controls.Add(btn1);
//requestPanel.Controls.Add(btn2);
