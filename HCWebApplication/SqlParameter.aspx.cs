using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCWebApplication
{
    public partial class SqlParameter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection("server=.;database=OA;uid=sa;pwd=hc123456;"))
            {
                string strSql = "select count(*) from UserInfo where UName=@UName";
                SqlCommand command = new SqlCommand(strSql, sqlConnection);
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter ("@UName",TextBox1.Text));
                sqlConnection.Open();
                int n =Convert.ToInt32(command.ExecuteScalar());
                Response.Write(n);
            }
        }
    }
}