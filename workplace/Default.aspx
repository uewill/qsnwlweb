<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    <div class="row">
        <div class="col-md-7">
            <div id="carousel-example-captions" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
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
                                <img src="/uploads/<%#Eval("imgpath") %>" title="<%#Eval("title") %>" style="width: 680px; height: 380px;">
                                <div class="carousel-caption">
                                    <p><a style="color: #fff;" href="/articalDetails.aspx?id=<%#Eval("id") %>" target="_blank"><%# TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),70) %></a></p>
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
        <div class="col-md-5" style="padding-left: 0px;">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <span class="moreright"><a href="/ArticalList.aspx?code=zxdt">更多</a></span>
                <h3>新闻资讯</h3>
            </div>
            <div class="col-md-12" style="height: 340px; overflow: hidden;">
                <ul class="newsul">
                    <asp:Repeater ID="rptNewsList" runat="server">
                        <ItemTemplate>
                            <li><a href="/ArticalDetails.aspx?id=<%#Eval("id") %>" title="<%#Eval("title") %>" target="_blank"><%#TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),40)  %></a><span class="text-right"><%#Eval("createtime","{0:yyyy-MM-dd}") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>


    <div class="row" style="margin-top: 10px;">
        <div class="col-md-6">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <span class="moreright"><a href="/ArticalList.aspx?code=pxdt">更多</a></span>
                <h3>培训动态</h3>
            </div>
            <div class="col-md-12" style="overflow: hidden;">
                <ul class="newsul">
                    <asp:Repeater ID="rptPXZX" runat="server">
                        <ItemTemplate>
                            <li><a href="/ArticalDetails.aspx?id=<%#Eval("id") %>" title="<%#Eval("title") %>" target="_blank"><%#TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),50)  %></a><span class="text-right"><%#Eval("createtime","{0:yyyy-MM-dd}") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="col-md-6">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <span class="moreright"><a href="/ArticalList.aspx?code=hdzt">更多</a></span>
                <h3>活动专题</h3>
            </div>
            <div class="col-md-12" style="overflow: hidden;">
                <ul class="newsul">
                    <asp:Repeater ID="rptHDZT" runat="server">
                        <ItemTemplate>
                            <li><a href="/ArticalDetails.aspx?id=<%#Eval("id") %>" title="<%#Eval("title") %>" target="_blank"><%#TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),50)  %></a><span class="text-right"><%#Eval("createtime","{0:yyyy-MM-dd}") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <h3>艺术培训</h3>
            </div>
        </div>
        <div class="col-md-12" style="margin-top: 10px;">

            <asp:Repeater ID="rptYSPX" runat="server">
                <ItemTemplate>
                    <div class="cscol-md-1-5">
                        <a href="ArticalDetails.aspx?id=<%#Eval("id") %>" target="_blank" title="<%#Eval("title") %>">
                            <div class="thumbnail">
                                <img src="/uploads/<%#Eval("imgPath") %>" style="height: 180px;" title="<%#Eval("title") %>">
                                <div class="caption" style="overflow: hidden; height: 120px;">
                                    <h4 class=" text-center"><%#Eval("title") %></h4>
                                    <p><%# TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("description")+""),70) %></p>
                                </div>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div class="row" style="margin-top: 10px;">
        <div class="col-md-8">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <span class="moreright"><a href="/ArticalList.aspx?code=yskjzx">更多</a></span>
                <h3>考级资讯</h3>
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
                <h3>艺术考级</h3>
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
    </div>

    <div class="row" style="margin-top: 10px;">
        <div class="col-md-6">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <span class="moreright"><a href="/ArticalList.aspx?code=skzxdt">更多</a></span>
                <h3>三宽家长学校动态</h3>
            </div>
            <div class="col-md-12" style="overflow: hidden;">
                <ul class="newsul">
                    <asp:Repeater ID="rptSKZXDT" runat="server">
                        <ItemTemplate>
                            <li><a href="/ArticalDetails.aspx?id=<%#Eval("id") %>" title="<%#Eval("title") %>" target="_blank"><%#TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),50)  %></a><span class="text-right"><%#Eval("createtime","{0:yyyy-MM-dd}") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="col-md-6">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <h3>三宽家长学校简介</h3>
            </div>
            <div class="col-md-12">
                <img src="<%=skimg %>" align="left" hspace="8" vspace="10" width="200" />
                <div style="padding-top: 10px;"><%=TFXK.Common.StrHelper.CutString(skdes,500)  %></div>


            </div>
        </div>
    </div>

    <div class="row" style="margin-top: 10px;">
        <div class="col-md-12">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC; margin-bottom: 10px;">
                <span class="moreright"><a href="/PicList.aspx?code=zxxq">更多</a></span>
                <h3>中心校区</h3>
            </div>

            <asp:Repeater ID="rptZXXQ" runat="server">
                <ItemTemplate>
                    <div class="col-md-3">
                        <a href="ArticalDetails.aspx?id=<%#Eval("id") %>" target="_blank" title="<%#Eval("title") %>">
                            <div class="thumbnail">
                                <img src="/uploads/<%#Eval("imgPath") %>" style="height: 180px;" title="<%#Eval("title") %>">
                                <div class="caption" style="overflow: hidden; height: 120px;">
                                    <h4 class=" text-center"><%#Eval("title") %></h4>
                                    <p><%# TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("description")+""),70) %></p>
                                </div>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div class="row" style="margin-top: 10px;">
        <div class="col-md-12">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC; margin-bottom: 10px;">
                <h3>关联单位</h3>
            </div>

            <asp:Repeater ID="rptGLDW" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <p>
                            <img src="/uploads/<%#Eval("imgPath") %>" style="height: 100px;" class="img-responsive" alt="<%#Eval("title") %>">
                        </p>
                        <h3><%#Eval("title") %></h3>
                        <p>
                            <%# TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("description")+""),180) %>
                        </p>
                    </div>
                </ItemTemplate>

            </asp:Repeater>

        </div>
    </div>
    <div class="row" style="margin-top: 10px; margin-bottom: 20px;">
        <div class="col-md-12">
            <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
                <h3>友情链接</h3>
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
    <script>
        $(document).ready(function () {
            $("#navHome").addClass("active");
        });
    </script>
</asp:Content>

