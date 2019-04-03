using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace LampinAround
{
    public partial class adminPage : System.Web.UI.Page
    {
        private string strConn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCatId.DataTextField = "CategoryName";
                ddlCatId.DataValueField = "CategoryID";
                ddlProdName.DataTextField = "ProductName";
                ddlProdName.DataValueField = "ProductID";
                GetData("Get_Categories", ddlCatId);
                GetData("Get_Product_List", ddlProdName);
            }
            
        }

        private void GetData(string procedure, DropDownList ddl = null)
        {
            SqlCommand cmd = default(SqlCommand);
            SqlDataReader dr = default(SqlDataReader);
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand(procedure, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    if (procedure == "Get_Categories")
                    {
                        ddl.DataSource = dr;
                        ddl.DataBind();
                    }
                    else if (procedure == "Get_Product_List")
                    {
                        ddl.DataSource = dr;
                        ddl.DataBind();
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
        protected void SendData(string procedure, string id)
        {
            SqlCommand cmd = default(SqlCommand);
            SqlDataReader dr = default(SqlDataReader);
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand(procedure, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if(procedure == "Get_CategoryByID")
                    {
                        cmd.Parameters.AddWithValue("@CategoryID", id);
                        cmd.Connection.Open();

                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        txtCatDescription.Text = dt.Rows[0]["CategoryDescription"].ToString();
                        txtCatName.Text = dt.Rows[0]["CategoryName"].ToString();
                    }
                    else if(procedure == "Get_Detailed_Product")
                    {
                        cmd.Parameters.AddWithValue("@ProductID",id);
                        cmd.Connection.Open();

                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        txtProductName.Text = dt.Rows[0]["ProductName"].ToString();
                        
                        txtPrice.Text = dt.Rows[0]["Price"].ToString();
                        txtFullDescription.Text = dt.Rows[0]["FullDescription"].ToString();
                        //make dropbox
                        txtProductStatus.Text = dt.Rows[0]["ProductStatus"].ToString();
                        txtFeatured.Text = Convert.ToBoolean(dt.Rows[0]["Featured"]).ToString();
                        txtCategoryID.Text = dt.Rows[0]["CategoryID"].ToString();
                    }
                    else if(procedure == "Update_Category")
                    {
                        cmd = new SqlCommand(procedure, conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (ddlCatId.SelectedItem.Text == "Add Category")
                        {
                            cmd.Parameters.AddWithValue("@CategoryId", "1");
                            cmd.Parameters.AddWithValue("@CategoryName", txtCatName.Text);
                            cmd.Parameters.AddWithValue("@CategoryDescription", txtCatDescription.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@CategoryName", txtCatName.Text);
                            cmd.Parameters.AddWithValue("@CategoryDescription", txtCatDescription.Text);
                            cmd.Parameters.AddWithValue("@CategoryId", id);
                        }
                        cmd.Connection.Open();

                        cmd.ExecuteNonQuery();
                    }
                    else if(procedure == "Update_Product")
                    {
                        cmd = new SqlCommand("Update_Product", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CategoryId", id);
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@FullDescription", txtFullDescription.Text);
                        cmd.Parameters.AddWithValue("@ProductStatus", txtProductStatus.Text);
                        cmd.Parameters.AddWithValue("@Featured", txtFeatured.Text);
                        cmd.Parameters.AddWithValue("@Price", Convert.ToDouble(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@CategoryID", txtCategoryID.Text);


                        cmd.Connection.Open();

                        cmd.ExecuteNonQuery();
                    }

                    Response.Redirect("adminPage.aspx");
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
        protected void ddlProdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if selected value != null
            SendData("Get_Detailed_Product", ddlProdName.SelectedValue);
        }

        protected void ddlCatId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if selected value != null

            SendData("Get_CategoryByID", ddlCatId.SelectedValue);
            //txtCatDescription.Text = dtCategories.Rows[0]["CategoryDescription"].ToString();
        }

        protected void btnSaveCategory_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //add if statement for adding new product
                SendData("Update_Category", ddlCatId.SelectedValue);
            }

            
            
        }
        protected void btnSaveToDatabase_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {   //add if statement for adding new product
                SendData("Update_Product", ddlCatId.SelectedValue);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = default(SqlCommand);
        
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand("Delete_Category", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CategoryId", ddlCatId.SelectedValue);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("adminPage.aspx");
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = default(SqlCommand);

            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand("Delete_Product", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductID", ddlProdName.SelectedValue);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("adminPage.aspx");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}