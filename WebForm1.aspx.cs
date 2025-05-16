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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void fun1(object sender, EventArgs e){
            string str = ((Button)sender).CssClass;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select Uname from bh where Num=" + Convert.ToInt32(str), sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read()) {
                name.Text = sqlDataReader[0].ToString();
            }
            Response.Write("hiii");
            sqlConnection.Close();
        }

    }
}