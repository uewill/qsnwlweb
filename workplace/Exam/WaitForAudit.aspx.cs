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
        if (testingCenter != null && testingCenter.Status == 1)
        {
            //wait
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}