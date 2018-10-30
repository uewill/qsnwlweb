<%@ Page Title="" Language="C#" MasterPageFile="~/Exam/ExtMasterPerson.master" AutoEventWireup="true" CodeFile="UpdateInfo.aspx.cs" Inherits="Exam_personal_UpdateInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">个人资料</h1>
        </div>
        <div class="col-md-12">
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <!-- /.panel-heading -->
                <form role="form" runat="server">
                    <div class="panel-body" id="panelAdd" runat="server">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>姓名</label>
                                       <input class="form-control" id="txtUserName" runat="server" required placeholder="姓名">
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label>性别 <span style="color: red">*</span></label>
                                    <p>
                                        <asp:DropDownList ID="ddlSex" CssClass="form-control " Width="120" runat="server">
                                            <asp:ListItem Text="男" Value="男"></asp:ListItem>
                                            <asp:ListItem Text="女" Value="女"></asp:ListItem>
                                        </asp:DropDownList>
                                    </p>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label>国籍 <span style="color: red">*</span></label>
                                    <p>
                                        <asp:DropDownList ID="ddlguoji" CssClass="form-control " Width="120" DataTextField="title" DataValueField="title" runat="server">
                                        </asp:DropDownList>
                                    </p>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label>民族 <span style="color: red">*</span></label>
                                    <p>
                                        <asp:DropDownList ID="ddlmingzu" CssClass="form-control " Width="120" DataTextField="title" DataValueField="title" runat="server">
                                        </asp:DropDownList>
                                    </p>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>姓名拼音 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtUserNamePy" runat="server" required placeholder="姓名拼音">
                                </div>
                            </div> 
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>身份证号 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtIDNumber" runat="server" required placeholder="身份证号码">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>手机号 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtPhoneNumber" runat="server" required placeholder="手机号">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>出生日期 <span style="color: red">*</span></label>
                                    <input class="form-control" id="txtBirthday" runat="server" placeholder="出生日期" onclick="WdatePicker()">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>考生所在地 <span style="color: red">*</span></label>
                                    <div class="form-inline">
                                        <div id="distpicker">
                                            <div class="form-group">
                                                <label class="sr-only" for="province1">Province</label>
                                                <select class="form-control" id="ddlprovice" onchange="setCity();" ></select>
                                            </div>
                                            <div class="form-group">
                                                <label class="sr-only" for="city1">City</label>
                                                <select class="form-control" id="ddlcity" onchange="setCity();"></select>
                                            </div>
                                            <div class="form-group">
                                                <label class="sr-only" for="district1">District</label>
                                                <select class="form-control" id="ddldistrict" onchange="setCity();"></select>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="margin-top: 10px;display:none;">
                                        <input class="form-control" id="txtContact" runat="server" required placeholder="当前所在地">
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel panel-danger">
                                    <div class="panel-heading">
                                        紧急联系人
                       
                                    </div>
                                    <!-- .panel-heading -->
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <label>紧急联系人 <span style="color: red">*</span></label>
                                                    <input class="form-control" id="txtjjcontact" runat="server" required placeholder="紧急联系人">
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <label>与考生关系 <span style="color: red">*</span></label>
                                                    <input class="form-control" id="txtjjship" runat="server" required placeholder="与考生关系">
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <label>联系电话 <span style="color: red">*</span></label>
                                                    <input class="form-control" id="txtjjphone" runat="server" required placeholder="联系电话">
                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <div class="form-group">
                                                    <label>通讯地址 <span style="color: red">*</span></label>
                                                    <input class="form-control" id="txtjjaddress" runat="server" required placeholder="通讯地址">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <button style="width: 120px;" id="btnSave" runat="server" onserverclick="btnSave_ServerClick" class="btn btn-success">保 存 </button>
                        </div>

                    </div>

                </form>
            </div>
            <!-- /.panel-body -->
        </div>

        <!-- /.panel -->
    </div>

    <script src="/Scripts/distpicker.data.js"></script>
    <script src="/Scripts/distpicker.js"></script>
    <script type="text/javascript">
        function setCity() {
            $("#ctl00_ContentPlaceHolder1_txtContact").val(  $("#ddlprovice").val()+"|"+  $("#ddlcity").val()+"|"+  $("#ddldistrict").val());
        }
        $(function () {
            'use strict';
           <%=currString%>
        });

    </script>
</asp:Content>

