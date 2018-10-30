using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.BLL;
using TFXK.Model;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    public string footerstr = string.Empty;
    public SiteConfig model;
    public string isShowAd = "none";

    TFXK.BLL.ArticlesBLL bllArtical = new TFXK.BLL.ArticlesBLL();
    private SiteConfigBLL bllSiteConfig = new SiteConfigBLL();
    TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        model = bllSiteConfig.GetModel("wzyh");
        if (model == null)
        {
            model = new SiteConfig();
        }



        int count = 0;
        rptSYGG.DataSource = bllArtical.GetAllListByCodeNo_Web(5, 1, "banner", out count);
        rptSYGG.DataBind();
        if (count > 0)
        {
            isShowAd = "true";
        }

        rptNavNews.DataSource = bllCategory.GetNextNodeByCode("xwzx");
        rptNavNews.DataBind();
        rptzpzs.DataSource = bllCategory.GetNextNodeByCode("zpzsclass");
        rptzpzs.DataBind();

        rptLXWM.DataSource = bllCategory.GetNextNodeByCode("zxgk");
        rptLXWM.DataBind();

        rptdqtk.DataSource = bllCategory.GetNextNodeByCode("dqtk2");
        rptdqtk.DataBind();
        



    }


    public string GetNavLink(object code, object type)
    {
        string currentPage = string.Empty;
        if (type.ToString().Equals("0"))
        {
            currentPage = "About.aspx?code=" + code;
        }
        else if (type.ToString().Equals("1"))
        {
            currentPage = "ArticalList.aspx?code=" + code;
        }
        else if (type.ToString().Equals("2"))
        {
            currentPage = "PicList.aspx?code=" + code;
        }
        return currentPage;
    }
}
