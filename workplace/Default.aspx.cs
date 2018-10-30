using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    TFXK.BLL.ArticlesBLL bllArtical = new TFXK.BLL.ArticlesBLL();
    TFXK.BLL.LinkBLL bllLink = new TFXK.BLL.LinkBLL();

    TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();

    public string isShowAd = "none";
    public string skimg = "images/nopic.jpg";
    public string skdes = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "首页";
        if (!IsPostBack)
        {
            InitData();
        }
    }
    private void InitData()
    {
        int count = 0;
        var data = bllArtical.GetAllListByCodeNo_Web(5, 1, "wzlm", "isOutlLink=1", out count);
        rptTuiJian.DataSource = data;
        rptTuiJian.DataBind();
        rptTuiJianNav.DataSource = data;
        rptTuiJianNav.DataBind();

        rptNewsList.DataSource = bllArtical.GetAllListByCodeNo_Web(10, 1, "xwzx", out count);
        rptNewsList.DataBind();

        rptZPZS.DataSource = bllArtical.GetAllListByCodeNo_Web(12, 1, "zpzs", out count);
        rptZPZS.DataBind();

        rptXGWJ.DataSource = bllArtical.GetAllListByCodeNo_Web(10, 1, "xgwj", out count);
        rptXGWJ.DataBind();

        rptKJBZ.DataSource = bllArtical.GetAllListByCodeNo_Web(10, 1, "kjbz", out count);
        rptKJBZ.DataBind();

        rptSYGG.DataSource = bllArtical.GetAllListByCodeNo_Web(5, 1, "sygg", out count);
        rptSYGG.DataBind();
        if (count > 0) {
            isShowAd = "true";
        }

        //rptYSKJ.DataSource = bllArtical.GetAllListByCodeNo_Web(4, 1, "yskjzy", out count);
        //rptYSKJ.DataBind();

        //rptSKZXDT.DataSource = bllArtical.GetAllListByCodeNo_Web(8, 1, "skzxdt", out count);
        //rptSKZXDT.DataBind();

        //rptZXXQ.DataSource = bllArtical.GetAllListByCodeNo_Web(4, 1, "zxxq", out count);
        //rptZXXQ.DataBind();

        //rptGLDW.DataSource = bllArtical.GetAllListByCodeNo_Web(3, 1, "gldw", out count);
        //rptGLDW.DataBind();

        rptLink.DataSource = bllLink.GetAllList();
        rptLink.DataBind();


        //var model = bllCategory.GetModel("skryb");
        //skimg = "/uploads/" + model.imgPath;
        //skdes = model.description;
    }
    public string GetFirstNews(int index, string title)
    {
        if (index == 0)
        {
            return string.Format("<b>{0}</b>", title);
        }
        return title;
    }
}