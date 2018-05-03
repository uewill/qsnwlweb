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

public partial class admin_AdsManage_Action : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_AdsManage_Action));
    private static readonly AdsBLL bll = new AdsBLL();
    public int i = 0;

    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                InitAction();
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }

    }
    #endregion

    #region 绑定动作
    private void InitAction()
    {
        if (Request.QueryString["type"] != null)
        {
            string type = Request.QueryString["type"].ToString();
            // 判断动作
            switch (type)
            {
                case "add":
                    break;
                case "modify":
                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        InitData(id);
                    }
                    else
                    {
                        ArtDilog.AlertAndRefresh("参数错误！", 1, "addArt", "error");
                    }
                    break;
            }
            this.hdfAction.Value = type;
        }
        else
        {
            ArtDilog.AlertAndRefresh("参数错误！", 1, "addArt", "error");
        }
    }
    #endregion

    #region 绑定
    private void InitData(int id)
    {
        Ads model = bll.GetModel(id);
        if (model != null)
        {
            txtOrderby.Text = model.orderid + "";
            txtTitle.Text = model.title;
            txtLinkUrl.Text = model.linkUrl;
            ddlPicArea.SelectedValue = model.typeid + "";
            if (!string.IsNullOrEmpty(model.linkImage))
            {
                hdfImgPath.Value = model.linkImage;
                newsImg.Src = "../../uploads_thum/" + model.linkImage;
                newsImg.Attributes.CssStyle.Add("display", "block");
            };
            hdfPid.Value = id + "";
        }
    }
    #endregion

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            TFXK.Model.Ads model = new TFXK.Model.Ads();
            try
            {
                model.id = int.Parse(Request.QueryString["id"].ToString());
            }
            catch { model.id = 0; }
            model.title = txtTitle.Text;
            model.orderid = int.Parse(txtOrderby.Text);
            model.linkUrl = txtLinkUrl.Text;
            model.typeid = int.Parse(ddlPicArea.SelectedValue);

            if (hdfImgPath.Value.Length > 10)
            {
                model.linkImage = hdfImgPath.Value;
            }
            string type = this.hdfAction.Value.Trim();
            // 判断动作
            switch (type)
            {
                case "add":
                    Add(model);
                    break;
                case "modify":
                    Modify(model);
                    break;
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            ArtDilog.Alert("网络错误!原因:" + ex.Message, "error", 2);
        }
    }
    #endregion

    #region 添加
    private void Add(Ads model)
    {
        int rows = bll.Add(model);
        if (rows > 0)
        {
            ArtDilog.AlertAndRefresh("添加信息成功！", 1);
        }
        else
        {
            ArtDilog.Alert("添加信息失败!", "error", 2);
        }
    }
    #endregion

    #region 修改
    private void Modify(Ads model)
    {
        bll.Update(model);
        ArtDilog.AlertAndRefresh("修改信息成功！", 1);
    }
    #endregion
}
