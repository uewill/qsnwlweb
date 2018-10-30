<%@ Page Language="C#" MasterPageFile="~/Exam/ExtMasterPerson.master" AutoEventWireup="true" CodeFile="TestingList.aspx.cs" Inherits="Exam_personal_TestingList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">报考记录</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <form runat="server">
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th style="width: 30px;"></th>
                                        <th class="col-xs-3">考级计划</th>
                                        <th class="col-xs-1">姓名</th>
                                        <th class="col-xs-1">考级专业</th>
                                        <th class="col-xs-1">报考等级</th>
                                        <th class="col-xs-1">已有最高等级</th>
                                        <th class="col-xs-1">支付状态</th>
                                        <th class="col-xs-2">报名时间</th>
                                        <th class="col-xs-1">操作</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptBind" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <th><%#Container.ItemIndex+1 %></th>
                                                <td><%#Eval("typeid") %></td>
                                                <td><%#Eval("UserName") %></td>
                                                <td><%#Eval("ClassID") %></td>
                                                <td><%#Eval("ClassLevel") %></td>
                                                <td><%#Eval("HaveMaxLevel") %></td>
                                                <td><%#GetStatusName(Eval("status")+"") %></td>
                                                <td><%#Eval("CreateTime") %></td>
                                              <td>
                                                  <%# GetActionLink(Eval("id")+"",Eval("status")+"") %>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>



                <webdiyer:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="AspNetPager1"
                    HorizontalAlign="Center" runat="server" AlwaysShow="true" FirstPageText="首页"
                    Font-Size="12px" LastPageText="尾页" NextPageText="下一页" PageSize="10" PrevPageText="上一页"
                    ShowBoxThreshold="11" TextAfterPageIndexBox="" TextBeforePageIndexBox="" UrlPaging="true"
                    OnPageChanging="AspNetPager1_PageChanging">
                </webdiyer:AspNetPager>

                <div class="row">
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

            <!-- /.col-lg-12 -->
        </div>
    </form>
    <!-- /.row -->
</asp:Content>

