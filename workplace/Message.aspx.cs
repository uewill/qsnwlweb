using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : System.Web.UI.Page
{
    private TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();
    private TFXK.BLL.MessagesBLL bllMessage = new TFXK.BLL.MessagesBLL();
    public TFXK.Model.Category currentCategory = new TFXK.Model.Category();
    public TFXK.Model.Category parentCategory = new TFXK.Model.Category();

    public string activeNav = "navHome";
    protected void Page_Load(object sender, EventArgs e)
    {
        InitData();
        if (!IsPostBack)
        {

        }
    }


    private void InitData()
    {
        string code = Request.QueryString["code"] + "";
        if (string.IsNullOrEmpty(code))
        {
            code = "zxly";
        }

        currentCategory = bllCategory.GetModel(code);
        if (currentCategory != null)
        {
            LocationControl.currentCategory = currentCategory;
            LeftNavControl.navParentID = currentCategory.parentID;
            LeftNavControl.navCode = code;
            parentCategory = bllCategory.GetModel(currentCategory.parentID);
            if (parentCategory != null)
            {
                //set nav
                LocationControl.parentCategory = parentCategory;
                activeNav = LocationControl.GetNavName();

                LeftNavControl.navTitle = parentCategory.title;
                Page.Title = currentCategory.title + "-" + parentCategory.title;
            }
            else
            {
                LeftNavControl.navTitle = currentCategory.title;
                Page.Title = currentCategory.title;
            }



        }
        else
        {
            Response.Redirect("~/");
        }
    }

    protected void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTitle.Value.Trim()))
        {
            TFXK.Common.Jscript.Alert("标题不能为空");
            return;
        }
        if (string.IsNullOrWhiteSpace(txtContent.Value.Trim()))
        {
            TFXK.Common.Jscript.Alert("留言不能为空");
            return;
        }
        if (string.IsNullOrWhiteSpace(txtUserName.Value.Trim()))
        {
            TFXK.Common.Jscript.Alert("联系人不能为空");
            return;
        }
        if (string.IsNullOrWhiteSpace(txtUserPhone.Value.Trim()))
        {
            TFXK.Common.Jscript.Alert("联系方式不能为空");
            return;
        }
        TFXK.Model.Messages message = new TFXK.Model.Messages();
        message.title = txtTitle.Value.ToString();
        message.msgContent = txtContent.Value.ToString();
        message.userNames = txtUserName.Value.ToString();
        message.userEmail = txtUserPhone.Value.ToString();
        message.createTime = DateTime.Now;
        int i = bllMessage.Add(message);

        if (i > 0)
        {

            TFXK.Common.Jscript.AlertAndRedirect("添加成功", "Message.aspx");
        }
        else
        {

            TFXK.Common.Jscript.Alert("添加失败");
        }
    }
}