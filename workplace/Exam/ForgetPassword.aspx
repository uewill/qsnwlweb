<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="Exame_Login" %>



<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>全国社会艺术水平考级文化部艺术发展中心成都考区-找回密码</title>

    <!-- Bootstrap core CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet">


    <!-- Custom styles for this template -->
    <link href="jumbotron-narrow.css" rel="stylesheet">


    <script src="/Scripts/jquery-1.10.2.min.js"></script>
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>

<body style="padding: 40px 0px; background-image: url(http://139.129.220.45/static/login/images/banner_slide_03.jpg)">

    <div class="container">

        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">

                <div class="jumbotron">
                    <div class="row" style="margin-bottom: 20px">
                        <div class="col-md-4 text-center">
                            <img src="images/logo.png" class="img-responsive" />
                        </div>
                        <div class="col-md-8">
                            <h4>全国社会美术水平考级 - 成都考区</h4>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <ul class="nav nav-tabs">
                                <li role="presentation" class="active"><a style="font-size: 18px;" href="#">找回密码</a></li>
                                <li role="presentation"><a href="/exam/Login.aspx">考点登录</a></li>
                                <li role="presentation"><a href="/exam/personal/Login.aspx">考生登录</a></li>
                            </ul>
                            <div class="row" style="padding-top: 10px; font-size: 14px;">
                                <div class="col-md-9">
                                    <form runat="server">
                                        <div class="form-group">
                                            <label for="txtName">手机号码</label>
                                            <div class="row">
                                                <div class="col-xs-9">
                                                    <input type="text" class="form-control" id="txtPhoneNumber" runat="server" placeholder="帐号绑定的手机号码">
                                                </div>
                                                <div class="col-xs-3">
                                                    <button type="button" id="btnSendCode" class="btn btn-primary">获取验证码</button>
                                                </div>
                                                <%--disabled="disabled"--%>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtName">验证码</label>
                                            <input type="text" class="form-control" id="txtValicode" runat="server" placeholder="请输入验证码">
                                        </div>
                                        <div class="form-group">
                                            <label for="txtName">新的密码</label>
                                            <input type="text" class="form-control" id="txtPassword" runat="server" placeholder="请输入新的密码">
                                        </div>
                                        <div class="form-group">
                                            <label for="txtName">确认密码</label>
                                            <input type="text" class="form-control" id="txtPassword2" runat="server" placeholder="再次确认密码">
                                        </div>
                                        <button type="button" runat="server" id="btnLogin" onclick="javascript:return doCheckMsg();" onserverclick="btnLogin_ServerClick" style="width: 120px;" class="btn btn-success">修改密码</button>
                                    </form>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-2"></div>

        </div>
        <footer class="footer text-center">
            <p>&copy; 2018 全国社会艺术水平考级文化部艺术发展中心成都考区</p>
        </footer>

    </div>
    <!-- /container -->
    <script type="text/javascript">
        function doCheckMsg() {
            var number = $("#txtPhoneNumber").val();
            var valicode = $("#txtValicode").val();
            var pass1 = $("#txtPassword").val();
            var pass2 = $("#txtPassword2").val();
            if (isNaN(number) || number.length != 11) {
                alert("手机号码不合法！");
                return false;
            }
            if (isNaN(valicode) || valicode.length != 11) {
                alert("请输入与正确的验证码！");
                return false;
            }
            if (pass1.length < 6 && pass1.length > 18) {
                alert("请输入6-18个字符的密码！");
                return false;
            }
            if (pass1 != pass2) {
                alert("两次密码输入不一致");
                return false;
            }
            return true;

        }
        var totalCount = 120;
        var myTimeOut;
        function setCountDown() {
            totalCount--;
            $("#btnSendCode").html("等待" + totalCount + "秒后重新获取");
            if (totalCount <= 0) {
                totalCount = 120;
                clearInterval(myTimeOut);
                $("#btnSendCode").removeAttr("disabled");
                $("#btnSendCode").html("重新获取验证码");
            }
        }
        $(document).ready(function () {
            $("#btnSendCode").click(function () {
                if ($("#btnSendCode").attr("disabled") == "disabled") {
                    return;
                }
                var number = $("#txtPhoneNumber").val() + "";
                if (isNaN(number) || number.length != 11) {
                    alert("录入手机号码不合法！");
                    return;
                }
                $("#btnSendCode").attr("disabled", "disabled");
                $.post("sendmsg.aspx", { number: number, type: <%=Request.QueryString["type"]==null?"0":Request.QueryString["type"]%> },
                    function (data, status) {
                        var resData = JSON.parse(data);
                        if (resData.result == 0) {
                            alert("发送成功");
                            myTimeOut = setInterval(setCountDown, 1000);
                        } else {
                            alert(resData.errmsg);
                            $("#btnSendCode").removeAttr("disabled");
                        }
                    });
            });
        });

    </script>
</body>
</html>



