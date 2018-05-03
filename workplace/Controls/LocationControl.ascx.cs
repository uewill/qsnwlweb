using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_LocationControl : System.Web.UI.UserControl
{
    public TFXK.Model.Category currentCategory = new TFXK.Model.Category();
    public TFXK.Model.Category parentCategory = new TFXK.Model.Category();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    public string GetNavName()
    {
        string activeNav = string.Empty;
        if (parentCategory != null)
        {
            if (parentCategory.codeNo.Equals("zxgk"))
            {
                activeNav = "navAbout";
            }
            else
            if (parentCategory.codeNo.Equals("xwzx"))
            {
                activeNav = "navNews";
            }
            else
            if (parentCategory.codeNo.Equals("skjzxx"))
            {
                activeNav = "navSK";
            }
            else
            if (parentCategory.codeNo.Equals("yszx"))
            {
                activeNav = "navYSZX";
            }
            else
            if (parentCategory.codeNo.Equals("tjyk"))
            {
                activeNav = "navTJYK";
            }
            else
            if (parentCategory.codeNo.Equals("edu"))
            {
                activeNav = "navQSN";
            }
            else
            if (parentCategory.codeNo.Equals("xchq"))
            {
                activeNav = "navYC";
            }
        }
        return activeNav;
    }
}