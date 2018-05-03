using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : System.Web.UI.Page
{
    private TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();
    public TFXK.Model.Category currentCategory = new TFXK.Model.Category();
    public TFXK.Model.Category parentCategory = new TFXK.Model.Category();

    public string activeNav = "navHome";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string code = Request.QueryString["code"] + "";
            if (string.IsNullOrEmpty(code))
            {
                code = "zxly";
            }

            currentCategory = bllCategory.GetModel(code);
            if (currentCategory != null)
            {
                LocationControl.currentCategory = currentCategory;
                LeftNavControl.navParentID = currentCategory.parentID;
                LeftNavControl.navCode = code;
                parentCategory = bllCategory.GetModel(currentCategory.parentID);
                if (parentCategory != null)
                {
                    //set nav
                    LocationControl.parentCategory = parentCategory;
                    activeNav = LocationControl.GetNavName();

                    LeftNavControl.navTitle = parentCategory.title;
                    Page.Title = currentCategory.title + "-" + parentCategory.title;
                }
                else
                {
                    LeftNavControl.navTitle = currentCategory.title;
                    Page.Title = currentCategory.title;
                }


              
            }
            else
            {
                Response.Redirect("~/");
            }
        }
    }
}