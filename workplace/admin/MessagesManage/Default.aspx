﻿<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="admin_MessagesManage_Default" Title="用户管理" %>

<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Panel" style="width: 100%; padding-top: 0px; margin-top: 0px;">
        <tr>
            <td style="height: 20px; text-align: center;">
                <dxrp:ASPxRoundPanel ID="panelSearch" ShowHeader="False" HeaderText="条件查询" runat="server"
                    Width="100%">
                    <PanelCollection>
                        <dxrp:PanelContent runat="server">
                            <div style="text-align: left; width: 100%;">
                                <table>
                                    <tr>
                                        <td style="width: 200px">
                                        </td><td style="text-align: right;">
                                            文章号
                                        </td>
                                        <td>
                                            <dxe:ASPxTextBox ID="txtAID" runat="server" Width="50px">
                                            </dxe:ASPxTextBox>
                                        </td>
                                        <td style="text-align: right;">
                                            标题
                                        </td>
                                        <td>
                                            <dxe:ASPxTextBox ID="txtSearchName" runat="server" Width="100px">
                                            </dxe:ASPxTextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlState" runat="server">
                                                <asp:ListItem Text="全部" Value="-1"></asp:ListItem>
                                                <asp:ListItem Text="未处理" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="已处理" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <dxe:ASPxButton ID="btnSearch" runat="server" Width="80px" Text=" 查询 " OnClick="btnSearch_Click">
                                            </dxe:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </dxrp:PanelContent>
                    </PanelCollection>
                </dxrp:ASPxRoundPanel>
            </td>
        </tr>
        <tr>
            <td>
                <table class="maincon" width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                    <tr>
                        <th width="5%" background="../images/bg.gif" align="center">
                            选中
                        </th>
                        <th width="10%" background="../images/bg.gif" align="center">
                            来源文章序号
                        </th>
                        <th width="15" background="../images/bg.gif" align="center">
                            主题
                        </th>
                        <th width="8%" background="../images/bg.gif" align="center">
                            姓名
                        </th>
                        <th width="25%" background="../images/bg.gif" align="center">
                            内容
                        </th>
                        <th width="10%" background="../images/bg.gif" align="center">
                            时间
                        </th>
                        <th width="8%" background="../images/bg.gif" align="center">
                            状态
                        </th>
                        <th width="10%" background="../images/bg.gif" align="center">
                            基本操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rptBind" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <input id="chkSelected" name="checkname" type="checkbox" runat="server" value='<%# Eval("ID") %>' />
                                </td>
                                <td align="center">
                                    <%# Eval("qicq") %>[<a href='../../ArticalView.aspx?Key=<%#Eval("qicq") %>'>查看</a>]
                                </td>
                                <td align="center">
                                    <%# Eval("title") %>
                                </td>
                                <td align="center">
                                    <%# Eval("userNames") %>
                                </td>
                                <td align="center">
                                    <%#Eval("msgcontent") %>
                                </td>
                                <td align="center">
                                    <%# Eval("createtime") %>
                                </td>
                                <td align="center">
                                    <%#StateName( Eval("stateID")) %>
                                </td>
                                <td align="center">
                                    <img src="../images/edt.gif" onclick="javascript:location='Action.aspx?type=modify&id=<%# Eval("id") %>';return false;"
                                        style="cursor: pointer; height: 16px; width: 16px;" alt="修改" />
                                    <asp:ImageButton ID="ibtnDel" ImageUrl="../images/del.gif" ToolTip="删除..." CommandName='<%# Eval("ID") %>'
                                        OnCommand="ibtnDel_OnCommand" OnClientClick="javascript:return confirm('您确定要删除吗');"
                                        runat="server" Height="16px" Width="16px" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" style="margin-top: 10px;" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center">
                            <webdiyer:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="AspNetPager1"
                                HorizontalAlign="Center" runat="server" AlwaysShow="false" FirstPageText="首页"
                                Font-Size="12px" LastPageText="尾页" NextPageText="下一页" PageSize="10" PrevPageText="上一页"
                                ShowBoxThreshold="11" TextAfterPageIndexBox="" TextBeforePageIndexBox="" UrlPaging="true"
                                OnPageChanging="AspNetPager1_PageChanging">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table>
                <table width="250px" style="font-size: 12px" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 50px;">
                        </td>
                        <td width="90">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div align="center">
                                            &nbsp;&nbsp;&nbsp;<input id="checkall" type="checkbox" />
                                        </div>
                                    </td>
                                    <td>
                                        <div align="center">
                                            全选</div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <%-- <td width="60">
                            <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div align="center">
                                            <img src="../images/22.gif" width="14" height="14" /></div>
                                    </td>
                                    <td>
                                        <div align="center">
                                            <a href="Action.aspx?type=add">添加</a>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>--%>
                        <td width="60">
                            <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div align="center">
                                            <img src="../images/33.gif" width="14" height="14" /></div>
                                    </td>
                                    <td>
                                        <div align="center">
                                            <asp:LinkButton ID="lbtnModify" runat="server" OnClick="lbtnModify_Click">修改</asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="60">
                            <table width="88%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div align="center">
                                            <img src="../images/11.gif" width="14" height="14" /></div>
                                    </td>
                                    <td>
                                        <div align="center">
                                            <asp:LinkButton ID="lbtnDelAll" OnClientClick="javascript:return confirm('您确定要删除所有选中项目吗');"
                                                runat="server" OnClick="lbtnDelAll_Click">删除</asp:LinkButton></div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>