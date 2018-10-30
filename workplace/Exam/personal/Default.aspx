<%@ Page Title="" Language="C#" MasterPageFile="~/Exam/ExtMasterPerson.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Exam_personal_Default" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">最新考级</h1>
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
                                        <th class="col-xs-2">标题</th>
                                        <th class="col-xs-2">日期</th>
                                        <th class="col-xs-1">总名额</th>
                                        <th class="col-xs-1">剩余名额</th>
                                        <th class="col-xs-2">考试地点</th>
                                        <th class="col-xs-2">报名日期</th>
                                        <th class="col-xs-2"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptBind" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <th><%#Container.ItemIndex+1 %></th>
                                                <td><%#Eval("TestingTitle") %></td>
                                                <td><%#Eval("TestTimeAMStart") %></td>
                                                <td><%#Eval("TotalCount") %></td>
                                                <td><%# (int.Parse(Eval("TotalCount")+"")-GetBMCount( Eval("id")+"")) %></td>
                                                <td><%#Eval("Address") %></td>
                                                <td><%#Eval("TestTimePMStart") %>至<%#Eval("TestTimePMEnd") %></td>
                                                <td>
                                                    <%# GetActionLink(Eval("id")+"",Eval("TestTimePMStart")+"",Eval("TestTimePMEnd")+"",Eval("TestTimeAMStart")+"",Eval("TestTimeAMEnd")+"") %>                                                </td>
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
            </div>
        </div>
    </form>
</asp:Content>

