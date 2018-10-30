<%@ Page Title="" Language="C#" MasterPageFile="~/Exam/ExtMasterPerson.master" AutoEventWireup="true" CodeFile="ViewTestingPay.aspx.cs" Inherits="Exam_personal_ViewTestingPay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                        <a href="#step-9" type="button" class="btn btn-success btn-circle">1</a>
                          <span style="background-color:#fff; padding-left:5px; padding-right:5px;">已完成</span>
                        <p>填写报名信息</p>
                    </div>
                    <div class="steps-step">
                        <a href="ViewTestingPay.aspx?id=<%=examModel.id %>" type="button" class="btn btn-success btn-circle">2</a>
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
<%--                <div class="panel-heading">
                    <ul class="nav nav-tabs">
                        <li role="presentation"><a href="#">
                            <h4><b>一、报名信息</b></h4>
                        </a></li>
                        <li role="presentation" class="active"><a href="ViewTestingPay.aspx?id=<%=examModel.id %>">
                            <h4><b>二、费用信息</b></h4>
                        </a></li>
                        <li role="presentation"><a href="ViewTesting.aspx?id=<%=examModel.id %>">
                            <h4><b>三、打印报考单</b></h4>
                        </a></li>
                    </ul>
                </div>--%>


                <!-- /.panel-heading -->
                <form role="form" runat="server">
                    <div class="panel-body" id="panelAdd" runat="server">

                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="panel panel-danger">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">报考费用说明</h3>
                                        </div>
                                        <div class="panel-body">
                                            总计费用:<b style="color: red; font-size: 38px"><%=NeedPayTotal %></b>&nbsp;&nbsp;支付状态：
                                            <b style="font-size:20px;"><%= (examModel.Status!=null&&examModel.Status.ToString().Equals("1")?"已支付":"待支付") %></b><br />
                                            <%=bkfysmCategory.description %>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label><%=planModel.TestingTitle %></label>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>考级时间：</label>
                                    <%=planModel.TestTimeAMStart %> 至 <%=planModel.TestTimeAMStart %>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>考级项目：  <%=examModel.ClassID %></label>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>考级地点：</label>
                                    <%=planModel.Address %>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>姓名：</label>
                                    <%=examModel.UserName %>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>姓名拼音：</label>
                                    <%=examModel.UserNamePY %>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>出生日期：</label>
                                    <%=examModel.Birthday %>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>性别：</label>
                                    <%=examModel.Sex %>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>国籍：</label>
                                    <%=examModel.Country %>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>民族：</label>
                                    <%=examModel.Mingzu %>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>联系电话：</label>
                                    <%=examModel.PhoneNumber %>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>考生所在地：</label>
                                    <%=examModel.Address %>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>报考专业：</label>
                                    <%=examModel.ClassID %>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>申报级别：</label>
                                    <%=examModel.ClassLevel %>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>申报专业已过最高级别：</label>
                                    <%=examModel.HaveMaxLevel %>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>证书编号：</label>
                                    <%=examModel.MaxLevelNo %>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>考生联系人：</label>
                                    <%=examModel.Contactor %>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>与考生关系：</label>
                                    <%=examModel.ContactorShip %>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>联系电话：</label>
                                    <%=examModel.ContactorPhone %>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>通讯地址：</label>
                                    <%=examModel.HomeAddress %>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>邮政编码：</label>
                                    <%=examModel.PostNo %>
                                </div>
                            </div>

                        </div>

                        <div class="form-group pull-right">
                            <a   style='width: 120px;display:<%= getPayStatus(examModel.Status)?"none":"block" %>' class="btn btn-success" href="/Exam/personal/NewTesting.aspx?id=<%=examModel.TypeID%>&tid=<%=examModel.id %>">返回修改资料</a>
                    
                            <a style='width: 120px;display:<%= getPayStatus(examModel.Status)?"block":"none" %>' class="btn btn-success" href="ViewTesting.aspx?id=<%=examModel.id %>">下一步</a>
                        </div>
                    </div>
                </form>
            </div>
            <!-- /.panel-body -->
        </div>

        <!-- /.panel -->
    </div>


</asp:Content>

