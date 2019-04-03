using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace LampinAround
{
    public partial class Default : System.Web.UI.MasterPage
    {
        private string strConn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            bool IsAdmin;
            //string categoryid = Request.QueryString["CategoryID"];
            if (Session["IsAdmin"] != null)
            {
                IsAdmin = Convert.ToBoolean(Session["IsAdmin"]);
                if (IsAdmin)
                {
                    lnkAdmin.Visible = true;
                }
            }

            if (!IsPostBack)
            {
                this.MasterLabel.Text = val;
                //divErrorMessage.Visible = false;
                GetData();
            }


        }
        protected void GetData()
        {
            SqlDataReader dr = default(SqlDataReader);
            SqlCommand cmd = default(SqlCommand);
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    cmd = new SqlCommand("Fill_Categories", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

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
   
        public TextBox SearchBoxMaster
        {
            get
            {
                return txtSearch;
            }
        }
        public Button SearchButton
        {
            get
            {
                return this.btnMasterSend;
            }
        }
        public string SearchTerm
        {
            get
            {
                return this.txtSearch.Text;
            }
        }
        public Label MasterLabel
        {
            get
            {
                return lblMessage;
            }
        }

        private string val
        {
            get
            {
                return Request["val"] != null ? Request["val"].ToString() : "";
            }
        }
    }
}