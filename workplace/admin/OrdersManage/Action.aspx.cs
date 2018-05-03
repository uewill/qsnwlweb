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

using TFXK.Model;
using TFXK.BLL;
using TFXK.Common;
using log4net;

public partial class admin_OrdersManage_Action : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_OrdersManage_Action));
    private static readonly UserOrdersBLL bll = new UserOrdersBLL();
    public UserOrders userOModel = new UserOrders();
    public int i = 0;

    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                InitAction();
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
        }

    }
    #endregion

    #region 绑定动作
    private void InitAction()
    {

        int id = int.Parse(Request.QueryString["id"].ToString());
        if (id > 0)
        {
            InitData(id);
        }
        else
        {
            Response.Redirect("Default.aspx", false);
        }
    }
    #endregion

    #region 绑定
    private void InitData(int id)
    {
        userOModel = bll.GetModel(id);
        ddlState.SelectedValue = userOModel.stateID + "";
    }
    #endregion

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        //验证代码
        try
        {
            TFXK.Model.UserOrders model = new TFXK.Model.UserOrders();
            try
            {
                model.id = int.Parse(Request.QueryString["id"].ToString());
            }
            catch { model.id = 0; }

            if (model.id > 0)
            {
                model = bll.GetModel(model.id);
                model.stateID = ddlState.SelectedIndex;
                Modify(model);
            }


        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            Msg.Show("网络错误!原因:" + ex.Message);
        }
    }
    #endregion


    #region 修改
    private void Modify(UserOrders model)
    {
        bll.Update(model);
        Msg.ShowAndRedirect("修改信息成功!", "Default.aspx");
    }
    #endregion

    #region 返回
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }
    #endregion

}
