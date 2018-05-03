<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftControl.ascx.cs" Inherits="admin_Controls_LeftControl" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxNavBar" TagPrefix="dxnb" %>
<dxrp:ASPxRoundPanel runat="server" ID="rpMenu" SkinID="RoundPanelNavigation" Width="100%"
    ShowHeader="False">
    <PanelCollection>
        <dxrp:PanelContent ID="PanelContentMain" Width="100%" runat="server">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr id="leftMenuDiv0" class="block">
                    <td width="190px">
                        <div>
                            <dxnb:ASPxNavBar ID="ASPxNavBar0" runat="server" Width="100%" AutoCollapse="false"
                                EncodeHtml="False" AllowSelectItem="True">
                                <Groups>
                                    <dxnb:NavBarGroup Expanded="true" Text="欢迎">
                                        <Items>
                                            <dxnb:NavBarItem NavigateUrl="~/admin/MainPage/welcome.aspx" Text="欢迎" Selected="true"
                                                Target="Frame1">
                                            </dxnb:NavBarItem>
                                        </Items>
                                    </dxnb:NavBarGroup>
                                </Groups>
                            </dxnb:ASPxNavBar>
                        </div>
                    </td>
                </tr>
                <tr id="leftMenuDiv1" class="block">
                    <td width="190px">
                        <dxnb:ASPxNavBar ID="ASPxNavBar1" runat="server" Width="100%" AutoCollapse="false"
                            EncodeHtml="False" AllowSelectItem="True">
                            <Groups>
                                <dxnb:NavBarGroup Name="navRWGL" Visible="true" Text="网站管理">
                                    <Items>
                                        <dxnb:NavBarItem NavigateUrl="~/admin/CategoryManage/default.aspx" Text="分类配置" Target="Frame1">
                                        </dxnb:NavBarItem>
                                        <dxnb:NavBarItem NavigateUrl="~/admin/UserManage/default.aspx" Text="管理员列表" Target="Frame1">
                                        </dxnb:NavBarItem>
                                        <dxnb:NavBarItem NavigateUrl="~/admin/SiteConfigManage/default.aspx" Text="站点设置"
                                            Target="Frame1">
                                        </dxnb:NavBarItem>
                                       <%-- <dxnb:NavBarItem NavigateUrl="~/admin/AdsManage/default.aspx" Text="广告管理" Target="Frame1">
                                        </dxnb:NavBarItem>--%>
                                        <dxnb:NavBarItem NavigateUrl="~/admin/LinkManage/default.aspx" Text="友情链接管理" Target="Frame1">
                                        </dxnb:NavBarItem>
                                    </Items>
                                </dxnb:NavBarGroup>
                            </Groups>
                        </dxnb:ASPxNavBar>
                    </td>
                </tr>
                <tr id="leftMenuDiv3" class="block">
                    <td width="190px">
                        <dxnb:ASPxNavBar ID="ASPxNavBar3" runat="server" Width="100%" AutoCollapse="false"
                            EncodeHtml="False" AllowSelectItem="True">
                            <Groups>
                                <dxnb:NavBarGroup Name="navHYGL" Visible="true" Text="会员管理">
                                    <Items>
                                        <dxnb:NavBarItem NavigateUrl="~/admin/CustomManage/default.aspx" Text="会员列表" Target="Frame1">
                                        </dxnb:NavBarItem>
                                    </Items>
                                </dxnb:NavBarGroup>
                            </Groups>
                        </dxnb:ASPxNavBar>
                        <dxnb:ASPxNavBar ID="ASPxNavBar4" runat="server" Width="100%" AutoCollapse="false"
                            EncodeHtml="False" AllowSelectItem="True">
                            <Groups>
                                <dxnb:NavBarGroup Name="navDDGL" Visible="true" Text="评论管理">
                                    <Items>
                                        <dxnb:NavBarItem NavigateUrl="~/admin/MessagesManage/default.aspx" Text="评论列表" Target="Frame1">
                                        </dxnb:NavBarItem>
                                    </Items>
                                </dxnb:NavBarGroup>
                            </Groups>
                        </dxnb:ASPxNavBar>
                    </td>
                </tr>
                <tr id="leftMenuDiv4" class="block">
                    <td width="190px">
                        <div>
                            <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" HeaderText="内容管理" runat="server" Width="100%">
                                <PanelCollection>
                                    <dxrp:PanelContent ID="PanelContent1" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TreeView ID="treeNav" runat="server" ExpandDepth="1" NodeIndent="10">
                                                    </asp:TreeView>
                                                </td>
                                            </tr>
                                        </table>
                                    </dxrp:PanelContent>
                                </PanelCollection>
                            </dxrp:ASPxRoundPanel>
                        </div>
                    </td>
                </tr>
            </table>
        </dxrp:PanelContent>
    </PanelCollection>
</dxrp:ASPxRoundPanel>
