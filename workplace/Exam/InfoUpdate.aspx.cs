using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Common;

public partial class Exame_InfoUpdate : System.Web.UI.Page
{
    private TFXK.BLL.TestingCenter testingCenterBLL = new TFXK.BLL.TestingCenter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var testingCenter = ExamAuthHelper.GetAuthData(this.Context);
            this.txtName.Value = testingCenter.KDName;
            this.txtAddress.Value = testingCenter.Address;
            this.txtUserName.Value = testingCenter.UserName;
            this.txtPhone.Value = testingCenter.UserPhone;
            this.txtTel.Value = testingCenter.UserTel;
            this.txtEmail.Value = testingCenter.UserEmail;
            this.txtDes.Value = testingCenter.KDDescription;


        }
    }

    protected void btnReg_ServerClick(object sender, EventArgs e)
    {
        try
        {
            TFXK.Model.TestingCenter testingCenter = ExamAuthHelper.GetAuthData(this.Context); ;
            testingCenter.Address = this.txtAddress.Value.Trim();
            testingCenter.UserName = this.txtUserName.Value.Trim();
            testingCenter.UserPhone = this.txtPhone.Value.Trim();
            testingCenter.UserTel = this.txtTel.Value.Trim();
            testingCenter.UserEmail = this.txtEmail.Value.Trim();
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
            if (chkChangePass.Checked)
            {
                if (string.IsNullOrEmpty(testingCenter.UserPass))
                {
                    Msg.Show("密码不能为空!");
                    return;
                }
                if (!testingCenter.UserPass.Equals(password2))
                {
                    Msg.Show("密码输入不一致!");
                    return;
                }
                testingCenter.UserPass = Security.EncryptDES(testingCenter.UserPass, "UEMASTER");
            }
            if (testingCenterBLL.Update(testingCenter))
            {
                Msg.ShowAndRedirect("更新成功", "default.aspx");
            }
            else
            {
                Msg.Show("更新失败!");
                return;
            }

        }
        catch (Exception ex)
        {
            Msg.Show("更新失败!" + ex.Message);
            return;
        }
    }
}