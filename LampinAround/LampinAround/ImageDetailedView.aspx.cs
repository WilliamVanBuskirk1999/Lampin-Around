using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace LampinAround
{
    public partial class ImageDetailedView : System.Web.UI.Page
    {
        private readonly string _strConn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string image = Request.QueryString["ImageID"];
            if (!IsPostBack)
            {
                LoadDetailView(image);
            }
        }
        private void LoadDetailView(string img)
        {
            SqlCommand cmd = default(SqlCommand);
            SqlDataReader dr = default(SqlDataReader);
            try
            {
                using (SqlConnection conn = new SqlConnection(_strConn))
                {
                    cmd = new SqlCommand("Get_Detailed_Image", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImageID", img);

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

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                int imageId = Convert.ToInt32(Request.QueryString["ImageID"]);
                using (SqlConnection conn = new SqlConnection(_strConn))
                {
                    SqlCommand cmd = new SqlCommand("VerifyImage", conn)
                    {
                       CommandType =  CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@ImageID", imageId);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Label lblImageName = (Label)rptDetailView.Items[0].FindControl("lblName");
                        string originalpath = Server.MapPath("~/TempImages/" + lblImageName.Text);
                        string newPath = Server.MapPath ("~/images/" + lblImageName.Text);

                        File.Move(originalpath, newPath);
                    }
                    conn.Close();
                }

            }
                
            catch(Exception ex)
            {

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int imageId = Convert.ToInt32(Request.QueryString["ImageID"]);
                using (SqlConnection conn = new SqlConnection(_strConn))
                {
                    SqlCommand cmd = new SqlCommand("DeleteImage", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@ImageID", imageId);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();

                    if(result > 0)
                    {
                        Label lblImageName = (Label)rptDetailView.Items[0].FindControl("lblName");
                        File.Delete(Server.MapPath("~/TempImages/" + lblImageName.Text));
                        
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
