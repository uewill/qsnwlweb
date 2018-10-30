using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exame_ExtMasterPerson : System.Web.UI.MasterPage
{
    public TFXK.Model.TestingPerson testingPerson = new TFXK.Model.TestingPerson();
    private TFXK.BLL.TestingCenter testingCenterBLL = new TFXK.BLL.TestingCenter();
    protected void Page_Load(object sender, EventArgs e)
    {
        testingPerson = ExamAuthHelper.GetPersonAuthData(this.Context);
        if (testingPerson == null)
        {
            Response.Redirect("login.aspx");
            return;
        }
    }

    public TFXK.Model.TestingPerson GetData()
    {
        return testingPerson;
    }
}
