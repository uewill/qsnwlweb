using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Common;

public partial class Exame_Login : System.Web.UI.Page
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
        string txtName = this.txtName.Value.Trim();
        string txtPass = this.txtPass.Value.Trim();
        if (string.IsNullOrEmpty(txtName))
        {
            Msg.Show("考生名不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(txtPass))
        {
            Msg.Show("登录密码不能为空!");
            return;
        }

        var model = testingPersonBLL.GetModelByPhone(txtName);
        if (model == null)
        {
            Msg.Show("考生不存在!");
            return;
        }
        if (!model.UserPassword.Equals(Security.EncryptDES(txtPass, "UEMASTER")))
        {
            Msg.Show("帐号与密码不匹配!");
            return;
        }
        if (model.Status == 3)
        {
            Msg.Show("考生已被停止登录,请与管理员联系!");
            return;
        }
        Session["PersonID"] = model.id;
        Response.Cookies.Add(new HttpCookie("PersonID", Security.EncryptDES(model.id.ToString(), "UEMASTER")));
        Response.Redirect("Default.aspx");
    }
}