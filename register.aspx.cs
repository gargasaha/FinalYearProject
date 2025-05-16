using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        static string passwd=null;
        static HttpPostedFile file;

        protected void Page_Load(object sender, EventArgs e)
        {

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            //Upassword.Text=passwd;
            if (state.Items.Count == 0) {
                
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select *from state", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                state.Items.Add(new ListItem("STATE"));
                while (sqlDataReader.Read())
                {
                    state.Items.Add(new ListItem(sqlDataReader[1].ToString(), sqlDataReader[0].ToString()));
                    
                }
                sqlConnection.Close();  
            }
            
            

        }
        /*~Register()
        {
            Email.Text = "";
            nm1.Text = "";
            nm2.Text = "";
            nm3.Text = "";
            nm4.Text = "";
            UnameF.Text = "";
            UnameL.Text = "";
            myTextbox.Text = "";
            state.Items.Clear();
            dist.Items.Clear();
            dob.Text = "";
            UpasswordC.Text = "";

        }*/
        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        protected void sendOtp(object sender, EventArgs e) {


            sqlConnection.Open();
            sqlCommand = new SqlCommand("select count(*) from friendinfo where userid='" + Email.Text.ToString() + "'", sqlConnection);
            sqlDataReader= sqlCommand.ExecuteReader();
            int i = 0;
            if (sqlDataReader.Read()) {
                i =Convert.ToInt32( sqlDataReader[0]);
            }
            if (i > 0) {
                Response.Write("<script>alert('already registered with same email');</script>");
                return;
            }
            sendto.Visible = true;
            send.Visible = false;
            otpenter.Visible = true;
            //return;
            

            string email = string.Empty;
            int random = GenerateRandomNo();
            email = Email.Text.ToString();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            //sqlConnection.Open();
            send.Visible = false;
            otpenter.Visible = true;
            try
            {
                sqlConnection.Open();
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("chatapp659@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Email verification";
                    mail.Body ="OTP IS "+random.ToString();
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("chatapp659@gmail.com", "mjwn gmtx eekj vkdv");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);

                    }
                    sendto.Visible = true;
                    sendto.Text = "OTP has been send to " + email;
                }
                sqlCommand = new SqlCommand("insertOtp",sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Email", email);
                sqlCommand.Parameters.AddWithValue("@otp", random);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex){
                Response.Write(ex.ToString());
            }
            sqlConnection.Close();
        }
        protected void verifyOtp(object sender, EventArgs e) {


            ////testing purpose
            otpenter.Visible = false;
            Email.Enabled = false;
            left.Visible = true;
            llbb11.Visible = false;
            right.Visible = true;
            //return;



            string str = nm1.Text.ToString() + nm2.Text.ToString() + nm3.Text.ToString() + nm4.Text.ToString();
            int final = Convert.ToInt32(str);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            sqlCommand = new SqlCommand("verifyOtp", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Email",Email.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@otp", final);
            SqlDataReader r = sqlCommand.ExecuteReader();
            int x = -1;
            while (r.Read())
            {
                x = Convert.ToInt32(r[0]);
            }
            if (x == 1)
            {
                otpenter.Visible = false;
                Email.Enabled = false;  
                left.Visible = true;
                llbb11.Visible=false;
                right.Visible = true;
            }
            else if (x == 3)
            {
                warninglbl.Visible = true;
                warninglbl.Text = "OTP IS WRONG";
                //Response.Write(x);
            }
            else if (x == 4) {
                warninglbl.Visible = true;
                warninglbl.Text = "TIME LIMIT EXCEEDED";
                //Response.Write(x);
            }


        }


        protected void fun1(object sender, EventArgs e) {
            dist.Items.Clear();
            //town.Items.Clear();
            dist.Items.Add(new ListItem("DISTRICT"));
            string stateid = state.SelectedValue;
            //Response.Write(stateid);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            sqlCommand = new SqlCommand("select *from dist where cStateCode='"+stateid+"'", sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read()) {
                dist.Items.Add(new ListItem(sqlDataReader[1].ToString(), sqlDataReader[0].ToString()));
            }
        }
        
        protected bool chkpasswordrules() {

            weaknesschk();
            if (!Upassword.Text.ToString().Equals(UpasswordC.Text.ToString())){
                chkval.Visible = true;
                chkval.ForeColor=System.Drawing.Color.Red;
                return false;
            }
            else
            {
                chkval.Visible = false;
                chkval.ForeColor = System.Drawing.Color.Red;

            }
            //Response.Write(s);
            return true;
        }
        protected void submit(object sender, EventArgs e)
        {

            int f = 0;
            //emni
            //Response.Write(state.SelectedValue);
            bool x=false;
            x=chkpasswordrules();
            if (x == false)
            {
                return;
            }
            if (Upassword.Text.Length == 0)
            {
                p1.ForeColor = System.Drawing.Color.Red;
                f = 1;
            }
            else
            {
                r1.ForeColor = System.Drawing.Color.Black;
            }
            if (UpasswordC.Text.Length == 0)
            {
                pp1.ForeColor = System.Drawing.Color.Red;
                f = 1;
            }
            else
            {
                r1.ForeColor = System.Drawing.Color.Black;
            }
            //User FName
            
            if (UnameF.Text.Length == 0)
            {
                r1.ForeColor = System.Drawing.Color.Red;
                
                //Response.Write("<script> alert('" + UnameF.Text.Length + "') </script>");
            }
            else
            {
                r1.ForeColor = System.Drawing.Color.Black;
            }
           
            //User LName
            
            if (UnameL.Text.Length == 0)
            {
                rr1.ForeColor = System.Drawing.Color.Red;
                //Response.Write("hii");
                f = 1;
            }
            else
            {
                rr1.ForeColor = System.Drawing.Color.Black;
            }

            if (myTextbox.Text.Length == 0)
            {
                f = 1;
                r2.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                r2.ForeColor = System.Drawing.Color.Black;
            }
            if (myTextbox.Text.Length < 10) {
                f = 1;
                incorrectphonenum.Visible = true;
                incorrectphonenum.Text = "Given phone number is not valid";
                incorrectphonenum.ForeColor = System.Drawing.Color.Red;
            }
          

            if (drp1.SelectedIndex == 0)
            {
                f = 1;
                r3.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                r3.ForeColor = System.Drawing.Color.Black;
            }

            if (dob.Text.Equals(string.Empty))
            {
                f = 1;
                r4.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                r4.ForeColor = System.Drawing.Color.Black;
            }
            

            if (state.SelectedIndex == 0)
            {
                f = 1;
                a1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                a1.ForeColor = System.Drawing.Color.Black;
            }

            if (dist.SelectedIndex == 0)
            {
                f = 1;
                a2.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                a2.ForeColor = System.Drawing.Color.Black;
            }

            //if (town.SelectedIndex == 0)
            //{
            //    f = 1;
            //    a3.ForeColor = System.Drawing.Color.Red;
            //}
            //else
            //{
            //    a3.ForeColor = System.Drawing.Color.Black;
            //}
            //Response.Write(f);
            if (f == 1) {
                f = 0;
                return;
            }
            //Response.Write(f);
            //HttpPostedFile postedFile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(file.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = file.ContentLength;
            Byte[] bytes = null;
            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg"
                || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
            {
                Stream stream = file.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                bytes = binaryReader.ReadBytes((int)stream.Length);
            }
            else
            {
                Response.Write("Format not supported");
            }



            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            sqlCommand = new SqlCommand("register", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserNameF", UnameF.Text.ToString().ToUpper());
            sqlCommand.Parameters.AddWithValue("@UserNameL", UnameL.Text.ToString().ToUpper());
            sqlCommand.Parameters.AddWithValue("@Phone", myTextbox.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@UserImage",bytes);
            sqlCommand.Parameters.AddWithValue("@Gender", drp1.SelectedItem.ToString());
            sqlCommand.Parameters.AddWithValue("@DOB", dob.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@UserPassword", Upassword.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@Email",Email.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@sc", state.SelectedValue.ToString());
            sqlCommand.Parameters.AddWithValue("@dc", dist.SelectedValue.ToString());


            /*Response.Write(dist.SelectedIndex.ToString() + " " + dist.SelectedValue.ToString() + " " + dist.SelectedItem.ToString());*/
            //return;
            sqlDataReader = sqlCommand.ExecuteReader();
            int i = 1;
            string Fid = string.Empty;
            string s = string.Empty;
            while (sqlDataReader.Read())
            {
                i = Convert.ToInt32(sqlDataReader[0].ToString());
                Fid = sqlDataReader[1].ToString();
            }
            //Response.Write(i);
            if (i == 0)
            {
                idshower.Text = "Account already exists";
                idshower.Visible = true;
                
                //Response.Write("Account already exists");
            }
            else
            {
                all.Visible=false;
                right.Visible=false;
                idshower.Text = "Your user ID is " + Email.Text.ToString();
                idshower.Visible= true;
                redirect.Visible = true;
                Session["Fid"] = Fid;
                Response.Write(Fid);
                //Response.Write("Account created");
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(4000);
            if (!FileUpload1.HasFile) {
                Response.Write("<script>alert('No image selected')</script>");
                return;
            }
            file = FileUpload1.PostedFile;
            int fileLen;
            // Get the length of the file.
            fileLen = FileUpload1.PostedFile.ContentLength;
            byte[] input = new byte[fileLen - 1];
            input = FileUpload1.FileBytes;

            byte[] fileBytes = new byte[FileUpload1.PostedFile.ContentLength];

            im.ImageUrl= "data:image/jpg;base64," + Convert.ToBase64String(input.ToArray(), 0, input.ToArray().Length);
            rm.Visible = true;
            sh.Visible = false;
            reg.Visible = true; 
            FileUpload1.Visible=false;
            //Response.Write(Server.MapPath(FileUpload1.FileName));
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            im.ImageUrl = "https://thumbs.dreamstime.com/b/cute-man-face-cartoon-cute-man-face-cartoon-vector-illustration-graphic-design-135024353.jpg";
            rm.Visible = false;
            sh.Visible = true;
            reg.Visible = false;
            file = null;
            FileUpload1.Visible = true;
        }

        protected void weaknesschk()
        {
            int s = 0, d = 0, au = 0, al = 0,f=0;
            string str = Upassword.Text.ToString();
            for (int i = 0; i < str.Count(); i++)
            {
                if ((str[i]==33 || str[i] == 35 || str[i] == 36 || str[i] == 37 || str[i] == 38 || str[i] == 64))
                {
                    s++;
                }
                if (str[i] == 32 || str[i] == 34 || (str[i]>=39 && str[i]<=47) || (str[i]>=91 && str[i]<=96) || (str[i]>=123 && str[i]<=127)) {
                    f++;
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
            if (au >= 1 && al >= 1 && s >= 1 && d >= 1 && str.Count()<=8 && f==0){
                passwd=Upassword.Text;
                weakness.Visible = false;
            }
            else
            {
                
                passwd = "hii";
                //Session["passwd"] = Upassword.Text.ToString();
                weakness.Visible = true;
                weakness.ForeColor = System.Drawing.Color.Red;
            }

        }
    }
}