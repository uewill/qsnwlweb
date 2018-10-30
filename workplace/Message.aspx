<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="About" %>

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
                <div class="col-md-12" style="padding-right: 0px; margin-top: 20px;">
                    <div class="row" style="margin-bottom: 20px;">

                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-2 control-label">标题</label>
                                <div class="col-sm-10">
                                    <input type="text" required runat="server" class="form-control" id="txtTitle" style="max-width: 100%" placeholder="标题">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">内容</label>
                                <div class="col-sm-10">
                                    <textarea class="form-control" required runat="server" id="txtContent" style="max-width: 100%" rows="6" placeholder="请输入留言内容"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-2 control-label">联系人</label>
                                <div class="col-sm-10">
                                    <input type="text" required runat="server" class="form-control" id="txtUserName" style="max-width: 60%" placeholder="联系人姓名">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-2 control-label">联系方式</label>
                                <div class="col-sm-10">
                                    <input type="text" required runat="server" class="form-control" id="txtUserPhone" style="max-width: 60%" placeholder="电话/邮箱/QQ">
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <button type="button" runat="server" id="btnSubmit" style="width: 120px" onserverclick="btnSubmit_ServerClick" class="btn btn-default">提 交 </button>
                                </div>
                            </div>
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

