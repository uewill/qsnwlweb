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
using System.IO;

using TFXK.Model;
using TFXK.BLL;
using TFXK.Common;
using log4net;

public partial class admin_MessagesManage_Action : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_MessagesManage_Action));
    private static readonly MessagesBLL bll = new MessagesBLL();
    public Messages tempMessage = new Messages();

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
        InitData(int.Parse(Request.QueryString["id"] + ""));
    }
    #endregion

    #region 绑定
    private void InitData(int id)
    {
        tempMessage = bll.GetModel(id);
        ddlState.SelectedValue = tempMessage.stateid + "";
        txtReplay.Value = tempMessage.recontent;

    }
    #endregion

    #region 添加/修改

    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        tempMessage = bll.GetModel(int.Parse(Request.QueryString["id"] + ""));
        tempMessage.recontent = txtReplay.Value;
        tempMessage.stateid = ddlState.SelectedIndex;
        bll.Update(tempMessage);
    }
    #endregion

    #region 返回
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }
    #endregion
}
