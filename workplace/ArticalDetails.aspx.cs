using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ArticalDetails : System.Web.UI.Page
{
    private TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();
    private TFXK.BLL.ArticlesBLL bllArticles = new TFXK.BLL.ArticlesBLL();
    public TFXK.Model.Category currentCategory = new TFXK.Model.Category();
    public TFXK.Model.Category parentCategory = new TFXK.Model.Category();
    public string activeNav = "navHome";

    public TFXK.Model.Articles articles = new TFXK.Model.Articles();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ids = Request.QueryString["id"] + "";
            int id = 0;
            if (string.IsNullOrEmpty(ids) || !int.TryParse(ids, out id) || id <= 0)
            {
                Response.Redirect("/Default.aspx");
            }
            articles = bllArticles.GetModel(id);
            if (articles == null)
            {
                Response.Redirect("/Default.aspx");
            }
            bllArticles.UpdateClick(id);

            currentCategory = bllCategory.GetModel(articles.parentId);
            if (currentCategory != null)
            {
                LeftNavControl.navParentID = currentCategory.parentID;
                LeftNavControl.navCode = currentCategory.codeNo;
                LocationControl.currentCategory = currentCategory;

                parentCategory = bllCategory.GetModel(currentCategory.parentID);
                if (parentCategory != null)
                {
                    LocationControl.parentCategory = parentCategory;
                    LeftNavControl.navTitle = parentCategory.title;
                    Page.Title = articles.title + "-" + currentCategory.title + "-" + parentCategory.title;


                    activeNav = LocationControl.GetNavName();

                }
                else
                {
                    LeftNavControl.navTitle = currentCategory.title;
                    Page.Title = articles.title + "-" + currentCategory.title;
                }


            }
            else
            {
                Response.Redirect("~/");
            }
        }
    }
}