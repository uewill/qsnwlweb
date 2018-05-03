<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="ModfyPass.aspx.cs" Inherits="admin_UserManage_ModfyPass" Title="修改密码" %>

<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="hdfAction" runat="server" />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="100%">
        <PanelCollection>
            <dxrp:PanelContent runat="server">
                <table class="category" width="100%" border="0" align="center" cellpadding="0" cellspacing="1"
                   >
                    <tr>
                        <td style="width: 100px; text-align: right">
                            用户名：</td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 100px; text-align: right">
                            更新密码：</td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtPass1"  Password="True"  Width="150px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtPass1_ITip" style="width: 250px;
                                            display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right">
                            更新密码：</td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtPass2"  Password="True"  Width="150px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtPass2_ITip" style="width: 250px;
                                            display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
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
     $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtPass_I").formValidator({onshow:"请输入原始密码",onfocus:"密码不能为空",oncorrect:"密码合法"}).InputValidator({min:1,onerror:"密码不能为空,请确认"});
$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtPass1_I").formValidator({onshow:"请输入密码",onfocus:"密码不能为空",oncorrect:"密码合法"}).InputValidator({min:1,onerror:"密码不能为空,请确认"});
$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtPass2_I").formValidator({onshow:"请再次输入密码",onfocus:"两次密码必须一致哦",oncorrect:"密码一致"}).InputValidator({min:1,onerror:"重复密码不能为空,请确认"}).CompareValidator({desID:"ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtPass1_I",operateor:"=",onerror:"2次密码不一致,请确认"});
});
    </script>

</asp:Content>
