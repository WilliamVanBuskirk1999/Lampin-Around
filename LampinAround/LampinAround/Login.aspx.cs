using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LampinAround
{
    public partial class Login1 : System.Web.UI.Page
    {
        private readonly string _strConn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        private bool _isAdmin;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected Boolean SendData(string procedure)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_strConn))
                {

                    SqlCommand cmd = new SqlCommand(procedure, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@Pword", txtPassword.Text);

                    SqlParameter parm1 = new SqlParameter("@UserID", SqlDbType.Int);
                    parm1.Direction = ParameterDirection.Output;
                    SqlParameter parm2 = new SqlParameter("@IsAdmin", SqlDbType.Bit);
                    parm2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm1);
                    cmd.Parameters.Add(parm2);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    int y = Convert.ToInt32(cmd.Parameters["@UserID"].Value);
                    _isAdmin = Convert.ToBoolean(cmd.Parameters["@IsAdmin"].Value);

                    if (y > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                //dr.Close();
            }
            return false;


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (SendData("spCheckLogin"))
            {
                Response.Cookies["login"].Value = txtUserName.Text;
                Response.Cookies["login"].Expires = DateTime.Now.AddDays(1);

                //Master.MasterLabel.Text = "Login Successful";
                string loginMessage = "Login Successful";
                if (_isAdmin)
                {
                    loginMessage = "Logged in as Admin";
                    Session["IsAdmin"] = _isAdmin;
                }

                Response.Redirect("index.aspx?val=" + loginMessage);


            }
            else
            {
                Master.MasterLabel.Text = "Login failed, please try again";
            }
        }


    }
}