<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopControl.ascx.cs" Inherits="admin_Controls_TopControl" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<div class="top" id="class_cnt1">

    <script language='javascript'>
var curStyle = 0;
var totalItem = 9;

function mv(selobj,moveout,itemnum)
{
   if(itemnum==curStyle) return false;
   if(moveout=='m') selobj.className = 'itemsel';
   if(moveout=='o') selobj.className = 'item';
   return true;
}

function changeSel(itemnum)
{
  curStyle = itemnum;
  for(i=0;i<=totalItem;i++)
  {
     if(document.getElementById('item'+i)) document.getElementById('item'+i).className='item';
     if(itemnum!=0){
     if(document.getElementById('leftMenuDiv'+i)) document.getElementById('leftMenuDiv'+i).className='none';
     }else{
         if(document.getElementById('leftMenuDiv'+i)) document.getElementById('leftMenuDiv'+i).className='block';
     }
  }
  if(document.getElementById('item'+itemnum)) document.getElementById('item'+itemnum).className='itemsel';
   if(document.getElementById('leftMenuDiv'+itemnum))document.getElementById('leftMenuDiv'+itemnum).className='block';
}

    </script>

    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="../images/topbg.gif">
        <tr>
            <td width='20%' height="60">
                <%--<img src="../images/logo.png" height="60px" style="margin:0px; padding:0px;" alt="公司LOGO" />--%>
            </td>
            <td width='70%' align="right" valign="bottom" height="60" <%-- style=" background-repeat:no-repeat; background-image:url(../images/topbg_1.gif);"--%>>
                <table width="750" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right" height="26" style="padding-right: 10px; line-height: 26px;">
                            您好：<span class="username"><asp:Label ID="lblUserName" runat="server"></asp:Label></span>，欢迎使用内容管理系统！
                            [<a href="../../" target="_blank">前台页面</a>] [<a href="../UserManage/ModfyPass.aspx"
                                target="Frame1">修改密码</a>] [ <a class="dx" style="font-size: 13px; line-height: 18px;"
                                    onclick="return confirm('确定退出？')" href="../login.aspx?signOut=true">安全退出</a>]&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="34" class="rmain">
                            <dl id="tpa">
                                <dd>
                                    <div class='itemsel' id='item0' onmousemove="mv(this,'move',0);" onmouseout="mv(this,'o',0);">
                                        <a href="Default.aspx" onclick="changeSel(0)" target="Frame1">主菜单</a></div>
                                </dd>
                                <asp:Panel ID="panlAdmin" runat="server" Visible="false">
                                    <dd>
                                        <div class='item' id='item1' onmousemove="mv(this,'m',1);" onmouseout="mv(this,'o',1);">
                                            <a href="MenuHome.aspx" onclick="changeSel(1)" target="Frame1">线路管理</a></div>
                                    </dd>
                                    <dd>
                                        <div class='item' id='item2' onmousemove="mv(this,'m',2);" onmouseout="mv(this,'o',2);">
                                            <a href="../RoleManage/" onclick="changeSel(2)" target="Frame1">用户管理</a></div>
                                    </dd>
                                    <dd>
                                        <div class='item' id='item3' onmousemove="mv(this,'m',3);" onmouseout="mv(this,'o',3);">
                                            <a href="../CustomManage/" onclick="changeSel(3)" target="Frame1">会员管理</a></div>
                                    </dd>
                                    <dd>
                                        <div class='item' id='item4' onmousemove="mv(this,'m',4);" onmouseout="mv(this,'o',4);">
                                            <a href="../ArticlesManage/" onclick="changeSel(4)" target="Frame1">网站内容</a></div>
                                    </dd>
                                    <dd>
                                        <div class='item' id='item5' onmousemove="mv(this,'m',5);" onmouseout="mv(this,'o',5);">
                                            <a href="../CategoryManage/" onclick="changeSel(5)" target="Frame1">网站配置</a></div>
                                    </dd>
                                </asp:Panel>
                            </dl>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="10%">
            </td>
        </tr>
    </table>
</div>
