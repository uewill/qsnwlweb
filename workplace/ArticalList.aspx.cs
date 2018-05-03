using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

public partial class ArticalList : System.Web.UI.Page
{
    private TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();
    private TFXK.BLL.ArticlesBLL bllArticles = new TFXK.BLL.ArticlesBLL();
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
                code = "zxdt";
            }

            currentCategory = bllCategory.GetModel(code);
            if (currentCategory != null)
            {
                LeftNavControl.navParentID = currentCategory.parentID;
                LeftNavControl.navCode = code;
                LocationControl.currentCategory = currentCategory;

                parentCategory = bllCategory.GetModel(currentCategory.parentID);
                if (parentCategory != null)
                {
                    LocationControl.parentCategory = parentCategory;
                    LeftNavControl.navTitle = parentCategory.title;
                    Page.Title = currentCategory.title + "-" + parentCategory.title;
                    activeNav = LocationControl.GetNavName();
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
    #region 分页绑定
    private void InitData(int PageIndex, string codeNo)
    {
        DataSet ds = new DataSet();
        int recordcount = 0; //获取总条数

        ds = bllArticles.GetAllListByCodeNo_Web(AspNetPager1.PageSize, PageIndex, codeNo, out recordcount);
        AspNetPager1.RecordCount = recordcount;
        AspNetPager1.CustomInfoHTML = "共<span class='red'>" + recordcount + "</span>条纪录";
        this.rptDataList.DataSource = ds;
        this.rptDataList.DataBind();
    }
    #endregion

    #region 分页控件加载
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string code = QueryStringHelper.GetString("code");
            if (string.IsNullOrEmpty(code))
            {
                code = "zxdt";
            }

            InitData(e.NewPageIndex, code);
        }

    }
    #endregion
}