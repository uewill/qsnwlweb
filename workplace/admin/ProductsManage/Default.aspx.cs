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

public partial class admin_ProductsManage_Default : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_ProductsManage_Default));
    private static readonly ProductsBLL bll = new ProductsBLL();
    private static readonly CategoryBLL cbll = new CategoryBLL();
    public string codeNo = "cpzx";

    public string CodeNo
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["codeNo"]))
            {
                codeNo = Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["codeNo"]));
            }
            return codeNo;
        }
    }

    public DataSet ds = new DataSet();

    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string rmStr = QueryStringHelper.GetString("isrm");
            string tejiaStr = QueryStringHelper.GetString("istj");
            string cxstr = QueryStringHelper.GetString("iscx");
            if (!string.IsNullOrEmpty(rmStr))
            { //热门
                bll.Update(int.Parse(rmStr.Split(',')[1]), int.Parse(rmStr.Split(',')[0]), 1);
            }
            if (!string.IsNullOrEmpty(tejiaStr))
            { //特价
                bll.Update(int.Parse(tejiaStr.Split(',')[1]), int.Parse(tejiaStr.Split(',')[0]), 0);
            }
            if (!string.IsNullOrEmpty(cxstr))
            { //促销
                bll.Update(int.Parse(cxstr.Split(',')[1]), int.Parse(cxstr.Split(',')[0]), 2);
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
    }
    #endregion

    #region 设置下拉列表分类信息
    public void SetDDLView()
    {
        DataSet ds = cbll.GetNextNodeByCode("cpzx");
        ddlType.DataSource = ds;
        ddlType.DataTextField = "title";
        ddlType.DataValueField = "id";
        ddlType.DataBind();
        ListItem item = new ListItem("全部产品", "-1");
        ddlType.Items.Insert(0, item);
        //  int pid = cbll.GetIdByCodeNo(CodeNo);
        //  CreateLevelDropDown(ddlType, ds.Tables[0], pid);
    }
    #endregion


    #region 绑定下拉列表   无限级

    ///   <summary>   
    ///   创建分级下拉框   
    ///   </summary>   
    private void CreateLevelDropDown(DropDownList ddlst, DataTable dt, int pid)
    {
        System.Collections.ArrayList allItems = new ArrayList();
        DataRow[] rows = dt.Select("[parentid]=" + pid + " or [id]=" + pid);
        foreach (DataRow row in rows)
            CreateLevelDropDownAssistant(dt, ref   allItems, row, string.Empty);

        ListItem[] items = new ListItem[allItems.Count];
        allItems.CopyTo(items);
        ddlst.Items.AddRange(items);
    }
    private void CreateLevelDropDownAssistant(DataTable dt, ref   ArrayList items, DataRow parentRow, string curHeader)
    {
        ListItem newItem = new ListItem(curHeader + parentRow["title"].ToString(), parentRow["id"].ToString());
        items.Add(newItem);
        parentRow.Delete();

        DataRow[] rows = dt.Select("[parentID]='" + newItem.Value + "'");
        for (int i = 0; i < rows.Length - 1; i++)
            CreateLevelDropDownAssistant(dt, ref   items, rows[i], curHeader.Replace("┣", "┃").Replace("┗", "┣") + "┣");

        if (rows.Length > 0)
            CreateLevelDropDownAssistant(dt, ref   items, rows[rows.Length - 1], curHeader.Replace("┣", "┃").Replace("┗", "┣") + "┗");
    }
    #endregion



    #region 分页绑定
    private void InitData(int PageIndex, string name, int parentId)
    {
        this.Title = "列表";    // 设置标题

        DataSet ds = new DataSet();
        int recordcount = 0; //获取总条数
        string wheStr = string.Empty;
        int sHotid = QueryStringHelper.GetInt("sHotID");
        if (sHotid == 1)
        {
            chkIsHot.Checked = true;
            wheStr = "isHot=1";
        }
        int sTjid = QueryStringHelper.GetInt("sTuiJian");


        if (sTjid == 1)
        {
            chkTuiJian.Checked = true;
            if (!string.IsNullOrEmpty(wheStr))
            {
                wheStr += " and ";
            }
            wheStr += " isTuijian=1";
        }
        int siscx = QueryStringHelper.GetInt("iscx");
        if (siscx == 1)
        {
            chkIsCX.Checked = true;
            if (!string.IsNullOrEmpty(wheStr))
            {
                wheStr += " and ";
            }
            wheStr += " desFild1=1";
        }

        if (!name.Equals(string.Empty) || parentId != -1)
        {
            ddlType.SelectedValue = parentId + "";
            //搜索
            ds = bll.GetSearchNameList(AspNetPager1.PageSize, PageIndex, name, parentId, wheStr, out recordcount);
            try
            {
                txtSearchName.Text = name;
            }
            catch { }
        }
        else
        {
            ds = bll.GetAllListByCodeNo(AspNetPager1.PageSize, PageIndex, CodeNo, wheStr, out recordcount);
        }

        AspNetPager1.RecordCount = recordcount;

        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            dt.Columns.Add("pcodeNo", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["pcodeNo"] = codeNo;
            }
        }

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
                SetDDLView();
                string name = string.Empty;
                int parentId = -1;
                if (!string.IsNullOrEmpty(Request.QueryString["title"]))
                {
                    name = Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["title"]));
                }
                if (!string.IsNullOrEmpty(Request.QueryString["parentId"]))
                {
                    parentId = Int32.Parse(Server.UrlDecode(StringUtil.HtmlEncode(Request.QueryString["parentId"])));
                }
                InitData(e.NewPageIndex, name, parentId);
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            Msg.Show(ex.Message);
        }
    }
    #endregion

    #region 删除
    protected void ibtnDel_OnCommand(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandName);
        int typeid = Convert.ToInt32(e.CommandArgument);
        try
        {

            bll.Delete(id);
            string str = " parentId=" + id + " and categoryId=" + typeid;
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
                HiddenField hf = rptItem.FindControl("hiddenParID") as HiddenField;
                if (chkDelete.Checked == true)
                {
                    id = chkDelete.Value.ToString();
                    bll.Delete(Int32.Parse(id));
                    string str = "parentid=" + id + " and categoryid=" + hf.Value;
                    //    pcbll.DeleteByParent(str);
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
                    Response.Redirect("Action.aspx?type=modify&id=" + id + "&codeNo=" + CodeNo, false);
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
            string name = this.txtSearchName.Text;
            string parentId = this.ddlType.SelectedItem.Value.ToString();
            int sHotID = chkIsHot.Checked ? 1 : 0;
            int sTuiJian = chkTuiJian.Checked ? 1 : 0;
            int isCX = chkIsCX.Checked ? 1 : 0;
            Response.Redirect("Default.aspx?title=" + name + "&parentId=" + parentId + "&codeNo=" + CodeNo + "&sHotID=" + sHotID + "&sTuiJian="+sTuiJian+"&iscx="+isCX, false);
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

    #region 修改排序
    protected void lbtnModifyOrder_Click(object sender, EventArgs e)
    {
        string chekNameID = "orderId";//默认排序名；
        try
        {
            string id = string.Empty;

            foreach (RepeaterItem rptItem in this.rptBind.Items)
            {
                HtmlInputText inputText = rptItem.FindControl("txtOrderBy") as HtmlInputText;
                HtmlInputCheckBox inputCheck = rptItem.FindControl("chkSelected") as HtmlInputCheckBox;
                try
                {
                    int orderid = int.Parse(inputText.Value);
                    int iid = int.Parse(inputCheck.Value);
                    bll.UpdateOrders(iid, orderid, chekNameID);
                }
                catch
                {
                }
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
        Response.Redirect(Request.RawUrl);
    }
    #endregion

    #region 修改排序
    protected void lbtnModifyRQ_Click(object sender, EventArgs e)
    {
        string chekNameID = "clicks";//默认排序名；
        try
        {
            string id = string.Empty;
            foreach (RepeaterItem rptItem in this.rptBind.Items)
            {
                HtmlInputText inputText = rptItem.FindControl("txtClicks") as HtmlInputText;
                HtmlInputCheckBox inputCheck = rptItem.FindControl("chkSelected") as HtmlInputCheckBox;
                try
                {
                    int orderid = int.Parse(inputText.Value);
                    int iid = int.Parse(inputCheck.Value);
                    bll.UpdateOrders(iid, orderid, chekNameID);
                }
                catch
                {
                }
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
        Response.Redirect(Request.RawUrl);
    }
    #endregion

    #region 设置为热门、推荐
    public string SetTuiJian(object obj, object id)
    {
        bool isSearch = false;
        string nowUrl = Request.RawUrl;
        if (nowUrl.Contains("istj"))
        {
            isSearch = true;
            nowUrl = nowUrl.Replace("istj", "t");
        }
        else if (nowUrl.Contains("?"))
        {
            isSearch = true;
        }
        switch (obj + "")
        {
            case "0":
                if (isSearch)
                {
                    return "<a href='" + nowUrl + "&istj=1," + id + "'>设为推荐</a>";
                }
                else
                {
                    return "<a href='" + nowUrl + "?istj=1," + id + "'>设为推荐</a>";
                }
                break;
            case "1":
                if (isSearch)
                {
                    return "<a href='" + nowUrl + "&istj=0," + id + "'>取消推荐</a>";
                }
                else
                {
                    return "<a href='" + nowUrl + "?istj=0," + id + "'>取消推荐</a>";
                }
                break;
        }
        return "";
    }

    public string SetHot(object obj, object id)
    {
        bool isSearch = false;
        string nowUrl = Request.RawUrl;
        if (nowUrl.Contains("isrm"))
        {
            isSearch = true;
            nowUrl = nowUrl.Replace("isrm", "t");
        }
        else if (nowUrl.Contains("?"))
        {
            isSearch = true;
        }
        switch (obj + "")
        {
            case "0":
                if (isSearch)
                {
                    return "<a href='" + nowUrl + "&isrm=1," + id + "'>设为热门</a>";
                }
                else
                {
                    return "<a href='" + nowUrl + "?isrm=1," + id + "'>设为热门</a>";
                }
                break;
            case "1":
                if (isSearch)
                {
                    return "<a href='" + nowUrl + "&isrm=0," + id + "'>取消热门</a>";
                }
                else
                {
                    return "<a href='" + nowUrl + "?isrm=0," + id + "'>取消热门</a>";
                }
                break;
        }
        return "";
    }

    public string SetCX(object obj, object id)
    {
        bool isSearch = false;
        string nowUrl = Request.RawUrl;
        if (nowUrl.Contains("iscx"))
        {
            isSearch = true;
            nowUrl = nowUrl.Replace("iscx", "t");
        }
        else if (nowUrl.Contains("?"))
        {
            isSearch = true;
        }
        switch (obj + "")
        {
            case "0":
                if (isSearch)
                {
                    return "<a href='" + nowUrl + "&iscx=1," + id + "'>设为促销</a>";
                }
                else
                {
                    return "<a href='" + nowUrl + "?iscx=1," + id + "'>设为促销</a>";
                }
                break;
            case "1":
                if (isSearch)
                {
                    return "<a href='" + nowUrl + "&iscx=0," + id + "'>取消促销</a>";
                }
                else
                {
                    return "<a href='" + nowUrl + "?iscx=0," + id + "'>取消促销</a>";
                }
                break;
        }
        return "<a href='" + nowUrl + "&iscx=1," + id + "'>设为促销</a>";
    }

    
    #endregion


}
