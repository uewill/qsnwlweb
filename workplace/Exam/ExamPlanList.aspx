<%@ Page Language="C#" MasterPageFile="~/Exam/ExtMaster.master" AutoEventWireup="true" CodeFile="ExamPlanList.aspx.cs" Inherits="Exam_ExamPlanList" %>

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
                    <div class="panel-heading">
                        考级状态：
                        <asp:DropDownList ID="ddlStatus" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" runat="server" AutoPostBack="true">
                            <asp:ListItem Text="全部" Value="-1" />
                            <asp:ListItem Text="待审核" Value="0" />
                            <asp:ListItem Text="已审核" Value="1" />
                            <asp:ListItem Text="已提交考生信息" Value="2" />
                            <asp:ListItem Text="已通知考试结果" Value="3" />
                        </asp:DropDownList>
                        通知状态：
                        <asp:DropDownList ID="ddlNoticeStatus" OnSelectedIndexChanged="ddlNoticeStatus_SelectedIndexChanged" runat="server" AutoPostBack="true">
                            <asp:ListItem Text="全部" Value="-1" />
                            <asp:ListItem Text="待确认" Value="0" />
                            <asp:ListItem Text="已确认" Value="1" />
                        </asp:DropDownList>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">


                        <div class="table-responsive">
                            <table class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th class="col-xs-1"></th>
                                        <th class="col-xs-4">考试时间</th>
                                        <th class="col-xs-1">状态</th>
                                        <th class="col-xs-2">创建时间</th>
                                        <th class="col-xs-2">审核时间</th>
                                        <th class="col-xs-2"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptBind" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <th><%#Container.ItemIndex+1 %></th>
                                                <td><%#Eval("TestingTime") %></td>
                                                <td><%#GetStatusName(Eval("status")+"") %></td>
                                                <td><%#Eval("CreateTime") %></td>
                                                <td><%#Eval("AuditTime") %></td>
                                                <td>
                                                    <a  class="btn btn-default btn-xs"href="ExamPlan.aspx?id=<%#Eval("id") %>">查看</a>
                                                    <a  class="btn btn-success btn-xs"href="ExamPlanStudent.aspx?id=<%#Eval("id") %>">报名信息</a>
                                                    <%--<a class="btn btn-default btn-xs" href="ExamPlan.aspx?id=<%#Eval("id") %>">领证确认</a>--%>
                                                       <asp:ImageButton ID="ibtnDel" CssClass="btn btn-default btn-xs" ImageUrl="../admin/images/del.gif" ToolTip="删除..." CommandName='<%# Eval("ID") %>' OnCommand="ibtnDel_OnCommand" OnClientClick="javascript:return confirm('您确定要删除吗');"
                                        runat="server" />
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
                    HorizontalAlign="Center" runat="server" AlwaysShow="false" FirstPageText="首页"
                    Font-Size="12px" LastPageText="尾页" NextPageText="下一页" PageSize="10" PrevPageText="上一页"
                    ShowBoxThreshold="11" TextAfterPageIndexBox="" TextBeforePageIndexBox="" UrlPaging="true"
                    OnPageChanging="AspNetPager1_PageChanging">
                </webdiyer:AspNetPager>

            </div>

            <!-- /.col-lg-12 -->
        </div>
    </form>
    <!-- /.row -->
</asp:Content>

