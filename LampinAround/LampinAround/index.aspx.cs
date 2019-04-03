using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;

namespace LampinAround
{
    public partial class index : System.Web.UI.Page
    {
        private string strConn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Master.TheDiv.Visible = true;
            //Master.ErrorLabel.Text = "Hello";
            
            //addCategory.Visible = false;
            Master.SearchButton.Click += SearchButton_Click;
            Master.SearchButton.Visible = true;
            //rptProductsMainPage.Visible = false;
            if (!IsPostBack)
            {
                FillFeaturedProducts();
            
                

            }
            
            string categoryid = Request.QueryString["CategoryID"];

            if (!string.IsNullOrEmpty(categoryid))
            {
                GetProductsByCategory(categoryid);
                rptProductsMainPage.Visible = true;
          
               
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            FillFeaturedProductsWithSearch(Master.SearchTerm);
        }

        private void FillFeaturedProductsWithSearch(string prod)
        {
            SqlCommand cmd = default(SqlCommand);
            SqlDataReader dr = default(SqlDataReader);
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand("Search_For_Product", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SearchParam", prod);

                    conn.Open();

                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    if (dr.HasRows)
                    {
                        rptProductsMainPage.Visible = true;
                        rptProductsMainPage.DataSource = dr;
                        rptProductsMainPage.DataBind();
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

        private void FillFeaturedProducts()
        {
            SqlCommand cmd = default(SqlCommand);
            SqlDataReader dr = default(SqlDataReader);

            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand("Load_Featured_Products", conn);

                    conn.Open();

                    dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    if (dr.HasRows)
                    {
                        rptProductsMainPage.DataSource = dr;
                        rptProductsMainPage.DataBind();
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

            }
        }
        //protected void GetCategories()
        //{
        //    SqlDataReader dr = default(SqlDataReader);
        //    SqlCommand cmd = default(SqlCommand);
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(strConn))
        //        {
        //            cmd = new SqlCommand("Fill_Categories", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            conn.Open();

        //            dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

        //            if (dr.HasRows)
        //            {
        //                rptCategories.DataSource = dr;
        //                //don't forget to bind the data

        //                rptCategories.DataBind();

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //lblMessage.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        //  dr.Close();
        //    }
        //}


        private void GetProductsByCategory(string prod)
        {
            SqlCommand cmd = default(SqlCommand);
            SqlDataReader dr = default(SqlDataReader);
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand("Display_Category", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryId", prod);

                    conn.Open();

                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    if (dr.HasRows)
                    {
                        //rptFromCategorie.Visible = true;
                        rptProductsMainPage.DataSource = dr;
                        rptProductsMainPage.DataBind();
                        //get category name from stored procedure
                        while (dr.Read())
                        {
                            h1PageLabel.InnerText = dr[1].ToString();
                        }
                    }
                    else
                    {
                        rptProductsMainPage.DataSource = null;
                        rptProductsMainPage.DataBind();
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

    }
}