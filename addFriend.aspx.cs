using FinalYearProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    

    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
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

            int i = 0;
            if (String.IsNullOrEmpty(Session["VFid"] as String))
            {

            }
            
            else
            {
                h1.Style["display"] = "block";
                h2.Style["display"] = "block";

                ds1.SelectCommand = "select Image,Fname,Lname,cDistName,cStateName,maritalStatus from friendInfo,state,dist where state.cStatecode=FriendInfo.sc and dist.cDistcode= FriendInfo.dc and fid='" + Session["VFid"].ToString() + "';";
                ds2.SelectCommand = "select *from Education where Fid='" + Session["VFid"].ToString() + "';";
                ds3.SelectCommand = "select *from Working where Fid='" + Session["VFid"].ToString() + "';";
                i++;
            }

            if (i == 1)
            {
                
            }
            else
            {
                try
                {

                    ds1.SelectCommand = "select Image,Fname,Lname,cDistName,cStateName,maritalStatus from friendInfo,state,dist where state.cStatecode=FriendInfo.sc and dist.cDistcode= FriendInfo.dc and fid='" + Request.QueryString["i"].ToString() + "';";
                    ds2.SelectCommand = "select *from Education where Fid='" + Request.QueryString["i"].ToString() + "';";
                    ds3.SelectCommand = "select *from Working where Fid='" + Request.QueryString["i"].ToString() + "';";
                    h1.Style["display"] = "block";
                    h2.Style["display"] = "block";
                    Session["VFid"] = Request.QueryString["i"].ToString();
                }
                catch
                {

                }
            }
            


            
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            //binddata();
        }
        //Session["Fid"] = "202404202";
        protected void gotocp(object sender, EventArgs e){
            Response.Redirect("ChatPage.aspx");
        }

        protected void tm1_Tick(object sender, EventArgs e)
        {
            ds1.SelectCommand = "select Image,Fname,Lname,cDistName,cStateName,maritalStatus from friendInfo,state,dist where state.cStatecode=FriendInfo.sc and dist.cDistcode= FriendInfo.dc and fid='" + Session["VFid"].ToString() + "';";
            dl1.DataBind();

            ds2.SelectCommand = "select *from Education where Fid='" + Session["VFid"].ToString() + "';";
            dl2.DataBind();

            ds3.SelectCommand = "select *from Working where Fid='" + Session["VFid"].ToString() + "';";
            dl3.DataBind();
        }
    }
}