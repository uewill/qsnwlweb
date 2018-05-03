<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="ArticalList.aspx.cs" Inherits="ArticalList" %>

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
                            <ul class="newsul">
                                <asp:Repeater ID="rptDataList" runat="server">
                                    <ItemTemplate>
                                        <li><a href="/articalDetails.aspx?id=<%#Eval("id") %>" target="_blank"><%#Eval("title") %></a><span class="text-right"><%#Eval("createtime","{0:yyyy-MM-dd}") %></span></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="page">
                                <webdiyer:AspNetPager CssClass="paginator" CurrentPageButtonClass="cpb" ID="AspNetPager1"
                                    HorizontalAlign="Left" runat="server" AlwaysShow="false" FirstPageText="首页" Font-Size="12px"
                                    LastPageText="尾页" NextPageText="下一页" PageSize="20" PrevPageText="上一页" ShowBoxThreshold="11"
                                    TextAfterPageIndexBox="" TextBeforePageIndexBox="" UrlPaging="true" CustomInfoTextAlign="Right"
                                    ShowCustomInfoSection="Left" OnPageChanging="AspNetPager1_PageChanging">
                                </webdiyer:AspNetPager>
                            </div>
                        </div>
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

