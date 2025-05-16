using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class chat : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        protected void unfriend(object sender, EventArgs e) {


            

            if (String.IsNullOrEmpty(Session["CFid"] as String)){

            }
            else{
                sqlConnection.Open();
                sqlCommand = new SqlCommand("unfriend", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("Fid", Session["Fid"].ToString());
                sqlCommand.Parameters.AddWithValue("CFid", Session["CFid"].ToString());
                sqlCommand.ExecuteNonQuery();
                Session["CFid"] = null;
                frndimage.ImageUrl= null;
                frndname.Text= "";
                sqlConnection.Close();
                Response.Redirect("chat.aspx");
            }
            
        }
        
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


            Page.MaintainScrollPositionOnPostBack = true;
            if (String.IsNullOrEmpty(Session["CFid"] as String))
            {
                //uf.Visible = false;
            }
            else
            {

                //uf.Visible = true;
                DateTime dateTime = DateTime.Now;
                string date1 = dateTime.ToString("MM/dd/yyyy");
                //Response.Write(Session["CFid"].ToString());
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
                sqlConnection.Open();


                byte[] bytes=null;
                string i = string.Empty,fname=string.Empty,lname=string.Empty;
                sqlCommand = new SqlCommand("select Fname,Lname,Image from FriendInfo where Fid='" + Session["CFid"].ToString() + "'", sqlConnection);
                sqlDataReader=sqlCommand.ExecuteReader();
                while (sqlDataReader.Read()) {
                    bytes = (byte[])sqlDataReader[2];
                    i = Convert.ToBase64String(bytes);
                    fname= (string)sqlDataReader[0];
                    lname= (string)sqlDataReader[1];
                }

                
                frndimage.ImageUrl = "data:Image1/png;base64," + i;
                frndname.Text = fname + " " + lname;



                sqlCommand = new SqlCommand("getchat", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Fid", Session["Fid"].ToString());
                sqlCommand.Parameters.AddWithValue("@CFid", Session["CFid"].ToString());
                sqlDataReader = sqlCommand.ExecuteReader();
                int f = 0;
                string date3 = string.Empty;
                Table table = new Table();
                table.CssClass = "tbl";

                TableRow row;

                while (sqlDataReader.Read())
                {
                    DateTime dt = Convert.ToDateTime(sqlDataReader[3].ToString());
                    string date2 = dt.ToString("MM/dd/yyyy");
                    string time = dt.ToString("HH:mm tt");
                    TableCell cell = null;

                    if (sqlDataReader[0].ToString().Equals(Session["Fid"].ToString()))
                    {
                        if (date1.Equals(date2))
                        {
                            if (f == 0)
                            {
                                f = 1;
                                TableRow row1 = new TableRow();
                                cell = new TableCell();
                                //date3 = date2;
                                cell.Text = "Today";
                                //cell.CssClass = "chtlbl1";
                                row1.Cells.Add(cell);
                                table.Rows.Add(row1);

                            }

                        }
                        else if (!date2.Equals(date3))
                        {
                            date3 = date2;
                            TableRow row1 = new TableRow();
                            cell = new TableCell();
                            cell.Text = date2;
                            row1.Cells.Add(cell);
                            table.Rows.Add(row1);

                        }
                        cell = new TableCell();
                        System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
                        if (sqlDataReader[4].ToString().Equals("1"))
                        {
                            string imageNum = sqlDataReader[2].ToString();
                            SqlCommand cmd = new SqlCommand("select *from ChatImageTable where Num='" + imageNum + "';", sqlConnection);
                            SqlDataReader reader= cmd.ExecuteReader();
                            ImageButton image = new ImageButton();
                            if (reader.Read()){
                                byte[] bt = (byte[])reader[1];
                                
                                string imreBase64Data = Convert.ToBase64String(bt);
                                image.ImageUrl= string.Format("data:image/png;base64,{0}", imreBase64Data);
                                
                                image.OnClientClick = "fun1('"+image.ImageUrl+"')";
                            }
                            image.CssClass = "im";
                            reader.Close();

                            cell.Controls.Add(image);
                            cell.Controls.Add(new LiteralControl("<br/>"));
                            cell.Controls.Add(new System.Web.UI.WebControls.Label() { Text = time,CssClass= "chtlbl11", ForeColor = System.Drawing.Color.Red });
                            cell.CssClass = "lbl1";
                        }
                        else
                        {
                            lbl.Text = sqlDataReader[2].ToString() + "<br>" + time;
                            lbl.CssClass = "chtlbl1";
                            cell.Controls.Add(lbl);
                            cell.CssClass = "lbl1";

                        }

                       
                        row = new TableRow();
                        row.Cells.Add(cell);
                        table.Rows.Add(row);

                    }
                    else
                    {
                        if (date1.Equals(date2) && f == 0)
                        {
                            if (f == 0)
                            {
                                f = 1;
                                TableRow row1 = new TableRow();
                                cell = new TableCell();
                                cell.Text = "Today";
                                row1.Cells.Add(cell);
                                table.Rows.Add(row1);

                            }
                        }
                        else if (!date2.Equals(date3) && f == 0)
                        {
                            date3 = date2;
                            date3 = date2;
                            cell = new TableCell();
                            cell.Text = date2;
                            row = new TableRow();
                            row.Cells.Add(cell);
                            table.Rows.Add(row);

                        }
                        cell = new TableCell();
                        
                        System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
                        if (sqlDataReader[4].ToString().Equals("1"))
                        {
                            string imageNum = sqlDataReader[2].ToString();
                            SqlCommand cmd = new SqlCommand("select *from ChatImageTable where Num='" + imageNum + "';", sqlConnection);
                            SqlDataReader reader = cmd.ExecuteReader();
                            ImageButton image = new ImageButton();
                            if (reader.Read())
                            {
                                byte[] bt = (byte[])reader[1];

                                string imreBase64Data = Convert.ToBase64String(bt);
                                image.ImageUrl = string.Format("data:image/png;base64,{0}", imreBase64Data);
                                image.OnClientClick = "fun1('" + image.ImageUrl + "')";
                            }
                            image.CssClass = "im";

                            reader.Close();
                            
                            cell.Controls.Add(image);
                            cell.Controls.Add(new LiteralControl("<br/>"));
                            cell.Controls.Add(new System.Web.UI.WebControls.Label() { Text = time, CssClass = "chtlbl22", ForeColor = System.Drawing.Color.Red });
                            cell.CssClass = "lbl2";
                        }
                        else
                        {
                            lbl.Text = sqlDataReader[2].ToString() + "<br>" + time;
                            lbl.CssClass = "chtlbl2";
                            cell.Controls.Add(lbl);
                            cell.CssClass = "lbl2";

                        }
                        row = new TableRow();
                        row.Cells.Add(cell);
                        table.Rows.Add(row);
                    }
                    //chatpnl.Controls.Add(new LiteralControl("<br/>"));
                }
                chatpnl.Controls.Add(table);

                sqlConnection.Close();

            }
        }
        
    }
}