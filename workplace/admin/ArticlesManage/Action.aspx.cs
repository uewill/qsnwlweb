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

public partial class admin_ArticlesManage_Action : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_ArticlesManage_Action));
    private static readonly ArticlesBLL bll = new ArticlesBLL();
    private static readonly CategoryBLL bllCategory = new CategoryBLL();
    private static readonly UsersBLL bllUser = new UsersBLL();
    public static string codeNo = "wzfl";
    public int i = 0;

    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                InitAction();
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }

    }
    #endregion

    #region 绑定动作
    private void InitAction()
    {
        if (Request.QueryString["codeNo"] != null)
        {
            codeNo = Request.QueryString["codeNo"] + "";
        }
        if (Request.QueryString["type"] != null)
        {
            BindSelType();
            string type = Request.QueryString["type"].ToString();
            string title = string.Empty;// 设置标题
            // 判断动作
            switch (type)
            {
                case "add":
                    title = "添加文章";
                    txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    try
                    {
                        ddlType.SelectedValue = bllCategory.GetIdByCodeNo(codeNo)+"";
                    }
                    catch { }
                    break;
                case "modify":
                    if (Request.QueryString["id"] != null)
                    {
                        title = "修改文章";
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        InitData(id);
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                    break;

            }
            this.Title = title;
            this.hdfAction.Value = type;
        }
        else
        {
            Response.Redirect("Default.aspx", false);
        }
    }
    #endregion

    #region 绑定
    private void InitData(int id)
    {
        Articles model = bll.GetModel(id);
        if (model != null)
        {
            txtTitle.Text = model.title;
            this.txtDate.Date = model.createTime.Value;
            this.txtClick.Text = model.clicks + "";
            this.txtOrderby.Text = model.orderId + "";
            txtContent.Value = model.description;
            this.txtSource.Text = model.source;
            if (!string.IsNullOrEmpty(model.imgPath))
            {
                hdfImgPath.Value = model.imgPath;
                newsImg.Src = "../../uploads/" + model.imgPath;
                newsImg.Attributes.CssStyle.Add("display", "block");
            }
            else {
                newsImg.Attributes.CssStyle.Add("display", "none"); 
            }

            ddlState.SelectedValue = model.state + "";
            txtOrderby.Text = model.orderId + "";
            ddlType.SelectedValue = model.parentId + "";
            txtOutLink.Text = model.outLinkPath;
            if (model.isOutlLink == 1)
            {
                ddlOutLink.SelectedIndex = 1;
            }
            else
            {
                ddlOutLink.SelectedIndex = 0;
            }

        }
    }
    #endregion

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        //验证代码
        try
        {
            TFXK.Model.Articles model = new TFXK.Model.Articles();
            try
            {
                model.id = int.Parse(Request.QueryString["id"].ToString());
            }
            catch { model.id = 0; }
            model.title = txtTitle.Text;
            model.source = this.txtSource.Text;
            model.orderId = int.Parse(this.txtOrderby.Text.Equals("") ? "0" : this.txtOrderby.Text);
            model.parentId = int.Parse(this.ddlType.SelectedValue + "");
            model.isSlideOn = 0;

            model.createTime = this.txtDate.Date;
            model.clicks = int.Parse(this.txtClick.Text.Equals("") ? "0" : this.txtClick.Text);
            model.description = this.txtContent.Value;
            try
            {
                model.publisher = bllUser.GetModelByUserName(Context.User.Identity.Name).trueName;
            }
            catch { }
            model.isOutlLink = ddlOutLink.SelectedIndex;
            model.outLinkPath = txtOutLink.Text;
            model.state = int.Parse(this.ddlState.SelectedValue);
            if (hdfImgPath.Value.Length > 10)
            {
                model.imgPath = hdfImgPath.Value;
            }

            string type = this.hdfAction.Value.Trim();
            // 判断动作
            switch (type)
            {
                case "add":
                    Add(model);
                    break;
                case "modify":
                    Modify(model);
                    break;
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            Msg.Show("网络错误!原因:" + ex.Message);
        }
    }
    #endregion

    #region 添加
    private void Add(Articles model)
    {
        int rows = bll.Add(model);
        hdfPid.Value = rows + "";
        hdfTid.Value = model.parentId + "";
        if (rows > 0)
        {
            Msg.ShowAndRedirect("添加信息成功!", "Default.aspx?codeNo=" + codeNo);
        }
        else
        {
            Msg.Show("添加信息失败!");
        }
    }
    #endregion

    #region 修改
    private void Modify(Articles model)
    {
        bll.Update(model);
        hdfPid.Value = model.id + "";
        hdfTid.Value = model.parentId + "";
        Msg.ShowAndRedirect("修改信息成功!", "Default.aspx?codeNo=" + codeNo);
    }
    #endregion

    #region 返回
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx?codeNo=" + codeNo, false);
    }
    #endregion

    #region 绑定下拉列表
    private void BindSelType()
    {
        DataSet ds = bllCategory.GetAllList();
      //  int pid = bllCategory.GetIdByCodeNo(codeNo);
        CreateLevelDropDown(ddlType, ds.Tables[0], 0);

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


}
