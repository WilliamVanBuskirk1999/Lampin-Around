using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LampinAround
{
    public partial class FinalizeOrder : System.Web.UI.Page
    {
        private string strConn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTax.Text = Request.Cookies["Tax"].Value + "\n";

                //Making it so the total can be used for calculations
                string totalForProduct = Request.Cookies["Total"].Value;
                totalForProduct = totalForProduct.Replace("$", "");
                totalForProduct = totalForProduct.Replace(",","");
               
                double total = Convert.ToDouble(totalForProduct);

                if(total < 35)
                {
                    lblTotal.Text = (total + 7).ToString();
                    lblShipping.Text = "7";
                }
                else if(total >= 35 && total <= 75)
                {
                    lblTotal.Text = (total + 12).ToString();
                    lblShipping.Text = "12";
                }
                else
                {
                    lblTotal.Text = (total).ToString();
                    lblShipping.Text = "Free Shipping";
                }
            }
        }

        protected void btnFinalize_Click(object sender, EventArgs e)
        {
            
                SqlCommand cmd = default(SqlCommand);
                SqlDataReader dr = default(SqlDataReader);

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand("GetEmail", conn);
                    cmd.Parameters.AddWithValue("@Username", Request.Cookies["login"].Value);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    if (dr.HasRows)
                    {
                        using (SqlConnection connTwo = new SqlConnection(strConn))
                        {
                            cmd = new SqlCommand("Final_Checkout", connTwo);
                            dr.Read();
                            string email = dr["Email"].ToString();
                            string address = dr["Address"].ToString();
                            string city = dr["City"].ToString();
                            string provState = dr["ProvState"].ToString();
                            int userID = Convert.ToInt32(dr["UserID"]);
                            Random rng = new Random();

                            int random = rng.Next(9999);

                            cmd.Parameters.AddWithValue("@CartID", Convert.ToInt32(Request.Cookies["cart"].Value));
                            cmd.Parameters.AddWithValue("@ShippingAddress", "an address");
                            cmd.Parameters.AddWithValue("@PaymentType", ddlPaymentOptions.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@AuthenticationNum", random.ToString());
                            cmd.Parameters.AddWithValue("@UserID", userID);
                            cmd.Parameters.AddWithValue("@OrderStatus", "Pending");
                            cmd.CommandType = CommandType.StoredProcedure;
                            connTwo.Open();
                            cmd.ExecuteNonQuery();
                            MailMessage mailMessage = new MailMessage();
                            mailMessage.To.Add(email);
                            mailMessage.From = new MailAddress("admin@lampinaround.com");
                            mailMessage.Subject = "Order Confirmation";
                            mailMessage.IsBodyHtml = true;
                            mailMessage.Body = "<p>Your order was successful and will be shipped to " + address + " " + city + ", " + provState + " your order number is " +
                                               random.ToString() + "</p>";
                            SmtpClient smtp = new SmtpClient("localhost");
                            smtp.Send(mailMessage);
                        }


                    }
                }
    }

        protected void ddlPaymentOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlPaymentOptions.Text == "PayPal")
            {

            }
        }
    }
}