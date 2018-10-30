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
using System.IO;
using System.Text;

public partial class admin_ExamStudentManage_Default : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_ExamStudentManage_Default));
    private static readonly TFXK.BLL.TestingStudent bll = new TFXK.BLL.TestingStudent();
    private static readonly TFXK.BLL.TestingPlan bllPlan = new TFXK.BLL.TestingPlan();
    private static readonly CategoryBLL cbll = new CategoryBLL();

    public DataSet ds = new DataSet();

    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion

    #region 分页绑定
    private void InitData(int PageIndex, string name, int status)
    {
        this.Title = "列表";    // 设置标题

        DataSet ds = new DataSet();
        int recordcount = 0; //获取总条数
        string wherestr = "";
        if (status >= 0)
        {
            wherestr += " planid=" + status;
        }

        ds = bll.GetList(AspNetPager1.PageSize, PageIndex, wherestr, out recordcount);

        AspNetPager1.RecordCount = recordcount;

        this.rptBind.DataSource = ds.Tables[0].DefaultView;
        this.rptBind.DataBind();
    }
    #endregion

    #region 分页控件加载
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                int status = -1;
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    status = Int32.Parse(Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["id"])));

                    InitData(e.NewPageIndex, "", status);

                    ddlType.SelectedValue = status.ToString();
                }
                else
                {
                    Response.Redirect("../ExamPlanManage/default.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion

    #region 删除
    protected void ibtnDel_OnCommand(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandName);
        try
        {

            bll.Delete(id);
            Msg.Show("删除成功!");
            InitData(1, "", -1); //重新绑定
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion

    #region 多选删除
    protected void lbtnDelAll_Click(object sender, EventArgs e)
    {
        try
        {
            string id = string.Empty;
            bool flg = false;

            foreach (RepeaterItem rptItem in this.rptBind.Items)
            {
                HtmlInputCheckBox chkDelete = rptItem.FindControl("chkSelected") as HtmlInputCheckBox;
                if (chkDelete.Checked == true)
                {
                    id = chkDelete.Value.ToString();
                    bll.Delete(Int32.Parse(id));
                    flg = true;
                }
            }

            if (flg)
            {
                Msg.Show("删除成功!");
            }
            else
            {
                Msg.Show("请选择要删除的记录!");
            }
            InitData(1, "", -1); //重新绑定
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion

    #region 搜索按钮
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string status = this.ddlType.SelectedItem.Value.ToString();
            Response.Redirect("Default.aspx?status=" + status, false);
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion

    #region 设置分类信息
    public string GetStateName(object obj)
    {
        switch (obj.ToString())
        {
            case "0":
                return "未审核";
            case "1":
                return "已审核";
            case "2":
                return "已提交考生信息";
            default:
                return "已通知考试结果";
        }
    }
    #endregion

    #region 设置分类信息
    public string GetDate(object obj)
    {
        try
        {
            return obj.ToString().Split(' ')[0];
        }
        catch
        {
            return "";
        }
    }
    #endregion


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

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        int row = 0;
        int pid = Int32.Parse(Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["id"])));
        var dss = bll.GetList(100, 1, "planid=" + pid, out row);

        DataTable dt = dss.Tables[0];

        DataTable newdt = new DataTable();
        newdt.Columns.Add("序号");
        newdt.Columns.Add("计划");
        newdt.Columns.Add("类型");
        newdt.Columns.Add("原有等级");
        newdt.Columns.Add("报考等级");
        newdt.Columns.Add("姓名");
        newdt.Columns.Add("拼音");
        newdt.Columns.Add("身份证号码");
        newdt.Columns.Add("性别");
        newdt.Columns.Add("国家");
        newdt.Columns.Add("民族");
        newdt.Columns.Add("生日");
        newdt.Columns.Add("创建时间");

        foreach (DataRow itemdr in dt.Rows) {

            DataRow newItemDR = newdt.NewRow();
            newItemDR["序号"] = itemdr["id"] + "";
            newItemDR["计划"] = bllPlan.GetModel(int.Parse(itemdr["PlanID"] + "")).TestingTime;
            newItemDR["类型"] = cbll.GetModel( int.Parse(itemdr["ClassID"] + "")).title;
            newItemDR["原有等级"] = itemdr["OrgLevel"] + "";
            newItemDR["报考等级"] = itemdr["LevelNum"] + "";
            newItemDR["姓名"] = itemdr["UserName"] + "";
            newItemDR["拼音"] = itemdr["UserNamePinyin"] + "";
            newItemDR["身份证号码"] = "'"+itemdr["IDNumber"] + "";
            newItemDR["性别"] = itemdr["Sex"].ToString().Equals("0")?"男":"女";
            newItemDR["国家"] =cbll.GetModel(int.Parse(itemdr["Country"] + "")).title;
            newItemDR["民族"] = cbll.GetModel(int.Parse(itemdr["EthnicGroup"] + "")).title;
            newItemDR["生日"] = itemdr["Birthday"] + "";
            newItemDR["创建时间"] = itemdr["CreateTime"] + "";
            newdt.Rows.Add(newItemDR);

        }


        
        Export.CreateExcel(this.Context, newdt, "考生信息-" + DateTime.Now.ToString());
    }
}
