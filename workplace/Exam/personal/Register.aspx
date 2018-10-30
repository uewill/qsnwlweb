<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Exame_Personal_Login" %>



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

    <title>中国美术学院考级中心-成都考区承办单位四川金色年华艺术中心-登录</title>

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
                            <img src="../images/logo.png" class="img-responsive" />
                        </div>
                        <div class="col-md-8">
                            <h4>全国社会美术水平考级 - 成都考区</h4>
                        </div>

                        <div class="col-md-12">
                            <h3>注册</h3>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <ul class="nav nav-tabs">
                                <li role="presentation"><a href="/exam/Regester.aspx">考点注册</a></li>
                                <li role="presentation" class="active"><a style="font-size: 18px;" href="/exam/personal/Register.aspx">考生注册</a></li>
                            </ul>
                            <div class="row" style="padding-top: 10px;">
                                <div class="col-md-9">
                                    <form runat="server">
                                        <div class="form-group">
                                            <label for="txtName">考生姓名(实名)</label>
                                            <input type="text" class="form-control" id="txtName" runat="server" placeholder="考生姓名">
                                        </div>
                                        <div class="form-group">
                                            <label for="txtPhone">手机号码</label>
                                            <input type="text" class="form-control" id="txtPhone" runat="server" placeholder="手机号码">
                                        </div>
                                        <div class="form-group">
                                            <label for="txtPass">登录密码</label>
                                            <input type="password" class="form-control" id="txtPass" runat="server" placeholder="登录密码">
                                        </div>
                                        <div class="form-group">
                                            <label for="txtPass2">确认密码</label>
                                            <input type="password" class="form-control" id="txtPass2" runat="server" placeholder="确认密码">
                                        </div>
                                        <button type="button" runat="server" id="btnLogin" onserverclick="btnLogin_ServerClick" style="width: 120px;" class="btn btn-success">注册</button>
                                        <a style="width: 120px;" class="btn btn-link" href="Login.aspx">已有帐号,直接登录？</a>  <a style="width: 120px;" class="btn btn-link" href="default.aspx">返回首页</a>
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
            <p>&copy; 2018 中国美术学院考级中心-成都考区承办单位四川金色年华艺术中心</p>
        </footer>

    </div>
    <!-- /container -->


    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>
</body>
</html>



