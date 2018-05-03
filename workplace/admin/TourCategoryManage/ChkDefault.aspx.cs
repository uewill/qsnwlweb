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

public partial class admin_TourCategoryManage_ChkDefault : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_TourCategoryManage_ChkDefault));
    private static readonly TourCategoryBLL bll = new TourCategoryBLL();
    private TourCategory model = new TourCategory();
    private CategoryBLL bllCategory = new CategoryBLL(); //文章配置
    List<int> allSels = new List<int>();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string selIDs = QueryStringHelper.GetString("ids");
                string[] stemp = selIDs.Split(',');
                foreach (string s in stemp)
                {
                    try
                    {
                        int i = int.Parse(s);
                        allSels.Add(i);
                    }
                    catch { }
                }
                InitTree();
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }
        foreach (int j in allSels)
        {
            try
            {
                ExtendNode(j);
            }
            catch { }
        }

    }

    #region 绑定栏目
    private void InitTree()
    {

        // treeNav.Attributes.Add("OnClick", "OnTreeNodeChecked()");
        this.treeNav.Nodes.Clear();
        string rootName = "栏目分类";
        TreeNode rootNode = new TreeNode(rootName);
        rootNode.Value = "0";
        //rootNode.NavigateUrl = navigateUrl;
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
            bool flag = false;
            if (allSels.Count > 0)
            {
                foreach (int k in allSels)
                {
                    if (int.Parse(id) == k)
                    {
                        flag = true;
                    }
                }
            }
            TreeNode myNode = new TreeNode();

            myNode.Value = id;
            if (flag)
            {
                myNode.Text = "<input type='checkbox' value='" + id + "' checked='true' title='" + title + "' onclick='dothis(this)'/>" + title;
            }
            else
            {
                myNode.Text = "<input type='checkbox' value='" + id + "' title='" + title + "' onclick='dothis(this)'/>" + title;
            }
            // myNode.NavigateUrl = "javascript:;";
            myNode.SelectAction = TreeNodeSelectAction.Expand;
            parentNode.ChildNodes.Add(myNode);
            InitTreeChild(Convert.ToInt32(id), myNode);
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
        if (ds != null)
        {
            DataTable dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
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
