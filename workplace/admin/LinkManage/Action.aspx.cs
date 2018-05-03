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
using System.IO;

using TFXK.Model;
using TFXK.BLL;
using TFXK.Common;
using log4net;

public partial class admin_LinkManagee_Action : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_LinkManagee_Action));
    private static readonly LinkBLL bll = new LinkBLL();
    //获取配置文件 保存图片的文件夹
    string pathpage = "uploads/";
    private string logourl = "";

    public string Logourl
    {
        get { return logourl; }
        set { logourl = value; }
    }

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

        if (Request.QueryString["type"] != null)
        {
            string type = Request.QueryString["type"].ToString();
            string title = string.Empty;// 设置标题
            // 判断动作
            switch (type)
            {
                case "add":
                    title = "添加链接";
                    //this.imgLink.Visible = false;
                    break;
                case "modify":
                    if (Request.QueryString["id"] != null)
                    {
                        title = "链接修改";
                        //  this.imgLink.Visible = true;
                        InitData(int.Parse(Request.QueryString["id"] + ""));
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                    break;

            }

            this.Title = title;
            this.hdfAction.Value = type;
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
        TFXK.Model.Link model = bll.GetModel(id);
        if (model != null)
        {
            hiddenPicPath.Value = model.logo;
            txtName.Text = model.title;
            txtOrder.Text = model.orderId + "";
            txtUrl.Text = model.linkUrl;
            if (!string.IsNullOrEmpty(model.logo))
            {
                imgLink.ImageUrl = "../../uploads/" + model.logo;
            };
            ddlLinkType.SelectedValue = model.isPictureOn;
            txtDescription.Text = model.description;
        }
    }
    #endregion

    #region 添加/修改

    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        //验证代码
        try
        {
            TFXK.Model.Link model = new TFXK.Model.Link();

            model.title = this.txtName.Text;
            model.linkUrl = this.txtUrl.Text;
            model.isPictureOn = ddlLinkType.SelectedValue;
            model.orderId = this.txtOrder.Text.Equals("") ? 0 : int.Parse(this.txtOrder.Text);
            model.parentId = 0;
            model.logo = hiddenPicPath.Value;
            model.description = txtDescription.Text;

            #region 上传图片
            if (this.uploadImg.PostedFile.FileName != "")
            {
                string uppath = Server.MapPath("~/" + pathpage);
                string ext = uploadImg.PostedFile.FileName.Substring(uploadImg.PostedFile.FileName.Length - 4);
                if (ext.ToUpper() == ".JPG" || ext.ToUpper() == ".PNG" || ext.ToUpper() == ".GIF" || ext.ToUpper() == ".BMP")
                {
                    string upName = DateTime.Now.ToString("yyyyMMddhhmmss") + ext;
                    try
                    {
                        uploadImg.SaveAs(uppath + upName);
                        if (hiddenPicPath.Value != "")
                        {
                            if (File.Exists(hiddenPicPath.Value))
                            {
                                File.Delete(hiddenPicPath.Value);
                            }
                        }
                        model.logo = upName;
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                }
            }

            #endregion

            // 防止网页重复提交

            string type = this.hdfAction.Value.Trim();
            // 判断动作
            switch (type)
            {
                case "add":
                    Add(model);
                    break;
                case "modify":
                    model.id = int.Parse(Request.QueryString["id"]);
                    Modify(model);
                    break;
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
    private void Modify(Link model)
    {
        bll.Update(model);
        Msg.ShowAndRedirect("修改信息成功!", "Default.aspx");
    }
    #endregion

    #region 添加
    private void Add(Link model)
    {
        int rows = bll.Add(model);
        if (rows > 0)
        {
            Msg.ShowAndRedirect("添加信息成功!", "Default.aspx");
        }
        else
        {
            Msg.Show("添加信息失败!");
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
