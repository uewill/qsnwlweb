<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoUpdate.aspx.cs" Inherits="Exame_InfoUpdate" %>


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

    <title>中国美术学院成都考级中心-资料更新</title>

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

<body style="padding: 10px 0px; background-color: #CCC">

    <div class="container">

        <div class="row">
            <div class="col-xs-2"></div>
            <div class="col-xs-8">

                <div class="jumbotron">
                    <div class="row" style="margin-bottom: 20px">
                        <div class="col-xs-12">
                            <table>
                                <tr>
                                    <td>
                                        <img src="images/logo.png" />&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td>
                                        <h3>全国社会美术水平考级 - 成都考区</h3>
                                    </td>
                                </tr>
                            </table>
                            <h3>资料更新</h3>
                        </div>
                    </div>
                    <form runat="server">
                        <div class="row">
                            <div class="col-xs-9">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">考点名称 <span style="color: red">*</span></label>
                                    <input id="txtName" runat="server" disabled="disabled" type="text" class="form-control" placeholder="考点名称">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">考点地址 <span style="color: red">*</span></label>
                                    <input id="txtAddress" runat="server" type="text" class="form-control" placeholder="考点地址">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">负责人姓名 <span style="color: red">*</span></label>
                                    <input id="txtUserName" runat="server" type="text" class="form-control" placeholder="负责人姓名">
                                </div>
                            </div>
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">手机号码 <span style="color: red">*</span></label>
                                    <input id="txtPhone" runat="server" type="text" class="form-control" placeholder="手机号码">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">座机固话 </label>
                                    <input id="txtTel" runat="server" type="text" class="form-control" placeholder="座机固话">
                                </div>
                            </div>
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">常用邮箱</label>
                                    <input id="txtEmail" runat="server" type="email" class="form-control" placeholder="常用邮箱">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">新密码 <span style="color: red">*</span></label>
                                    <asp:CheckBox ID="chkChangePass" runat="server" Text="是否修改密码？" />
                                    <input id="txtPass" runat="server" type="password" class="form-control" placeholder="新密码">
                                </div>
                            </div>
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">确认密码 <span style="color: red">*</span></label>
                                    <input id="txtPass2" runat="server" type="password" class="form-control" placeholder="确认密码">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">考点介绍</label>
                                    <textarea id="txtDes" runat="server" class="form-control" placeholder="考点介绍" rows="3"></textarea>
                                </div>

                                <button type="button" id="btnReg" runat="server" onserverclick="btnReg_ServerClick" style="width: 120px;" class="btn btn-success">保存</button>
                                <a style="width: 120px;" class="btn btn-link" href="Default.aspx">返回管理主页</a>
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


