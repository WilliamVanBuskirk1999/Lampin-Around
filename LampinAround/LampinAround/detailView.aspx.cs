using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Configuration;

namespace LampinAround
{
    public partial class detailView : System.Web.UI.Page
    {

        private string strConn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string product = Request.QueryString["ProductID"];
            if (!IsPostBack)
            {
                LoadDetailView(product);
            }
        }
        private void LoadDetailView(string prod)
        {
            SqlCommand cmd = default(SqlCommand);
            SqlDataReader dr = default(SqlDataReader);
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand("Get_Detailed_Product", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", prod);

                    conn.Open();

                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    if (dr.HasRows)
                    {
                        rptDetailView.Visible = true;
                        rptDetailView.DataSource = dr;
                        rptDetailView.DataBind();

                    }
                    else
                    {
                        
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                //dr.Close();
            }
        }



        protected void editDetailView_Click(object sender, EventArgs e)
        {
            //sendToDatabase.Visible = true;
        }

        protected void btnSaveToDatabase_Click(object sender, EventArgs e)
        {

            //UpdateProductInfo(Request.QueryString["ProductID"]);
        }

      
      

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
              
                    if (Request.Cookies["cart"] == null)
                    {
                        using (SqlConnection conn = new SqlConnection(strConn))
                        {
                            conn.Open();

                            String toSend = "";

                            //Creating the output parameter
                            SqlParameter cartIdParm = new SqlParameter();

                            cartIdParm.SqlDbType = SqlDbType.Int;
                            cartIdParm.Value = 0;
                            cartIdParm.ParameterName = "@CartId";
                            cartIdParm.Direction = ParameterDirection.Output;


                            //Setting up the command
                            SqlCommand cmd2 = new SqlCommand("CreateACart", conn);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Add(cartIdParm);

                            if (Request.Cookies["login"] == null)
                            {
                                cmd2.Parameters.AddWithValue("@uname", DBNull.Value);
                            }
                            else
                            {
                                cmd2.Parameters.AddWithValue("@uname", Request.Cookies["login"].Value);
                            }

                            //Executing
                            cmd2.ExecuteNonQuery();
                            toSend = cmd2.Parameters[0].Value.ToString();

                            //Setting the cookie equal to what the query returns
                            Response.Cookies["cart"].Value = toSend;
                            conn.Close();
                        }
                    }
                
               
            
                int product = Convert.ToInt32(Request.QueryString["ProductID"]);
                int cartId = Convert.ToInt32(Request.Cookies["cart"].Value);



                SqlCommand cmd = default(SqlCommand);
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand("AddToCart", conn);

                    cmd.Parameters.AddWithValue("@pId", product);
                    cmd.Parameters.AddWithValue("@qty", 1);
                    cmd.Parameters.AddWithValue("@cartID", cartId);
             
                    
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Close();

                }

                Response.Redirect("ShoppingCart.aspx");

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
               
            }
        }
    }
}