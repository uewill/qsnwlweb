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

public partial class admin_ExamPersonManage_Action : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_ExamPersonManage_Action));
    private static readonly TFXK.BLL.TestingPersonExam bllCenter = new TFXK.BLL.TestingPersonExam();
    public TFXK.Model.TestingPersonExam dataModel = new TFXK.Model.TestingPersonExam();
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
        dataModel = bllCenter.GetModel(id);
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