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
    private TFXK.BLL.TestingPerson testingPerson = new TFXK.BLL.TestingPerson();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void btnLogin_ServerClick(object sender, EventArgs e)
    {
        int type = 0;
        int.TryParse(Request.QueryString["type"] + "", out type);

        string txtName = this.txtPhoneNumber.Value.Trim();
        if (string.IsNullOrEmpty(txtName))
        {
            Msg.Show("考点名不能为空!");
            return;
        }

        if (!(Session["valicode" + txtName] + "").Equals(txtValicode.Value))
        {
            Msg.Show("验证码不正确!");
            return;
        }

        if (!txtPassword.Value.Equals(txtPassword2.Value))
        {
            Msg.Show("输入密码不一致!");
            return;
        }

        if (type == 0)
        {//考点
            var model = testingCenterBLL.GetModelByName(txtName);
            if (model == null)
            {
                Msg.Show("考点不存在!");
                return;
            }
            model.UserPass = txtPassword.Value.Trim();
            testingCenterBLL.Update(model);

            TFXK.Common.Jscript.AlertAndRedirect("修改密码成功", "/exam/login.aspx");
        }
        else if (type == 1)
        {
            var model = testingPerson.GetModelByPhone(txtName);
            if (model == null)
            {
                Msg.Show("考生不存在!");
                return;
            }
            model.UserPassword = txtPassword.Value.Trim();
            testingPerson.Update(model);
            TFXK.Common.Jscript.AlertAndRedirect("修改密码成功","/exam/personal/login.aspx");
        }
    }

}