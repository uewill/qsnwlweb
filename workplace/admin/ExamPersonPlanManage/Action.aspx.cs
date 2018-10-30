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
using System.Text;
using System.Collections.Generic;

public partial class admin_ExamPersonPlanManage_Action : BasePage
{
    private static readonly ILog log = LogManager.GetLogger(typeof(admin_ExamPersonPlanManage_Action));
    private static readonly TFXK.BLL.TestingPersonPlan bll = new TFXK.BLL.TestingPersonPlan();
    private static readonly CategoryBLL bllCategory = new CategoryBLL();
    public int i = 0;
    public string[] subClass = new string[] { }; 

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
                    title = "添加计划";
                    txtCreateTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                case "modify":
                    if (Request.QueryString["id"] != null)
                    {
                        title = "修改计划";
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        InitData(id);
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                    break;

            }
            this.Title = title;
            this.hdfAction.Value = type;
            BindClassData();
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

        //this.txtDate.EditFormatString = "yyyy-MM-dd HH:mm";
        //this.txtDate.DisplayFormatString = "yyyy-MM-dd HH:mm";
        //this.txtEndTime.EditFormatString = "yyyy-MM-dd HH:mm";
        //this.txtEndTime.DisplayFormatString = "yyyy-MM-dd HH:mm";
        //txtDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
        //txtDate.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
        TFXK.Model.TestingPersonPlan model = bll.GetModel(id);
        if (model != null)
        {
            txtTitle.Text = model.TestingTitle;
            if (model.TestTimeAMStart.HasValue)
            {
                this.txtStartTime.Value = model.TestTimeAMStart.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (model.TestTimeAMStart.HasValue)
            {
                this.txtEndTime.Value = model.TestTimeAMEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }

            if (model.TestTimePMStart.HasValue)
            {
                this.txtCheckStartTime.Value = model.TestTimePMStart.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (model.TestTimePMStart.HasValue)
            {
                this.txtCheckEndTime.Value = model.TestTimePMEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }

            if (model.CreateTime.HasValue)
            {
                this.txtCreateTime.Value = model.CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            txtContent.Value = model.Description;
            this.txtAddress.Text = model.Address;
            txtTotalCount.Text = model.TotalCount+"";
            ddlState.SelectedValue = model.Status + "";
            txtOrderby.Text = model.OrderNum + "";
            this.txtNumberPrefx.Text= model.NumberPrefx;
            this.txtNumberEnd.Text= model.NumberStart;
            if (!string.IsNullOrEmpty(model.TestingSubClass))
            {
                subClass = model.TestingSubClass.Split(',');
            }
        }
    }
    #endregion

    #region 添加/修改
    protected void ibtnAdd_Click(object sender, EventArgs e)
    {
        //验证代码
        try
        {
            StringBuilder strClassIds = new StringBuilder();
            foreach (RepeaterItem rptParItem in this.rptClass.Items)
            {
                Repeater rplChild = (Repeater)rptParItem.FindControl("rptCheckList");
                if (rplChild == null)
                {
                    continue;
                }
                foreach (RepeaterItem rptItem in rplChild.Items)
                {
                    HtmlInputCheckBox inputCheck = rptItem.FindControl("chkSubClass") as HtmlInputCheckBox;
                    try
                    {
                        if (inputCheck.Checked)
                        {
                            int iid = int.Parse(inputCheck.Value);
                            strClassIds.AppendFormat("{0},", iid);
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                Msg.Show("请输入考级标题");
                return;
            }

            if (string.IsNullOrEmpty(strClassIds + ""))
            {
                Msg.Show("请选择考试分类");
                return;
            }
            if (string.IsNullOrEmpty(txtTotalCount.Text.Trim()))
            {
                Msg.Show("请输入计划人数");
                return;
            }



            if (string.IsNullOrEmpty(txtNumberPrefx.Text.Trim() + ""))
            {
                Msg.Show("请输入固定编号");
                return;
            }
            if (string.IsNullOrEmpty(txtNumberEnd.Text.Trim()))
            {
                Msg.Show("请输入结尾编号，数字自增");
                return;
            }

            TFXK.Model.TestingPersonPlan model = new TFXK.Model.TestingPersonPlan();
            try
            {
             int id = int.Parse(Request.QueryString["id"].ToString());
              model= bll.GetModel(id);
            }
            catch { model.id = 0; }
            model.TestingSubClass = strClassIds.ToString().TrimEnd(',');
            model.TestingTitle = txtTitle.Text;
            model.Address = this.txtAddress.Text;
            model.OrderNum = int.Parse(this.txtOrderby.Text.Equals("") ? "0" : this.txtOrderby.Text);
            model.TestTimeAMStart = DateTime.Parse(this.txtStartTime.Value);
            model.TestTimeAMEnd = DateTime.Parse(this.txtEndTime.Value);

            model.TestTimePMStart = DateTime.Parse(this.txtCheckStartTime.Value);
            model.TestTimePMEnd = DateTime.Parse(this.txtCheckEndTime.Value);

            model.CreateTime = DateTime.Parse(this.txtCreateTime.Value);
            model.Description = this.txtContent.Value;
            model.Status = int.Parse(this.ddlState.SelectedValue);
            model.TotalCount = int.Parse(this.txtTotalCount.Text);

            model.NumberPrefx = this.txtNumberPrefx.Text;
            model.NumberStart = this.txtNumberEnd.Text;
            string type = this.hdfAction.Value.Trim();
            // 判断动作
            switch (type)
            {
                case "add":
                    Add(model);
                    model.NumberIndex = int.Parse(model.NumberStart.TrimStart('0'));
                    break;
                case "modify":
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

    #region 添加
    private void Add(TFXK.Model.TestingPersonPlan model)
    {
        int rows = bll.Add(model);
        hdfPid.Value = rows + "";
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

    #region 修改
    private void Modify(TFXK.Model.TestingPersonPlan model)
    {
        bll.Update(model);
        hdfPid.Value = model.id + "";
        Msg.ShowAndRedirect("修改信息成功!", "Default.aspx");
    }
    #endregion

    #region 返回
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }
    #endregion

    #region 绑定下拉列表
    private void BindClassData()
    {
        DataSet ds = bllCategory.GetNextNodeByCode_web("kjkmpz");
        rptClass.DataSource = ds;
        rptClass.DataBind();

    }

    public DataSet GetSubClass(String code)
    {
        return bllCategory.GetNextNodeByCode_web(code);
    }

    public bool getSubChecked(object subId) {
        bool isChecked = false;
        foreach (string item in subClass) {
            if (subId.ToString().Equals(item)) {
                isChecked = true;
                break;
            }
        }
        return isChecked;
    }
    #endregion


    #region 绑定下拉列表   无限级

    ///   <summary>   
    ///   创建分级下拉框   
    ///   </summary>   
    private void CreateLevelDropDown(DropDownList ddlst, DataTable dt, int pid)
    {

        System.Collections.ArrayList allItems = new ArrayList();
        DataRow[] rows = dt.Select("[parentid]=" + pid + " or [id]=" + pid);
        foreach (DataRow row in rows)
            CreateLevelDropDownAssistant(dt, ref allItems, row, string.Empty);

        ListItem[] items = new ListItem[allItems.Count];
        allItems.CopyTo(items);
        ddlst.Items.AddRange(items);
    }
    private void CreateLevelDropDownAssistant(DataTable dt, ref ArrayList items, DataRow parentRow, string curHeader)
    {
        ListItem newItem = new ListItem(curHeader + parentRow["title"].ToString(), parentRow["id"].ToString());
        items.Add(newItem);
        parentRow.Delete();

        DataRow[] rows = dt.Select("[parentID]='" + newItem.Value + "'");
        for (int i = 0; i < rows.Length - 1; i++)
            CreateLevelDropDownAssistant(dt, ref items, rows[i], curHeader.Replace("┣", "┃").Replace("┗", "┣") + "┣");

        if (rows.Length > 0)
            CreateLevelDropDownAssistant(dt, ref items, rows[rows.Length - 1], curHeader.Replace("┣", "┃").Replace("┗", "┣") + "┗");
    }
    #endregion


}
