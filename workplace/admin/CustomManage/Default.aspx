<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="admin_CustomManage_Default" Title="用户管理" %>

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
                                        </td>
                                        <td style="text-align: right;">
                                            <dxe:ASPxLabel ID="lblSearchName" Width="70px" runat="server" Text="用户名：">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td>
                                            <dxe:ASPxTextBox ID="txtSearchName" runat="server" Width="170px">
                                            </dxe:ASPxTextBox>
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
                            用户名
                        </th>
                        <th width="10%" background="../images/bg.gif" align="center">
                            姓名
                        </th>
<%--                        <th width="10%" background="../images/bg.gif" align="center">
                            联系电话
                        </th>--%>
                        <th width="10%" background="../images/bg.gif" align="center">
                            电子邮件
                        </th>
                        <th width="10%" background="../images/bg.gif" align="center">
                            注册时间
                        </th>
                        <th width="10%" background="../images/bg.gif" align="center">
                            审核状态
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
                                    <%# Eval("loginName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("trueName")%>
                                </td>
                                <%--<td align="center">
                                    <%# Eval("tel")%>
                                </td>--%>
                                <td align="center">
                                    <%# Eval("email")%>
                                </td>
                                <td align="center">
                                    <%# Convert.ToDateTime(Eval("regDate").ToString()).ToString("yyy-MM-dd")%>
                                </td>
                                <td align="center">
                                    <%# Eval("stateID").ToString().Equals("1") ? "审核通过" : "等待审核"%>
                                </td>
                                <td align="center">
                                    <img src="../images/edt.gif" onclick="javascript:location='Custom.aspx?type=modify&id=<%# Eval("id") %>';return false;"
                                        style="cursor: pointer; height: 16px; width: 16px;" title="修改" />
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
                                Font-Size="12px" LastPageText="尾页" NextPageText="下一页" PageSize="20" PrevPageText="上一页"
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
                        <td width="60">
                            <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div align="center">
                                            <img src="../images/22.gif" width="14" height="14" /></div>
                                    </td>
                                    <td>
                                        <div align="center">
                                            <a href="Custom.aspx?type=add">添加</a></div>
                                    </td>
                                </tr>
                            </table>
                        </td>
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
