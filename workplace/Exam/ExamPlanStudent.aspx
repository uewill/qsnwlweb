<%@ Page Title="" Language="C#" MasterPageFile="~/Exam/ExtMaster.master" AutoEventWireup="true" CodeFile="ExamPlanStudent.aspx.cs" Inherits="Exam_ExamPlanStudent" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
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
                        K('#ctl00_ContentPlaceHolder1_txtIDImg1').val(url);
                        K('#ctl00_ContentPlaceHolder1_imgID1').attr("src", url);
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
                        K('#ctl00_ContentPlaceHolder1_txtIDImg2').val(url);
                        K('#ctl00_ContentPlaceHolder1_imgID2').attr("src", url);
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
        });
    </script>

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">报名信息</h1>
        </div>
        <div class="col-xs-12">
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">

                <div class="panel-heading">
                    <div class="form-group">
                        <label>考级计划</label>
                        <p class="form-control-static"><%=planModel.TestingTime %>&nbsp;&nbsp;<%=planModel.Contactor %></p>
                        <p class="form-control-static"><%=planModel.TestingClass %></p>
                    </div>
                </div>
                <!-- /.panel-heading -->
                <form role="form" runat="server">
                    <div class="panel-body" id="panelAdd" runat="server">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label>报考科目 <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlClass" runat="server" DataValueField="id" DataTextField="title"></asp:DropDownList>
                                    &nbsp;&nbsp;  &nbsp;&nbsp;
                                    <label>报考等级 <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlLevel" runat="server">
                                        <asp:ListItem Text="一级" Value="一级" />
                                        <asp:ListItem Text="二级" Value="二级" />
                                        <asp:ListItem Text="三级" Value="三级" />
                                        <asp:ListItem Text="四级" Value="四级" />
                                        <asp:ListItem Text="五级" Value="五级" />
                                        <asp:ListItem Text="六级" Value="六级" />
                                        <asp:ListItem Text="七级" Value="七级" />
                                        <asp:ListItem Text="八级" Value="八级" />
                                        <asp:ListItem Text="九级" Value="九级" />
                                        <asp:ListItem Text="十级" Value="十级" />
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;  &nbsp;&nbsp;
                                    <label>原等级 <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlOrgLevel" runat="server">
                                        <asp:ListItem Text="一级" Value="一级" />
                                        <asp:ListItem Text="二级" Value="二级" />
                                        <asp:ListItem Text="三级" Value="三级" />
                                        <asp:ListItem Text="四级" Value="四级" />
                                        <asp:ListItem Text="五级" Value="五级" />
                                        <asp:ListItem Text="六级" Value="六级" />
                                        <asp:ListItem Text="七级" Value="七级" />
                                        <asp:ListItem Text="八级" Value="八级" />
                                        <asp:ListItem Text="九级" Value="九级" />
                                        <asp:ListItem Text="十级" Value="十级" />
                                    </asp:DropDownList>&nbsp;&nbsp;  &nbsp;&nbsp;
                                    <label>国籍 <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlCountry" runat="server" DataValueField="id" DataTextField="title"></asp:DropDownList>
                                    &nbsp;&nbsp;  &nbsp;&nbsp;
                                    <label>名族 <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlMingzu" runat="server" DataValueField="id" DataTextField="title"></asp:DropDownList>
                                    &nbsp;&nbsp;  &nbsp;&nbsp;
                                    <label>性别 <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlSex" runat="server">
                                        <asp:ListItem Text="男" Value="0" />
                                        <asp:ListItem Text="女" Value="1" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-xs-3">
                                <div class="form-group">
                                    <label>姓名 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtUserName" runat="server" placeholder="姓名">
                                </div>
                            </div>
                            <div class="col-xs-3">
                                <div class="form-group">
                                    <label>姓名拼音 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtUserNamePinyin" runat="server" placeholder="姓名拼音">
                                </div>
                            </div>
                            <div class="col-xs-3">
                                <div class="form-group">
                                    <label>身份证号 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtID" runat="server" placeholder="身份证号">
                                </div>
                            </div>
                            <div class="col-xs-3">
                                <div class="form-group">
                                    <label>出生日期 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtBirthday" runat="server" placeholder="出生日期" onclick="WdatePicker()">
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-xs-2">
                                <div class="form-group">
                                    <label>考生图片 <span style="color: red">*</span></label>
                                    <input id="txtIDImg1" runat="server" type="hidden" class="form-control" />
                                    <input type="button" id="insertfile" value="选择文件" />
                                </div>
                            </div>
                            <div class="col-xs-2">
                                <img id="imgID1" runat="server" src="/images/nopic.jpg" height="140" width="100" class="img-rounded">
                            </div>
                            <div class="col-xs-2">
                                <div class="form-group">
                                    <label>作品图片 <span style="color: red">*</span></label>
                                    <input id="txtIDImg2" runat="server" type="hidden" class="form-control" />
                                    <input type="button" id="insertfile2" value="选择文件" />
                                </div>
                            </div>

                            <div class="col-xs-2">
                                <img id="imgID2" runat="server" src="/images/nopic.jpg" height="140" width="100" class="img-rounded">
                            </div>
                            <div class="col-xs-4"></div>
                        </div>

                        <div class="form-group">
                            <button style="width: 120px;" id="btnSave" runat="server" onserverclick="btnSave_ServerClick" class="btn btn-success">添加</button>
                            <button style="width: 140px;" id="btnGoToPay" runat="server"  OnClientClick="javascript:return confirm('您确定要删除吗');" onserverclick="btnGoToPay_ServerClick" class="btn btn-danger">完成考生信息录入</button>
                            <p class="form-control-static">完成考生信息录入后,将不能再修改考生信息</p>
                        </div>

                    </div>

                    <div class="panel-body" id="panelList">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th style="width: 60px;"></th>
                                        <th class="col-xs-1">报考科目</th>
                                        <th class="col-xs-1">报考等级</th>
                                        <th class="col-xs-1">原等级</th>
                                        <th class="col-xs-1">姓名/性别</th>
                                        <th class="col-xs-1">姓名拼音</th>
                                        <th class="col-xs-1">国籍/名族</th>
                                        <th class="col-xs-1">生日</th>
                                        <th class="col-xs-1">身份证号</th>
                                        <th class="col-xs-1">照片</th>
                                        <th class="col-xs-1">作品</th>
                                        <th class="col-xs-1"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptBind" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <th><%#Container.ItemIndex+1 %></th>
                                                <td><%# GetCategoryName(Eval("classid")) %></td>
                                                <td><%#Eval("LevelNum")%></td>
                                                <td><%#Eval("OrgLevel") %></td>
                                                <td><%#Eval("UserName") %>&nbsp;/&nbsp;<%#Eval("sex").ToString().Equals("0")?"男":"女" %></td>
                                                <td><%#Eval("UserNamePinyin") %></td>
                                                <td><%# GetCategoryName(Eval("Country")) %>&nbsp;/&nbsp;<%# GetCategoryName(Eval("EthnicGroup")) %></td>
                                                <td><%#Eval("Birthday","{0:yyyy/MM/dd}") %></td>
                                                <td><%#Eval("IDNumber") %></td>
                                                <td>

                                                    <img src="<%# GetImagePath(Eval("UserHeadImage")) %>" width="80" /></td>
                                                <td>
                                                    <img src="<%# GetImagePath(Eval("UserWorkImage")) %>" width="80" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ibtnDel" CssClass="btn btn-default btn-xs" ImageUrl="../admin/images/del.gif" ToolTip="删除..." CommandName='<%# Eval("ID") %>' OnCommand="ibtnDel_OnCommand" OnClientClick="javascript:return confirm('您确定要删除吗');"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>

                        <webdiyer:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="AspNetPager1"
                            HorizontalAlign="Center" runat="server" AlwaysShow="false" FirstPageText="首页"
                            Font-Size="12px" LastPageText="尾页" NextPageText="下一页" PageSize="30" PrevPageText="上一页"
                            ShowBoxThreshold="11" TextAfterPageIndexBox="" TextBeforePageIndexBox="" UrlPaging="true"
                            OnPageChanging="AspNetPager1_PageChanging">
                        </webdiyer:AspNetPager>
                    </div>


                </form>
            </div>
            <!-- /.panel-body -->
        </div>

        <!-- /.panel -->
    </div>


</asp:Content>

