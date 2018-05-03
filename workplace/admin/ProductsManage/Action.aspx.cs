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

public partial class admin_ProductsManage_Action : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_ProductsManage_Action));
    private static readonly ProductsBLL bll = new ProductsBLL();
    private static readonly CategoryBLL bllCategory = new CategoryBLL();
    private static readonly ProExtCategoryBLL bllProExtCategory = new ProExtCategoryBLL();
    public static string codeNo = "cpzx";
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
            BindExtData();
            string type = Request.QueryString["type"].ToString();
            string title = string.Empty;// 设置标题
            // 判断动作
            switch (type)
            {
                case "add":
                    title = "添加文章";
                    try
                    {
                        ddlType.SelectedValue = bllCategory.GetIdByCodeNo(codeNo) + "";
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
        Products model = bll.GetModel(id);
        if (model != null)
        {
            txtTitle.Text = model.title;
            txtCpmsDes.Value = model.cpdes;
            this.txtCode.Text = model.codeNo;
            txtBrandName.Text = model.brandName;
            txtDanwei.Text = model.danwei;
            txtSalePrice.Text = model.salePrice + "";
            txtCusPrice.Text = model.cusPrice + "";
            txtMianliao.Text = model.mianliao;
            txtColorName.Text = model.colorname;
            ddlType.SelectedValue = model.parentID + "";
            txtDescription.Text = model.admindes;
            if (!string.IsNullOrEmpty(model.imgPath))
            {
                hdfImgPath.Value = model.imgPath;
                newsImg.Src = "../../uploads/" + model.imgPath;
                newsImg.Attributes.CssStyle.Add("display", "block");
            }
            txtCpmsDes.Value = model.cpdes;
            txtFzccDes.Value = model.fzccdes;
            txtXdbyDes.Value = model.xdbxdes;
            txtSHfwDes.Value = model.shfwdes;
            chkTuiJian.Checked = model.isTuijian == 1 ? true : false;
            chkIsHot.Checked = model.isHot == 1 ? true : false;
            txtClick.Text = model.clicks + "";
            txtOrderby.Text = model.orderID + "";
            if (model.desFild1 != null)
            {
                chkIsCX.Checked = model.desFild1.Value == 1 ? true : false;
            };
            SetSelectIDs(id);

        }
    }
    #endregion

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        //验证代码
        try
        {
            TFXK.Model.Products model = new TFXK.Model.Products();
            try
            {
                model.id = int.Parse(Request.QueryString["id"].ToString());
            }
            catch { model.id = 0; }

            model.title = txtTitle.Text;
            try
            {
                model.clicks = int.Parse(this.txtClick.Text);
            }
            catch
            {
                model.clicks = 0;
            }

            try
            {
                model.orderID = int.Parse(txtOrderby.Text);
            }
            catch
            {
                model.orderID = 0;
            }

            model.cpdes = txtCpmsDes.Value;
            model.codeNo = this.txtCode.Text;
            model.brandName = txtBrandName.Text;
            model.danwei = txtDanwei.Text;
            try
            {
                model.salePrice = decimal.Parse(txtSalePrice.Text);
            }
            catch
            {
                model.salePrice = 0;
            }

            try
            {
                model.cusPrice = decimal.Parse(txtCusPrice.Text);
            }
            catch
            {
                model.cusPrice = 0;
            }

            model.mianliao = txtMianliao.Text;
            model.colorname = txtColorName.Text;
            model.parentID = int.Parse(ddlType.SelectedValue);
            model.admindes = txtDescription.Text;
            if (hdfImgPath.Value.Length > 10)
            {
                model.imgPath = hdfImgPath.Value;
            }

            model.cpdes = txtCpmsDes.Value;
            model.fzccdes = txtFzccDes.Value;
            model.xdbxdes = txtXdbyDes.Value;
            model.shfwdes = txtSHfwDes.Value;

            model.desFild1= chkIsCX.Checked == true ? 1 : 0;
            model.isTuijian = chkTuiJian.Checked == true ? 1 : 0;
            model.isHot = chkIsHot.Checked == true ? 1 : 0;

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
    private void Add(Products model)
    {
        int rows = bll.Add(model);
        if (rows > 0)
        {
            SaveExtData(rows, 1);
            Msg.ShowAndRedirect("添加信息成功!", "Default.aspx?codeNo=" + codeNo);
        }
        else
        {
            Msg.Show("添加信息失败!");
        }
    }
    #endregion

    #region 修改
    private void Modify(Products model)
    {
        bll.Update(model);
        SaveExtData(model.id, 0);
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
        DataSet ds = bllCategory.GetAllChildByCodeNoPar(codeNo);
        int pid = bllCategory.GetIdByCodeNo(codeNo);
        CreateLevelDropDown(ddlType, ds.Tables[0], pid);
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

    #region 设置附属栏目

    private void BindExtData()
    {
        chkBoxListExt.DataSource = bllCategory.GetNextNodeByCode_web("sxfl");
        chkBoxListExt.DataTextField = "title";
        chkBoxListExt.DataValueField = "id";
        chkBoxListExt.DataBind();
    }

    private void SaveExtData(int pid, int isadd)
    {
        if (isadd != 1)
        {
            bllProExtCategory.DeleteByPid(pid);
        }
        if (pid > 0)
        {

            ProExtCategory TempExt = new ProExtCategory();
            TempExt.productID = pid;
            for (int i = 0; i < chkBoxListExt.Items.Count; i++)//得到当前选定值
            {
                if (chkBoxListExt.Items[i].Selected)
                {
                    TempExt.extCateID = int.Parse(chkBoxListExt.Items[i].Value);
                    bllProExtCategory.Add(TempExt);
                }
            }
        }
    }

    private void SetSelectIDs(int pid)
    {
        DataTable dt = bllProExtCategory.GetListByPid(pid).Tables[0];
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < chkBoxListExt.Items.Count; i++)//得到当前选定值
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (chkBoxListExt.Items[i].Value.Equals(item["extCateID"] + ""))
                    {
                        chkBoxListExt.Items[i].Selected = true;
                    }
                }
            }
        }
    }
    #endregion
}
