<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ArtItemMasterPage.master"
    AutoEventWireup="true" CodeFile="Action.aspx.cs" Inherits="admin_AdsManage_Action"
    ValidateRequest="false" Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="Stylesheet" href="../js/uploadify.css" />

    <script type="text/javascript" src="../js/swfobject.js"></script>

    <script type="text/javascript" src="../js/jquery.uploadify.min.js"></script>

    <script type="text/javascript">
$(document).ready(function(){
$("#fileUpload").uploadify({
		'uploader'       : '../js/uploadify.swf',
		'script'         : '../ImageHadder/UploadAdsHandler.ashx',
		'scriptData'     :{'imgPaths':$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_hdfImgPath").attr("value")},
		'cancelImg'      : '../js/cancel.png',
		'folder'         : '../../uploads',
		'fileDesc'       : '图片文件' , //出现在上传对话框中的文件类型描述 
        'fileExt'        : '*.jpg;*.bmp;*.png;*.gif',      //控制可上传文件的扩展名，启用本项时需同时声明fileDesc 
		'auto'           : true,
		'method'         :'GET',
		'multi'          : false,
		'onComplete': function(event,queueId, fileObj,response,data) {
		$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_newsImg").attr("src","../../uploads_thum/"+response.toString());
		$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_newsImg").css("display","block");
		$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_hdfImgPath").attr("value",response.toString());
		//动态设置参数
		//$("#fileUpload").uploadifySettings('scriptData',{'typeid':$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ddlPicArea").attr("value")});
		}
	});

});

    </script>

    <input type="hidden" id="hdfAction" runat="server" />
    <input type="hidden" id="hdfPid" runat="server" />
    <input type="hidden" id="hdfSaleNum" runat="server" />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="600px"
        Height="250px">
        <PanelCollection>
            <dxrp:PanelContent runat="server">
                <table class="category" width="100%" align="center" height="250px">
                    <tr>
                        <td style="width: 100px; text-align: right;">
                            标题：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtTitle" Width="250px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtTitle_ITip" style="width: 100px;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right">
                            位置：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlPicArea" runat="server">
                                            <asp:ListItem Text="全站导航下广告(1000*76/auto)" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="首页导航下广告(1000*76/auto)" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="首页左侧广告切换(245*224)" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="首页左侧公司简介下(247*94)" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="首页公司简介下右侧(740*94)" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="首页百科上面广告(247*94)" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="合作单位上面广告(740*94)" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="友情链接上广告(1000*96/auto)" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="产品中心右侧广告(247*auto)" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="蜀国布衣首页右侧(217*209)" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="首页右侧最新活动(247*94)" Value="10"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtPrice_ITip" style="width: 100px;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right">
                            链接地址：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtLinkUrl" runat="server" Width="250">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="Div1" style="width: 100px;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; vertical-align: top;">
                        </td>
                        <td>
                            <div style="float: left;">
                                <img id='newsImg' runat="server" width="100" height="80" style="border: dashed 1px #ccc;
                                    padding-left: 2px; display: none;" />
                                <input type="hidden" id="hdfImgPath" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right">
                            添加图片：
                        </td>
                        <td style="text-align: left;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td>
                                        <input type="file" id="fileUpload" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            排序编号：
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxSpinEdit ID="txtOrderby" runat="server" Height="21px" Number="0" MinValue="0"
                                            MaxValue="99999" AllowNull="False">
                                        </dxe:ASPxSpinEdit>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right">
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td style="width: 80px;">
                                        <dxe:ASPxButton ID="btnSave" runat="server" AutoPostBack="False" Text="确 定" OnClick="ibtnAdd_Click"
                                            Width="66px">
                                            <ClientSideEvents Click="function validate(s, e) {      
                                             e.processOnServer =  jQuery.formValidator.PageIsValid('1'); 
                           }    " />
                                        </dxe:ASPxButton>
                                    </td>
                                    <td style="width: 80px;">
                                        <dxe:ASPxButton ID="btnBack" runat="server" Text="返 回" Width="63px">
                                            <ClientSideEvents Click="function(){
                                        $.dialog.close();
                                        }" />
                                        </dxe:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </dxrp:PanelContent>
        </PanelCollection>
    </dxrp:ASPxRoundPanel>

    <script language="javascript" type="text/javascript">
$(document).ready(function(){
$.formValidator.initConfig({onError:function(msg){alert(msg)}});
      $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtTitle_I").formValidator({onshow:"请输入广告名称",onfocus:"不能为空",oncorrect:"合法"}).InputValidator({min:1,onerror:"不能为空,请确认"});
      

});
    </script>

</asp:Content>
