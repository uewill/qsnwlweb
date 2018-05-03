<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_MainPage_Default" %>

<%@ Register Src="../Controls/TopControl.ascx" TagName="TopControl" TagPrefix="uc2" %>
<%@ Register Src="../Controls/LeftControl.ascx" TagName="LeftControl" TagPrefix="uc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站后台管理系统</title>
    <link type="text/css" rel="stylesheet" href="../css/main.css" />

    <script src="../js/jquery.js" type="text/javascript" language="javascript"></script>

    <script src="../js/topsz.js" type="text/javascript" language="javascript"></script>

    <script language="javascript" type="text/javascript">
	      function SetCwinHeight(){
  var iframeid=document.getElementById("Frame1"); //iframe id
  if (document.getElementById){
   if (iframeid && !window.opera){
    if (iframeid.contentDocument && iframeid.contentDocument.body.offsetHeight){
     iframeid.height = iframeid.contentDocument.body.offsetHeight+200;
    }else if(iframeid.Document && iframeid.Document.body.scrollHeight){
     iframeid.height = iframeid.Document.body.scrollHeight+200;
    }
   }
  }
 }
    </script>
    
        
    <!-- artDialog -->

    <script type="text/javascript" src="../../ArtDialog/artDialog.min.js" charset="utf-8"></script>

    <script> 
(function($){
	// 改变默认配置
	var d = $.dialog.defaults;
	// 预缓存皮肤，数组第一个为默认皮肤
	d.skin = ['aero','normal', 'chrome', 'facebook', 'aero'];
	// 是否开启特效
	//d.effect = true;
	// 指定超过此面积的对话框拖动的时候用替身
	//d.showTemp = 100000;
	
})(art);

  //打开指定窗口
  function openWindow(urlPath,titles,artID){
   $.dialog.open("../"+urlPath,{
   title:titles,
   id:artID
   });
 }
    </script>


</head>
<body>
    <form id="form2" runat="server">
    <uc2:TopControl ID="TopControl1" runat="server" />
    <div class="center">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <div id="sfqclick" style="width: 200px;">
                        <uc1:LeftControl ID="LeftControl1" runat="server"></uc1:LeftControl>
                    </div>
                </td>
                <td width="13" valign="top" style="height: 360px">
                    <input type="image" onclick='showhidediv("sfqclick");return false;' style="margin-top: 150px;
                        margin-left: 2px; padding-right: 2px;" src="../images/leftan.gif" width="9" height="52" />
                </td>
                <td width="100%" valign="top">
                    <iframe id="Frame1" name="Frame1" width="90%" height="auto;" src="welcome.aspx" allowtransparency="true"
                        onload="Javascript:SetCwinHeight()" frameborder="0" scrolling="no"></iframe>
                </td>
            </tr>
        </table>
    </div>
    <div id="bottomNav">
            &copy;Copyright 2010 <a href="http://www.uemaster.com" target="_blank">成都优意科技</a>
            保留所有权利</div>
    </form>
</body>
</html>
