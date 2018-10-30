using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam_personal_UpdateInfo : System.Web.UI.Page
{
    private TFXK.BLL.TestingPerson testingPersonBLL = new TFXK.BLL.TestingPerson();
    public TFXK.Model.TestingPerson testingPersonModel = new TFXK.Model.TestingPerson();
    private TFXK.BLL.CategoryBLL bllCategory = new TFXK.BLL.CategoryBLL();

    public string currString = string.Empty;

    public string[] currAareas = new string[] { "", "", "" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var data = ExamAuthHelper.GetAuthPersonID(this.Context);
            InitData(data);
        }
    }
    private void InitData(int examid)
    {
        testingPersonModel = testingPersonBLL.GetModel(examid);
        ddlguoji.DataSource = bllCategory.GetNextNodeByCode("kjgj");
        ddlguoji.DataBind();
        ddlguoji.SelectedValue = testingPersonModel.Country;
        ddlmingzu.DataSource = bllCategory.GetNextNodeByCode("kjmz");
        ddlmingzu.DataBind();
        ddlmingzu.SelectedValue = testingPersonModel.Mingzu;
        ddlSex.SelectedValue = testingPersonModel.Sex;

        txtUserName.Value = testingPersonModel.UserName;
        txtUserNamePy.Value = testingPersonModel.UserNamePY;
        txtPhoneNumber.Value = testingPersonModel.PhoneNumber;
        txtBirthday.Value = testingPersonModel.Birthday;
        txtContact.Value = testingPersonModel.Address;
        txtIDNumber.Value = testingPersonModel.IDNumber;
        string[] currAreas = testingPersonModel.Address.Split('|');
        if (currAreas == null || currAreas.Length != 3)
        {
            currAareas = new string[] { "四川省", "成都市", "青羊区" };
        }
        currString = @" var $distpicker = $('#distpicker'); $distpicker.distpicker({province: '" + currAreas[0] + "',city: '" + currAareas[1] + "', district: '" + currAareas[2] + "'}); ";
        txtjjcontact.Value = testingPersonModel.Contactor;
        txtjjship.Value = testingPersonModel.ContactorShip;
        txtjjphone.Value = testingPersonModel.ContactorPhone;
        txtjjaddress.Value = testingPersonModel.HomeAddress;



    }

    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        var testingPersonModel = testingPersonBLL.GetModel(ExamAuthHelper.GetAuthPersonID(this.Context));
        testingPersonModel.UserNamePY = txtUserNamePy.Value.Trim();
        testingPersonModel.PhoneNumber = txtPhoneNumber.Value;
        testingPersonModel.Birthday = txtBirthday.Value;
        testingPersonModel.Address = txtContact.Value;
        testingPersonModel.Contactor = txtjjcontact.Value;
        testingPersonModel.ContactorShip = txtjjship.Value;
        testingPersonModel.ContactorPhone = txtjjphone.Value;
        testingPersonModel.HomeAddress = txtjjaddress.Value;
        testingPersonModel.Sex = ddlSex.SelectedValue;
        testingPersonModel.Country = ddlguoji.SelectedValue;
        testingPersonModel.Mingzu = ddlmingzu.SelectedValue;
        testingPersonModel.UserName = txtUserName.Value;
        testingPersonModel.IDNumber = txtIDNumber.Value;

        testingPersonBLL.Update(testingPersonModel);
        TFXK.Common.Jscript.AlertAndRedirect("修改成功", "updateinfo.aspx");
    }
}