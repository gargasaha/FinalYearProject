using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FinalYearProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        static int f = 0, i = 0, pl = 0;
        static string ss;
        static string dd;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            string Fid = string.Empty;
            try
            {
                Fid = Session["Fid"].ToString();
            }
            catch (Exception ex) {
                Response.Redirect("SignIn.aspx");
            }

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            
            if (!IsPostBack)
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from friendInfo where Fid='" + Session["Fid"].ToString() + "'", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    byte[] bytes = (byte[])sqlDataReader["Image"];
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    profileImg.ImageUrl = "data:image/png;base64," + base64String;
                    fname.Text = sqlDataReader[1].ToString();
                    lname.Text = sqlDataReader[2].ToString();
                    ph.Text = sqlDataReader[3].ToString();
                    dob.Text = Convert.ToDateTime(sqlDataReader["DOB"]).ToString("yyyy-MM-dd");

                    SqlCommand com = new SqlCommand("select cStateName from friendInfo,state where state.cStateCode=sc and Fid='" + Session["Fid"] + "'",sqlConnection);
                    SqlDataReader dr= com.ExecuteReader();
                    if (dr.Read())
                    {
                        s.Text = dr[0].ToString();
                        //d.Text = dr[1].ToString();
                    }

                    com = new SqlCommand("select cDistName from friendInfo,dist where dist.cDistCode=dc and Fid='" + Session["Fid"] + "'", sqlConnection);
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        d.Text = dr[0].ToString();
                        //d.Text = dr[1].ToString();
                    }

                    dr.Close();
                    


                    marital.Items.Clear();
                    marital.Items.Add("Not mentioned");
                    marital.Items.Add("Married");
                    marital.Items.Add("Unmarried");
                    if (sqlDataReader["maritalStatus"].ToString().Equals("Not Mentioned"))
                    {
                        marital.SelectedIndex = 0;
                    }
                    else if (sqlDataReader["maritalStatus"].ToString().Equals("Married"))
                    {
                        marital.SelectedIndex = 1;
                    }
                    else if (sqlDataReader["maritalStatus"].ToString().Equals("Not married"))
                    {
                        marital.SelectedIndex = 2;
                    }
                }
                sqlConnection.Close();  
            }
            
        }

        protected void uploadimage(object sender, EventArgs e)
        {
            sqlConnection.Open();
            if (i == 0)
            {
                fi.Visible = true;

                uplBtn.Text = "Upload";
                i = 1;
            }
            else if (i == 1)
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
                sqlConnection.Close();
                Response.Redirect("EditProfile.aspx");

            }
            sqlConnection.Close();
        }
        protected void EditStateDist(object sender, EventArgs e)
        {
            sqlConnection.Open();
            if (f == 0)
            {
                p1.Visible = false;
                p2.Visible = true;
                SqlCommand cmd = new SqlCommand("select *from state", sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    state.Items.Add(new ListItem(reader[1].ToString(), reader[0].ToString()));
                }
                reader.Close();
                ed.Text = "Save Changes";
                f = 1;
            }
            else
            {
                
                p1.Visible = true;
                p2.Visible = false;
                f = 0;
                ss = state.SelectedItem.ToString();
                dd = district.SelectedItem.ToString();
                //Response.Write(ss + " " + dd);
                if (ss.Equals("STATE") || dd.Equals("DISTRICT")) {
                    Response.Write("<script>alert('Select valid state and district')</script>");
                    ed.Text = "Edit state & distrct";
                    return;
                }
                else
                {
                    s.Text = state.SelectedItem.ToString();
                    d.Text = district.SelectedItem.ToString();
                }

                sqlCommand = new SqlCommand("update friendInfo set sc='" + state.SelectedValue + "',dc='" + district.SelectedValue + "' where Fid='" + Session["Fid"].ToString()+"';", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                ed.Text = "Edit state & distrct";
            }

            sqlConnection.Close();

        }
        protected void fun1(object sender, EventArgs e)
        {
            sqlConnection.Open();
            district.Items.Clear();
            //town.Items.Clear();
            district.Items.Add(new ListItem("DISTRICT"));
            string stateid = state.SelectedValue;
            //Response.Write(stateid);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            sqlCommand = new SqlCommand("select *from dist where cStateCode='" + stateid + "'", sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                district.Items.Add(new ListItem(sqlDataReader[1].ToString(), sqlDataReader[0].ToString()));
            }
            sqlConnection.Close();
        }

        protected void showWorking(object sender, EventArgs e)
        {
            Response.Redirect("EditWorkingProfile.aspx");
        }
        protected void showeducation(object sender, EventArgs e)
        {
            Response.Redirect("EditEducationalProfile.aspx");
        }
        protected void saveChanges(object sender, EventArgs e)
        {

            if(fname.Text.Length==0 || fname.Text.Length == 0 || (ph.Text.Length==0 || ph.Text.Length>10) || s.Text.Equals("STATE") || d.Text.Equals("DISTRICT"))
            {
                if(fname.Text.Length == 0)
                {
                    fname.BorderColor = Color.Red;
                }
                if(lname.Text.Length == 0)
                {
                    lname.BorderColor = Color.Red;
                }
                if ((ph.Text.Length == 0 || ph.Text.Length > 10))
                {
                    ph.BorderColor = Color.Red;
                }
                if (s.Text.Equals("STATE"))
                {
                    s.BorderColor = Color.Red;
                }
                if (d.Text.Equals("DISTRICT"))
                {
                    d.BorderColor= Color.Red;
                }
                Response.Write("<script>alert('Invalid Input')</script>");
                return;
            }
            else
            {
                fname.BorderColor = Color.Black;
                lname.BorderColor = Color.Black;
                ph.BorderColor = Color.Black;
                s.BorderColor = Color.Black;
                d.BorderColor = Color.Black;
            }

            sqlConnection.Open();
            sqlCommand = new SqlCommand("updprofile", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("Fname", fname.Text.ToString());
            sqlCommand.Parameters.AddWithValue("Lname", lname.Text.ToString());
            sqlCommand.Parameters.AddWithValue("Phone", ph.Text.ToString());
            
            sqlCommand.Parameters.AddWithValue("DOB", dob.Text.ToString());
            sqlCommand.Parameters.AddWithValue("m", marital.SelectedValue.ToString());
            
            sqlCommand.Parameters.AddWithValue("Fid", Session["Fid"].ToString());
            sqlCommand.ExecuteNonQuery();



            if (marital.SelectedValue.ToString().Equals("Not Mentioned"))
            {
                marital.SelectedIndex = 0;
            }
            else if (marital.SelectedValue.ToString().Equals("Married"))
            {
                marital.SelectedIndex = 1;
            }
            else if (marital.SelectedValue.ToString().Equals("Not married"))
            {
                marital.SelectedIndex = 2;
            }
            //Response.Write(fname.Text + " " + lname.Text + " " + ph.Text + " " + state.SelectedItem + " " + district.sele + " " + dob.Text + " " + marital.SelectedItem + " " + ss + " " + dd + " " + Session["fid"]);
            sqlConnection.Close();
            Response.Redirect("EditProfile.aspx");
        }

    }
}