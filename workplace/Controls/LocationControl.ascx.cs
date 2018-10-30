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
            else
            if (parentCategory.codeNo.Equals("dqtk2"))
            {
                activeNav = "navDQTK2";
            }
            
        }
        return activeNav;
    }


    public string GetParentLink()
    {
        string linkCode = string.Empty;
        switch (parentCategory.codeNo)
        {
            case "zxgk":
                linkCode = "lxwm";
                break;
            case "xwzx":
                linkCode = "zxdt";
                break;
            case "xzzqclass":
                linkCode = "xzzq";
                break;
            case "kjbzclass":
                linkCode = "kjbz";
                break;
            case "kdmlclass":
                linkCode = "kdml";
                break;
            case "dqtkclass":
                linkCode = "dqtk";
                break;
            case "dqtk2":
                linkCode = "dqtktktz";
                break;
            case "zpzsclass":
                linkCode = "zpzs";
                break;
            case "kjjcclass":
                linkCode = "kjjc";
                break;
            case "cjcxclass":
                linkCode = "cjcx";
                break;
            default:
                return string.Empty;
        }

        return "<a style=\"color:#202020;\" href=\"/ArticalList.aspx?code=" + linkCode + "\">" + parentCategory.title + "</a>";
    }
}