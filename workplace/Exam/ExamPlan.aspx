<%@ Page Title="" Language="C#" MasterPageFile="~/Exam/ExtMaster.master" AutoEventWireup="true" CodeFile="ExamPlan.aspx.cs" Inherits="Exam_ExamPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function setSetp(setp) {
            $("#ctl00_ContentPlaceHolder1_panelAdd").hide();
            $("#ctl00_ContentPlaceHolder1_panelAudit").hide();
            $("#ctl00_ContentPlaceHolder1_panelNotice").hide();
            $("#ctl00_ContentPlaceHolder1_panelPay").hide();
            $("#ctl00_ContentPlaceHolder1_panelGet").hide();

            $("#liSetpNavAdd").removeClass("active");
            $("#liSetpNavAudit").removeClass("active");
            $("#liSetpNavNotice").removeClass("active");
            $("#liSetpNavPay").removeClass("active");
            $("#liSetpNavGet").removeClass("active");
            if (setp == 1) {
                $("#liSetpNavAdd").addClass("active");
                $("#ctl00_ContentPlaceHolder1_panelAdd").show();
            } else if (setp == 2) {
                $("#liSetpNavAudit").addClass("active");
                $("#ctl00_ContentPlaceHolder1_panelAudit").show();
            } else if (setp == 3) {
                $("#liSetpNavNotice").addClass("active");
                $("#ctl00_ContentPlaceHolder1_panelNotice").show();
            }
             else if (setp == 4) {
                $("#liSetpNavPay").addClass("active");
                $("#ctl00_ContentPlaceHolder1_panelPay").show();
            }
             else if (setp == 5) {
                $("#liSetpNavGet").addClass("active");
                $("#ctl00_ContentPlaceHolder1_panelGet").show();
            }
        }
    </script>

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">报名安排</h1>
        </div>
        <div class="col-xs-12">
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <ul class="nav nav-tabs">
                        <li role="presentation" class="active" id="liSetpNavAdd"><a href="javascript:setSetp(1);">1、填写考级通知</a></li>
                        <li role="presentation" id="liSetpNavAudit"><a href="javascript:setSetp(2);">2、通知中</a></li>
                        <li role="presentation" id="liSetpNavNotice"><a href="javascript:setSetp(3);">3、安排通知</a></li>
                        <li role="presentation" id="liSetpNavPay"><a href="javascript:setSetp(4);">4、支付信息</a></li>
                        <li role="presentation" id="liSetpNavGet"><a href="javascript:setSetp(5);">5、领证通知</a></li>
                    </ul>
                </div>
                <!-- /.panel-heading -->
                <form role="form" runat="server">
                    <div class="panel-body" id="panelAdd" runat="server">
                        <div class="row">
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label>考点名称</label>
                                    <p class="form-control-static"><%=testCenterName %></p>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label>考试时间 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtTime" runat="server" required placeholder="考试时间">
                                    <p class="form-control-static" style="color: #777">例：2018年6月2日 星期六 上午9点至12点结束</p>
                                </div>
                            </div>
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label>考试科目 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtClass" runat="server" required placeholder="考试科目">
                                    <p class="form-control-static" style="color: #777">例：速写、素描、</p>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label>考试地点 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtAddress" runat="server" required placeholder="考试地点">
                                    <p class="form-control-static" style="color: #777">例：成都市武侯区xx路xx号xx室</p>
                                </div>
                            </div>
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label>乘车线路 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtRoad" runat="server" required placeholder="乘车线路">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label>联系信息 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtContact" runat="server" required placeholder="联系信息">
                                    <p class="form-control-static" style="color: #777">例：张老师  13882245337</p>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>其他备注</label>
                            <textarea class="form-control" id="txtDes" runat="server" rows="3"></textarea>
                        </div>
                        <div class="form-group">
                            <button style="width: 120px;" id="btnSave" runat="server" onserverclick="btnSave_ServerClick" class="btn btn-success">提交</button>
                        </div>

                    </div>

                    <div class="panel-body" id="panelAudit" runat="server">
                        <div class="row">
                            <div class="col-xs-12">
                                <%=auditMsg %>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body" id="panelNotice" runat="server">
                        <div class="row">
                            <div class="col-xs-12">
                                <%=noticeMsg %>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body" id="panelPay" runat="server">
                        <div class="row">
                            <div class="col-xs-12">
                                <%=payMsg %>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body" id="panelGet" runat="server">
                        <div class="row">
                            <div class="col-xs-12">
                                <%=getMsg %>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
            <!-- /.panel-body -->
        </div>

        <!-- /.panel -->
    </div>


</asp:Content>

