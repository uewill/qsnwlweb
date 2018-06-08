<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>中国美术学院成都考级中心-后台管理登陆</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <div class="bottom">
            </div>
            <div class="top">
            </div>
            <div class="text1">
                <div class="suo">
                </div>
            </div>
            <div class="text">
                <dt><span >用户名</span>
                    <input id="txtUserName" runat="server" type="text" />
                </dt>
                <dt><span>密&nbsp;&nbsp;&nbsp;码&nbsp;</span>
                    <input id="txtPassword" runat="server" type="password" />
                </dt>
                <dt><span>验证码</span>
                    <input id="txtCheckCode" runat="server" type="text" style="width: 50px;" />
                    <em>
                        <img id="code" style="cursor: pointer" onclick="this.src='Codeimg.aspx?'+Math.random();"
                            src="Codeimg.aspx" align="middle" title="换一张"/></em> </dt>
                <dt>
                <input type="image" src="images/input.gif" value="确认登陆" style="width: 62px; height: 22px;margin-top: 10px; margin-right: 20px;" id="btnSubmit" runat="server" onserverclick="btnSubmit_ServerClick" />
                <input type="image" src="images/inputclear.gif" value="清空重填" style="width: 62px;
                        height: 22px; margin-top: 10px;" onclick="javascript:document.form1.reset();return false;" />
                </dt>
            </div>
            <div class="text2">
            </div>
        </div>
    </form>
  <div id="bottomNav">
            &copy;Copyright 2018 <a href="../" target="_blank">中国美术学院成都考级中心</a>
            保留所有权利</div>
</body>
</html>
