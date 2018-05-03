﻿<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Action.aspx.cs" Inherits="admin_LinkManagee_Action" Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdfAction" runat="server" />
    <input type="hidden" id="hiddenPicPath" runat="server" />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="100%">
        <PanelCollection>
            <dxrp:PanelContent runat="server">
                <table class="category" width="100%" border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <td align="right" width="30%" style="line-height: 35px; height: 35px;" nowrap="nowrap">
                            名称：
                        </td>
                        <td align="left" height="35">
                            <asp:TextBox ID="txtName" Width="300px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%" style="line-height: 35px; height: 35px;" nowrap="nowrap">
                            链接地址：
                        </td>
                        <td align="left" height="35">
                            <dxe:ASPxTextBox ID="txtUrl" runat="server" Width="300px">
                            </dxe:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%" style="line-height: 35px; height: 35px;" nowrap="nowrap">
                            链接类型：
                        </td>
                        <td align="left" height="35">
                            <asp:DropDownList ID="ddlLinkType" runat="server">
                             <%--   <asp:ListItem Text="合作伙伴(图片显示需传图)" Value="1"></asp:ListItem>
                                <asp:ListItem Text="合作伙伴文字显示不需传图)" Value="0"></asp:ListItem>--%>
                                <asp:ListItem Text="友情链接" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%">
                            图片：
                        </td>
                        <td align="left" height="35">
                            <asp:Image ID="imgLink" ImageUrl="../images/nopic.jpg" Width="120" Height="80"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" nowrap="nowrap" style="line-height: 35px; height: 35px" width="30%">
                            图片：
                        </td>
                        <td align="left" height="35">
                            <dxuc:ASPxUploadControl ID="uploadImg" runat="server">
                            </dxuc:ASPxUploadControl>
                        </td>
                    </tr>
                    <tr>
                        <tr>
                            <td align="right" nowrap="nowrap" style="line-height: 35px; height: 35px" width="30%">
                                排序：
                            </td>
                            <td align="left" height="35">
                                <dxe:ASPxSpinEdit ID="txtOrder" runat="server" Height="21px" Number="0">
                                </dxe:ASPxSpinEdit>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="30%" style="line-height: 35px; height: 35px;" nowrap="nowrap">
                                描述：
                            </td>
                            <td align="left" height="35">
                                <asp:TextBox TextMode="MultiLine" Width="300" ID="txtDescription" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="35">
                            </td>
                            <td height="35">
                                <table>
                                    <tr>
                                        <td>
                                            <dxe:ASPxButton ID="btnAdd" runat="server" OnClick="ibtnAdd_Click" Text=" 确定  ">
                                            </dxe:ASPxButton>
                                        </td>
                                        <td>
                                            <dxe:ASPxButton ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click">
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