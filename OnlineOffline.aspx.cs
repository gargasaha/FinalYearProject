using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class OnlineOffline : System.Web.UI.Page
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
            
            if (temp.Text.Equals("0")) {
                showonline();

            }

            else
            {
                srch();
            }
            sqlConnection.Close();
        }
        protected void setsession(object sender, EventArgs e)
        {
            Session["CFid"] = ((Button)sender).ID.ToString();
        }
        protected void showonline()
        {
            sqlConnection.Open();
            sqlCommand = new SqlCommand("listFromOnlineFriend", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Fid", Session["Fid"].ToString());
            sqlDataReader = sqlCommand.ExecuteReader();
           
            Table tbl1 = new Table();
            tbl1.CssClass = "tbl";

            while (sqlDataReader.Read())
            {

                SqlCommand command1 = new SqlCommand("select LiveInfo Info from LiveUser where Fid='" + sqlDataReader[3].ToString() + "'", sqlConnection);
                SqlDataReader reader1 = command1.ExecuteReader();
                int status = -1;
                while (reader1.Read())
                {
                    status = Convert.ToInt32(reader1[0]);
                }
                reader1.Close();
                
                TableRow row = new TableRow();

                ImageButton img = new ImageButton();
                Image img2 = new Image();
                byte[] bytes = (byte[])sqlDataReader[2];
                string i = Convert.ToBase64String(bytes);
                img.ImageUrl = "data:Image1/png;base64," + i;
                img.OnClientClick = "fun1(" + sqlDataReader["Fid"].ToString() + ")";
                img.Height = 100;
                img.Width = 100;
                img.CssClass = "aa";

                if (status == 1)
                {
                    img2.ImageUrl = "~/IMAGES/green.gif";
                    img2.CssClass = "lowerimg2";
                }
                else
                {
                    img2.ImageUrl = "~/IMAGES/offlinered.png";
                }

                string temp = string.Empty;
                SqlCommand Command2 = new SqlCommand("getchatonemessage", sqlConnection);
                Command2.CommandType = System.Data.CommandType.StoredProcedure;
                Command2.Parameters.AddWithValue("@Fid", Session["Fid"].ToString());
                Command2.Parameters.AddWithValue("@CFid", sqlDataReader[3].ToString());
                SqlDataReader reader2 = Command2.ExecuteReader();
                while (reader2.Read())
                {
                    if (sqlDataReader[0].ToString().Equals(Session["Fid"].ToString())){

                    }
                    else{
                        temp = reader2[2].ToString();
                    }
                }
                reader2.Close();

                img2.Height = 10;
                img2.Width = 10;
                Button btn = new Button();
                btn.Width = 150;
                btn.Text = " " + sqlDataReader[0].ToString() + " " + sqlDataReader[1].ToString() + "\n" + temp;
                btn.CssClass = "aa";
                //btn.ForeColor = System.Drawing.Color.White;
                btn.ID = sqlDataReader[3].ToString();
                btn.Click += new EventHandler(setsession);

                //adding profile image to table cell
                TableCell cell1 = new TableCell();
                cell1.Controls.Add(img);
                //cell1.BackColor = System.Drawing.Color.Gray;

                //adding online icon to table cell
                TableCell cell2 = new TableCell();
                cell2.Controls.Add(img2);
                //cell2.BackColor = System.Drawing.Color.Gray;

                //adding friend name to table cell
                TableCell cell3 = new TableCell();
                cell3.Controls.Add(btn);
                //cell3.BackColor = System.Drawing.Color.Gray;
                //cell3.Controls.Add(lbl);


                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                //row.CssClass = "row";
                //row.BackColor = System.Drawing.Color.Gray;
                tbl1.Rows.Add(row);
                //tbl1.BackColor = System.Drawing.Color.Gray;
            }
            sqlDataReader.Close();
            pnl1.Controls.Add(tbl1);
            
            sqlConnection.Close();
        }
        protected void showSearchResult(object sender, EventArgs e)
        {
            temp.Text = "1";
            srch();
        } 
        protected void srch()
        {
            if (searchpnl.Text.ToString().Equals(string.Empty))
            {
                return;
            }
            cr.Visible = true;
            sqlConnection.Open();
            string str = searchpnl.Text.ToString();
            int f = 0, count = 0;
            StringBuilder fname = new StringBuilder();
            StringBuilder lname = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    if (f == 0)
                    {
                        fname.Append(str[i]);
                    }
                    if (f == 1)
                    {
                        lname.Append(str[i]);
                    }
                }
                else
                {
                    if (count == 0)
                    {
                        f = 1;
                        count++;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            pnl1.Controls.Clear();

            sqlCommand = new SqlCommand("searchFrnd", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Fname", fname.ToString());
            sqlCommand.Parameters.AddWithValue("@Lname", lname.ToString());
            sqlCommand.Parameters.AddWithValue("@Fid", Session["Fid"].ToString());
            sqlDataReader = sqlCommand.ExecuteReader();

            Table tbl1 = new Table();
            tbl1.CssClass = "tbl";

            while (sqlDataReader.Read())
            {

                SqlCommand command1 = new SqlCommand("select LiveInfo Info from LiveUser where Fid='" + sqlDataReader[3].ToString() + "'", sqlConnection);
                SqlDataReader reader1 = command1.ExecuteReader();
                int status = -1;
                while (reader1.Read())
                {
                    status = Convert.ToInt32(reader1[0]);
                }
                reader1.Close();

                TableRow row = new TableRow();

                Image img = new Image();
                Image img2 = new Image();
                byte[] bytes = (byte[])sqlDataReader[2];
                string i = Convert.ToBase64String(bytes);
                img.ImageUrl = "data:Image1/png;base64," + i;
                img.Height = 100;
                img.Width = 100;
                img.CssClass = "aa";

                if (status == 1)
                {
                    img2.ImageUrl = "~/IMAGES/green.gif";
                    img2.CssClass = "lowerimg2";
                }
                else
                {
                    img2.ImageUrl = "~/IMAGES/offlinered.png";
                }

                string temp = string.Empty;
                SqlCommand Command2 = new SqlCommand("getchatonemessage", sqlConnection);
                Command2.CommandType = System.Data.CommandType.StoredProcedure;
                Command2.Parameters.AddWithValue("@Fid", Session["Fid"].ToString());
                Command2.Parameters.AddWithValue("@CFid", sqlDataReader[3].ToString());
                SqlDataReader reader2 = Command2.ExecuteReader();
                while (reader2.Read())
                {
                    if (sqlDataReader[0].ToString().Equals(Session["Fid"].ToString()))
                    {

                    }
                    else
                    {
                        temp = reader2[2].ToString();
                    }
                }
                reader2.Close();

                img2.Height = 10;
                img2.Width = 10;
                Button btn = new Button();
                btn.Width = 150;
                btn.Text = " " + sqlDataReader[0].ToString() + " " + sqlDataReader[1].ToString() + "\n" + temp;
                btn.CssClass = "aa";
                //btn.ForeColor = System.Drawing.Color.White;
                btn.ID = sqlDataReader[3].ToString();
                btn.Click += new EventHandler(setsession);

                //adding profile image to table cell
                TableCell cell1 = new TableCell();
                cell1.Controls.Add(img);
                //cell1.BackColor = System.Drawing.Color.Gray;

                //adding online icon to table cell
                TableCell cell2 = new TableCell();
                cell2.Controls.Add(img2);
                //cell2.BackColor = System.Drawing.Color.Gray;

                //adding friend name to table cell
                TableCell cell3 = new TableCell();
                cell3.Controls.Add(btn);
                //cell3.BackColor = System.Drawing.Color.Gray;
                //cell3.Controls.Add(lbl);


                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                //row.CssClass = "row";
                //row.BackColor = System.Drawing.Color.Gray;
                tbl1.Rows.Add(row);
                //tbl1.BackColor = System.Drawing.Color.Gray;
            }
            sqlDataReader.Close();
            pnl1.Controls.Add(tbl1);

            cr.Visible = true;
            sqlConnection.Close();
            f = 1;
        }
        protected void disableSearch(object sender, EventArgs e) {
            searchpnl.Text= string.Empty;
            cr.Visible = false;
            temp.Text = "0";
        }
    }
}