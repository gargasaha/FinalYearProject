using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        static int f = 0;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Fid"] = "202406041";
          

            try
            {
                string s = Session["Fid"].ToString();
            }
            catch (Exception ex) {
                Response.Redirect("signin.aspx");
            }

                //lbl.Text = Request.QueryString["t1"];
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            onlineofflineiframe.Attributes["src"] = "OnlineOffline.aspx";
            chatiframe.Attributes["src"] = "chat.aspx";
            addfrnd_frndreq.Attributes["src"] = "FrndReq.aspx";
            sqlConnection.Close();
        }
        protected void sendmessage(object sender, EventArgs e)
        {
            sqlConnection.Open();
            sqlCommand = new SqlCommand("insertchat", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Mode", '0');
            sqlCommand.Parameters.AddWithValue("@Fid", Session["Fid"].ToString());
            sqlCommand.Parameters.AddWithValue("@CFid", Session["CFid"].ToString());
            sqlCommand.Parameters.AddWithValue("@msg", msglbl.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@Image",(byte)100);
            msglbl.Text = string.Empty;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        
        protected void sendImage(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Session["CFid"] as String))
            {
                return;
            }
            else
            {
                chatiframe.Visible = false;
                ss.Visible = false;
                popup.Visible = true;
            }

        }
        private byte[] ReadFileBytes(HttpPostedFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.InputStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
        protected void exitt(object sender, EventArgs e)
        {
            chatiframe.Visible = true;
            ss.Visible = true;
            popup.Visible = false;
        }
        protected void select(object sender, EventArgs e)
        {
            
            byte[] imageBytes = ReadFileBytes(fileUpload.PostedFile);
            if (!fileUpload.HasFile)
            {
                Response.Write("<script>alert('Select a image')</script>");
                return;
            }
            sqlConnection.Open();
            sqlCommand = new SqlCommand("insertchat", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Mode", '1');
            sqlCommand.Parameters.AddWithValue("@Fid", Session["Fid"].ToString());
            sqlCommand.Parameters.AddWithValue("@CFid", Session["CFid"].ToString());
            sqlCommand.Parameters.AddWithValue("@msg", Session["Fid"].ToString());
            sqlCommand.Parameters.AddWithValue("@Image", imageBytes);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();


            chatiframe.Visible = true;
            ss.Visible = true;
            popup.Visible = false;

        }
        /*~WebForm2()
        {
            Session["Fid"] = "";
            Session["CFid"] = "";
            Session["VFid"] = "";
            Session.Clear();
        }*/
    }
}