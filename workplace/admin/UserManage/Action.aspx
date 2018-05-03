<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Action.aspx.cs" Inherits="admin_UserManage_Action" ValidateRequest="false"
    Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <input type="hidden" id="hdfAction" runat="server" />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="100%">
        <PanelCollection>
            <dxrp:PanelContent runat="server">
                <table class="category" width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                    <tr>
                        <td style="width: 100px; text-align: right">
                            用户名：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtUserName" Width="150px" runat="server">
                                        </dxe:ASPxTextBox>
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
                            密 码：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtPass" Password="True" Width="150px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtPass_ITip" style="width: 250px;
                                            display: inline;">
                                        </div>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="linkModify" Visible="False" runat="server">密码重置</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right">
                            姓 名：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtTrueName" Width="150px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtTrueName_ITip" style="width: 250px;
                                            display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right">
                            联系电话：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtTel" Width="150px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
               
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            邮 箱：
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtMail" Width="150px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtMail_ITip" style="width: 250px;
                                            display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                 
                    <tr>
                        <td style="width: 100px; text-align: right; height: 48px;">
                            审核状态：
                        </td>
                        <td style="text-align: left; height: 48px;">
                            <asp:DropDownList ID="ddlState" runat="server">
                                <asp:ListItem Value="0" Selected="True" Text="未审核"></asp:ListItem>
                                <asp:ListItem Value="1" Text="已审核"></asp:ListItem>
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
                                            <ClientSideEvents Click="function validate(s, e) {      
                                             e.processOnServer =  jQuery.formValidator.PageIsValid('1'); 
                           }    " />
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

    <script language="javascript" type="text/javascript">
$(document).ready(function(){
$.formValidator.initConfig({onError:function(msg){alert(msg)}});
     $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtUserName_I").formValidator({onshow:"请输入",onfocus:"不能为空",oncorrect:"合法"}).InputValidator({min:1,onerror:"不能为空,请确认"});
     $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtPass_I").formValidator({onshow:"请输入",onfocus:"不能为空",oncorrect:"合法"}).InputValidator({min:1,onerror:"不能为空,请确认"});
  $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtMail_I").formValidator({empty:true,onshow:"请输入",onfocus:"请输入电子邮件地址",oncorrect:"输入正确"}).RegexValidator({regexp:"^[_a-z0-9]+@([_a-z0-9]+\.)+[a-z0-9]{2,3}$",onerror:"只能为电子邮件地址"});
//    $("#ctl00_ContentPlaceHolder1_txt_loginCount").formValidator({empty:true,onshow:"请输入",onfocus:"只能输入数字",oncorrect:"输入正确"}).RegexValidator({regexp:"num",datatype:"enum",onerror:"只能为数字"});
  $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtTrueName_I").formValidator({onshow:"请输入",onfocus:"不能为空",oncorrect:"合法"}).InputValidator({min:1,onerror:"不能为空,请确认"});

});
    </script>

</asp:Content>
