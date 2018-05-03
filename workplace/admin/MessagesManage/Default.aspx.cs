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

public partial class admin_MessagesManage_Default : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_MessagesManage_Default));
    private static readonly MessagesBLL bll = new MessagesBLL();

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
    private void InitData(int PageIndex, string name, int stateid)
    {
        this.Title = "链接列表";    // 设置标题

        DataSet ds = new DataSet();
        int recordcount = 0; //获取总条数
        string where = string.Empty;
        if (!string.IsNullOrEmpty(name))
        {
            where = "title like '%" + name + "%'";
        }
        if (stateid >= 0)
        {
            if (!string.IsNullOrEmpty(where))
            {
                where += " and ";
            }
            where += " stateid=" + stateid;
            ddlState.SelectedValue = stateid + "";
        }
        int ppid = QueryStringHelper.GetInt("txtAID");
        if (ppid > 0)
        {
            if (!string.IsNullOrEmpty(where))
            {
                where += " and ";
            }
            where += " qicq='" + ppid + "'";
        }
        //txtAID

        //搜索
        ds = bll.GetList(AspNetPager1.PageSize, PageIndex, where, out recordcount);


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
                string name = QueryStringHelper.GetString("title");
                int stateid = QueryStringHelper.GetInt("stateid");

                InitData(e.NewPageIndex, name, stateid);
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
            // 防止网页重复提交

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
            // 防止网页重复提交
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
            InitData(1, "", -1);  // 重新绑定列表
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
                    Response.Redirect("Action.aspx?type=modify&id=" + id, false);
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

    #region 搜索按钮
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string name = this.txtSearchName.Text.Trim();
            string stateid = ddlState.SelectedValue;
            Response.Redirect("Default.aspx?title=" + name + "&stateid=" + stateid + "&txtAID=" + txtAID.Text, false);
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion

    #region  设置logo路径
    public string StateName(object obj)
    {
        if (obj.ToString() == "1")
        {
            return "已显示";
        }
        else
        {
            //ImgLogo.Visible = false;
            return "未显示";
        }
    }

    #endregion
}

