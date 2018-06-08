<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Description.aspx.cs" Inherits="admin_CategoryManage_Description" ValidateRequest="false"
    Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Kinde/kindeditor.js" type="text/javascript"></script>

    <script type="text/javascript">
	KindEditor.ready(function(K) {
			var editor1 = K.create('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtContent', {
				cssPath : '../../kinde/plugins/code/prettify.css',
				uploadJson : '../../kinde/asp.net/upload_json.ashx',
				fileManagerJson : '../../kinde/asp.net/file_manager_json.ashx',
				allowFileManager : true,
			});
		});

    </script>


    <input type="hidden" id="hdfID" runat="server" />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="100%">
        <PanelCollection>
            <dxrp:PanelContent ID="PanelContent1" runat="server">
                <table class="category" width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                    <tr>
                        <td style="width: 100px; text-align: right">
                            栏目名称：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtUserName_ITip" style="width: 250px;
                                            display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right">
                            栏目描述：
                        </td>
                        <td style="text-align: left;">
                             <textarea id="txtContent" runat="server" style="height: 400px; width:100%; visibility: hidden;"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right">
                        </td>
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
