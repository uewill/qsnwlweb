<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="ArticalDetails.aspx.cs" Inherits="ArticalDetails" %>

<%@ Register Src="~/Controls/LeftNavControl.ascx" TagPrefix="uc1" TagName="LeftNavControl" %>
<%@ Register Src="~/Controls/LocationControl.ascx" TagPrefix="uc1" TagName="LocationControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="row" style="margin-bottom: 20px;">
        <div class="col-xs-12">
            <div class="col-xs-3">
                <uc1:LeftNavControl runat="server" ID="LeftNavControl" />
            </div>
            <div class="col-xs-9" style="padding-right: 0px;">
                <div class="col-md-12" style="padding-right: 0px;">
                    <uc1:LocationControl runat="server" ID="LocationControl" />
                </div>
                <div class="col-md-12">
                    <div class="row" style="clear: both; margin-top:15px; margin-bottom:10px;">
                        <div class="col-xs-12 text-center">
                            <h4><%=articles.title %></h4>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            发布时间：<%= articles.createTime.Value.ToString("yyyy-MM-dd")%>  来源：<%=articles.publisher %>
                        </div>
                    </div>

                    <%if (!string.IsNullOrEmpty(articles.imgPath))
                        {%>
                    <div class="row" style="margin-top:10px;">
                        <div class="col-xs-12 text-center">
                            <img src="/uploads/<%=articles.imgPath %>" style="margin:0 auto;" class="img-responsive" alt="<%=articles.title %>">
                        </div>
                    </div>
                    <%} %>

                    <div class="row">
                        <div class="col-xs-12 web-content">
                            <%=articles.description %>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 text-right" style="margin-top: 30px; margin-bottom: 30px; height: 30px;">
                    <!-- JiaThis Button BEGIN -->
                    <div class="jiathis_style_32x32" style="float: right;">
                        <a class="jiathis_button_qzone"></a>
                        <a class="jiathis_button_tsina"></a>
                        <a class="jiathis_button_weixin"></a>
                        <a class="jiathis_button_cqq"></a>
                        <a class="jiathis_button_copy"></a>
                        <a href="http://www.jiathis.com/share" class="jiathis jiathis_txt jtico jtico_jiathis" target="_blank"></a>
                    </div>
                    <script type="text/javascript" src="http://v3.jiathis.com/code_mini/jia.js" charset="utf-8"></script>
                    <!-- JiaThis Button END -->
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="Server">
    <script>
        $(document).ready(function () {
            $("#<%=activeNav%>").addClass("active");
        });
    </script>
</asp:Content>

