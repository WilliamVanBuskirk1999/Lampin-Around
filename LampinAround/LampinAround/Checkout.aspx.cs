using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LampinAround
{
    public partial class Checkout : System.Web.UI.Page
    {
       
        private string strConn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDetails();
            }
        }

        private void LoadDetails()
        {
            try
            {
                SqlCommand cmd = default(SqlCommand);
                SqlDataReader dr = default(SqlDataReader);

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand("GetBillingInfo", conn);
                    cmd.Parameters.AddWithValue("@Uname", Request.Cookies["login"].Value);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    if (dr.HasRows)
                    {

                        rptUserInfo.DataSource = dr;
                        rptUserInfo.DataBind();
                        
                    }

                    conn.Open();
                    dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string country = dr["Country"].ToString();

                            if (country == "Canada")
                            {
                                DropDownListProvinces.Visible = true;
                                DropDownListState.Visible = false;
                            }
                            else
                            {
                                DropDownListProvinces.Visible = false;
                                DropDownListState.Visible = true;
                            }



                        }
                    }

                }

                   


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = default(SqlCommand);
                int successful;

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    TextBox address = (TextBox)rptUserInfo.Items[0].FindControl("txtAddress");
                    TextBox city = (TextBox)rptUserInfo.Items[0].FindControl("txtCity");
                    TextBox postalCode = (TextBox)rptUserInfo.Items[0].FindControl("txtPostalCode");
                    TextBox country = (TextBox)rptUserInfo.Items[0].FindControl("txtCountry");
                    TextBox phone = (TextBox)rptUserInfo.Items[0].FindControl("txtPhoneNumber");

                    cmd = new SqlCommand("UpdateShippingInfo", conn);
                    cmd.Parameters.AddWithValue("@Username", Request.Cookies["login"].Value);
                    cmd.Parameters.AddWithValue("@Address", address.Text);
                    cmd.Parameters.AddWithValue("@City", city.Text);
                    cmd.Parameters.AddWithValue("@PostalCode", postalCode.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone.Text);


                    if (DropDownListProvinces.Visible == true)
                    {
                        cmd.Parameters.AddWithValue("@ProvState", DropDownListProvinces.SelectedValue);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProvState", DropDownListState.SelectedValue);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    successful = cmd.ExecuteNonQuery();

                    conn.Close();

                   
                }

                if(successful == 1)
                {
                    Master.MasterLabel.Text = "Update Successful";
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void btnChoosePayment_Click(object sender, EventArgs e)
        {
            
                Response.Redirect("FinalizeOrder.aspx");
            
           
        }
    }
}
