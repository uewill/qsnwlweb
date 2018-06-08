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
            if (parentCategory.codeNo.Equals("xgwjclass"))
            {
                activeNav = "navXGWJ";
            }
            else
            if (parentCategory.codeNo.Equals("xzzqclass"))
            {
                activeNav = "navXZZQ";
            }
            else
            if (parentCategory.codeNo.Equals("kjbzclass"))
            {
                activeNav = "navKJBZ";
            }
            else
            if (parentCategory.codeNo.Equals("kdmlclass"))
            {
                activeNav = "navKDML";
            }
            else
            if (parentCategory.codeNo.Equals("dqtkclass"))
            {
                activeNav = "navDQTK";
            }
            else
            if (parentCategory.codeNo.Equals("zpzsclass"))
            {
                activeNav = "navZPZS";
            }
            else
            if (parentCategory.codeNo.Equals("kjjcclass"))
            {
                activeNav = "navKJJC";
            }
            else
            if (parentCategory.codeNo.Equals("kdml"))
            {
                activeNav = "navKDML";
            }
        }
        return activeNav;
    }
}