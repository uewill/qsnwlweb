<%@ Page Title="" Language="C#" MasterPageFile="~/Exam/ExtMasterPerson.master" AutoEventWireup="true" CodeFile="NewTesting.aspx.cs" Inherits="Exam_personal_NewTesting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
      
    </style>

    <script language="JavaScript" type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">考级报名</h1>
        </div>
        <div class="col-md-12">
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">

            <!-- Stepper -->
            <div class="steps-form">
                <div class="steps-row setup-panel">
                    <div class="steps-step">
                        <a href="#" type="button" class="btn btn-success btn-circle">1</a>
                        <p>填写报名信息</p>
                    </div>
                    <div class="steps-step">
                        <a href="#" type="button" class="btn btn-default btn-circle" disabled="disabled">2</a>
                        <p>支付报考费用</p>
                    </div>
                    <div class="steps-step">
                        <a href="#" type="button" class="btn btn-default btn-circle" disabled="disabled">3</a>
                        <p>报考单详情</p>
                    </div>
                </div>
            </div>
        </div>



        <div class="col-lg-12">
            <div class="panel panel-default">
                <!-- /.panel-heading -->
                <form role="form" runat="server">
            <input type="hidden" runat="server" id="hdfNumber" />
                    <div class="panel panel-green" style="margin: 6px;">
                        <div class="panel-heading">考级计划</div>
                        <div class="panel-body" runat="server">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label><%=planModel.TestingTitle %></label>
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <label>考级项目：</label>
                                        <%=GetSubCategoryName() %>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>考级时间：</label>
                                        <%=planModel.TestTimeAMStart %> 至 <%=planModel.TestTimeAMStart %>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>考级地点：</label>
                                        <%=planModel.Address %>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>考级名额：</label>
                                        <%=planModel.TotalCount %>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="panel panel-default" style="margin: 6px;">
                        <div class="panel-body" id="panelStep1">
                            <div class="row">
                                <div class="col-lg-12">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>姓名</label>
                                        <input class="form-control" id="txtUserName" runat="server" required placeholder="姓名">
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>姓名拼音</label>
                                        <input class="form-control" id="txtUserNamePy" runat="server" required placeholder="姓名拼音">
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>出生日期</label>
                                        <input class="form-control" id="txtBirthday" runat="server" placeholder="出生日期" onclick="WdatePicker()">
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>性别</label>
                                        <asp:DropDownList ID="ddlSex" CssClass="form-control " Width="120" runat="server">
                                            <asp:ListItem Text="男" Value="男"></asp:ListItem>
                                            <asp:ListItem Text="女" Value="女"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>国籍</label>
                                        <asp:DropDownList ID="ddlguoji" CssClass="form-control " Width="120" DataTextField="title" DataValueField="title" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>民族</label>
                                        <asp:DropDownList ID="ddlmingzu" CssClass="form-control " Width="120" DataTextField="title" DataValueField="title" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                  <div class="col-md-2">
                                    <div class="form-group">
                                        <label>身份证号码 <span style="color: red">*</span></label>
                                        <input class="form-control" id="txtIDNumber" runat="server" required placeholder="身份证号码">
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>联系电话 <span style="color: red">*</span></label>
                                        <input class="form-control" id="txtPhoneNumber" runat="server" required placeholder="联系电话">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>考生所在地 <span style="color: red">*</span></label>
                                        <input class="form-control" id="txtContact" runat="server" required placeholder="考生所在地">
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>报考专业 <span style="color: red">*</span></label>
                                        <asp:DropDownList ID="ddlClass" CssClass="form-control" runat="server" DataTextField="title" DataValueField="title">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>申报级别 <span style="color: red">*</span></label>
                                        <asp:DropDownList CssClass="form-control" ID="ddlLevel" runat="server">
                                            <asp:ListItem Text="一级" Value="一级"></asp:ListItem>
                                            <asp:ListItem Text="二级" Value="二级"></asp:ListItem>
                                            <asp:ListItem Text="三级" Value="三级"></asp:ListItem>
                                            <asp:ListItem Text="四级" Value="四级"></asp:ListItem>
                                            <asp:ListItem Text="五级" Value="五级"></asp:ListItem>
                                            <asp:ListItem Text="六级" Value="六级"></asp:ListItem>
                                            <asp:ListItem Text="七级" Value="七级"></asp:ListItem>
                                            <asp:ListItem Text="八级" Value="八级"></asp:ListItem>
                                            <asp:ListItem Text="九级" Value="九级"></asp:ListItem>
                                            <asp:ListItem Text="十级" Value="十级"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>申报专业已过的最高级别 <span style="color: red">*</span></label>
                                        <asp:DropDownList CssClass="form-control" ID="ddlHaveLevel" runat="server">
                                            <asp:ListItem Text="无" Value="无"></asp:ListItem>
                                            <asp:ListItem Text="一级" Value="一级"></asp:ListItem>
                                            <asp:ListItem Text="二级" Value="二级"></asp:ListItem>
                                            <asp:ListItem Text="三级" Value="三级"></asp:ListItem>
                                            <asp:ListItem Text="四级" Value="四级"></asp:ListItem>
                                            <asp:ListItem Text="五级" Value="五级"></asp:ListItem>
                                            <asp:ListItem Text="六级" Value="六级"></asp:ListItem>
                                            <asp:ListItem Text="七级" Value="七级"></asp:ListItem>
                                            <asp:ListItem Text="八级" Value="八级"></asp:ListItem>
                                            <asp:ListItem Text="九级" Value="九级"></asp:ListItem>
                                            <asp:ListItem Text="十级" Value="十级"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>证书编号</label>
                                        <input class="form-control" id="txtLevelNo" runat="server" placeholder="证书编号">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>考生联系人 <span style="color: red">*</span></label>
                                        <input class="form-control" id="txtjjcontact" runat="server" required placeholder="考生联系人">
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>与考生关系 <span style="color: red">*</span></label>
                                        <input class="form-control" id="txtjjship" runat="server" required placeholder="与考生关系">
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>联系电话 <span style="color: red">*</span></label>
                                        <input class="form-control" id="txtjjphone" runat="server" required placeholder="联系电话">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>通讯地址 <span style="color: red"></span></label>
                                        <input class="form-control" id="txtjjaddress" runat="server" placeholder="通讯地址">
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>邮政编码 <span style="color: red"></span></label>
                                        <input class="form-control" id="txtPostNo" runat="server" placeholder="邮政编码">
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>指导老师 <span style="color: red"></span></label>
                                        <input class="form-control" id="txtZhiDao" runat="server" placeholder="指导老师">
                                    </div>
                                </div>

                            </div>

                            <div class="form-group pull-right">
                                <button style="width: 120px;" id="btnSave" runat="server" onserverclick="btnSave_ServerClick" class="btn btn-success">提交报考信息</button>
                            </div>



                        </div>
                    </div>
                </form>
                <!-- /.panel -->
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <h3 class="panel-title">考级报名表下载</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="btn-group" role="group" aria-label="...">
                                    <asp:Repeater ID="rptDownload" runat="server">
                                        <ItemTemplate>
                                            <a class="btn btn-default" href="<%#Eval("description") %>" target="_blank"><%#Eval("title") %></a>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>


</asp:Content>

