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

public partial class admin_UserJiamenManage_Action : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_UserJiamenManage_Action));
    private static readonly TFXK.BLL.TestingCenter bll = new TFXK.BLL.TestingCenter();
    public TFXK.Model.TestingCenter userOModel = new TFXK.Model.TestingCenter();
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

        int id = int.Parse(Request.QueryString["id"].ToString());
        if (id > 0)
        {
            InitData(id);
        }
        else
        {
            Response.Redirect("Default.aspx", false);
        }
    }
    #endregion

    #region 绑定
    private void InitData(int id)
    {
        userOModel = bll.GetModel(id);
        ddlState.SelectedValue = userOModel.Status + "";
        txtUserName.Text = userOModel.UserName;
        txtUserPhone.Text = userOModel.UserPhone;
        txtUserEmail.Text = userOModel.UserEmail;
    }
    #endregion

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        //验证代码
        try
        {
            TFXK.Model.TestingCenter model = new TFXK.Model.TestingCenter();
            try
            {
                model.id = int.Parse(Request.QueryString["id"].ToString());
            }
            catch { model.id = 0; }

            if (model.id > 0)
            {
                model = bll.GetModel(model.id);
                model.Status = ddlState.SelectedIndex;
                model.UserName = txtUserName.Text;
                model.UserPhone = txtUserPhone.Text;
                model.UserEmail = txtUserEmail.Text;
                if (chkChangePass.Checked && !string.IsNullOrEmpty(txtPass.Text.Trim()))
                {
                    model.UserPass = Security.EncryptDES(txtPass.Text.Trim(), "UEMASTER");
                }
                Modify(model);
            }


        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            Msg.Show("网络错误!原因:" + ex.Message);
        }
    }
    #endregion


    #region 修改
    private void Modify(TFXK.Model.TestingCenter model)
    {
        bll.Update(model);
        Msg.ShowAndRedirect("修改信息成功!", "Default.aspx");
    }
    #endregion

    #region 返回
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }
    #endregion

}
