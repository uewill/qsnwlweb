<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Action.aspx.cs" Inherits="admin_ExamPlanManage_Action" ValidateRequest="false"
    Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<%@ Register TagPrefix="dxrp" Namespace="DevExpress.Web.ASPxRoundPanel" Assembly="DevExpress.Web.v9.2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <script src="../../Kinde/kindeditor.js" type="text/javascript"></script>

    <script type="text/javascript">
	KindEditor.ready(function(K) {
			var editor1 = K.create('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtAuditDes', {
				cssPath : '../../kinde/plugins/code/prettify.css',
				uploadJson : '../../kinde/asp.net/upload_json.ashx',
				fileManagerJson : '../../kinde/asp.net/file_manager_json.ashx',
				allowFileManager : true,
			});
		});

    </script>

    <input type="hidden" id="hdfAction" runat="server" />
    <input type="hidden" id="hdfPid" runat="server" />
    <input type="hidden" id="hdfTid" runat="server" />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="100%">
        <PanelCollection>
            <dxrp:PanelContent runat="server">
                <table class="category" width="100%" align="center" style="line-height: 25px;">
                    <tr>
                        <td style="width: 100px; text-align: right;">考点名称：
                        </td>
                        <td style="text-align: left;">
                            <%=KJName%>

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right;">考试时间：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.TestingTime%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">考级科目：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.TestingClass%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">联系方式：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.Contactor%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">考试地址：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.Address%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">乘车路线：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.AddresDes%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right" valign="top">备注：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.Description%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right" valign="top">审核回复：
                        </td>
                        <td style="text-align: left; margin: 0px; padding: 0px;">
                              <textarea id="txtAuditDes" runat="server" style="height: 300px; width: 100%; visibility: hidden;"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">确认通知：
                        </td>
                        <td>
                            <%= getNoticeStatus(userOModel.NoticeConfirm+"")%>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">收件地址：
                        </td>
                        <td>
                            <%=userOModel.NoticeAddress%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">收件人及电话：
                        </td>
                        <td>
                            <%=userOModel.NoticeGetUser%>&nbsp; <%=userOModel.NoticeGetPhone%>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">提交时间：
                        </td>
                        <td>
                            <%=userOModel.CreateTime%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 48px;">审核状态：
                        </td>
                        <td style="text-align: left; height: 48px;">
                            <asp:DropDownList ID="ddlState" runat="server">
                                <asp:ListItem Value="0" Text="待审核"></asp:ListItem>
                                <asp:ListItem Value="1" Text="已审核"></asp:ListItem>
                                <asp:ListItem Value="2" Text="已提交考生信息"></asp:ListItem>
                                <asp:ListItem Value="3" Text="通知领取证书"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right"></td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td style="width: 80px;">
                                        <dxe:ASPxButton ID="btnSave" runat="server" AutoPostBack="False" Text="确 定" OnClick="ibtnAdd_Click"
                                            Width="66px">
                                        </dxe:ASPxButton>
                                    </td>
                                    <td style="width: 80px;">
                                        <dxe:ASPxButton ID="btnBack" runat="server" OnClick="btnBack_Click" Text="返 回" Width="63px">
                                        </dxe:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </dxrp:PanelContent>
        </PanelCollection>
    </dxrp:ASPxRoundPanel>
</asp:Content>
