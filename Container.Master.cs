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
    public partial class Container : System.Web.UI.MasterPage
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        static bool flag=false;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                string s = Session["Fid"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("signin.aspx");
            }
            //Session["Fid"] = "202406021";
            //lbl.Text = Request.QueryString["t1"];
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            sqlCommand = new SqlCommand("select  Image from Friendinfo where Fid='" + Session["Fid"].ToString() + "'", sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                byte[] bytes = (byte[])sqlDataReader[0];
                string i = Convert.ToBase64String(bytes);
                usrimg.ImageUrl = "data:Image1/png;base64," + i;
            }
        }
        protected void gotoaf(object sender, EventArgs e)
        {

            Session["VFid"] = null;
            Response.Redirect("addFriend.aspx");
        }
        protected void gotoch(object sender, EventArgs e)
        {
            Session["VFid"] = null;
            Response.Redirect("ChatPage.aspx");
        }
        protected void showMenuBar(object sender, EventArgs e)
        {
            if (flag == false)
            {
                menubar.Visible = true;
                flag=true;
            }
            else
            {
                menubar.Visible = false;
                flag = false;
            }
            
        }
        protected void editProfile(object sender, EventArgs e)
        {
            
        }
        protected void logOut(object sender, EventArgs e) {
            sqlCommand = new SqlCommand("update Liveuser set LiveInfo='0' where Fid='" + Session["Fid"] + "';", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            Session["Fid"] = null;
            Session["VFid"] = null;
            Response.Redirect("signin.aspx");
        }
        protected void increaseDecrease(object sender, EventArgs e) {
            if (fl.Text.ToString().Equals("0"))
            {
                fl.Text = "1";
                lightDark.Visible=true;
            }
            else
            {
                fl.Text = "0";
                lightDark.Visible = false;
            }
        }
        protected void makeThemeLight(object sender, EventArgs e) {
            Session["fl"] = "0";
            lightDark.Visible = false;
        }
        protected void makeThemeDark(object sender, EventArgs e){
            Session["fl"] = "1";
            lightDark.Visible = false;
        }
        
    }
}