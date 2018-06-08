using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Common;

public partial class Exam_ExamPlanList : System.Web.UI.Page
{
    private static readonly TFXK.BLL.TestingPlan bll = new TFXK.BLL.TestingPlan();
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

                int status = -1;
                if (!string.IsNullOrEmpty(Request.QueryString["status"]))
                {
                    status = Int32.Parse(Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["status"])));
                }
                int nstatus = -1;
                if (!string.IsNullOrEmpty(Request.QueryString["nstatus"]))
                {
                    nstatus = Int32.Parse(Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["nstatus"])));
                }
                InitData(e.NewPageIndex, "", status, nstatus);

                ddlStatus.SelectedValue = status.ToString();
                ddlNoticeStatus.SelectedValue = nstatus.ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    #endregion

    #region 分页绑定
    private void InitData(int PageIndex, string name, int status, int nstatus)
    {
        DataSet ds = new DataSet();
        int recordcount = 0; //获取总条数
        string wherestr = "centerid="+ExamAuthHelper.GetAuthCenterID(this.Context);
        if (status >= 0)
        {
            wherestr += " and Status=" + status;
        }
        if (nstatus >= 0)
        {
            wherestr += " and NoticeConfirm=" + nstatus;
        }

        ds = bll.GetList(AspNetPager1.PageSize, PageIndex, wherestr, out recordcount);

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
        Response.Redirect("ExamPlanList.aspx?status=" + this.ddlStatus.SelectedValue + "&nstatus=" + ddlNoticeStatus.SelectedValue);
    }

    protected void ddlNoticeStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ExamPlanList.aspx?status=" + this.ddlStatus.SelectedValue + "&nstatus=" + ddlNoticeStatus.SelectedValue);
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


            int status = -1;
            if (!string.IsNullOrEmpty(Request.QueryString["status"]))
            {
                status = Int32.Parse(Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["status"])));
            }
            int nstatus = -1;
            if (!string.IsNullOrEmpty(Request.QueryString["nstatus"]))
            {
                nstatus = Int32.Parse(Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["nstatus"])));
            }
            InitData(1, "", status, nstatus);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}