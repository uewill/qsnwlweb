<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="PicList.aspx.cs" Inherits="PicList" %>

<%@ Register Src="~/Controls/LeftNavControl.ascx" TagPrefix="uc1" TagName="LeftNavControl" %>
<%@ Register Src="~/Controls/LocationControl.ascx" TagPrefix="uc1" TagName="LocationControl" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="row" style="margin-bottom: 20px;">
        <div class="col-xs-12">
            <div class="col-xs-3">
                <uc1:LeftNavControl runat="server" ID="LeftNavControl" />
            </div>
            <div class="col-xs-9" style="padding-right: 0px;">
                <div class="col-md-12">
                    <uc1:LocationControl runat="server" ID="LocationControl" />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Repeater ID="rptDataList" runat="server">
                                <ItemTemplate>
                                    <div class="col-sm-6 col-md-4" style="margin-top: 10px;">
                                        <a href="ArticalDetails.aspx?id=<%#Eval("id") %>" target="_blank" title="<%#Eval("title") %>">
                                            <div class="thumbnail">
                                                <img src="/uploads/<%#Eval("imgPath") %>" style="height: 180px;" title="<%#Eval("title") %>">
                                                <div class="caption" style="overflow: hidden; height:120px;">
                                                    <h4 class=" text-center"><%#Eval("title") %></h4>
                                                    <p style='<%# GetVisable(Eval("description"))%>'><%# TFXK.Common.StrHelper.CutString(TFXK.Common.StrHelper.checkStr( Eval("description")+""),70) %></p>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="page">
                                <webdiyer:AspNetPager CssClass="paginator" CurrentPageButtonClass="cpb" ID="AspNetPager1"
                                    HorizontalAlign="Left" runat="server" AlwaysShow="false" FirstPageText="首页" Font-Size="12px"
                                    LastPageText="尾页" NextPageText="下一页" PageSize="12" PrevPageText="上一页" ShowBoxThreshold="11"
                                    TextAfterPageIndexBox="" TextBeforePageIndexBox="" UrlPaging="true" CustomInfoTextAlign="Right"
                                    ShowCustomInfoSection="Left" OnPageChanging="AspNetPager1_PageChanging">
                                </webdiyer:AspNetPager>
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
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="Server">
    <script>
        $(document).ready(function () {
            $("#<%=activeNav%>").addClass("active");
        });
    </script>
</asp:Content>

