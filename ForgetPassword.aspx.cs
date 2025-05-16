using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();   
        }
        public int GenerateRandomNo()
        {
            int _min = 0000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        protected void submitotp(object sender, EventArgs e) {

            string str = nm1.Text.ToString() + nm2.Text.ToString() + nm3.Text.ToString() + nm4.Text.ToString();
            int final=Convert.ToInt32(str);
            sqlCommand = new SqlCommand("verifyOtp",sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Email",usrId.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@otp", final);
            SqlDataReader r =sqlCommand.ExecuteReader();
            int x=-1;
            while (r.Read()) {
                x = Convert.ToInt32(r[0]);
            }
            if (x == 1)
            {
                
                sendotpl.Visible = false;
                btnsendcode.Visible = false;
                nm1.Visible = false;
                nm2.Visible = false;
                nm3.Visible = false;
                nm4.Visible = false;
                sbotp.Visible = false;
                cnfpl.Visible = true;
                cnfpcl.Visible = true;
                password.Visible = true;
                passwordc.Visible = true;
                upb.Visible = true;
            }
            else if (x == 3)
            {
                wrong.Visible = true;
            }
            else if (x == 4) { 
                wrong.Visible=true;
                wrong.Text = "TIME LIMIT EXCEEDED";
            }

        }
        protected void updatePassword(object sender, EventArgs e) {
            int s = 0, d = 0, au = 0, al = 0,f=0;
            string str = password.Text.ToString();
            for (int i = 0; i < str.Count(); i++)
            {
                if ((str[i] >= 32 && str[i] <= 47) || (str[i] >= 58 && str[i] <= 64) || (str[i] >= 91 && str[i] <= 96) || (str[i] >= 123 && str[i] <= 126))
                {
                    s++;
                }
                if (str[i] >= 48 && str[i] <= 57)
                {
                    d++;
                }
                if (str[i] >= 65 && str[i] <= 90)
                {
                    au++;
                }
                if (str[i] >= 97 && str[i] <= 122)
                {
                    al++;
                }

            }
            if (au >= 1 && al >= 1 && s >= 1 && d >= 1 && str.Count() <= 8)
            {
                weakness.Visible = false;
            }
            else
            {
                weakness.Visible = true;
                weakness.ForeColor = System.Drawing.Color.Red;
                f = 1;
            }

            if (!password.Text.ToString().Equals(passwordc.Text.ToString()))
            {
                chkval.Visible = true;
                chkval.ForeColor = System.Drawing.Color.Red;
                f = 1;
            }
            else
            {
                chkval.Visible = false;
                chkval.ForeColor = System.Drawing.Color.Red;

            }
            if (f == 1) {
                return;
            }





            sqlCommand = new SqlCommand("update friendInfo set Upassword='" + password.Text.ToString() + "' where userId='"+usrId.Text.ToString()+"'", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            Response.Redirect("Signin.aspx");
        }
        protected void sendCode(object sender, EventArgs e) {
            string id=usrId.Text.ToString();

            string email = usrId.Text.ToString();
            int random =GenerateRandomNo();
            
            sqlCommand = new SqlCommand("delete from vf where Email='" + email + "'", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            try {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("chatapp659@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Verification";
                    mail.Body = random.ToString();
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("chatapp659@gmail.com", "mjwn gmtx eekj vkdv");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);

                    }
                }
                sqlCommand = new SqlCommand("insertOtp", sqlConnection);
                sqlCommand.CommandType=System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Email", email);
                sqlCommand.Parameters.AddWithValue("@otp",random);
                sqlCommand.ExecuteNonQuery();
                //Response.Write("OTP sent");
                nm1.Visible= true;
                nm2.Visible= true;
                nm3.Visible= true;
                nm4.Visible= true;
                sbotp.Visible= true;    
            }
            catch(Exception ex) { 
                Response.Write(ex.ToString());
            }
        }
    }
}