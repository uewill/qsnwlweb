using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TFXK.Model;
using TFXK.BLL;
using TFXK.Common;
using log4net;

public partial class admin_AdsManage_Default : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_AdsManage_Default));
    private static readonly AdsBLL bll = new AdsBLL();
    private static readonly CategoryBLL cbll = new CategoryBLL();

    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion

    #region 分页绑定
    private void InitData(int PageIndex, string name)
    {
        DataSet ds = new DataSet();
        int recordcount = 0; //获取总条数

        if (!string.IsNullOrEmpty(name))
        {
            try
            {
                txtSearchName.Text = name;

            }
            catch { }

            string where = "1=1";
            if (!string.IsNullOrEmpty(name))
            {
                where += " and title like '%" + name + "%'";
            }
            ds = bll.GetList(AspNetPager1.PageSize, PageIndex, where, out recordcount);
        }
        else
        {
            ds = bll.GetList(AspNetPager1.PageSize, PageIndex, "", out recordcount);
        }
        AspNetPager1.RecordCount = recordcount;
        this.rptBind.DataSource = ds.Tables[0].DefaultView;
        this.rptBind.DataBind();
    }
    #endregion

    #region 分页控件加载
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                string name = string.Empty;
                if (!string.IsNullOrEmpty(Request.QueryString["title"]))
                {
                    name = Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["title"]));
                }
                InitData(e.NewPageIndex, name);
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion


    #region 搜索按钮
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string name = this.txtSearchName.Text;
            Response.Redirect("Default.aspx?title=" + name, false);
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion


    public string GetTypeName(object obj)
    {
        switch (obj + "")
        {
            case "0":
                return "全站导航下广告(1000*76/auto)";
            case "8":
                return "首页导航下广告(1000*76/auto)";
            case "1":
                return "首页左侧广告切换(245*224)";
            case "2":
                return "首页左侧公司简介下广告(247*94)";
            case "3":
                return "首页公司简介下右侧(740*94)";
            case "4":
                return "首页百科上面广告(247*94)";
            case "5":
                return "合作单位上面广告(740*94)";
            case "6":
                return "友情链接上广告(1000*96/auto)";
            case "7":
                return "产品中心右侧广告(247*auto)"; 
            case "9":
                return "蜀国布衣首页右侧(217*209)";
            case "10":
                return "首页右侧最新活动下(247*94)";
            default:
                return "";
                break;
        }
    }

    public string GetImg(object obj)
    {
        if (!string.IsNullOrEmpty(obj + ""))
        {
            return "<img src='../../uploads_thum/" + obj + "' width='100px' height='50px' />";
        } return "";
    }
}
