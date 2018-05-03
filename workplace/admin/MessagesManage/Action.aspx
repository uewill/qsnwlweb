<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Action.aspx.cs" Inherits="admin_MessagesManage_Action" Title="Untitled Page" %>

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
                            标题：
                        </td>
                        <td align="left" height="35">
                         <%=tempMessage.title %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%" style="line-height: 35px; height: 35px;" nowrap="nowrap">
                            姓名：
                        </td>
                        <td align="left" height="35">
                           <%=tempMessage.userNames %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%" style="line-height: 35px; height: 35px;" nowrap="nowrap">
                            联系方式：
                        </td>
                        <td align="left" height="35">
                           <%=tempMessage.userEmail %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%">
                            留言内容：
                        </td>
                        <td align="left" height="35">
                           <%=tempMessage.msgContent %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" nowrap="nowrap" style="line-height: 35px; height: 35px" width="30%">
                            来源ID：
                        </td>
                        <td align="left" height="35">
                        <%=tempMessage.qicq %>
                        </td>
                    </tr>
                    <tr>
                        <tr>
                            <td align="right" nowrap="nowrap" style="line-height: 35px; height: 35px" width="30%">
                                留言时间：
                            </td>
                            <td align="left" height="35">
                               <%=tempMessage.createTime %>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td align="right" width="30%" style="line-height: 35px; height: 35px;" nowrap="nowrap">
                                回复：
                            </td>
                            <td align="left" height="35">
                               <textarea id="txtReplay" rows="8" cols="40" runat="server"></textarea>
                            </td>
                        </tr>
                        
                         <tr>
                            <td align="right" width="30%" style="line-height: 35px; height: 35px;" nowrap="nowrap">
                                状态：
                            </td>
                            <td align="left" height="35">
                               <asp:DropDownList ID="ddlState" runat="server">
                               <asp:ListItem Text="不显示" Value="0"></asp:ListItem> 
                               <asp:ListItem Text="已显示" Value="1"></asp:ListItem>
                               </asp:DropDownList>
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
