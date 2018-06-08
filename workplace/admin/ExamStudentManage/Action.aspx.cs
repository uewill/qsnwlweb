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

public partial class admin_ExamPlanManage_Action : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_ExamPlanManage_Action));
    private static readonly TFXK.BLL.TestingPlan bll = new TFXK.BLL.TestingPlan();
    private static readonly TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();
    private static readonly TFXK.BLL.TestingCenter bllCenter = new TFXK.BLL.TestingCenter();
    public TFXK.Model.TestingPlan userOModel = new TFXK.Model.TestingPlan();
    public string KJName = string.Empty;
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
        var centerModel = bllCenter.GetModel(userOModel.CenterID);
        KJName = centerModel.KDName;
        if (string.IsNullOrEmpty(userOModel.AuditDescription))
        {
            userOModel.AuditDescription = bllCategory.GetModel("aptzmb").description;
        }

        txtAuditDes.Value = userOModel.AuditDescription;
        //txtUserName.Text = userOModel.UserName;
        //txtUserPhone.Text = userOModel.UserPhone;
        //txtUserEmail.Text = userOModel.UserEmail;
    }
    #endregion

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        //验证代码
        try
        {
            TFXK.Model.TestingPlan model = new TFXK.Model.TestingPlan();
            try
            {
                model.id = int.Parse(Request.QueryString["id"].ToString());
            }
            catch { model.id = 0; }

            if (model.id > 0)
            {
                model = bll.GetModel(model.id);
                model.Status = ddlState.SelectedIndex;
                model.AuditDescription = txtAuditDes.Value.Trim();
                //model.UserPhone = txtUserPhone.Text;
                //model.UserEmail = txtUserEmail.Text;
                //if (chkChangePass.Checked && !string.IsNullOrEmpty(txtPass.Text.Trim()))
                //{
                //    model.UserPass = Security.EncryptDES(txtPass.Text.Trim(), "UEMASTER");
                //}
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
    private void Modify(TFXK.Model.TestingPlan model)
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

    public string getNoticeStatus(string status)
    {
        switch (status)
        {
            case "0":
                return "未确认";
            case "1":
                return "已确认,上门领取";
            case "2":
                return "已确认,快递取件";
            default:
                return "未确认";
        }
    }
    public string getStatusName(string status)
    {
        switch (status)
        {
            case "0":
                return "未确认";
            case "1":
                return "已审核";
            case "2":
                return "已提交考生信息";
            case "3":
                return "已通知考试结果";
            default:
                return "其他";
        }
    }
}