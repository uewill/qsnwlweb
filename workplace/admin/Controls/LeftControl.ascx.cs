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
using log4net;
using TFXK.BLL;
using System.Collections.Generic;
using TFXK.Common;
using DevExpress.Web.ASPxNavBar;

public partial class admin_Controls_LeftControl : System.Web.UI.UserControl
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_Controls_LeftControl));
    private static readonly CategoryBLL bll = new CategoryBLL();
    private static readonly UsersBLL bllUser = new UsersBLL();
    private Category model = new Category();
    private static readonly string navigateUrl = "Default.aspx";
    private static readonly string tempQZUrl = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Users UserModel = bllUser.GetModelByUserName(Context.User.Identity.Name);
                if (UserModel != null)
                {
                    if (UserModel.roleid == 1)
                    {
                        InitTree();
                    }
                }
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
            }
            catch { }
        }
    }

    #region 绑定栏目
    private void InitTree()
    {
        this.treeNav.Nodes.Clear();
        string rootName = "栏目列表";
        TreeNode rootNode = new TreeNode(rootName);
        rootNode.Value = "0";
        rootNode.NavigateUrl = "javascript:void(0);";
        InitTreeChild(0, rootNode);
        this.treeNav.Nodes.Add(rootNode);

        // 

        //关于我们
        //NavBarGroup myNavGroup = ASPxNavBar5.Groups.FindByName("navYLGS");
        //DataSet ds = bll.GetNextNodeByCode("ylgs");
        //if (ds != null && ds.Tables[0] != null)
        //{
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        myNavGroup.Items.Add(dr["title"] + "", dr["codeNo"] + "", "", "../CategoryManage/Description.aspx?code=" + dr["codeNo"], "Frame1");
        //    }
        //}
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
        DataSet ds = bll.GetList("parentId=" + parentId + " and stateid=1");
        string title = string.Empty;
        string id = string.Empty;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            title = dr["title"].ToString();
            id = dr["id"].ToString();
            TreeNode myNode = new TreeNode(title);
            myNode.Value = id;
            myNode.Target = "Frame1";

            if (!bll.HasChild(int.Parse(dr["id"].ToString())))
            {
               
                //if (dr["parentid"].ToString().Equals("18"))
                //{
                //    myNode.NavigateUrl = "../ProductsManage/?parentId=" + dr["id"];
                //}
                //else if (dr["parentid"].ToString().Equals("27"))
                //{
                //    myNode.NavigateUrl = "../SGProductsManage/?parentId=" + dr["id"];
                //}
                //else if (dr["codeNo"].ToString().Equals("jmdzs"))
                //{
                //    myNode.NavigateUrl = "../SGDPManage/?parentId=" + dr["id"];
                //}
                //else
                //{

                    if (dr["codeNo"].ToString().Equals("jdlygstj"))
                    {
                        myNode.NavigateUrl = "../CompanyLineManage/";
                    }
                    else
                    {
                        //内容展示栏目 分类
                        if (dr["typeID"].ToString().Equals("0"))
                        {
                            myNode.NavigateUrl = "../CategoryManage/Description.aspx?code=" + dr["codeNo"];
                        }
                        else if (dr["typeID"].ToString().Equals("3"))
                        {
                            continue;
                        }
                    else
                    {
                            myNode.NavigateUrl = "../ArticlesManage/Default.aspx?codeNo=" + dr["codeNo"];
                        }
                    }
                //}
            }
            else
            {
                myNode.SelectAction = TreeNodeSelectAction.Expand;
            }

            parentNode.ChildNodes.Add(myNode);
            InitTreeChild(Convert.ToInt32(id), myNode);
        }
    }
    #endregion

    #region 无限级绑定
    /// <summary>
    /// 无限级绑定
    /// </summary>
    /// <param name="parentId">父分类编号</param>
    /// <param name="parentNode">TreeNode</param>
    private void InitTreeChild2(int parentId, TreeNode parentNode)
    {
        DataSet ds = bll.GetList("parentId=" + parentId + " and stateid=1");
        string title = string.Empty;
        string id = string.Empty;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            title = dr["title"].ToString();
            id = dr["id"].ToString();
            TreeNode myNode = new TreeNode(title);
            myNode.Value = id;
            myNode.Target = "Frame1";

            if (!bll.HasChild(int.Parse(dr["id"].ToString())))
            {
                ////内容展示栏目 分类
                //if (dr["typeID"].ToString().Equals("0"))
                //{
                myNode.NavigateUrl = "../VisaManage/Description.aspx?cid=" + dr["id"];
                //}
                //else if (dr["typeID"].ToString().Equals("3"))
                //{
                //    continue;
                //}
                //else
                //{
                //    myNode.NavigateUrl = "../ArticlesManage/Default.aspx?codeNo=" + dr["codeNo"];
                //}
            }
            else
            {
                myNode.SelectAction = TreeNodeSelectAction.Expand;
            }

            parentNode.ChildNodes.Add(myNode);
            InitTreeChild2(Convert.ToInt32(id), myNode);
        }
    }
    #endregion

}
