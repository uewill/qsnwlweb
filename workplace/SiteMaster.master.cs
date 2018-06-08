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

    private SiteConfigBLL bllSiteConfig = new SiteConfigBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        model = bllSiteConfig.GetModel("wzyh");
        if (model == null)
        {
            model = new SiteConfig();
        }
    }
}
