<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Action.aspx.cs" Inherits="admin_ExamPersonManage_Action" ValidateRequest="false"
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
                        <td style="width: 200px; text-align: right;">姓名：
                        </td>
                        <td style="text-align: left;">
                            <%=dataModel.UserName%> /  <%=dataModel.UserNamePY%>

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; text-align: right;">出生日期：
                        </td>
                        <td style="text-align: left;">
                            <%=dataModel.Birthday%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; text-align: right; height: 37px;">性别：
                        </td>
                        <td style="text-align: left;">
                            <%=dataModel.Sex%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; text-align: right; height: 37px;">国籍：
                        </td>
                        <td style="text-align: left;">
                            <%=dataModel.Country%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; text-align: right; height: 37px;">民族：
                        </td>
                        <td style="text-align: left;">
                            <%=dataModel.Mingzu%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; text-align: right; height: 37px;">联系电话：
                        </td>
                        <td style="text-align: left;">
                            <%=dataModel.PhoneNumber%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; text-align: right" valign="top">考生所在地：
                        </td>
                        <td style="text-align: left;">
                            <%=dataModel.Address%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; text-align: right" valign="top">报考专业：
                        </td>
                        <td style="text-align: left; margin: 0px; padding: 0px;">
                            <%=dataModel.ClassID%> / <%=dataModel.ClassLevel%> 
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; text-align: right; height: 37px;">申报专业已有的最高级别：
                        </td>
                        <td>
                            <%=dataModel.HaveMaxLevel%> / <%=dataModel.MaxLevelNo%> 
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 200px; text-align: right; height: 37px;">考生联系人：
                        </td>
                        <td>
                            <%=dataModel.Contactor%>  /  <%=dataModel.ContactorPhone%>  
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; text-align: right; height: 37px;">与考生关系：
                        </td>
                        <td>
                            <%=dataModel.ContactorShip%> 
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; text-align: right; height: 37px;">通讯地址：
                        </td>
                        <td>
                            <%=dataModel.HomeAddress%> /邮编：  <%=dataModel.PostNo%> 
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 200px; text-align: right; height: 48px;">付款状态：
                        </td>
                        <td style="text-align: left; height: 48px;">
                            <asp:DropDownList ID="ddlState" runat="server">
                                <asp:ListItem Value="0" Text="未付款"></asp:ListItem>
                                <asp:ListItem Value="1" Text="已付款"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; text-align: right; height: 37px;">提交时间：
                        </td>
                        <td>
                            <%=dataModel.CreateTime%>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 200px; text-align: right"></td>
                        <td style="text-align: left;">
                            <table>
                                <tr><td style="width: 80px;">
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
