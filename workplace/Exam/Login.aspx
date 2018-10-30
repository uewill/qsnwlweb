<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Exame_Login" %>



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

    <title>中国美术学院成都考级中心-登录</title>

    <!-- Bootstrap core CSS -->
    <link href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">


    <!-- Custom styles for this template -->
    <link href="jumbotron-narrow.css" rel="stylesheet">


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

                        <div class="col-md-12">
                            <h3>登录</h3>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <ul class="nav nav-tabs">
                                <li role="presentation" class="active"><a href="/exam/Login.aspx">考点登录</a></li>
                                <li role="presentation"><a style="font-size: 18px;" href="/exam/personal/Login.aspx">考生登录</a></li>
                            </ul>

                            <div class="row">
                                <div class="col-md-9">
                                    <form runat="server">
                                        <div class="form-group">
                                            <label for="txtName">考点帐号</label>
                                            <input type="text" class="form-control" id="txtName" runat="server" placeholder="考点帐号">
                                        </div>
                                        <div class="form-group">
                                            <label for="txtPass">登录密码</label>
                                            <input type="password" class="form-control" id="txtPass" runat="server" placeholder="登录密码">
                                        </div>
                                        <%--                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="remi">
                                        记住密码
                                    </label>
                                </div>--%>
                                        <button type="button" runat="server" id="btnLogin" onserverclick="btnLogin_ServerClick" style="width: 120px;" class="btn btn-success">登录</button>
                                        <a style="width: 100px;" class="btn btn-link" href="ForgetPassword.aspx">忘记密码？</a>
                                        <a style="width: 100px;" class="btn btn-link" href="Regester.aspx">注册考点</a>   
                                        <a style="width: 100px;" class="btn btn-link" href="../default.aspx">返回首页</a>
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
            <p>&copy; 2018 中国美术学院成都考级中心</p>
        </footer>

    </div>
    <!-- /container -->


    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>
</body>
</html>



