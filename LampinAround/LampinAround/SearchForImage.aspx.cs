using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace LampinAround
{
    public partial class VerifyImage : System.Web.UI.Page
    {
        private readonly string _strConn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_strConn))
                {

                    SqlDataReader dr = default(SqlDataReader);
                    SqlCommand cmd = new SqlCommand("SearchForImage", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@SearchParam",txtSearch.Text);




                    conn.Open();

                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    if (dr.HasRows)
                    {
                        rptResults.DataSource = dr;
                        rptResults.DataBind();
                    }
                    

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}