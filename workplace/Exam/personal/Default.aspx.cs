using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Common;

public partial class Exam_personal_Default : System.Web.UI.Page
{
    private static readonly TFXK.BLL.TestingPersonPlan bll = new TFXK.BLL.TestingPersonPlan();
    private static readonly TFXK.BLL.TestingPersonExam bllExam = new TFXK.BLL.TestingPersonExam();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 分页控件加载
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                InitData(e.NewPageIndex);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    #endregion

    #region 分页绑定
    private void InitData(int PageIndex)
    {
        DataSet ds = new DataSet();
        int recordcount = 0; //获取总条数
        string wherestr = "Status=1";
        ds = bll.GetListFull(AspNetPager1.PageSize, PageIndex, wherestr, out recordcount);

        AspNetPager1.RecordCount = recordcount;

        this.rptBind.DataSource = ds.Tables[0].DefaultView;
        this.rptBind.DataBind();

    }
    #endregion

    public string GetStatusName(string statusid)
    {
        switch (statusid)
        {
            case "0":
                return "待审核";
            case "1":
                return "已审核";
            case "2":
                return "已提交考生信息";
            case "3":
                return "已通知考试结果";
            default:
                return string.Empty;
        }
    }

    public int GetBMCount(string id) {

        return bllExam.GetRecordCount("TypeID=" + id);
    }

    public string GetActionLink(string id, string bmStart, string bmEnd, string ksStart, string ksEnd)
    {
        if (!string.IsNullOrEmpty(ksEnd) && DateTime.Parse(ksEnd) < DateTime.Now)
        {
            return "考试已结束";
        }
        if (!string.IsNullOrEmpty(ksStart) && DateTime.Parse(ksStart)<DateTime.Now)
        {
            return "正在考试";
        }

        if (!string.IsNullOrEmpty(bmStart) && !string.IsNullOrEmpty(bmStart))
        {
            if (DateTime.Parse(bmStart) < DateTime.Now && DateTime.Parse(bmEnd) > DateTime.Now)
            {
                return "<a class=\"btn btn-success btn-ms\" href=\"NewTesting.aspx?id=" + id + "\">正在报名</a>";
            }
            else if (DateTime.Parse(bmStart) > DateTime.Now)
            {
                return "报名暂未开始";
            }
            else if (DateTime.Parse(bmEnd)< DateTime.Now)
            {
                return "报名已结束";
            }
        }

        return string.Empty;


    }
}