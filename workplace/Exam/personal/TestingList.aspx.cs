using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Common;

public partial class Exam_personal_TestingList : System.Web.UI.Page
{
    private static readonly TFXK.BLL.TestingPersonExam bll = new TFXK.BLL.TestingPersonExam();
    private static readonly TFXK.BLL.ArticlesBLL articlesBLL = new TFXK.BLL.ArticlesBLL();

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
        string wherestr = "personid="+ExamAuthHelper.GetAuthPersonID(this.Context);
        ds = bll.GetList(AspNetPager1.PageSize, PageIndex, wherestr, out recordcount);

        AspNetPager1.RecordCount = recordcount;

        this.rptBind.DataSource = ds.Tables[0].DefaultView;
        this.rptBind.DataBind();

        rptDownload.DataSource = articlesBLL.GetAllListByCodeNo(10,1, "bkzlxz", out recordcount);
        rptDownload.DataBind();

    }
    #endregion

    public string GetStatusName(string statusid)
    {
        switch (statusid)
        {
            case "0":
                return "待支付";
            case "1":
                return "已支付/报名成功";
            default:
                return string.Empty;
        }
    }
    public string GetActionLink(string id, string status) {
        switch (status)
        {
            case "0":
                return "<a class=\"btn btn-success btn - ms\" href=\"ViewTestingPay.aspx?id=" + id + "\">去支付</a>";
            case "1":
                return "<a class=\"btn btn-success btn - ms\" href=\"ViewTesting.aspx?id="+id+"\">查看并打印</a>";
            default:
                return string.Empty;
        }
    }

    //public string GetBMLink(string id,string sid, string nsid)
    //{
    //    if (sid.Equals("1") && nsid.Equals("0"))
    //    {
    //        return "<a href=\"ExamPlan.aspx?id="+id+"\">报名信息</a>";
    //    }
    //    return string.Empty;
    //}

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("TestingList.aspx");
    }

    protected void ddlNoticeStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("TestingList.aspx");
    }


    protected void ibtnDel_OnCommand(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandName);
        try
        {
            var model = bll.GetModel(id);
            if (model.Status == 0)
            {

                bll.Delete(id);
                Msg.Show("删除成功!");
            }
            else
            {
                Msg.Show("只有待审核状态的申请可以被删除!");
            }
            InitData(1);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}