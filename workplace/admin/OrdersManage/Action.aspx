<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Action.aspx.cs" Inherits="admin_OrdersManage_Action" ValidateRequest="false"
    Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdfAction" runat="server" />
    <input type="hidden" id="hdfPid" runat="server" />
    <input type="hidden" id="hdfTid" runat="server" />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="100%">
        <PanelCollection>
            <dxrp:PanelContent runat="server">
                <table class="category" width="100%" align="center" style="line-height: 25px;">
                    <tr>
                        <td style="width: 100px; text-align: right;">
                            款式类型：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.typeID%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            季节：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.Jijie%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            定制总量：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.chkOrderNum%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            具体数量：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.orderNum%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right" valign="top">
                            期望价格：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.hopePrice%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right" valign="top">
                            产品编号：
                        </td>
                        <td style="text-align: left; margin: 0px; padding: 0px;">
                            <%=userOModel.proCode%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            补充信息：
                        </td>
                        <td>
                            <%=userOModel.otherDes%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            附件：
                        </td>
                        <td>
                            <a href='../../orderfiles/<%=userOModel.filePaths%>' target="_blank"><%= userOModel.filePaths%></a>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            联系人：
                        </td>
                        <td>
                            <%=userOModel.contactUserName%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            性别：
                        </td>
                        <td>
                            <%=userOModel.userSex==1?"女":"男"%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            电话：
                        </td>
                        <td>
                            <%=userOModel.userTel%>/
                            <%=userOModel.userPhone%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            电子邮件：
                        </td>
                        <td>
                            <%=userOModel.userEmail%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            企业名称：
                        </td>
                        <td>
                            <%=userOModel.companyName%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            联系地址：
                        </td>
                        <td>
                            <%=userOModel.companyAddress%>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            提交时间：
                        </td>
                        <td>
                            <%=userOModel.des1%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 48px;">
                            审核状态：
                        </td>
                        <td style="text-align: left; height: 48px;">
                            <asp:DropDownList ID="ddlState" runat="server">
                                <asp:ListItem Value="0" Text="未处理"></asp:ListItem>
                                <asp:ListItem Value="1" Selected="True" Text="已处理"></asp:ListItem>
                            </asp:DropDownList>
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
