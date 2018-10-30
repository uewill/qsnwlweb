using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam_personal_PrintViewby : System.Web.UI.Page
{
    public TFXK.Model.TestingPersonPlan planModel = new TFXK.Model.TestingPersonPlan();
    public TFXK.Model.TestingPersonExam examModel = new TFXK.Model.TestingPersonExam();

    public TFXK.BLL.TestingPersonExam bllExam = new TFXK.BLL.TestingPersonExam();
    public TFXK.BLL.TestingPersonPlan bllPlan = new TFXK.BLL.TestingPersonPlan();
    public TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();

    private TFXK.Model.TestingPerson personModel = new TFXK.Model.TestingPerson();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["fromadmin"]) && Request.QueryString["fromadmin"].ToString().Equals("admin"))
            {


            }
            else
            {
                personModel = ExamAuthHelper.GetPersonAuthData(this.Context);
                if (personModel == null)
                {
                    Response.Redirect("/default.aspx");
                    return;
                }
            }


            this.Title = "右键进行打印";
            InitData();
        }
    }

    private void InitData()
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"] + "", out id) && id > 0)
        {
            examModel = bllExam.GetModel(id);
            if (examModel == null || (personModel.id != 0 && examModel.PersonID.Value != personModel.id))
            {
                examModel = new TFXK.Model.TestingPersonExam();
                return;
            }
            planModel = bllPlan.GetModel(examModel.TypeID.Value);
            if (planModel == null)
            {
                planModel = new TFXK.Model.TestingPersonPlan();
                return;
            }
        }
    }

    public string GetAddress(string address)
    {
        if (string.IsNullOrEmpty(address)) {
            return string.Empty;
        }
        string[] adds = address.Split(' ');
        if (adds.Length == 3)
        {
            return adds[1] + " " + adds[1];
        }
        return address;
    }
    public string GetPersonNo(object id, object date)
    {
        try
        {

            return DateTime.Parse(date + "").ToString("yyyyMMddHH") + id;
        }
        catch
        {
            return string.Empty;
        }
    }

}