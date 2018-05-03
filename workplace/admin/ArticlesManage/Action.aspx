<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Action.aspx.cs" Inherits="admin_ArticlesManage_Action" ValidateRequest="false"
    Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="Stylesheet" href="../js/uploadify.css" />

    <script type="text/javascript" src="../js/swfobject.js"></script>

    <script type="text/javascript" src="../js/jquery.uploadify.min.js"></script>

    <script type="text/javascript">
$(document).ready(function(){
$("#fileUpload").uploadify({
		'uploader'       : '../js/uploadify.swf',
		'script'         : '../ImageHadder/UploadHandler.ashx',
		'scriptData'     :{'imgPaths':$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_hdfImgPath").attr("value")},
		'cancelImg'      : '../js/cancel.png',
		'folder'         : '../../uploads',
		'fileDesc'       : '图片文件' , //出现在上传对话框中的文件类型描述 
        'fileExt'        : '*.jpg;*.bmp;*.png;*.gif',      //控制可上传文件的扩展名，启用本项时需同时声明fileDesc 
		'auto'           : true,
		'method'         :'GET',
		'multi'          : false,
		'onComplete': function(event,queueId, fileObj,response,data) {
		$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_newsImg").attr("src","../../uploads/"+response.toString());
		$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_newsImg").css("display","block");
		$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_hdfImgPath").attr("value",response.toString());
		//动态设置参数
		$("#fileUpload").uploadifySettings('scriptData',{'imgPaths':$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_hdfImgPath").attr("value")});
		}
	});
	$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtSource_I").focus(function (){
        if ($('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtSource_I').val() =='世纪年华艺术中心'){
        $('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtSource_I').val('');}
  });
  
  $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtSource_I").blur(function (){
      if($('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtSource_I').val()==''){
          $('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtSource_I').val('世纪年华艺术中心');
      }
  });
});


    </script>

    <script src="../../Kinde/kindeditor.js" type="text/javascript"></script>

    <script type="text/javascript">
KE.show({
    id : 'ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtContent',
    imageUploadJson : '../../Handler/uploadfile.ashx',
    fileManagerJson :' ../../Handler/Managefile_json.ashx',
    allowFileManager : true
});
    </script>

    <br />
    <input type="hidden" id="hdfAction" runat="server" />
    <input type="hidden" id="hdfPid" runat="server" />
    <input type="hidden" id="hdfTid" runat="server" />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="100%">
        <PanelCollection>
            <dxrp:PanelContent runat="server">
                <table class="category" width="100%" align="center" style="line-height: 25px;">
                    <tr>
                        <td style="width: 100px; text-align: right;">
                            标题：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtTitle" Width="300px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtTitle_ITip" style="width: 250px;
                                            display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            来源：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtSource" Text="世纪年华艺术中心" Width="150px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="Div1" style="width: 250px; display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            栏目：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlType" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtPass_ITip" style="width: 250px;
                                            display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            是否推荐：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlOutLink" Width="50" runat="server">
                                            <asp:ListItem Value="0" Text="否"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="是"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                   <td>
                                      
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                      <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            链接地址：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtOutLink" Width="200px" runat="server">
                                                    </dxe:ASPxTextBox>
                                    </td>
                                   <td>
                                      
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
                        <td style="width: 100px; text-align: right" valign="top">
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
                        <td style="width: 100px; text-align: right" valign="top">
                            内容：
                        </td>
                        <td style="text-align: left; margin: 0px; padding: 0px;">
                              <textarea id="txtContent" runat="server" style="height: 300px; width: 650px; visibility: hidden;"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            发布时间：
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxDateEdit ID="txtDate" runat="server">
                                        </dxe:ASPxDateEdit>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txt_pubDate_ITip" style="width: 250px;
                                            display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 48px;">
                            审核状态：
                        </td>
                        <td style="text-align: left; height: 48px;">
                            <asp:DropDownList ID="ddlState" runat="server">
                                <asp:ListItem Value="0" Text="未审核"></asp:ListItem>
                                <asp:ListItem Value="1" Selected="True" Text="已审核"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            点击次数：
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxSpinEdit ID="txtClick" runat="server" Height="21px" Number="0" AllowNull="False">
                                        </dxe:ASPxSpinEdit>
                                    </td>
                                    <td>
                                        <div id="Div2" style="width: 250px; display: inline;">
                                        </div>
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
                                        <dxe:ASPxSpinEdit ID="txtOrderby" runat="server" Height="21px" Number="0" MinValue="0" AllowNull="False">
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
                                        <dxe:ASPxButton ID="btnBack" runat="server" OnClick="btnBack_Click" Text="返 回" Width="63px">
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
      $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtTitle_I").formValidator({onshow:"请输入",onfocus:"不能为空",oncorrect:"合法"}).InputValidator({min:1,onerror:"不能为空,请确认"});
      
});
    </script>

</asp:Content>
