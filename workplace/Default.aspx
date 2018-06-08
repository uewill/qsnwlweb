<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    <div class="row" style="height: 320px;">
        <div class="col-md-4">
            <div id="carousel-example-captions" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators" style="bottom: 5px;">
                    <asp:Repeater ID="rptTuiJianNav" runat="server">
                        <ItemTemplate>
                            <li data-target="#carousel-example-captions" data-slide-to="<%#Container.ItemIndex%>" class="<%#Container.ItemIndex==0?"active":"" %>"></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ol>
                <div class="carousel-inner" role="listbox">
                    <asp:Repeater ID="rptTuiJian" runat="server">
                        <ItemTemplate>
                            <div class="item<%#Container.ItemIndex==0?" active":"" %>">
                                <img src="/uploads/<%#Eval("imgpath") %>" title="<%#Eval("title") %>" style="height: 320px;">
                                <div class="carousel-caption" style="padding-bottom: 10px;">
                                    <p><a style="color: #fff;" href="/articalDetails.aspx?id=<%#Eval("id") %>" target="_blank"><%# TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),40) %></a></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
                <a class="left carousel-control" href="#carousel-example-captions" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">上一条</span>
                </a>
                <a class="right carousel-control" href="#carousel-example-captions" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">下一条</span>
                </a>
            </div>

        </div>
        <div class="col-md-4">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <%-- <span class="moreright"><a href="/ArticalList.aspx?code=zxdt">更多</a></span>--%>
                <h4>最新动态</h4>
            </div>
            <div class="col-md-12" style="border-bottom: solid 1px #CCC; height: 280px; overflow: hidden;">
                <ul class="newsul">
                    <asp:Repeater ID="rptNewsList" runat="server">
                        <ItemTemplate>
                            <li><a href="/ArticalDetails.aspx?id=<%#Eval("id") %>" title="<%#Eval("title") %>" target="_blank"><%#GetFirstNews(Container.ItemIndex,TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),30))  %></a><span class="text-right"><%#Eval("createtime","{0:yyyy-MM-dd}") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="col-md-4" style="padding-left: 0px;">
            <a href="/Exam/Default.aspx"><img src="images/kaoji.jpg" style="padding: 0px 20px 10px 20px; height: 270px;" /></a>
            <div class="col-md-6">
                <a class="btn btn-success btn-lg" style="width: 100%;">成绩查询</a>
            </div>
            <div class="col-md-6">
                <a class="btn btn-default btn-lg" href="About.aspx?code=syzn" style="width: 100%;">使用指南</a>
            </div>

        </div>
    </div>
    <div class="row"  style="margin-top:10px;display:<%=isShowAd%>">
        <div class="col-md-12">
            <asp:Repeater ID="rptSYGG" runat="server">
                <ItemTemplate>
                    <a href="<%#Eval("outlinkpath") %>" target="_blank" style="padding-bottom:5px;" title="<%#Eval("title") %>">
                        <img src="/uploads/<%#Eval("imgPath") %>" class="img-responsive" title="<%#Eval("title") %>">
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div class="row" style="margin-top: 10px;">
        <div class="col-md-12">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <span class="moreright"><a href="/ArticalList.aspx?code=zpzs">更多</a></span>
                <h4>作品展示</h4>
            </div>
        </div>
        <div id="divZP" class="col-md-12" style="margin-top: 10px;">
            <asp:Repeater ID="rptZPZS" runat="server">
                <ItemTemplate>
                    <div class="col-md-2">
                        <a href="ArticalDetails.aspx?id=<%#Eval("id") %>" target="_blank" title="<%#Eval("title") %>">
                            <div class="thumbnail">
                                <img src="/uploads/<%#Eval("imgPath") %>" style="height: 200px;" title="<%#Eval("title") %>">
                                <div class="caption" style="overflow: hidden; height: 40px;">
                                    <h5 class=" text-center"><%#Eval("title") %></h5>
                                </div>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div class="row" style="margin-top: 10px;">
        <div class="col-md-6">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <span class="moreright"><a href="/ArticalList.aspx?code=xgwj">更多</a></span>
                <h4>相关文件</h4>
            </div>
            <div class="col-md-12" style="overflow: hidden;">
                <ul class="newsul">
                    <asp:Repeater ID="rptXGWJ" runat="server">
                        <ItemTemplate>
                            <li><a href="/ArticalDetails.aspx?id=<%#Eval("id") %>" title="<%#Eval("title") %>" target="_blank"><%#TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),50)  %></a><span class="text-right"><%#Eval("createtime","{0:yyyy-MM-dd}") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="col-md-6">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <span class="moreright"><a href="/ArticalList.aspx?code=kjbz">更多</a></span>
                <h4>考级标准</h4>
            </div>
            <div class="col-md-12" style="overflow: hidden;">
                <ul class="newsul">
                    <asp:Repeater ID="rptKJBZ" runat="server">
                        <ItemTemplate>
                            <li><a href="/ArticalDetails.aspx?id=<%#Eval("id") %>" title="<%#Eval("title") %>" target="_blank"><%#TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),50)  %></a><span class="text-right"><%#Eval("createtime","{0:yyyy-MM-dd}") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>



    <%--    <div class="row" style="margin-top: 10px;">
        <div class="col-md-8">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <span class="moreright"><a href="/ArticalList.aspx?code=yskjzx">更多</a></span>
                <h4>考级资讯</h4>
            </div>
            <div class="col-md-12" style="overflow: hidden;">
                <ul class="newsul">
                    <asp:Repeater ID="rptKJZX" runat="server">
                        <ItemTemplate>
                            <li><a href="/ArticalDetails.aspx?id=<%#Eval("id") %>" title="<%#Eval("title") %>" target="_blank"><%#TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),50)  %></a><span class="text-right"><%#Eval("createtime","{0:yyyy-MM-dd}") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="col-md-4">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <h4>艺术考级</h4>
            </div>
            <div class="col-md-12">
                <asp:Repeater ID="rptYSKJ" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6" style="margin-top: 10px;">
                            <div class="thumbnail">
                                <a href="ArticalDetails.aspx?id=<%#Eval("id") %>" target="_blank" title="<%#Eval("title") %>">
                                    <img src="/uploads/<%#Eval("imgPath") %>" class="img-responsive" title="<%#Eval("title") %>">
                                </a>
                            </div>
                        </div>


                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>--%>

    <div class="row" style="margin-top: 10px; margin-bottom: 20px;">
        <div class="col-md-12">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <h4>友情链接</h4>
            </div>
            <div class="col-md-12 linklist">
                <ul>
                    <asp:Repeater ID="rptLink" runat="server">
                        <ItemTemplate>
                            <li><a href="<%#Eval("linkurl") %>" target="_blank"><%#Eval("title") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="Server">
    <script src="https://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <%--    <link rel="stylesheet" href="content/liMarquee.css">
    <script src="/scripts/jquery.liMarquee.js"></script>--%>

    <script>
        $(document).ready(function () {
            $("#navHome").addClass("active");
            //$('#divZP').liMarquee();
        });
    </script>
</asp:Content>

