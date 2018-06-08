using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exame_ExtMaster : System.Web.UI.MasterPage
{
    public TFXK.Model.TestingCenter testingCenter = new TFXK.Model.TestingCenter();
    private TFXK.BLL.TestingCenter testingCenterBLL = new TFXK.BLL.TestingCenter();
    protected void Page_Load(object sender, EventArgs e)
    {
        testingCenter = ExamAuthHelper.GetAuthData(this.Context);
        if (testingCenter == null)
        {
            Response.Redirect("login.aspx");
            return;
        }
        if (testingCenter.Status == 0)
        {
            Response.Redirect("uploadinfo.aspx");
            return;
        }
        if (testingCenter.Status == 1)
        {
            Response.Redirect("WaitForAudit.aspx");
            return;
        }

    }

    public TFXK.Model.TestingCenter GetData()
    {
        return testingCenter;
    }
}
