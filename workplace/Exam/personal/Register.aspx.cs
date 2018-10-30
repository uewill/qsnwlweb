using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Common;

public partial class Exame_Personal_Login : System.Web.UI.Page
{
    private TFXK.BLL.TestingPerson testingPersonBLL = new TFXK.BLL.TestingPerson();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void btnLogin_ServerClick(object sender, EventArgs e)
    {
        TFXK.Model.TestingPerson testingPerson = new TFXK.Model.TestingPerson();

        testingPerson.UserName = this.txtName.Value.Trim();
        testingPerson.PhoneNumber = this.txtPhone.Value.Trim();
        testingPerson.UserPassword = this.txtPass.Value.Trim();
        string txtPass2 = this.txtPass2.Value.Trim();
        if (string.IsNullOrEmpty(testingPerson.UserName))
        {
            Msg.Show("考生名称不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(testingPerson.PhoneNumber) || testingPerson.PhoneNumber.Length!=11)
        {
            Msg.Show("请输入正确手机号码!");
            return;
        }
        if (string.IsNullOrEmpty(testingPerson.UserPassword))
        {
            Msg.Show("登录密码不能为空!");
            return;
        }
        if (!testingPerson.UserPassword.Equals(txtPass2))
        {
            Msg.Show("登录密码不匹配!");
            return;
        }
        if (testingPersonBLL.Exists(testingPerson.PhoneNumber))
        {
            Msg.Show("手机号已存在!");
            return;
        }
        testingPerson.Status = 0;
        int res = testingPersonBLL.Add(testingPerson);
        if (res > 0)
        {
            Response.Cookies.Add(new HttpCookie("PersonID", Security.EncryptDES(res.ToString(), "UEMASTER")));
            Session["PersonID"] = res.ToString();
            Response.Redirect("Default.aspx");
        }
        else
        {
            Msg.Show("注册失败!");
            return;
        }
    }
}