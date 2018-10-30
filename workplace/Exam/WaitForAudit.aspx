<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WaitForAudit.aspx.cs" Inherits="Exame_UploadInfo" %>


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

    <title>中国美术学院成都考级中心-等待审核</title>

    <!-- Bootstrap core CSS -->
    <link href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>

<body style="padding: 10px 0px; background-color: #CCC">

    <div class="container">
        <div class="row">
   <div class="col-md-2"></div>
            <div class="col-md-8">

                <div class="jumbotron">
                    <div class="row" style="margin-bottom: 20px">
                        <div class="col-md-4 text-center">
                                        <img src="images/logo.png"  class="img-responsive"/></div>
                         <div class="col-md-8">
                                   <h4>全国社会美术水平考级 - 成都考区</h4></div>
                                
                            <div class="col-md-12"><h3>登录</h3></div>
                        </div>
                    <form runat="server">
                        <div class="row">
                            <div class="col-xs-9">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">注册资料已提交审核，请等待审核</label>
                                </div>
                            </div>
                        </div>
                    </form>

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


