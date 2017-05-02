using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using System.IO;

namespace WebApp3001_2
{
    public partial class Metal_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["type"] != "administrator")
            {
                Response.Redirect("~/Login.aspx");
            }
            string selectedValue = ddlImage.SelectedValue;
            ShowImages();
            ddlImage.SelectedValue = selectedValue;
        }

        private void ShowImages()
        {
            //Get all filepaths
            string[] images = Directory.GetFiles(Server.MapPath("~/Imgs"));

            //Get all filenames and add them to an arraylist
            ArrayList imageList = new ArrayList();

            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\") + 1);
                imageList.Add(imageName);
            }

            //Set the arrayList as the dropdownview's datasource and refresh
            ddlImage.DataSource = imageList;
            ddlImage.DataBind();
        }

        private void ClearTextFields()
        {
            txtType.Text = "";
            txtPrice.Text = "";
            txtWeight.Text = "";
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/Imgs") + filename);
                lblResult.Text = "Image " + filename + " succesfully uploaded!";
                Page_Load(sender, e);
            }
            catch (Exception)
            {
                lblResult.Text = "Upload failed!";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                string type = txtType.Text;
                double price = Convert.ToDouble(txtPrice.Text);
                price = price / 100;
                string weight = txtWeight.Text;
                string image = "~/Imgs" + ddlImage.SelectedValue;

                Metals metals = new Metals(type, price, weight, image);
                ConnectionClass.AddMetal(metals);
                lblResult.Text = "Upload succesful!";
                ClearTextFields();
            }
            catch (Exception)
            {
                lblResult.Text = "Upload failed!";
            }
        }

        
    }
}