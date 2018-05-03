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

public partial class admin_CustomManage_Default : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_CustomManage_Default));
    private static readonly CustomersBLL bll = new CustomersBLL();
    //private static readonly RoleBLL bllRole = new RoleBLL();
    public DataSet ds = new DataSet();

    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion



    #region 分页绑定
    private void InitData(int PageIndex, string name)
    {
        this.Title = "用户列表";    // 设置标题

        DataSet ds = new DataSet();
        int recordcount = 0; //获取总条数

        if (!name.Equals(string.Empty) && name != null)
        {
            txtSearchName.Text = name;
            //搜索
            ds = bll.GetList(AspNetPager1.PageSize, PageIndex, name, out recordcount);
        }
        else
        {
            ds = bll.GetList(AspNetPager1.PageSize, PageIndex, out recordcount);
        }

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
                string name = string.Empty;

                if (!string.IsNullOrEmpty(Request.QueryString["title"]))
                {
                    name = Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["title"]));
                }
                InitData(e.NewPageIndex, name);
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion

    #region 查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string title = StringUtil.CheckStr(txtSearchName.Text.Trim());
        Response.Redirect("Default.aspx?title=" + title, false);
    }
    #endregion

    #region 删除
    protected void ibtnDel_OnCommand(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandName);
        //int typeid = Convert.ToInt32(e.CommandArgument);
        try
        {
            bll.Delete(id);
            Msg.Show("删除成功!");
            InitData(1, ""); //重新绑定
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
                   
                    id = chkDelete.Value.ToString();// Msg.Show(id);
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
            InitData(1, ""); //重新绑定
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion

    #region 修改
    protected void lbtnModify_Click(object sender, EventArgs e)
    {
        try
        {
            string id = string.Empty;

            foreach (RepeaterItem rptItem in this.rptBind.Items)
            {
                HtmlInputCheckBox chkDelete = rptItem.FindControl("chkSelected") as HtmlInputCheckBox;
                if (chkDelete.Checked == true)
                {
                    id = chkDelete.Value.ToString();
                    Response.Redirect("Custom.aspx?type=modify&id=" + id, false);
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion


    #region 设置分类信息
    public string GetCategoryName(object obj)
    {
        CategoryBLL cbll = new CategoryBLL();
        return cbll.GetModel(int.Parse(obj.ToString())).title;
    }
    #endregion
}
