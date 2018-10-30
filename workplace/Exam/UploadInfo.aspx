<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadInfo.aspx.cs" Inherits="Exame_UploadInfo" %>


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

    <title>中国美术学院成都考级中心 - 更新资料</title>

    <!-- Bootstrap core CSS -->
    <link href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://cdn.bootcss.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->


    <link rel="stylesheet" href="../Kinde/themes/default/default.css" />
    <script src="../Kinde/kindeditor-all-min.js"></script>
    <script src="../Kinde/lang/zh-CN.js"></script>
    <script>
        KindEditor.ready(function (K) {
            var editor = K.editor({
                uploadJson: '../../kinde/asp.net/upload_json.ashx',
                allowFileManager: false
            });

            var uploadbutton = K.uploadbutton({
                button: K('#insertfile')[0],
                fieldName: 'imgFile',
                url: '../../kinde/asp.net/upload_json.ashx',
                afterUpload: function (data) {
                    if (data.error === 0) {
                        var url = K.formatUrl(data.url, 'absolute');
                        K('#txtIDImg1').val(url);
                        K('#imgID1').attr("src", url);
                    } else {
                        alert(data.message);
                    }
                },
                afterError: function (str) {
                    alert('自定义错误信息: ' + str);
                }
            });
            uploadbutton.fileBox.change(function (e) {
                uploadbutton.submit();
            });

            var uploadbutton2 = K.uploadbutton({
                button: K('#insertfile2')[0],
                fieldName: 'imgFile',
                url: '../../kinde/asp.net/upload_json.ashx',
                afterUpload: function (data) {
                    if (data.error === 0) {
                        var url = K.formatUrl(data.url, 'absolute');
                        K('#txtIDImg2').val(url);
                        K('#imgID2').attr("src", url);
                    } else {
                        alert(data.message);
                    }
                },
                afterError: function (str) {
                    alert('自定义错误信息: ' + str);
                }
            });
            uploadbutton2.fileBox.change(function (e) {
                uploadbutton2.submit();
            });

            var uploadbutton3 = K.uploadbutton({
                button: K('#insertfile3')[0],
                fieldName: 'imgFile',
                url: '../../kinde/asp.net/upload_json.ashx',
                afterUpload: function (data) {
                    if (data.error === 0) {
                        var url = K.formatUrl(data.url, 'absolute');
                        K('#txtYYZZ').val(url);
                        K('#imgID3').attr("src", url);
                    } else {
                        alert(data.message);
                    }
                },
                afterError: function (str) {
                    alert('自定义错误信息: ' + str);
                }
            });
            uploadbutton3.fileBox.change(function (e) {
                uploadbutton3.submit();
            });
        });
    </script>
</head>

<body style="padding: 10px 0px; background-color: #CCC">

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
                            <h3>更新资料</h3>
                        </div>
                    </div>
                    <form runat="server">
                        <div class="row">
                            <div class="col-md-9">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">身份证号： <span style="color: red">*</span></label>
                                    <input id="txtID" runat="server" type="text" class="form-control" placeholder="身份证号">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">身份证正面照 <span style="color: red">*</span></label>
                                    <input id="txtIDImg1" runat="server" type="hidden" class="form-control" placeholder="身份证正面照">
                                    <input type="button" id="insertfile" value="选择文件" />

                                </div>

                                <img id="imgID1" runat="server" src="/images/nopic.jpg" height="120" alt="..." class="img-rounded">
                            </div>
                            <div class="col-md-6">
                                示例：
                                <img src="images/id1.png" height="120" alt="..." class="img-rounded">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">身份证背面照 <span style="color: red">*</span></label>
                                    <input id="txtIDImg2" runat="server" type="hidden" class="form-control" placeholder="身份证背面照" />
                                    <input type="button" id="insertfile2" value="选择文件" />
                                </div>

                                <img id="imgID2" runat="server" src="/images/nopic.jpg" height="120" alt="..." class="img-rounded">
                            </div>
                            <div class="col-md-6">
                                示例：
                                <img src="images/id2.png" height="120" alt="..." class="img-rounded">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">营业执照 <span style="color: red">*</span></label>
                                    <input id="txtYYZZ" runat="server" type="hidden" class="form-control" placeholder="营业执照">
                                    <input type="button" id="insertfile3" value="选择文件" />
                                </div>
                                <img id="imgID3" runat="server" src="/images/nopic.jpg" height="120" alt="..." class="img-rounded">
                            </div>
                            <div class="col-md-6">
                                示例：
                                <img src="images/yyzz3.png" height="120" alt="..." class="img-rounded">
                            </div>

                        </div>
                        <div class="row">
                            <button type="button" id="btnReg" runat="server" onserverclick="btnReg_ServerClick" style="width: 120px;" class="btn btn-success">提交资料</button>
                        </div>
                    </form>

                </div>
            </div>
            <div class="col-md-2"></div>

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


