using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_LeftNavControl : System.Web.UI.UserControl
{
    TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();
    TFXK.BLL.ArticlesBLL bllArticles = new TFXK.BLL.ArticlesBLL();

    public string navTitle = string.Empty;
    public string navCode = string.Empty;
    public int navParentID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var navList = bllCategory.GetNextNodeByID_web(navParentID);
            rptNavList.DataSource = navList;
            rptNavList.DataBind();
            int rowCount = 0;
            var adList = bllArticles.GetAllListByCodeNo_Web(10, 1, "sygg", out rowCount);
            rptAdList.DataSource = adList;
            rptAdList.DataBind();

        }
    }

    public string GetItemURL(string type, string code)
    {
        var currentPage =string.Empty;

        if (code.Equals("rygw") || code.Equals("gldw")||code.Equals("zxxq"))
        {
            currentPage = "PicList.aspx?code=" + code;
        }
        else if (type.Equals("0"))
        {
            currentPage = "About.aspx?code=" + code;
        }
        else if (type.Equals("1"))
        {
            currentPage = "ArticalList.aspx?code=" + code;
        }
        else if (type.Equals("2"))
        {
            currentPage = "PicList.aspx?code=" + code;
        }

        return currentPage;

    }
}