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

public partial class admin_UserManage_ModfyPass : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_UserManage_ModfyPass));
    private static readonly UsersBLL bll = new UsersBLL();
    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["userName"] != null)
                {
                    string userName = Request.QueryString["userName"];
                    InitData(userName);
                }
                else
                {
                    Response.Redirect("ModfyPass.aspx?userName=" + Context.User.Identity.Name, false);
                }
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }

    }
    #endregion

    #region 绑定
    private void InitData(string userName)
    {
        this.lblUserName.Text = userName;
    }
    #endregion

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            TFXK.Model.Users model = new TFXK.Model.Users();
            model.userName = Request.QueryString["userName"].ToString();
            model.password = txtPass2.Text;

            try
            {
                bll.UpdatePassword(model);
                Msg.ShowAndRedirect("修改信息成功!", "Default.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("出现错误,错误信息：" + ex.Message);
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            Msg.Show("网络错误!原因:" + ex.Message);
        }
    }
    #endregion

    #region 返回
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }
    #endregion
}
