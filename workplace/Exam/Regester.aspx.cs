using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Common;

public partial class Exame_Regester : System.Web.UI.Page
{
    private TFXK.BLL.TestingCenter testingCenterBLL = new TFXK.BLL.TestingCenter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void btnReg_ServerClick(object sender, EventArgs e)
    {
        try
        {
            TFXK.Model.TestingCenter testingCenter = new TFXK.Model.TestingCenter();
            testingCenter.KDName = this.txtName.Value.Trim();
            testingCenter.Address = this.txtAddress.Value.Trim();
            testingCenter.UserName = this.txtUserName.Value.Trim();
            testingCenter.UserPhone = this.txtPhone.Value.Trim();
            testingCenter.UserTel = this.txtTel.Value.Trim();
            testingCenter.UserEmail = this.txtEmail.Value.Trim();
            testingCenter.UserPass = this.txtPass.Value.Trim();
            testingCenter.KDDescription = this.txtDes.Value.Trim();

            string password2 = this.txtPass2.Value.Trim();
            if (string.IsNullOrEmpty(testingCenter.KDName))
            {
                Msg.Show("考点名称不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(testingCenter.Address))
            {
                Msg.Show("考点地址不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(testingCenter.UserName))
            {
                Msg.Show("负责人名称不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(testingCenter.UserPhone))
            {
                Msg.Show("负责人电话不能为空!");
                return;
            }
            if (!testingCenter.UserPass.Equals(password2))
            {
                Msg.Show("密码输入不一致!");
                return;
            }
            if (string.IsNullOrEmpty(testingCenter.UserPass))
            {
                Msg.Show("密码不能为空!");
                return;
            }
            if (testingCenterBLL.ExistsName(testingCenter.KDName))
            {
                Msg.Show("考点名已存在!");
                return;
            }
            testingCenter.Status = 0;
            int res = testingCenterBLL.Add(testingCenter);
            if (res > 0)
            {
                Response.Cookies.Add(new HttpCookie("ExamID", res.ToString()));
                Session["ExamID"] = res.ToString();
                Response.Redirect("UploadInfo.aspx");
            }
            else
            {
                Msg.Show("注册失败!");
                return;
            }
        }
        catch (Exception ex)
        {
            Msg.Show("注册失败!" + ex.Message);
            return;
        }
    }
}