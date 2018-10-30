using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Model;

public partial class Exam_personal_NewTesting : System.Web.UI.Page
{
    private TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();
    private TFXK.BLL.TestingPerson bllTestingPerson = new TFXK.BLL.TestingPerson();
    private TFXK.BLL.TestingPersonExam bllTestingPersonExam = new TFXK.BLL.TestingPersonExam();
    public TFXK.Model.TestingPerson testingPersonModel = new TFXK.Model.TestingPerson();
    private static readonly TFXK.BLL.TestingPersonPlan bllPlan = new TFXK.BLL.TestingPersonPlan();
    public TFXK.Model.TestingPersonPlan planModel = new TestingPersonPlan();
    private static readonly TFXK.BLL.ArticlesBLL articlesBLL = new TFXK.BLL.ArticlesBLL();
    public List<TFXK.Model.Category> subClassList = new List<Category>();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int exid = 0;
            int exInfoID = 0;
            if (int.TryParse(Request.QueryString["id"] + "", out exid) && exid > 0)
            {
                int.TryParse(Request.QueryString["tid"] + "", out exInfoID);

                InitExamData(exid);
                var data = ExamAuthHelper.GetAuthPersonID(this.Context);
                InitData(data, exInfoID);
            }
            else
            {
                Response.Redirect("Default.aspx");
                Response.End();
            }
        }

    }

    private void InitExamData(int exid)
    {
        planModel = bllPlan.GetModel(exid);
        if (planModel == null)
        {
            Response.Redirect("Default.aspx");
            Response.End();
        }

        subClassList = bllCategory.GetModelList(" id in(" + planModel.TestingSubClass + ")");

        ddlClass.DataSource = subClassList;
        ddlClass.DataBind();
    }

    private void InitData(int examid, int exInfoID)
    {
        //ddlClass.DataSource = bllCategory.GetNextNodeByCode("kjkmpz");
        //ddlClass.DataBind();
        ddlguoji.DataSource = bllCategory.GetNextNodeByCode("kjgj");
        ddlguoji.DataBind();
        ddlmingzu.DataSource = bllCategory.GetNextNodeByCode("kjmz");
        ddlmingzu.DataBind();
        if (exInfoID > 0)
        {
            var testingPersonModel = bllTestingPersonExam.GetModel(exInfoID);
            if (testingPersonModel.Status == 1)
            {//只允许未支付状态 修改
                Response.Redirect("ViewTestingPay.aspx");
                Response.End();
            }
            if (testingPersonModel.Status == 2)
            {//只允许未支付状态 修改
                Response.Redirect("ViewTesting.aspx");
                Response.End();
            }


            ddlguoji.SelectedValue = testingPersonModel.Country;
            ddlmingzu.SelectedValue = testingPersonModel.Mingzu;
            ddlSex.SelectedValue = testingPersonModel.Sex;
            txtUserName.Value = testingPersonModel.UserName;
            txtUserNamePy.Value = testingPersonModel.UserNamePY;
            txtPhoneNumber.Value = testingPersonModel.PhoneNumber;
            txtBirthday.Value = testingPersonModel.Birthday;
            txtContact.Value = testingPersonModel.Address.Replace("|", " "); ;
            txtjjcontact.Value = testingPersonModel.Contactor;
            txtjjship.Value = testingPersonModel.ContactorShip;
            txtjjphone.Value = testingPersonModel.ContactorPhone;
            txtjjaddress.Value = testingPersonModel.HomeAddress;
            txtZhiDao.Value = testingPersonModel.Zhidao;
            txtPostNo.Value = testingPersonModel.PostNo;
            ddlLevel.SelectedValue = testingPersonModel.HaveMaxLevel;
            hdfNumber.Value = testingPersonModel.ExamNumber;
            txtIDNumber.Value = testingPersonModel.IDNumber;
        }
        else
        {
            testingPersonModel = bllTestingPerson.GetModel(examid);
            ddlguoji.SelectedValue = testingPersonModel.Country;
            ddlmingzu.SelectedValue = testingPersonModel.Mingzu;
            ddlSex.SelectedValue = testingPersonModel.Sex;
            txtUserName.Value = testingPersonModel.UserName;
            txtUserNamePy.Value = testingPersonModel.UserNamePY;
            txtPhoneNumber.Value = testingPersonModel.PhoneNumber;
            txtBirthday.Value = testingPersonModel.Birthday;
            txtContact.Value = testingPersonModel.Address.Replace("|", " "); ;
            txtjjcontact.Value = testingPersonModel.Contactor;
            txtjjship.Value = testingPersonModel.ContactorShip;
            txtjjphone.Value = testingPersonModel.ContactorPhone;
            txtjjaddress.Value = testingPersonModel.HomeAddress;
            txtIDNumber.Value = testingPersonModel.IDNumber;
        }



        int recordcount = 0;
        rptDownload.DataSource = articlesBLL.GetAllListByCodeNo(10, 1, "bkzlxz", out recordcount);
        rptDownload.DataBind();



    }
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {

        TestingPersonExam examModel = new TestingPersonExam();
        examModel.UserName = txtUserName.Value.Trim();
        examModel.UserNamePY = txtUserNamePy.Value.Trim();
        examModel.PhoneNumber = txtPhoneNumber.Value;
        examModel.Birthday = txtBirthday.Value;
        examModel.Address = txtContact.Value;
        examModel.Contactor = txtjjcontact.Value;
        examModel.ContactorShip = txtjjship.Value;
        examModel.ContactorPhone = txtjjphone.Value;
        examModel.HomeAddress = txtjjaddress.Value;
        examModel.Sex = ddlSex.SelectedValue;
        examModel.Country = ddlguoji.SelectedValue;
        examModel.Mingzu = ddlmingzu.SelectedValue;
        examModel.ClassID = ddlClass.SelectedValue;
        examModel.ClassLevel = ddlLevel.SelectedValue;
        examModel.HaveMaxLevel = ddlHaveLevel.SelectedValue;
        examModel.MaxLevelNo = txtLevelNo.Value;
        examModel.Contactor = txtjjcontact.Value;
        examModel.ContactorShip = txtjjship.Value;
        examModel.HomeAddress = txtjjaddress.Value;
        examModel.IDNumber = txtIDNumber.Value;
        examModel.Zhidao = txtZhiDao.Value;
        examModel.Status = 0;
        examModel.PostNo = txtPostNo.Value;
        examModel.PersonID = ExamAuthHelper.GetAuthPersonID(this.Context);
        examModel.CreateTime = DateTime.Now;
        examModel.ExamNumber = hdfNumber.Value;
        examModel.TypeID = int.Parse(Request.QueryString["id"]);
        if (string.IsNullOrEmpty(examModel.UserName))
        {
            TFXK.Common.Jscript.Alert("用户名不能为空");
            return;
        }
        if (string.IsNullOrEmpty(examModel.UserNamePY))
        {
            TFXK.Common.Jscript.Alert("用户名拼音不能为空");
            return;
        }
        if (
             string.IsNullOrEmpty(examModel.Contactor))
        {
            TFXK.Common.Jscript.Alert("联系人不能为空");
            return;
        }
        if (string.IsNullOrEmpty(examModel.ContactorPhone))
        {
            TFXK.Common.Jscript.Alert("联系人电话不能为空");
            return;
        }
        int resId = 0;
        int exid = 0;
        if (int.TryParse(Request.QueryString["tid"] + "", out exid))
        {
            examModel.id = exid;
            bllTestingPersonExam.Update(examModel);
            resId = exid;
        }
        else
        {
            var planModel = bllPlan.GetModel(int.Parse(Request.QueryString["id"] + ""));
            if (bllTestingPersonExam.Exists(planModel.id, examModel.IDNumber))
            {
                TFXK.Common.Jscript.AlertAndRedirect("已存在报考记录，请确认", "ViewTestingPay.aspx?id=" + resId);
                return;
            }
            else
            {
                planModel.NumberIndex += 1;
                bllPlan.Update(planModel);
                examModel.ExamNumber = planModel.NumberPrefx + buildNumber(planModel.NumberStart, (planModel.NumberIndex) + "");

                resId = bllTestingPersonExam.Add(examModel);

            }

        }

        TFXK.Common.Jscript.AlertAndRedirect("报考成功", "ViewTestingPay.aspx?id=" + resId);
    }

    private string buildNumber(string vauleStr, string value)
    {
        int count = vauleStr.Length - value.Length;
        for (int i = 0; i < count; i++)
        {
            value = string.Format("0{0}", value);
        }

        return value;

    }


    public string GetSubCategoryName()
    {

        try
        {
            StringBuilder subStr = new StringBuilder();
            foreach (var model in subClassList)
            {
                subStr.Append(model.title + " ");
            }
            return subStr.ToString();
        }
        catch { }

        return string.Empty;

    }
}