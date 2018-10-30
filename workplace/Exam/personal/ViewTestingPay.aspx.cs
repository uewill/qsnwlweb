using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Model;

public partial class Exam_personal_ViewTestingPay : System.Web.UI.Page
{
    private TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();
    private TFXK.BLL.TestingPerson bllTestingPerson = new TFXK.BLL.TestingPerson();
    private TFXK.BLL.TestingPersonExam bllTestingPersonExam = new TFXK.BLL.TestingPersonExam();
    public TFXK.Model.TestingPerson testingPersonModel = new TFXK.Model.TestingPerson();
    private static readonly TFXK.BLL.TestingPersonPlan bllPlan = new TFXK.BLL.TestingPersonPlan();
    public TFXK.Model.TestingPersonPlan planModel = new TestingPersonPlan();
    private static readonly TFXK.BLL.ArticlesBLL articlesBLL = new TFXK.BLL.ArticlesBLL();
    public TFXK.Model.TestingPersonExam examModel = new TestingPersonExam();
    public TFXK.Model.Category bkfysmCategory = new Category();
    public string NeedPayTotal = "0.00";

    protected void Page_Load(object sender, EventArgs e)
    {


        int exid = 0;
        if (int.TryParse(Request.QueryString["id"] + "", out exid) && exid > 0)
        {

            InitExamData(exid);
            //var data = ExamAuthHelper.GetAuthPersonID(this.Context);
            //InitData(data);
            bkfysmCategory = bllCategory.GetModel("bkfysm");
        }
        else
        {
            Response.Redirect("Default.aspx");
            Response.End();
        }


    }

    private void InitExamData(int exid)
    {

        examModel = bllTestingPersonExam.GetModel(exid);
        if (examModel.TypeID != null && examModel.TypeID.Value != 0)
        {
            planModel = bllPlan.GetModel(examModel.TypeID.Value);
            if (planModel == null)
            {
                Response.Redirect("Default.aspx");
                Response.End();
            }

            NeedPayTotal = GetPayMoney(examModel.TypeID + "", examModel.ClassLevel).ToString("n2");

        }
    }
    public double GetPayMoney(string type, string level)
    {
        double baseMoney = 140;
        int parId = bllCategory.GetModelByName(examModel.ClassID).parentID;
        if (parId == 245)
        {//美术

            baseMoney = 140;
        }
        else if (parId == 272)
        {
            //表演
            baseMoney = 160;
        }

        if (level.Equals("一级"))
        {
            return baseMoney + 10;
        }
        else if (level.Equals("二级"))
        {
            return baseMoney + 20;
        }
        else if (level.Equals("三级"))
        {
            return baseMoney + 30;
        }
        else if (level.Equals("四级"))
        {
            return baseMoney + 40;
        }
        else if (level.Equals("五级"))
        {
            return baseMoney + 50;
        }
        else if (level.Equals("六级"))
        {
            return baseMoney + 60;
        }
        else if (level.Equals("七级"))
        {
            return baseMoney + 70;
        }
        else if (level.Equals("八级"))
        {
            return baseMoney + 80;
        }
        else if (level.Equals("九级"))
        {
            return baseMoney + 90;
        }
        else if (level.Equals("十级"))
        {
            return baseMoney + 100;
        }
        return baseMoney;
    }

    public bool getPayStatus(int? status) {
        if (status == null || status.Value != 1) {
            return false;
        }
        return true;
    }
}