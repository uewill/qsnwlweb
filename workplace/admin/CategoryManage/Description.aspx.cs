using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TFXK.Common;
using TFXK.Model;
using log4net;
using TFXK.BLL;

public partial class admin_CategoryManage_Description : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_CategoryManage_Description));
    private static readonly CategoryBLL bll = new CategoryBLL();
    private Category model = new Category();
    private bool falg = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }

    }

    public void InitData()
    {
        string code = Request.QueryString["code"];
        if (!string.IsNullOrEmpty(code))
        {
                model = bll.GetModel(StringUtil.CheckStr(code));
                if (model != null)
                {
                    DataTable dt = bll.GetAllChildByCode(model.codeNo).Tables[0];
                    lblTitle.Text = model.title;
                    txtContent.Value = model.description;
                    hdfID.Value = model.id + "";
                }
        }

    }

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        //验证代码
        try
        {
            bll.UpdateDes(int.Parse(hdfID.Value), txtContent.Value);
            Msg.Show("保存成功！");
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            Msg.Show("网络错误!原因:" + ex.Message);
        }
    }
    #endregion

    #region 返回
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }
    #endregion
}
