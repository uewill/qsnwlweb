using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFXK.Common;

public partial class Exame_UploadInfo : System.Web.UI.Page
{
    private TFXK.BLL.TestingCenter testingCenterBLL = new TFXK.BLL.TestingCenter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var data = ExamAuthHelper.GetAuthData(this.Context);
            InitData(data.id);
        }
    }
    private void InitData(int examid)
    {
        TFXK.Model.TestingCenter testingCenter = new TFXK.Model.TestingCenter();
        testingCenter = testingCenterBLL.GetModel(examid);
        txtID.Value = testingCenter.IDNo;
        this.txtIDImg1.Value = testingCenter.IDImage;
        this.txtIDImg2.Value = testingCenter.IDImage2;
        this.txtYYZZ.Value = testingCenter.WorkImage;
        if (!string.IsNullOrEmpty(testingCenter.IDImage))
        {
            imgID1.Src = testingCenter.IDImage;
        }
        if (!string.IsNullOrEmpty(testingCenter.IDImage2))
        {

            imgID2.Src = testingCenter.IDImage2;
        }
        if (!string.IsNullOrEmpty(testingCenter.WorkImage))
        {
            imgID3.Src = testingCenter.WorkImage;
        }
    }

    protected void btnReg_ServerClick(object sender, EventArgs e)
    {
        try
        {
            TFXK.Model.TestingCenter testingCenter = new TFXK.Model.TestingCenter();
            testingCenter = testingCenterBLL.GetModel(ExamAuthHelper.GetAuthCenterID(this.Context));
            testingCenter.IDNo = txtID.Value.Trim();
            testingCenter.IDImage = this.txtIDImg1.Value.Trim();
            testingCenter.IDImage2 = this.txtIDImg2.Value.Trim();
            testingCenter.WorkImage = this.txtYYZZ.Value.Trim();
            if (string.IsNullOrEmpty(testingCenter.IDNo))
            {
                Msg.Show("请填写身份证号码!");
                return;
            }
            if (string.IsNullOrEmpty(testingCenter.IDImage))
            {
                Msg.Show("请上传身份证正面照!");
                return;
            }
            else
            {
                imgID1.Src = testingCenter.IDImage;
            }
            if (string.IsNullOrEmpty(testingCenter.IDImage2))
            {
                Msg.Show("请上传身份证背面照!");
                return;
            }
            else
            {
                imgID2.Src = testingCenter.IDImage2;
            }
            if (string.IsNullOrEmpty(testingCenter.WorkImage))
            {
                Msg.Show("请上传营业执照照片!");
                return;
            }
            else
            {
                imgID3.Src = testingCenter.WorkImage;
            }


            testingCenter.Status = 1;
            bool res = testingCenterBLL.Update(testingCenter);
            if (res)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Msg.Show("保存失败!");
                return;
            }
        }
        catch (Exception ex)
        {
            Msg.Show("保存失败!" + ex.Message);
            return;
        }
    }
}