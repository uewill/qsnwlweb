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

public partial class admin_CustomManage_Custom : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_CustomManage_Custom));
    private static readonly CustomersBLL bll = new CustomersBLL();
    //private static readonly CategoryBLL bllCategory = new CategoryBLL();

    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                InitCustom();
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }

    }
    #endregion

    #region 绑定动作
    private void InitCustom()
    {
        if (Request.QueryString["type"] != null)
        {
            string type = Request.QueryString["type"].ToString();
            string title = string.Empty;// 设置标题
            // 判断动作
            switch (type)
            {
                case "add":
                    title = "用户添加";
                    break;
                case "modify":
                    if (Request.QueryString["id"] != null)
                    {
                        title = "用户修改";
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
        Customers model = bll.GetModel(id);
        if (model != null)
        {

            txtUserName.Text = model.loginName;

            txtTrueName.Text = model.trueName;
            rbtList.SelectedValue = model.cardID;
            txtMail.Text = model.email;
            ddlState.Text = model.stateID.ToString();
            hdfpass.Value = model.loginPass;

        }
    }
    #endregion

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {

        try
        {
            Customers model = new Customers();
            model.cardID = rbtList.SelectedValue;
            model.stateID = int.Parse(ddlState.Text);
            model.trueName = txtTrueName.Text;
            model.loginName = txtUserName.Text;
            model.regDate = DateTime.Now;
            model.email = txtMail.Text;

            string type = this.hdfAction.Value.Trim();
            // 判断动作
            switch (type)
            {
                case "add":
                    model.loginPass = Security.EncryptPassword(model.phone.Substring(5), "MD5");
                    Add(model);
                    break;
                case "modify":
                    model.loginPass = hdfpass.Value;
                    model.id = int.Parse(Request.QueryString["id"].ToString());
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
    private void Add(Customers model)
    {
        int rows = bll.Add(model);
        if (rows > 0)
        {
            Msg.ShowAndRedirect("添加信息成功!", "Default.aspx");
        }
        else
        {
            Msg.Show("添加信息失败!");
        }
    }
    #endregion

    #region 修改
    private void Modify(Customers model)
    {
        bll.Update(model);
        Msg.ShowAndRedirect("修改信息成功!", "Default.aspx");
    }
    #endregion

    #region 返回
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    #endregion
}
