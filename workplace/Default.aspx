<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
   
     <style>
        h4 {
            /*font-weight: bold;
           margin-top: 5px;
            margin-bottom: 6px;*/
            color: #FFF;
        }

        #donate_carousel {
            height: 210px;
            overflow: hidden;
        }

        .donate_bar {
            list-style: none;
            margin-left: 5px;
            padding: 0;
            line-height: 50px;
        }

            .donate_bar li {
                list-style: none;
                list-style: none;
                margin: 0;
                padding: 0;
            }

            .donate_bar span {
                font-size: 8px;
                color: royalblue;
                margin-left: 0;
            }

            .donate_bar a {
                text-decoration: none;
                font-size: 14px;
                color: #666;
            }
    </style>
<%--        <div class="row" style="margin-bottom: 10px;">
        <div class="col-xs-4">
            <div class="navstack">
               <i class="icon iconfont icon-staff"></i>
                <div><a href="Exam/Login.aspx">登录系统</a></div>
            </div>
        </div>
        <div class="col-xs-4">
            <div class="navstack">
                <i class="icon iconfont icon-qiyeyuanquwuye-xianxing"></i>
                   <div><a href="ArticalList.aspx?code=kdml">考点查询</a></div>
            </div>
        </div>
        <div class="col-xs-4">
            <div class="navstack">
                <i class="icon iconfont icon-magnifier"></i>
                   <div><a href="http://139.129.220.45">成绩查询</a></div>
            </div>
        </div>
    </div>--%>

     <div class="row" style="margin-bottom: 10px; background-color: #f2f4f7">

        <div class="col-xs-4 text-center">
            <table style="width: 100%; height: 100px; vertical-align: central;">
                <tr>
                    <td style="text-align: right;">
                        <img src="Images/iconbmxt.png" width="50" />
                    </td>
                    <td style="text-align: left; font-size: 20px; font-family: 'Microsoft YaHei'; color: #434343; padding-left: 10px;">
                        <a class="navstacklink" href="/exam/personal/Register.aspx">考生报名系统 </a>
                    </td>
                </tr>
            </table>

        </div>


        <div class="col-xs-4 text-center">
            <table style="width: 100%; height: 100px; vertical-align: central;">
                <tr>
                    <td style="text-align: right;">
                        <img src="Images/iconzc.png" width="50" />
                    </td>
                    <td style="text-align: left; font-size: 20px; font-family: 'Microsoft YaHei'; color:#434343; padding-left: 10px;">
                        <a class="navstacklink" href="/exam/Regester.aspx">考点注册 </a>
                    </td>
                </tr>
            </table>

        </div>


        <div class="col-xs-4 text-center">
            <table style="width: 100%; height: 100px; vertical-align: central;">
                <tr>
                    <td style="text-align: right;">
                        <img src="Images/iconcjcx.png" width="50" />
                    </td>
                    <td style="text-align: left; font-size: 20px; font-family: 'Microsoft YaHei';padding-left: 10px;">
                        <a class="navstacklink" href="http://139.129.220.45">成绩查询 </a>
                    </td>
                </tr>
            </table>

        </div>
    </div>
   <div class="row">
        <div class="col-md-6" style="padding-right: 5px;">
            <div id="carousel-example-captions" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators" style="top: 2px; left: 80%; bottom: unset;">
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
                                <a style="color: #fff;" href="/articalDetails.aspx?id=<%#Eval("id") %>" target="_blank">
                                    <img src="/uploads/<%#Eval("imgpath") %>" title="<%#Eval("title") %>" style="overflow: hidden; height: 360px; width: 100%" /></a>
                                <div class="carousel-caption" style="width: 100%; left: 0px; bottom: 0px; padding-bottom: 0px; padding-top: 10px; padding-bottom: 0px; background: rgba(2,2,2,0.6)">
                                    <p><a style="color: #fff;" href="/articalDetails.aspx?id=<%#Eval("id") %>" target="_blank"><%# TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),60) %></a></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
                <a class="left carousel-control" href="#carousel-example-captions" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-menu-left" style="top: 50%;" aria-hidden="true"></span>
                    <span class="sr-only">上一条</span>
                </a>
                <a class="right carousel-control" href="#carousel-example-captions" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-menu-right" style="top: 50%;" aria-hidden="true"></span>
                    <span class="sr-only">下一条</span>
                </a>
            </div>
        </div>
        <div class="col-md-6" style="padding-left: 5px;">
                <div class="col-md-12" style="border-bottom: solid 1px #CCC; background-color:#D90110; padding-top: 5px;">
                <span class="moreright"><a href="/ArticalList.aspx?code=zxdt">更多</a></span>
                <h4>最新动态</h4>
            </div>
            <div class="col-md-12" style="border-bottom: solid 1px #CCC; height: 320px; overflow: hidden;">
                <ul class="newsul">
                    <asp:Repeater ID="rptNewsList" runat="server">
                        <ItemTemplate>
                            <li><a href="/ArticalDetails.aspx?id=<%#Eval("id") %>" title="<%#Eval("title") %>" target="_blank"><%#GetFirstNews(Container.ItemIndex,TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("title")+""),60))  %></a><span class="text-right"><%#Eval("createtime","{0:yyyy-MM-dd}") %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
     <%--   <div class="col-md-4" style="padding-left: 0px;">
            <a href="/Exam/Default.aspx"><img src="images/kaoji.jpg" style="padding: 0px 20px 10px 20px; height: 270px;" /></a>
            <div class="col-md-6">
                <a class="btn btn-success btn-lg" style="width: 100%;">成绩查询</a>
            </div>
            <div class="col-md-6">
                <a class="btn btn-default btn-lg" href="About.aspx?code=syzn" style="width: 100%;">使用指南</a>
            </div>

        </div>--%>
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
             <div class="col-md-12" style="border-bottom: solid 1px #CCC; background-color:#D90110; padding-top: 5px;">
                <span class="moreright"><a href="/PicList.aspx?code=zpzs">更多</a></span>
                <h4>作品展示</h4>
            </div>
        <div id="divZP" class="col-md-12" style="margin-top: 10px;">
            <asp:Repeater ID="rptZPZS" runat="server">
                <ItemTemplate>
                    <div class="col-md-3" style="overflow: hidden; display: block; padding-right:10px;padding-left:10px;">
                        <a href="ArticalDetails.aspx?id=<%#Eval("id") %>" class="thumbnaildiv" target="_blank" title="<%#Eval("title") %>">
                            <div class="thumbnail" style="overflow: hidden; padding: 0px;">
                                <img src="http://gmcdkj.com/uploads/<%#Eval("imgPath") %>" style="height: 240px;" title="<%#Eval("title") %>">
                            </div>

                            <div class="caption" style="overflow: hidden; width: 92.5%; position: absolute; bottom: 20px; margin-left: 1px; text-align: center; color: #FFF; background-color: rgba(2,2,2,0.6); height: 30px;">
                                <h5 class=" text-center"><%#Eval("title") %></h5>
                            </div>
                        </a>
                    </div>
                  <%--  <div class="col-md-2">
                        <a href="ArticalDetails.aspx?id=<%#Eval("id") %>" target="_blank" title="<%#Eval("title") %>">
                            <div class="thumbnail" style="padding:0px;">
                                <img src="/uploads/<%#Eval("imgPath") %>" style="height: 200px;" title="<%#Eval("title") %>">
                                <div class="caption" style="overflow: hidden; height: 60px;">
                                    <h5 class=" text-center"><%#Eval("title") %></h5>
                                </div>
                            </div>
                        </a>
                    </div>--%>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div class="row" style="margin-top: 10px;">
        <div class="col-md-6" style="padding-right:5px;">
             <div class="col-md-12" style="border-bottom: solid 1px #CCC; background-color:#D90110; padding-top: 5px;">
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
        <div class="col-md-6" style="padding-left:5px;">
                         <div class="col-md-12" style="border-bottom: solid 1px #CCC; background-color:#D90110; padding-top: 5px;">
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
              <div class="col-md-12" style="border-bottom: solid 1px #CCC; background-color:#D90110; padding-top: 5px;">
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

<%--      <div class="guide">
        <div id="divFllowus" class="divvisable">
            <img src="http://www.sckaoji.com/uploads/image/20180619/20180619233103_3580.jpg" width="240" height="240" />
        </div>
        <div class="guide-wrap">
            <a href="javascrip:void(0);" id="linkFllowus" class="top" title="关注我们"><span>
                <i class="icon iconfont icon-wechat"></i>关注我们</span></a>
            <a href="Exam/Login.aspx" class="edit" title="登录考区"><span>
                <i class="icon iconfont icon-yonghu-xianxing"></i>登录考区</span></a>
            <a href="http://www.artexamcn.com/article/detail/id/1233.shtml" class="find" title="查成绩"><span>
                <i class="icon iconfont icon-sousuo"></i>查询成绩</span></a>
            <a href="Message.aspx" class="report" title="留言"><span>
                <i class="icon iconfont icon-liaotianduihua-xianxing"></i>在线留言</span></a>
            <a href="javascript:window.scrollTo(0,0)" class="top" title="回顶部"><span>
                <i class="icon iconfont icon-huidingbu"></i>回到顶部</span></a>
        </div>
    </div>--%>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="Server">
    <script>
        $(document).ready(function () {
            $("#navHome").addClass("active");
        });
    </script>
</asp:Content>

