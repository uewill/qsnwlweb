using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using TFXK.Model;
using TFXK.BLL;
using TFXK.Common;
using log4net;

public partial class admin_UserManage_UserModfyPass : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_UserManage_UserModfyPass));
    private static readonly UsersBLL bll = new UsersBLL();
    #region 加载
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    if (!IsPostBack)
        //    {
        //        InitData(Context.User.Identity.Name);

        //    }
        //}
        //catch (Exception ex)
        //{
        //    log.Error(ex.Message);
        //}

    }
    #endregion

    #region 绑定
    private void InitData(string userName)
    {
        this.lblUserName.Text = userName;
    }
    #endregion

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            TFXK.Model.Users model = new TFXK.Model.Users();
            model.userName = Context.User.Identity.Name;
            model.password = txtPass2.Text;

            string password = this.txtPass.Text.Trim();
            bool flg = bll.Exists(model.userName, password);
            if (flg)
            {
                bll.UpdatePassword(model);
                Msg.Show("修改信息成功!");
            }
            else
            {
                Msg.Show("原始密码错误!");
            }
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            Msg.Show("网络错误!原因:" + ex.Message);
        }
    }
    #endregion
}
