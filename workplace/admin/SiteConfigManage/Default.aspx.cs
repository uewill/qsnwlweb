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
using TFXK.Common;
using TFXK.Model;
using log4net;
using TFXK.BLL;

public partial class admin_SiteConfigManage_Default : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_SiteConfigManage_Default));
    private static readonly CategoryBLL bllCategory = new CategoryBLL();
    private SiteConfigBLL bllSiteConfig = new SiteConfigBLL();
    private bool falg = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDDLList();
            InitData();

        }

    }

    public void InitData()
    {

        string code = Request.QueryString["code"];
        if (string.IsNullOrEmpty(code)||code.Equals("wzyh"))
        {
            code = "wzyh";
        }
        ddlType.SelectedValue = code;
        SiteConfig model = bllSiteConfig.GetModel(code);
        if (model != null)
        {
            txtTitle.Value = model.title;
            txtMata.Value = model.mata;
            txtFooter.Value = model.footer;
            txtDescription.Value = model.description;
            hdfID.Value = code;
            ddlType.SelectedValue = code;
        }

    }

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        //验证代码
        try
        {
            SiteConfig tempModel = new SiteConfig();
            try
            {
                tempModel = bllSiteConfig.GetModel(hdfID.Value);
            }
            catch { }
            if (tempModel == null)
            {
                tempModel = new SiteConfig();
                tempModel.description = txtDescription.Value;
                tempModel.title = txtTitle.Value;
                tempModel.mata = txtMata.Value;
                tempModel.footer = txtFooter.Value;
                tempModel.codeNo = QueryStringHelper.GetString("code");
                bllSiteConfig.Add(tempModel);
            }
            else
            {

                tempModel.description = txtDescription.Value;
                tempModel.title = txtTitle.Value;
                tempModel.mata = txtMata.Value;
                tempModel.footer = txtFooter.Value;
                bllSiteConfig.Update(tempModel);
            }
            Msg.Show("保存成功！");
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            Msg.Show("网络错误!原因:" + ex.Message);
        }
    }
    #endregion

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx?code=" + ddlType.SelectedValue);
    }
    private void BindDDLList()
    {
        ddlType.DataSource = bllCategory.GetAllChildByCode("wzyh");
        ddlType.DataTextField = "title";
        ddlType.DataValueField = "codeNo";
        ddlType.DataBind();
    }
}
