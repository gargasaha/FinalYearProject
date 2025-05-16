using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        static int f = 0,i=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Fid = string.Empty;
            try
            {
                Fid = Session["Fid"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("SignIn.aspx");
            }

            if (f == 1)
            {
                pnl1.Visible = true;
            }
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            sqlCommand = new SqlCommand("select * from friendInfo where Fid='" + Session["Fid"].ToString() + "'", sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                byte[] bytes = (byte[])sqlDataReader["Image"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                profileImg.ImageUrl = "data:image/png;base64," + base64String;
            }
            sqlDataReader.Close();
            sqlCommand = new SqlCommand("select count(*) from working where fid='" + Session["Fid"].ToString() + "'", sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            int count = 0;
            if (sqlDataReader.Read())
            {
                count = Convert.ToInt32(sqlDataReader[0].ToString());
            }
            sqlDataReader.Close ();
            if (count == 0)
            {

            }
            else
            {
                sqlCommand = new SqlCommand("select *from working where fid='" + Session["Fid"] + "'" , sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read()) {
                    Panel p = new Panel();
                    p.Controls.Add(new TextBox()
                    {
                        Text = sqlDataReader[1].ToString(),
                        Width = 150,
                        Height = 25,
                        ID = sqlDataReader[2].ToString()
                    });
                    

                    Button btn2 = new Button();
                    btn2.Text = "Delete";
                   
                    btn2.CssClass = sqlDataReader[2].ToString();
                    btn2.Click += new EventHandler(deleteWork);
                    p.Controls.Add(btn2);
                    p.CssClass = sqlDataReader[2].ToString();
                    pnl2.Controls.Add(p);
                    pnl2.Controls.Add(new LiteralControl("<br>"));
                    pnl2.Controls.Add(new LiteralControl("<br>"));
                }
            }
        }
        
        protected void addWorkingField(object sender, EventArgs e) {
            if (f == 0)
            {
                pnl1.Visible = true;
                f = 1;
                wi.ImageUrl = "IMAGES/minus.png";
            }
            else if (f == 1) {
                pnl1.Visible = false;
                f = 0;
                wi.ImageUrl = "IMAGES/add.png";
            }
            else
            {
                Response.Write("<script>alert('Add Work on given field')</script>");
            }
            
        }
        
        protected void deleteWork(object sender, EventArgs e) {
            sqlCommand = new SqlCommand("delete from working where Wid='" + ((Button)sender).CssClass + "'", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            Response.Redirect("EditWorkingProfile.aspx");
        }
        protected void uploadimage(object sender, EventArgs e)
        {
            if (i == 0)
            {
                fi.Visible = true;

                uplBtn.Text = "Upload";
                i = 1;
            }
            else
            {
                if (!fi.HasFile)
                {
                    Response.Write("<script>alert('No image selected')</script>");
                    return;
                }
                else
                {
                    byte[] image;
                    Stream s = fi.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(s);
                    image = br.ReadBytes((Int32)s.Length);
                    SqlCommand cmd = new SqlCommand("update friendinfo set Image=@i where Fid='" + Session["Fid"].ToString() + "'", sqlConnection);
                    cmd.Parameters.AddWithValue("@i", image);
                    cmd.ExecuteNonQuery();
                    fi.Visible = false;
                    uplBtn.Text = "Upload new image";
                    i = 0;
                    Response.Redirect("EditWorkingProfile.aspx");
                    
                }
            }
        }
        protected void addWork(object sender,EventArgs e) {
            sqlCommand = new SqlCommand("insertWork", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("Fid", Session["Fid"].ToString());
            sqlCommand.Parameters.AddWithValue("workingstatus",tb1.Text.ToString());
            tb1.Text = "";
            pnl1.Visible = false;
            
            sqlCommand.ExecuteNonQuery();
            f = 0;
            Response.Redirect("EditWorkingProfile.aspx");
        }
        
    }
}