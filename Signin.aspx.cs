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
    public partial class Signin : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader reader;
        
        protected void Page_Load(object sender, EventArgs e){

        }
        protected void conSubmit(object sender, EventArgs e)
        {
            Response.Write("hello");
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select Fid,Upassword from FriendInfo where UserId = '" + txt1.Text + "'", sqlConnection);
            string PassDb = string.Empty;
            string Fid=string.Empty;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PassDb = reader[1].ToString();
                Fid = reader[0].ToString();
            }


            reader.Close();

            if (PassDb == txt2.Text)
            {
                sqlCommand = new SqlCommand("update LiveUser set LiveInfo='1' where Fid='" + Fid.ToString() + "'", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                Session["Fid"] = Fid;
                Session["CFid"]=string.Empty;
                Session["email"]= txt1.Text;    
                Response.Redirect("ChatPage.aspx");
            }
            else
            {
                lbl4.Text = "Ivalid UserId ,Password";
            }

        }
    }

}