<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="admin_SiteConfigManage_Default" ValidateRequest="false"
    Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Kinde/kindeditor.js" type="text/javascript"></script>


    <script type="text/javascript">
	KindEditor.ready(function(K) {
			var editor1 = K.create('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtFooter', {
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
                                        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; vertical-align: top;">
                            展示标题：
                        </td>
                        <td style="text-align: left;">
                            <textarea id="txtTitle" runat="server" style="width: 100%; height: 100px;"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; vertical-align: top;">
                            站点描述：
                        </td>
                        <td style="text-align: left;">
                            <textarea id="txtDescription" runat="server" style="width: 100%; height: 100px;"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; vertical-align: top;">
                            Mata关键字：
                        </td>
                        <td style="text-align: left;">
                            <textarea id="txtMata" runat="server" style="width: 100%; height: 100px;"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; vertical-align: top;">
                            底部文字：
                        </td>
                        <td style="text-align: left;">
                            <textarea id="txtFooter" runat="server" style="width: 100%; height: 200px;"></textarea>
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
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </dxrp:PanelContent>
        </PanelCollection>
    </dxrp:ASPxRoundPanel>
</asp:Content>
