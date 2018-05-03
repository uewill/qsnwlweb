<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="welcome.aspx.cs" Inherits="admin_MainPage_welcome" Title="欢迎登录网站管理后台" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../images/skin.css" rel="stylesheet" type="text/css" />
    <div style="position: relative; color: #000">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="17" valign="top" background="../images/mail_leftbg.gif">
                    <img src="../images/left-top-right.gif" width="17" height="29" />
                </td>
                <td valign="top" background="../images/content-bg.gif">
                    <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg"
                        id="table2">
                        <tr>
                            <td height="31">
                                <div class="titlebt">
                                    欢迎界面</div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="16" valign="top" background="../images/mail_rightbg.gif">
                    <img src="../images/nav-right-bg.gif" width="16" height="29" />
                </td>
            </tr>
            <tr>
                <td valign="middle" background="../images/mail_leftbg.gif">
                    &nbsp;
                </td>
                <td valign="top" bgcolor="#F7F8F9">
                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="2" valign="top">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td valign="top">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <span class="left_bt">感谢您使用 优意科技 网站管理系统程序</span><br>
                                <br>
                                <span class="left_txt">&nbsp;<img src="../images/ts.gif" width="16" height="16">
                                    提示：<br>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;您现在使用的是由 优意科技 定制开发的一套用于构建企业信息类型网站的专业系统！如果您有任何疑问请拨打左下角的</span><span
                                        class="left_ts">客服电话</span><span class="left_txt">进行咨询！<br>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;网站栏目完美整合，一站通使用方式，功能强大，操作简单，后台操作易如反掌，只需会打字，会上网，就会管理网站！<br>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;此程序是您建立,宣传地区级商家网络信息形象的首选方案！
                                            <br>
                                        </span>
                            </td>
                            <td width="7%">
                                &nbsp;
                            </td>
                            <td width="40%" valign="top">
                                <table width="100%" height="144" border="0" cellpadding="0" cellspacing="0" class="line_table">
                                    <tr>
                                        <td width="7%" height="27" background="../images/news-title-bg.gif">
                                            <img src="../images/news-title-bg.gif" width="2" height="27">
                                        </td>
                                        <td width="93%" background="../images/news-title-bg.gif" class="left_bt2">
                                            最新动态
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="102" valign="top">
                                            &nbsp;
                                        </td>
                                        <td height="102" valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <!--JavaScript部分-->

                                <script language="javascript">
function secBoard(n)
{
for(i=0;i<secTable.cells.length;i++)
secTable.cells[i].className="sec1";
secTable.cells[n].className="sec2";
for(i=0;i<mainTable.tBodies.length;i++)
mainTable.tBodies[i].style.display="none";
mainTable.tBodies[n].style.display="block";
}
                                </script>

                                <!--HTML部分-->
                                <table width="72%" border="0" cellpadding="0" cellspacing="0" id="secTable">
                                    <tbody>
                                        <tr align="middle" height="20">
                                            <td align="center" class="sec2">
                                                服务器基本信息
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table class="main_tab" id="mainTable" cellspacing="0" cellpadding="0" width="100%"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td valign="top" align="middle">
                                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#FAFBFC">
                                                                &nbsp;
                                                            </td>
                                                            <td bgcolor="#FAFBFC" class="left_txt">
                                                                服务器IP地址： <span class="left_ts">
                                                                    <asp:Label ID="lbIp" runat="server" Width="100px"></asp:Label>
                                                                </span>服务器域名：<span class="left_ts"><asp:Label ID="lbDomain" runat="server"></asp:Label>
                                                                </span>
                                                            </td>
                                                            <td bgcolor="#FAFBFC" class="left_txt">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#FAFBFC">
                                                                &nbsp;
                                                            </td>
                                                            <td bgcolor="#FAFBFC" class="left_txt">
                                                                服务器端口： <span class="left_ts">
                                                                    <asp:Label ID="lbPort" Width="100px" runat="server"></asp:Label>
                                                                </span>服务器IIS版本：<span class="left_ts"><asp:Label ID="lbIISVer" runat="server"></asp:Label>
                                                            </td>
                                                            </span><td bgcolor="#FAFBFC" class="left_txt">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#FAFBFC">
                                                                &nbsp;
                                                            </td>
                                                            <td bgcolor="#FAFBFC" class="left_txt">
                                                                本文件所在文件夹：<span class="left_ts"><asp:Label ID="lbPhPath" runat="server"></asp:Label>
                                                            </td>
                                                            </span>
                                                            <td bgcolor="#FAFBFC" class="left_txt">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#FAFBFC">
                                                                &nbsp;
                                                            </td>
                                                            <td bgcolor="#FAFBFC" class="left_txt">
                                                                服务器操作系统： <span class="left_ts">
                                                                    <asp:Label ID="lbOperat" runat="server"></asp:Label>
                                                            </td>
                                                            </span>
                                                            <td bgcolor="#FAFBFC" class="left_txt">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="3">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td valign="top">
                                <table width="100%" height="144" border="0" cellpadding="0" cellspacing="0" class="line_table">
                                    <tr>
                                        <td width="7%" height="27" background="../images/news-title-bg.gif">
                                            <img src="../images/news-title-bg.gif" width="2" height="27">
                                        </td>
                                        <td width="93%" background="../images/news-title-bg.gif" class="left_bt2">
                                            程序说明
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="102" valign="top">
                                            &nbsp;
                                        </td>
                                        <td height="102" valign="top">
                                            <label>
                                            </label>
                                            <label>
                                                <textarea name="textarea"  style="width:95%;height:100%;border:none;" readonly="readonly"  rows="8" class="left_txt"> 您现在使用的是由优意科技网络科技公司定制开发的一套用于构建企业信息类型网站的专业系统！如果您有任何疑问请拨打左下角的客服电话进行咨询！
      网站栏目完美整合，一站通使用方式，功能强大，操作简单，后台操作易如反掌，只需会打字，会上网，就会管理网站！
      此程序是您建立,宣传地区级商家网络信息形象的首选方案！ </textarea>
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="40" colspan="4">
                                <table width="100%" height="1" border="0" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC">
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="2%">
                                &nbsp;
                            </td>
                            <td width="51%" class="left_txt">
                                <img src="../images/icon-mail2.gif" width="16" height="11">
                                客户服务邮箱：395931834@qq.com
                                <img src="../images/icon-phone.gif" width="17" height="14">
                                客户服务电话：181-9078-0080
                                <br>
                                <img src="../images/icon-phone.gif" width="17" height="14">
                                官方网站：http://www.uemaster.com
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
                <td background="../images/mail_rightbg.gif">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="bottom" background="../images/mail_leftbg.gif">
                    <img src="../images/buttom_left2.gif" width="17" height="17" />
                </td>
                <td background="../images/buttom_bgs.gif">
                    <img src="../images/buttom_bgs.gif" width="17" height="17">
                </td>
                <td valign="bottom" background="../images/mail_rightbg.gif">
                    <img src="../images/buttom_right2.gif" width="16" height="17" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
