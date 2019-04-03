using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Data;
using System.Configuration;

namespace LampinAround
{
    public partial class ManageImages : System.Web.UI.Page
    {
        private string imgName = "";
        private readonly string _strConn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if(uplPics.HasFile == true)
                {
                    //Allowing the user to choose a file name
                    string imgPath = "";
                    
                    string extension = Path.GetExtension(uplPics.PostedFile.FileName);
                    if (txtImgName.Text != "")
                    {
                        imgPath = Server.MapPath("~/TempImages") + "\\" + txtImgName.Text + extension;
                        imgName = txtImgName.Text + extension;
                    }
                    else
                    {
                        imgPath = Server.MapPath("~/TempImages") + "\\" + uplPics.FileName;
                        imgName = uplPics.FileName;
                    }

                    //Setting a path incase the file exists
                    string pathForExisting = Server.MapPath("~/TempImages") + "\\";

                   

                    System.Drawing.Image img = System.Drawing.Image.FromStream(uplPics.PostedFile.InputStream);

                    bool imgSaved = false;

                    string tempFileName = "";

                    if (System.IO.File.Exists(imgPath))
                    {
                        int counter = 2;

                        while (System.IO.File.Exists(imgPath))
                        {
                            tempFileName = counter.ToString() + imgName;
                            imgPath = pathForExisting + tempFileName;
                            counter++;
                        }

                        imgName = tempFileName;

                        if (ImageFormat.Jpeg.Equals(img.RawFormat))
                        {
                            doSaveImage(imgPath);
                            InsertImageIntoDB(imgName);
                        }
                        else if (ImageFormat.Png.Equals(img.RawFormat))
                        {
                            doSaveImage(imgPath);
                            InsertImageIntoDB(imgName);
                        }
                        else
                        {
                            lblMessage.Text = "Not a valid image. Please try again.";
                        }

                        lblMessage.Text = "There was an existing image with the same name. Your file was saved as " + imgName;
                    }
                    else
                    {
                        if (ImageFormat.Jpeg.Equals(img.RawFormat))
                        {
                            imgSaved = doSaveImage(imgPath);
                            InsertImageIntoDB(imgName);
                        }
                        else if (ImageFormat.Png.Equals(img.RawFormat))
                        {
                            imgSaved = doSaveImage(imgPath);
                            InsertImageIntoDB(imgName);
                        }
                        else
                        {
                            lblMessage.Text = "The file uploaded was not in the correct format";
                        }
                    }

                }
            }
            catch(Exception ex)
            {

            }
        }

        protected Boolean doSaveImage(string imgPath)
        {
            if (File.Exists(imgPath))
            {
                lblMessage.Text = "<h3> That file already exists. Please select a different file </h3>";
            }
            else
            {
                uplPics.SaveAs(imgPath);
                lblMessage.Text = "File uploaded to: " + imgPath;

                imgUploaded.ImageUrl = "~/TempImages/" + imgName;

                int nameLength = uplPics.FileName.Length;
                int intRem = nameLength - 4;

                string strNoExtension = uplPics.FileName.Substring(0, nameLength - 3);

                if (txtAlt.Text == "")
                {
                    imgUploaded.AlternateText = strNoExtension;
                }
                else
                {
                    imgUploaded.AlternateText = txtAlt.Text;
                }
                imgUploaded.Visible = true;
            }
            return true;
        }

        protected void InsertImageIntoDB(string imageName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_strConn))
                {

                    SqlCommand cmd = new SqlCommand("InsertImage", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@ImageName", imageName);
                    cmd.Parameters.AddWithValue("@Alttext", txtAlt.Text);




                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}