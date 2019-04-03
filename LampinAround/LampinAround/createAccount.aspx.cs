using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace LampinAround
{
    public partial class login : Page
    {
        private string strConn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {          
            rangeDOB.MaximumValue = DateTime.Now.AddYears(-19).ToShortDateString();
            rangeDOB.MinimumValue = DateTime.Now.AddYears(-100).ToShortDateString();
            if (!IsPostBack)
            {
                DropDownListState.Visible = false;
            }

        }

        protected bool SendData(string procedure)
        {
            SqlCommand cmd = default(SqlCommand);
            //SqlDataReader dr = default(SqlDataReader);
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand(procedure, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", txtFName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@IsArchived", false);
                    cmd.Parameters.AddWithValue("@IsAdmin", chkAdmin.Checked ? true : false);
                    cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@Pword", txtPassword.Text);

                    if (ddlCountry.SelectedItem.ToString() == "Canada")
                    {
                        cmd.Parameters.AddWithValue("@ProvState", DropDownListProvinces.SelectedValue);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProvState", DropDownListState.SelectedValue);
                    }

                    conn.Open();

                    int x = cmd.ExecuteNonQuery();

                    if (x > 0)
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

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (SendData("Update_Account"))
            {
                lblMessage.Text = "Account Created Successfully";
                MailMessage mailMessage = new MailMessage();

                mailMessage.To.Add(txtEmail.Text);
                mailMessage.From = new MailAddress("admin@lampinaround.com");
                mailMessage.Subject = "Send Email Demo";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "<a href='http://localhost:58546/AccountActivate.aspx'>" +
                    "Please click on this to activate your account.</a>";
                SmtpClient smtp = new SmtpClient("localhost");
                smtp.Send(mailMessage);
            }

        }

        protected void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            if (SendData("Update_Account"))
            {
                lblMessage.Text = "Account Updated Successfully";
            }
        }

        protected bool SearchData(string procedure)
        {
            SqlCommand cmd = default(SqlCommand);
            SqlDataReader dr = default(SqlDataReader);
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand(procedure, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SearchTerm", txtSearchAccount.Text);
                    conn.Open();
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    txtFName.Text = dt.Rows[0]["FirstName"].ToString();
                    txtLName.Text = dt.Rows[0]["LastName"].ToString();
                    txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    ddlCountry.SelectedValue = dt.Rows[0]["Country"].ToString();
                    txtCity.Text = dt.Rows[0]["City"].ToString();
                    txtPhoneNumber.Text = dt.Rows[0]["PhoneNumber"].ToString();
                    txtUserName.Text = dt.Rows[0]["Uname"].ToString();
                    
                  

                    return true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            return false;
        }

        protected void btnSearchAccount_Click(object sender, EventArgs e)
        {
            if (SearchData("spSearchForUser"))
            {
                lblMessage.Text = "Search successful";
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlCountry.SelectedItem.ToString() == "USA")
            {
                DropDownListState.Visible = true;
                DropDownListProvinces.Visible = false;
            }
            else
            {
                DropDownListState.Visible = false;
                DropDownListProvinces.Visible = true;
            }
        }
    }
}