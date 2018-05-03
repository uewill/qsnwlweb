<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Action.aspx.cs" Inherits="admin_ProductsManage_Action" ValidateRequest="false"
    Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%-- dxtable--%>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dxw" %>
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
	$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtBrandName_I").focus(function (){
	if( $('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtBrandName_I').val()=='严氏制衣'){
        $('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtBrandName_I').val('');}
  });
  
  $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtBrandName_I").blur(function (){
      if($('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtBrandName_I').val()==''){
        $('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtBrandName_I').val('严氏制衣');
      }
  });
  
  	$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtDanwei_I").focus(function (){
	if( $('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtDanwei_I').val()=='件'){
        $('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtDanwei_I').val('');}
  });
  
  $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtDanwei_I").blur(function (){
      if($('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtDanwei_I').val()==''){
        $('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtDanwei_I').val('件');
      }
  });
  
});


    </script>

    <script src="../../Kinde/kindeditor.js" type="text/javascript"></script>

    <script type="text/javascript">
KE.show({
    id : 'ctl00_ContentPlaceHolder1_ASPxRoundPanel1_carTabPage_txtCpmsDes',
    imageUploadJson : '../../Handler/uploadfile.ashx',
    fileManagerJson :' ../../Handler/Managefile_json.ashx',
    allowFileManager : true
});

KE.show({
    id : 'ctl00_ContentPlaceHolder1_ASPxRoundPanel1_carTabPage_txtFzccDes',
    imageUploadJson : '../../Handler/uploadfile.ashx',
    fileManagerJson :' ../../Handler/Managefile_json.ashx',
    allowFileManager : true
});

KE.show({
    id : 'ctl00_ContentPlaceHolder1_ASPxRoundPanel1_carTabPage_txtXdbyDes',
    imageUploadJson : '../../Handler/uploadfile.ashx',
    fileManagerJson :' ../../Handler/Managefile_json.ashx',
    allowFileManager : true
});

KE.show({
    id : 'ctl00_ContentPlaceHolder1_ASPxRoundPanel1_carTabPage_txtSHfwDes',
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
                            产品名称：
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
                            产品编号：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtCode" Width="300px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtCode_ITip" style="width: 250px;
                                            display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            品牌：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtBrandName" Text="严氏制衣" Width="300px" runat="server">
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
                            单位：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtDanwei" Text="件" Width="300px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="Div3" style="width: 250px; display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            市场价：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtSalePrice" Font-Bold="true" Font-Size="Large" ForeColor="Blue"
                                            Text="0" Width="300px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="Div4" style="width: 250px; display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            会员价：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtCusPrice" Font-Bold="true" Font-Size="Large" ForeColor="Red"
                                            Text="0" Width="300px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="Div5" style="width: 250px; display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            面料成分：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtMianliao" Width="300px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="Div6" style="width: 250px; display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            色系：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtColorName" Width="300px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="Div7" style="width: 250px; display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            备注：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtDescription" Width="300px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="Div8" style="width: 250px; display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            产品类别：
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
                            产品属性：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList ID="chkBoxListExt" RepeatDirection="Horizontal" runat="server">
                                        </asp:CheckBoxList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">
                            推荐热门：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkTuiJian" runat="server" runat="server" />推荐
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkIsHot" runat="server" runat="server" />热门
                                    </td>
                                      <td>
                                        <asp:CheckBox ID="chkIsCX" runat="server" runat="server" />促销
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
                            描述设置：
                        </td>
                        <td style="text-align: left;" class="editTab">
                            <dxtc:ASPxPageControl ID="carTabPage" runat="server" ActiveTabIndex="0" EnableHierarchyRecreation="True">
                                <TabPages>
                                    <dxtc:TabPage Text="产品描述">
                                        <ContentCollection>
                                            <dxw:ContentControl ID="ContentControl1" runat="server">
                                                <textarea id="txtCpmsDes" runat="server" style="height: 300px; width: 650px; visibility: hidden;"></textarea>
                                            </dxw:ContentControl>
                                        </ContentCollection>
                                    </dxtc:TabPage>
                                    <dxtc:TabPage Text="服装尺寸">
                                        <ContentCollection>
                                            <dxw:ContentControl ID="ContentControl2" runat="server">
                                                <textarea id="txtFzccDes" runat="server" style="height: 300px; width: 650px; visibility: hidden;"></textarea>
                                            </dxw:ContentControl>
                                        </ContentCollection>
                                    </dxtc:TabPage>
                                    <dxtc:TabPage Text="洗涤保养">
                                        <ContentCollection>
                                            <dxw:ContentControl ID="ContentControl3" runat="server">
                                                <textarea id="txtXdbyDes" runat="server" style="height: 300px; width: 650px; visibility: hidden;"></textarea>
                                            </dxw:ContentControl>
                                        </ContentCollection>
                                    </dxtc:TabPage>
                                    <dxtc:TabPage Text="售后服务">
                                        <ContentCollection>
                                            <dxw:ContentControl ID="ContentControl4" runat="server">
                                                <textarea id="txtSHfwDes" runat="server" style="height: 300px; width: 650px; visibility: hidden;"></textarea>
                                            </dxw:ContentControl>
                                        </ContentCollection>
                                    </dxtc:TabPage>
                                </TabPages>
                            </dxtc:ASPxPageControl>
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
                                        <dxe:ASPxSpinEdit ID="txtOrderby" runat="server" Height="21px" Number="0" MinValue="0"
                                            AllowNull="False">
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
    $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtCode_I").formValidator({onshow:"请输入产品编码",onfocus:"不能为空",oncorrect:"合法"}).InputValidator({min:1,onerror:"不能为空,请确认"});
});
    </script>

</asp:Content>
