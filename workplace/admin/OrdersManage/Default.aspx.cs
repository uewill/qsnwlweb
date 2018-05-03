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

public partial class admin_OrdersManage_Default : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_OrdersManage_Default));
    private static readonly UserOrdersBLL bll = new UserOrdersBLL();
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
    private void InitData(int PageIndex, string name, int parentId)
    {
        this.Title = "列表";    // 设置标题

        DataSet ds = new DataSet();
        int recordcount = 0; //获取总条数
        string wherestr = "";
        if (parentId >= 0)
        {
            wherestr += "stateID=" + parentId;
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

                int parentId = -1;
                if (!string.IsNullOrEmpty(Request.QueryString["parentId"]))
                {
                    parentId = Int32.Parse(Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["parentId"])));
                }
                InitData(e.NewPageIndex, "", parentId);
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
            string parentId = this.ddlType.SelectedItem.Value.ToString();
            Response.Redirect("Default.aspx?parentId=" + parentId, false);
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
        if (obj.ToString().Equals("1"))
        {
            return "已处理";
        }
        else {
            return "未处理";
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
}
