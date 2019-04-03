using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;

namespace LampinAround
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        private SqlConnection _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid(cartGrid);
                CalculateTax();
                CalculateTotal();

            }



        }

        /// <summary>
        /// Fills the grid
        /// </summary>
        /// <param name="stapleMe">Grid to fill</param>
        /// <param name="lblOutput"></param>
        public void FillGrid(GridView stapleMe, Label lblOutput = null)
        {
            SqlDataReader dr = default(SqlDataReader);
            SqlCommand cmd = default(SqlCommand);

            try
            {
                if (Request.Cookies["login"] != null)
                {
                    using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
                    {
                        cmd = new SqlCommand("GetCartItems", cnn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@cartID", Convert.ToInt32(Request.Cookies["cart"].Value));

                        cnn.Open();
                        cmd.Connection = cnn;
                        dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                        if (dr.HasRows)
                        {

                            stapleMe.DataSource = dr;
                            stapleMe.DataBind();

                            //cartGrid.Rows[0].Style["display"] = "none";
                        }
                        else
                        {
                            if (lblOutput != null)
                            {
                                lblOutput.Visible = true;
                                lblOutput.Text = "No results :(";
                            }
                        }
                    }

                }
                else
                {
                    using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
                    {
                        cmd = new SqlCommand("GetCartItems", cnn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@cartID", Convert.ToInt32(Request.Cookies["cart"].Value));

                        cnn.Open();
                        cmd.Connection = cnn;
                        dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                        if (dr.HasRows)
                        {

                            stapleMe.DataSource = dr;
                            stapleMe.DataBind();

                            //cartGrid.Rows[0].Style["display"] = "none";
                        }
                        else
                        {
                            if (lblOutput != null)
                            {
                                lblOutput.Visible = true;
                                lblOutput.Text = "No results :(";
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (lblOutput != null)
                {
                    lblOutput.Visible = true;
                    lblOutput.Text = ex.Message;
                }
            }
            finally
            {

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string product;
            string cartQuantity;
            foreach (GridViewRow row in cartGrid.Rows)
            {
                var cb = (HtmlInputCheckBox)row.FindControl("Remove");
                if (cb.Checked == true)
                {
                    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("DeleteFromCart", cnn);

                    product = ((Label)row.Cells[0].FindControl("ProductID")).Text;
                    cartQuantity = Request.Cookies["cart"].Value;

                    cmd.Parameters.AddWithValue("@cartID", Convert.ToInt32(cartQuantity));
                    cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(product));

                    DeleteCartItem(cmd);
                }
            }

            FillGrid(cartGrid);
            Response.Redirect("ShoppingCart.aspx");
        }


        protected void btnUpdateQty_Click(object sender, EventArgs e)
        {
            string product;
            string cartQuantity;


            //Going through all the rows to add parameters
            for (int x = 0; x < cartGrid.Rows.Count; x++)
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
                SqlCommand cmd = new SqlCommand();

                 product = ((Label)cartGrid.Rows[x].Cells[0].FindControl("ProductID")).Text;
                 cartQuantity = ((TextBox)cartGrid.Rows[x].Cells[2].FindControl("Quantity")).Text;

                if ( cartQuantity == string.Empty || Convert.ToInt32(cartQuantity) == 0)
                {                     
                            string cartId = Request.Cookies["cart"].Value;

                            cmd = new SqlCommand("DeleteFromCart",cnn);
                            cmd.Parameters.AddWithValue("@cartID", Convert.ToInt32(cartId));
                            cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(product));
                            
                                 
                            DeleteCartItem(cmd);
                    
                }
                else
                {
                    cmd = new SqlCommand("SetCartItemQty", cnn);

                    cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(cartQuantity));
                    cmd.Parameters.AddWithValue("@pid", Convert.ToInt32(product));
                    cmd.Parameters.AddWithValue("@cartId", Convert.ToInt32(Request.Cookies["cart"].Value));

                    UpdateCart(cmd);
                }
            }

            //Refreshing the grid
            FillGrid(cartGrid);

            //Recalculating
            CalculateTax();
            CalculateTotal();
            Response.Redirect("ShoppingCart.aspx");




        }

        /// <summary>
        /// Does the transaction to update a cart
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="cnn"></param>
        private void UpdateCart(SqlCommand cmd)
        {
            //Executing the sql command
            using (_cnn)
            {
                SqlTransaction transaction = null;

                _cnn.Open();

                transaction = _cnn.BeginTransaction();

                cmd.Transaction = transaction;


                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Starting the transaction
                try
                {

                    cmd.Connection = _cnn;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    //If the transaction commit fails, try to rollback. If that fails, 
                    try
                    {
                        transaction.Rollback();
                        ex.Message.ToString();
                    }
                    catch (Exception ex2)
                    {
                        ex2.Message.ToString();
                    }
                }


                _cnn.Close();
            }

        }
        /// <summary>
        /// Deletes a cart item and does a transaction
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="cnn"></param>
        private void DeleteCartItem(SqlCommand cmd)
        {
            using (_cnn)
            {
                SqlTransaction transaction = null;

                _cnn.Open();

                transaction = _cnn.BeginTransaction();

                cmd.Transaction = transaction;


                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Starting the transaction
                try
                {
                    cmd.Connection = _cnn;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    //If the transaction commit fails, try to rollback. If that fails, 
                    try
                    {
                        transaction.Rollback();
                        ex.Message.ToString();
                    }
                    catch (Exception ex2)
                    {
                        ex2.Message.ToString();
                    }
                }


                _cnn.Close();
            }
        }
        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            if(Request.Cookies["login"] == null)
            {
                //Put the response.redirect to login
                Response.Redirect("Login.aspx");
            }
            else if (Request.Cookies["cart"] == null)
            {
                Master.MasterLabel.Text = "Please create a cart";
            }
            else if(cartGrid.Rows.Count == 0)
            {
                Master.MasterLabel.Text = "Ensure that you have items in your cart";
            }
            else
            {
                Response.Redirect("CheckOut.aspx");
            }
        }


        /// <summary>
        /// Calculating the tax and displaying it in the label
        /// </summary>
        private decimal CalculateTax()
        {
            string quantity;
            decimal total = 0;
            decimal tax = 0;

            const decimal taxRate = (decimal)0.15;

            foreach (GridViewRow row in cartGrid.Rows)
            {
                 quantity = ((Label)row.Cells[2].FindControl("lblSubtotal")).Text;

                quantity = quantity.Replace("$", "");
                quantity = quantity.Replace(",", "");

                total += Convert.ToDecimal(quantity);
            }

            tax = total * taxRate;

            lblTax.Text = tax.ToString("c");

            Response.Cookies["Tax"].Value = lblTax.Text;

            return tax;
        }

        /// <summary>
        /// Calculating the total and displaying it in the label
        /// </summary>
        private void CalculateTotal()
        {
            string quantity;
            decimal total = 0;

            foreach (GridViewRow row in cartGrid.Rows)
            {
                quantity = ((Label)row.Cells[2].FindControl("lblSubtotal")).Text;

                quantity = quantity.Replace("$", "");
                quantity = quantity.Replace(",", "");

                total += Convert.ToDecimal(quantity);
            }
            

            lblTotal.Text = (CalculateTax() + total).ToString("c");

            Response.Cookies["Total"].Value = lblTotal.Text;
        }

        protected void GetData()
        {
            MasterPage myMasterPage = (MasterPage)Page.Master;

            Repeater rptCategories = (Repeater)myMasterPage.FindControl("rptCategories");

            SqlDataReader dr = default(SqlDataReader);
            SqlCommand cmd = default(SqlCommand);
            try
            {
                using (_cnn)
                {
                    cmd = new SqlCommand("Fill_Categories", _cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    _cnn.Open();

                    dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    if (dr.HasRows)
                    {

                        rptCategories.DataSource = dr;
                        //don't forget to bind the data

                        rptCategories.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                //lblMessage.Text = ex.Message;
            }
            finally
            {
                //  dr.Close();
            }
        }
    }
}
