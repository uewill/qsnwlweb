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

public partial class admin_UserManage_Action : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_UserManage_Action));
    private static readonly UsersBLL bll = new UsersBLL();
    private static readonly CategoryBLL bllCategory = new CategoryBLL();

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
                        txtPass.Password = false;
                        this.txtPass.Enabled = false;
                        this.txtUserName.Enabled = false;
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
        Users model = bll.GetModel(id);
        if (model != null)
        {
            txtMail.Text = model.email;
            txtPass.Text = model.password;
            txtTel.Text = model.telephone;
            txtTrueName.Text = model.trueName;
            txtUserName.Text = model.userName;
            ddlState.SelectedValue = model.state + "";
            linkModify.NavigateUrl = "modfyPass.aspx?username=" + model.userName;
            linkModify.Visible = true;
          
        }
    }
    #endregion

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        //验证代码
        try
        {
            Users model = new Users();
            model.trueName = txtTrueName.Text;
            model.userName = txtUserName.Text;
            model.telephone = txtTel.Text;
            model.state = int.Parse(ddlState.SelectedValue);
            model.email = txtMail.Text;
            model.password = txtPass.Text;

            model.roleid = 0;
            model.loginCount = 0;
            model.question = "";
            model.address = "";
            model.answer = "";
            model.description = "";
            model.regDate = DateTime.Now;
            model.lastLoginDate = DateTime.Now;
            string type = this.hdfAction.Value.Trim();
            // 判断动作
            switch (type)
            {
                case "add":
                    Add(model);
                    break;
                case "modify":
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
    private void Add(Users model)
    {
        if (bll.Exists(model.userName))
        {
            Msg.Show("此用户名已存在！");
        }
        else
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

    }
    #endregion

    #region 修改
    private void Modify(Users model)
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
