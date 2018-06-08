<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Action.aspx.cs" Inherits="admin_UserJiamenManage_Action" ValidateRequest="false"
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
                        <td style="width: 100px; text-align: right;">考点名称：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.KDName%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right;">联系人：
                        </td>
                        <td style="text-align: left;">
                            <dxe:ASPxTextBox ID="txtUserName" Width="200px" runat="server">
                            </dxe:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">联系电话：
                        </td>
                        <td style="text-align: left;">
                            <dxe:ASPxTextBox ID="txtUserPhone" Width="200px" runat="server">
                            </dxe:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">邮箱：
                        </td>
                        <td style="text-align: left;">
                            <dxe:ASPxTextBox ID="txtUserEmail" Width="200px" runat="server">
                            </dxe:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">联系地址：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.Address%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right" valign="top">身份证ID：
                        </td>
                        <td style="text-align: left;">
                            <%=userOModel.IDNo%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right" valign="top">身份证正面：
                        </td>
                        <td style="text-align: left; margin: 0px; padding: 0px;">
                            <img src="<%=userOModel.IDImage%>" width="240" height="180" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">身份证反面：
                        </td>
                        <td>
                            <img src="<%=userOModel.IDImage2%>" width="240" height="180" />
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">营业执照：
                        </td>
                        <td>
                            <img src="<%=userOModel.WorkImage%>" width="240" height="180" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">备注：
                        </td>
                        <td>
                            <%=userOModel.KDDescription%>
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
                        <td style="width: 100px; text-align: right; height: 37px;">修改密码？
                            <dxe:ASPxCheckBox ID="chkChangePass" runat="server"></dxe:ASPxCheckBox>
                        </td>
                        <td style="text-align: left;">

                            <dxe:ASPxTextBox ID="txtPass" Width="200px" runat="server">
                            </dxe:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 48px;">审核状态：
                        </td>
                        <td style="text-align: left; height: 48px;">
                            <asp:DropDownList ID="ddlState" runat="server">
                                <asp:ListItem Value="0" Text="待补充资料"></asp:ListItem>
                                <asp:ListItem Value="1" Text="待审核"></asp:ListItem>
                                <asp:ListItem Value="2" Text="审核通过"></asp:ListItem>
                                <asp:ListItem Value="3" Text="禁止登录"></asp:ListItem>
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
