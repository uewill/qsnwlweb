using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Common;

public partial class Exam_ExamPlan : System.Web.UI.Page
{
    public string testCenterName = string.Empty;
    private TFXK.BLL.TestingPlan bllTestingPlan = new TFXK.BLL.TestingPlan();
    private TFXK.BLL.TestingStudent bllTestingStudent = new TFXK.BLL.TestingStudent();
    private TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();
    public string isReadOnly = "false";
    public string auditMsg = "请等待通知";
    public string noticeMsg = "请等待通知";
    public string payMsg = "请等待通知";
    public string getMsg = "请等待通知";

    protected void Page_Load(object sender, EventArgs e)
    {
        var auth = ExamAuthHelper.GetAuthData(this.Context);
        testCenterName = auth.KDName;
        if (!IsPostBack)
        {
            int exid = 0;
            if (int.TryParse(Request.QueryString["id"] + "", out exid) && exid > 0)
            {
                InitData(exid);
            }
            else
            {
                SetStep(1);
            }

        }
    }

    private void InitData(int exid)
    {
        var currentCenterID = ExamAuthHelper.GetAuthCenterID(this.Context);
        var model = bllTestingPlan.GetModel(exid);
        if (model.CenterID != currentCenterID)
        {
            Response.Redirect("ExamPlanList.aspx");
        }
        txtTime.Value = model.TestingTime;
        txtClass.Value = model.TestingClass;
        txtAddress.Value = model.Address;
        txtContact.Value = model.Contactor;
        txtDes.Value = model.Description;
        txtRoad.Value = model.AddresDes;
        auditMsg = bllCategory.GetModel("kjshz").description;
        if (model.Status >= 1)
        {
            noticeMsg = model.AuditDescription;
        }
        if (model.Status != 0)
        {
            txtTime.Disabled = true;
            txtClass.Disabled = true;
            txtAddress.Disabled = true;
            txtContact.Disabled = true;
            txtDes.Disabled = true;
            txtRoad.Disabled = true;
            btnSave.Visible = false;
        }
        if (model.Status == 0)
        {
            SetStep(2);
        }
        else if (model.Status == 1)
        {
            SetStep(3);
        }
        else if (model.Status == 2)
        {
            SetStep(4);
            //支付

            int count = bllTestingStudent.GetRecordCount("planid=" + model.id);
            payMsg = string.Format("共<b>{0}</b>位学员参加考试,请联系我们进行考试费用支付。", count);
        }
        else if (model.Status == 3)
        {
            SetStep(5);
        }
        else
        {
            SetStep(1);
        }
    }
    private void SetStep(int id)
    {
        Page page = (Page)HttpContext.Current.Handler;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "", "<script>setSetp(" + id + ")</script>", false);
    }

    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        TFXK.Model.TestingPlan model = new TFXK.Model.TestingPlan();
        model.TestingTime = txtTime.Value.Trim();
        model.TestingClass = txtClass.Value.Trim();
        model.Address = txtAddress.Value.Trim();
        model.Contactor = txtContact.Value.Trim();
        model.Description = txtDes.Value.Trim();
        model.AddresDes = txtRoad.Value.Trim();
        model.Status = 0;
        model.NoticeConfirm = 0;
        if (string.IsNullOrEmpty(model.TestingTime))
        {
            Msg.Show("考试时间不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(model.TestingClass))
        {
            Msg.Show("考试科目不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(model.Address))
        {
            Msg.Show("考试地点不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(model.Contactor))
        {
            Msg.Show("联系人不能为空!");
            return;
        }

        model.CenterID = ExamAuthHelper.GetAuthCenterID(this.Context);
        if (bllTestingPlan.Add(model))
        {
            Msg.ShowAndRedirect("添加成功!", "ExamPlanList.aspx");
        }
    }
}