using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Common;

public partial class Exame_Login : System.Web.UI.Page
{
    private TFXK.BLL.TestingCenter testingCenterBLL = new TFXK.BLL.TestingCenter();
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
            Msg.Show("考点名不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(txtPass))
        {
            Msg.Show("登录密码不能为空!");
            return;
        }

        var model = testingCenterBLL.GetModelByName(txtName);
        if (model == null)
        {
            Msg.Show("考点不存在!");
            return;
        }
        if (!model.UserPass.Equals(Security.EncryptDES(txtPass, "UEMASTER")))
        {
            Msg.Show("帐号与密码不匹配!");
            return;
        }
        if (model.Status == 3)
        {
            Msg.Show("考点已被停止登录,请与管理员联系!");
            return;
        }
        Session["ExamID"] = model.id;
        Response.Cookies.Add(new HttpCookie("ExamID", Security.EncryptDES(model.id.ToString(), "UEMASTER")));
        if (model.Status == 0)
        {
            Response.Redirect("UploadInfo.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}