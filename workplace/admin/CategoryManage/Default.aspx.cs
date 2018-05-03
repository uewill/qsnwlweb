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
using TFXK.BLL;
using TFXK.Model;
using log4net;
using TFXK.Common;
using System.Collections.Generic;

public partial class admin_CategoryManage_Default : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_CategoryManage_Default));
    private static readonly CategoryBLL bll = new CategoryBLL();
    private Category model = new Category();
    private static readonly string navigateUrl = "Default.aspx";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                InitTree();
                BindRight();

                // CreateLevelDropDown(DropDownList1, bll.GetList("").Tables[0]);
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
        if (Request.QueryString["id"] != null)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"] + "");
                ExtendNode(id);
            }
            catch { }
        }
    }

    #region 绑定栏目
    private void InitTree()
    {
        this.treeNav.Nodes.Clear();
        string rootName = "栏目分类";
        TreeNode rootNode = new TreeNode(rootName);
        rootNode.Value = "0";
        rootNode.NavigateUrl = navigateUrl;
        InitTreeChild(0, rootNode);
        this.treeNav.Nodes.Add(rootNode);
    }
    #endregion

    #region 无限级绑定
    /// <summary>
    /// 无限级绑定
    /// </summary>
    /// <param name="parentId">父分类编号</param>
    /// <param name="parentNode">TreeNode</param>
    private void InitTreeChild(int parentId, TreeNode parentNode)
    {
        DataSet ds = bll.GetList("parentId=" + parentId);
        string title = string.Empty;
        string id = string.Empty;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            title = dr["title"].ToString();
            id = dr["id"].ToString();
            TreeNode myNode = new TreeNode(title);
            myNode.Value = id;
            myNode.NavigateUrl = navigateUrl + "?id=" + id;
            parentNode.ChildNodes.Add(myNode);
            InitTreeChild(Convert.ToInt32(id), myNode);
        }
    }
    #endregion

    #region 绑定下拉列表

    ///   <summary>   
    ///   创建分级下拉框   
    ///   </summary>   
    private void CreateLevelDropDown(DropDownList ddlst, DataTable dt)
    {
        System.Collections.ArrayList allItems = new ArrayList();
        DataRow[] rows = dt.Select("[parentid]=" + 0);
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

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        //验证代码
        try
        {
            if (string.IsNullOrEmpty(Request.QueryString["type"] + ""))
            {
                Category model = new Category();
                model.codeNo = txtCode.Text.Trim().Replace(" ", "");
                model.id = int.Parse(hdfnodeID.Value);
                model.parentID = int.Parse(hdfparentID.Value);
                model.title = txtTitle.Text;
                model.orderId = int.Parse(hdforderID.Value);
                model.description = hdfDes.Value;
                model.stateID = ddlState.SelectedIndex;
                model.imgPath = hdfImg.Value;
                model.typeID = int.Parse(rbtType.SelectedItem.Value + "");
                model.outLink = txtLink.Text;
                bll.Update(model);
                Response.Redirect("Default.aspx?id=" + model.id, false);
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["type"] + ""))
                {
                    Category model = new Category();
                    model.title = txtTitle.Text;
                    model.codeNo = txtCode.Text;
                    // 防止网页重复提交

                    if (!bll.ExistsCode(model.codeNo))
                    {
                        try
                        {
                            model.parentID = int.Parse(Request.QueryString["pid"]);
                        }
                        catch
                        {
                            Msg.Show("参数错误！");
                        }
                        model.orderId = bll.GetChildNum(model.parentID);
                        model.description = "";
                        model.stateID = ddlState.SelectedIndex;
                        model.typeID = rbtType.SelectedIndex;
                        model.outLink = txtLink.Text;
                        // model.imgPath = 
                        int res = bll.Add(model);
                        Response.Redirect("Default.aspx?id=" + res, false);
                    }
                    else
                    {
                        Msg.Show("编码已存在！");
                    }

                }
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            Msg.Show("网络错误!原因:" + ex.Message);
        }
    }
    #endregion


    #region 绑定右边
    public void BindRight()
    {
        Category model = new Category();
        int id = 0;
        try
        {
            if (!string.IsNullOrEmpty(Request.QueryString["type"] + ""))
            {
                ASPxRoundPanel2.Visible = true;
                if (Request.QueryString["type"].ToString().Equals("add"))
                {
                    try
                    {
                        id = int.Parse(Request.QueryString["id"] + "");

                    }
                    catch
                    {
                        id = 0;
                        return;
                    }
                    model = bll.GetModel(id);
                    hdforderID.Value = model.orderId + "";
                    hdfDes.Value = model.description;
                }
                else
                {
                    id = int.Parse(Request.QueryString["id"] + "");
                    model = bll.GetModel(id);
                    hdforderID.Value = model.orderId + "";
                    hdfDes.Value = model.description;
                    hdfImg.Value = model.imgPath;
                    if (!string.IsNullOrEmpty(model.imgPath))
                    {
                        newsImg.Src = "../../uploads/" + model.imgPath;
                        newsImg.Attributes.CssStyle.Add("display", "block");
                    }
                    txtLink.Text = model.outLink;
                    ddlState.SelectedIndex = model.stateID;
                    try
                    {
                        rbtType.SelectedIndex = model.typeID;
                    }
                    catch { }
                }
                hdfnodeID.Value = Request.QueryString["id"] + "";
                hdfparentID.Value = Request.QueryString["pid"] + "";

            }
            else
            {
                id = int.Parse(Request.QueryString["id"] + "");
                ASPxRoundPanel2.Visible = true;
                if (id != 0)
                {
                    model = bll.GetModel(id);
                    hdfnodeID.Value = id + "";
                    hdfparentID.Value = model.parentID + "";
                    hdforderID.Value = model.orderId + "";
                    hdfDes.Value = model.description;
                    txtTitle.Text = model.title;
                    txtCode.Text = model.codeNo;
                    hdfImg.Value = model.imgPath;
                    if (!string.IsNullOrEmpty(model.imgPath))
                    {
                        newsImg.Src = "../../uploads/" + model.imgPath;
                        newsImg.Attributes.CssStyle.Add("display", "block");
                    }
                    ddlState.SelectedIndex = model.stateID;
                    txtLink.Text = model.outLink;
                    try
                    {
                        rbtType.SelectedIndex = model.typeID;
                    }
                    catch { }
                }
            }
            if (model.typeID == 3)
            { //链接的隐藏显示
                //divLink.Visible = true;
                divLink.Attributes.CssStyle.Add("display", "block");
            }
            else
            {
                divLink.Attributes.CssStyle.Add("display", "none");
            }

            if (Request.QueryString["type"] != null)
            {
                if (Request.QueryString["type"].ToString().Equals("add") || Request.QueryString["type"].ToString().Equals("addchild"))
                {
                    txtCode.Enabled = true;
                }
                else
                {
                    txtCode.Enabled = false;
                }
            }
        }
        catch
        {
            ASPxRoundPanel2.Visible = false;
        }
    }
    #endregion

    #region 添加同级栏目
    protected void btnAddOne_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx?type=add&pid=" + hdfparentID.Value + "&id=" + hdfnodeID.Value, false);
    }
    #endregion

    #region 添加子级栏目
    protected void btnAddChild_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx?type=addchild&pid=" + hdfnodeID.Value + "&id=" + hdfnodeID.Value, false);
    }
    #endregion

    #region 添加下移栏目
    protected void btnDown_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hdfnodeID.Value);
        int orderid = int.Parse(hdforderID.Value);
        // 防止网页重复提交
        List<int> oid = bll.GetUpOrDownOrderID(id, orderid, 0);
        if (oid != null)
        {
            bll.UpdateOrderId(id, oid[0]);
            bll.UpdateOrderId(oid[1], orderid);
            Response.Redirect("Default.aspx?id=" + id, false);
        }
    }
    #endregion

    #region 添加上移栏目
    protected void btnUp_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hdfnodeID.Value);
        int orderid = int.Parse(hdforderID.Value);
        // 防止网页重复提交

        List<int> oid = bll.GetUpOrDownOrderID(id, orderid, 1);
        if (oid != null)
        {
            bll.UpdateOrderId(id, oid[0]);
            bll.UpdateOrderId(oid[1], orderid);
            Response.Redirect("Default.aspx?id=" + id, false);
        }
    }
    #endregion

    #region 删除栏目
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int id = 0;
        try
        {
            id = int.Parse(hdfnodeID.Value);
        }
        catch
        {
            Msg.Show("没有选择栏目");
        }
        if (id != 0)
        {
            if (!bll.HasChild(id))
            {
                int pid = bll.GetModel(id).parentID;
                bll.Delete(id);
                bll.UpdateOrderByDel(int.Parse(hdfparentID.Value), int.Parse(hdforderID.Value));
                Msg.ShowAndRedirect("删除成功！", "Default.aspx?id=" + pid);
            }
            else
            {
                Msg.Show("该类含有子分类,请先删除子分类！");
            }
        }

    }
    #endregion


    #region 展开树当前选择的节点、
    /// <summary>
    /// 展开树当前选择的节点
    /// </summary>
    /// <param name="id">当前值</param>
    public void ExtendNode(int id)
    {
        treeNav.CollapseAll();
        DataSet ds = bll.GetParentIdsByID(id);
        string navTitle = string.Empty;
        if (ds != null)
        {
            DataTable dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["pid"].ToString().Equals("0"))
                {
                    //  navTitle = "当前位置:栏目分类 >";
                }
                else
                {
                    navTitle = bll.GetModel(int.Parse(dr["pid"].ToString())).title + ">" + navTitle;
                }



                TreeNodeCollection tc = treeNav.Nodes;
                foreach (TreeNode node in tc)
                {
                    if (dr["pid"].ToString().Equals(node.Value))
                    {
                        node.Expand();
                    };
                    showName(node, dr["pid"].ToString());
                }
            }
        }
        ASPxRoundPanel2.HeaderText = navTitle + bll.GetModel(id).title;
        if (Request.QueryString["type"] != null)
        {
            if (Request.QueryString["type"].ToString().Equals("add"))
            {

                ASPxRoundPanel2.HeaderText += " > [添加同级分类]";

            }
            else
            {
                ASPxRoundPanel2.HeaderText += " > [添加子级分类]";
            }
        }
        else
        {
            ASPxRoundPanel2.HeaderText += " > [修改分类]";

        }
    }



    private void showName(TreeNode treenode, string value)   //递归检测每个分支下的节点 
    {
        foreach (TreeNode tn in treenode.ChildNodes)
        {
            if (value.Equals(tn.Value))
            {
                tn.Expand();
            };
            this.showName(tn, value);
        }
    }


    #endregion
}
