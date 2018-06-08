using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.BLL;
using TFXK.Common;

public partial class Exam_ExamPlanStudent : System.Web.UI.Page
{
    public string testCenterName = string.Empty;
    private TFXK.BLL.TestingPlan bllTestingPlan = new TFXK.BLL.TestingPlan();
    private TFXK.BLL.TestingStudent bllTestingStudent = new TFXK.BLL.TestingStudent();
    private TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();
    public TFXK.Model.TestingPlan planModel = new TFXK.Model.TestingPlan();

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
                Response.Redirect("ExamPlanList.aspx");
            }
        }
    }

    private void InitData(int exid)
    {
        var currentCenterID = ExamAuthHelper.GetAuthCenterID(this.Context);
        planModel = bllTestingPlan.GetModel(exid);
        if (planModel.CenterID != currentCenterID)
        {
            Response.Redirect("ExamPlanList.aspx");
        }
        if (planModel.Status == 1)
        {
            panelAdd.Visible = true;
            ddlClass.DataSource = bllCategory.GetNextNodeByCode("kjkmpz");
            ddlClass.DataBind();
            ddlCountry.DataSource = bllCategory.GetNextNodeByCode("kjgj");
            ddlCountry.DataBind();
            ddlMingzu.DataSource = bllCategory.GetNextNodeByCode("kjmz");
            ddlMingzu.DataBind();
        }
        else
        {
            panelAdd.Visible = false;
        }

    }




    #region 分页控件加载
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                int id = -1;
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    id = Int32.Parse(Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["id"])));
                }
                InitListData(e.NewPageIndex, id);

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    #endregion

    #region 分页绑定
    private void InitListData(int PageIndex, int id)
    {
        DataSet ds = new DataSet();
        int recordcount = 0; //获取总条数
        string wherestr = "1=1 ";
        if (id >= 0)
        {
            wherestr += " and PlanID=" + id;
        }

        ds = bllTestingStudent.GetList(AspNetPager1.PageSize, PageIndex, wherestr, out recordcount);

        AspNetPager1.RecordCount = recordcount;

        this.rptBind.DataSource = ds.Tables[0].DefaultView;
        this.rptBind.DataBind();
    }
    #endregion


    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        TFXK.Model.TestingStudent model = new TFXK.Model.TestingStudent();
        DateTime birthday;
        DateTime.TryParse(txtBirthday.Value + "", out birthday);
        model.Birthday = birthday;
        model.ClassID = int.Parse(ddlClass.SelectedValue);
        model.Country = ddlCountry.SelectedValue;
        model.CreateTime = DateTime.Now;
        model.EthnicGroup = ddlMingzu.SelectedValue;
        model.IDNumber = txtID.Value + "";
        model.IsPass = 0;
        model.LevelNum = ddlLevel.SelectedValue;
        model.OrgLevel = ddlOrgLevel.SelectedValue;
        model.PlanID = Int32.Parse(Request.QueryString["id"]);
        model.Score = 0;
        model.Sex = int.Parse(ddlSex.SelectedValue);
        model.UserHeadImage = txtIDImg1.Value.ToString();
        model.UserWorkImage = txtIDImg2.Value.ToString();
        model.UserName = txtUserName.Value.ToString();
        model.UserNamePinyin = txtUserNamePinyin.Value.ToString();

        if (string.IsNullOrEmpty(model.UserName))
        {
            InitData(model.PlanID.Value);
            Msg.Show("名称不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(model.UserNamePinyin))
        {
            InitData(model.PlanID.Value);
            Msg.Show("名称拼音不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(model.IDNumber))
        {
            InitData(model.PlanID.Value);
            Msg.Show("身份证不能为空!");
            return;
        }
        if (model.Birthday == null)
        {
            InitData(model.PlanID.Value);
            Msg.Show("出生日期不能为空!");
            return;
        }
        int id = bllTestingStudent.Add(model);
        if (id > 0)
        {
            Response.Redirect("ExamPlanStudent.aspx?id=" + model.PlanID);
        }
    }

    public string GetCategoryName(object obj)
    {
        CategoryBLL cbll = new CategoryBLL();
        return cbll.GetModel(int.Parse(obj.ToString())).title;
    }
    public string GetImagePath(object obj)
    {
        if (string.IsNullOrEmpty(obj + ""))
        {
            return "/images/nopic.jpg";
        }
        else
        {
            return obj.ToString();
        }
    }
    protected void ibtnDel_OnCommand(object sender, CommandEventArgs e)
    {
        int idx = Convert.ToInt32(e.CommandName);
        try
        {

            bllTestingStudent.Delete(idx);
            Msg.Show("删除成功!");


            int id = -1;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Int32.Parse(Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["id"])));
            }
            InitData(id);
            InitListData(1, id);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnGoToPay_ServerClick(object sender, EventArgs e)
    {
        int id = Int32.Parse(Request.QueryString["id"]);
        var currentCenterID = ExamAuthHelper.GetAuthCenterID(this.Context);
        var planModel2 = bllTestingPlan.GetModel(id);
        int count = bllTestingStudent.GetRecordCount(" planid=" + id);
        if (count == 0)
        {
            InitData(id);
            InitListData(1, id);
            Msg.Show("提交失败，尚未录入考生信息");
            return;
        }
        if (planModel2.Status == 1)
        {
            planModel2.Status = 2;
            bllTestingPlan.Update(planModel2);
            Msg.ShowAndRedirect("提交成功", "ExamPlan.aspx?id=" + id);
        }
        else
        {
            InitData(id);
            InitListData(1, id);
        }
    }
}