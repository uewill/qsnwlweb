using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Model;

public partial class Exam_personal_ViewTesting : System.Web.UI.Page
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
    public string printDesString = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {


        int exid = 0;
        if (int.TryParse(Request.QueryString["id"] + "", out exid) && exid > 0)
        {

            InitExamData(exid);
            //var data = ExamAuthHelper.GetAuthPersonID(this.Context);
            //InitData(data);
            bkfysmCategory= bllCategory.GetModel("bkfysm");

            printDesString = bllCategory.GetModel("grbkdysm").description;
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

        }
    }
}