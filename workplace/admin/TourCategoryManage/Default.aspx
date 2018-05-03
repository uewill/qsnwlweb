<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="admin_TourCategoryManage_Default" ValidateRequest="false"
    Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%-- dxtable--%>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dxw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="Stylesheet" href="../js/uploadify.css" />

    <script type="text/javascript" src="../js/swfobject.js"></script>

    <script type="text/javascript" src="../js/jquery.uploadify.min.js"></script>

    <script src="../../Kinde/kindeditor.js" type="text/javascript"></script>

    <script type="text/javascript">
KE.show({
    id : 'ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_carTabPage_txtContent',
    imageUploadJson : '../../Handler/uploadfile.ashx',
    fileManagerJson :' ../../Handler/Managefile_json.ashx',
     skinType: 'tinymce',
    cssPath : './index.css',
    allowFileManager : true
});
KE.show({
    id : 'ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_carTabPage_txtContent_wxts',
    imageUploadJson : '../../Handler/uploadfile.ashx',
    fileManagerJson :' ../../Handler/Managefile_json.ashx',
     skinType: 'tinymce',
    cssPath : './index.css',
    allowFileManager : true
});
KE.show({
    id : 'ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_carTabPage_txtContent_xqwd',
    imageUploadJson : '../../Handler/uploadfile.ashx',
    fileManagerJson :' ../../Handler/Managefile_json.ashx',
     skinType: 'tinymce',
    cssPath : './index.css',
    allowFileManager : true
});
KE.show({
    id : 'ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_carTabPage_txtContent_yjgl',
    imageUploadJson : '../../Handler/uploadfile.ashx',
    fileManagerJson :' ../../Handler/Managefile_json.ashx',
     skinType: 'tinymce',
    cssPath : './index.css',
    allowFileManager : true
});
    </script>

    <script type="text/javascript">
$(document).ready(function(){
var tourid =0;
var typeName = '<%=Request.QueryString["type"] %>';
if(typeName.length!=0){
 tourid =0;
}else{
  tourid =$("#ctl00_ContentPlaceHolder1_hdfnodeID").attr("value"); 
}
$("#fileUpload").uploadify({
		'uploader'       : '../js/uploadify.swf',
		'script'         : '../ImageHadder/UploadTourHandler.ashx',
		'scriptData'     :{'tourID':tourid,'typeID':1},
		'cancelImg'      : '../js/cancel.png',
		'folder'         : '../../uploads',
		'fileDesc'       : '图片文件' , //出现在上传对话框中的文件类型描述 
        'fileExt'        : '*.jpg;*.bmp;*.png;*.gif',      //控制可上传文件的扩展名，启用本项时需同时声明fileDesc 
		'auto'           : true,
		'method'         :'GET',
		'multi'          : false,
		'onComplete': function(event,queueId, fileObj,response,data) {
		  var res = response.toString().split('|');
		    $("#uploadImages").append(" <td id='img_"+res[0]+"'><img  src='../../uploads/"+res[1]+"' width=\"100\" height=\"80\" /><br /><a href='javascript:' onclick='DeleteTourImg("+res[0]+")'>删除</a></td>");	
	        $("#ctl00_ContentPlaceHolder1_hdfImg").attr("value",$("#ctl00_ContentPlaceHolder1_hdfImg").attr("value")+","+res[0]);
		}
	});
});

    function DeleteTourImg(obj){
        if(confirm("确认删除？")){
             $.ajax({
                 type: "POST",
                 url: "../imagehadder/ImgDelHand.ashx",
                 data: "id="+obj,
                 success: function(msg){     
                   $("#ctl00_ContentPlaceHolder1_hdfImg").attr("value", $("#ctl00_ContentPlaceHolder1_hdfImg").attr("value").replace(','+obj,''));
                   $("#img_"+obj).remove();
                },
                error:function(a,b,c){
                    alert("删除失败");
                }
            });  
        }
    }


    </script>

    <style>
        #uploadImages
        {
            border: dashed 1px #ccc;
            margin-bottom: 5px;
            padding-left: 2px;
        }
    </style>
    <input type="hidden" runat="server" id="hdfnodeID" />
    <input type="hidden" runat="server" id="hdfparentID" />
    <input type="hidden" runat="server" id="hdfImg" />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="100%">
        <PanelCollection>
            <dxrp:PanelContent runat="server">
                <table style="height: 400px;">
                    <tr>
                        <td valign="top" style="width: 350px; vertical-align: top;">
                            <dxrp:ASPxRoundPanel ID="ASPxRoundPanel3" HeaderText="树形分类" runat="server" Width="100%"
                                Height="240px">
                                <PanelCollection>
                                    <dxrp:PanelContent runat="server">
                                        <asp:TreeView ID="treeNav" runat="server" ExpandDepth="1" NodeIndent="10">
                                        </asp:TreeView>
                                    </dxrp:PanelContent>
                                </PanelCollection>
                            </dxrp:ASPxRoundPanel>
                        </td>
                        <td valign="top">
                            <dxrp:ASPxRoundPanel ID="ASPxRoundPanel2" HeaderText="操作 -- 当前节点" runat="server"
                                Width="720px" Height="400px">
                                <PanelCollection>
                                    <dxrp:PanelContent runat="server">
                                        <table>
                                            <tr>
                                                <td style="width: 124px; height: 47px">
                                                    <dxe:ASPxButton ID="btnAddOne" runat="server" Text="添加同级分类" OnClick="btnAddOne_Click"
                                                        Width="102px">
                                                    </dxe:ASPxButton>
                                                </td>
                                                <td style="height: 47px; width: 124px">
                                                    <dxe:ASPxButton ID="btnAddChild" runat="server" OnClick="btnAddChild_Click" Text="添加子级分类">
                                                    </dxe:ASPxButton>
                                                </td>
                                                <td style="width: 70px; height: 47px">
                                                    <dxe:ASPxButton ID="btnUp" runat="server" OnClick="btnUp_Click" Text="上移">
                                                    </dxe:ASPxButton>
                                                </td>
                                                <td style="height: 47px">
                                                    <dxe:ASPxButton ID="btnDown" runat="server" OnClick="btnDown_Click" Text="下移">
                                                    </dxe:ASPxButton>
                                                </td>
                                                <td style="height: 47px">
                                                    <dxe:ASPxButton ID="btnDelete" runat="server" CausesValidation="False" OnClick="btnDelete_Click"
                                                        Text="删除">
                                                        <ClientSideEvents Click="function(s,e) { e.processOnServer = confirm('确定删除?请确认没有存在引用!\r\n若存在则删除后引用页则可能无法正常显示！'); }" />
                                                    </dxe:ASPxButton>
                                                </td>
                                                <td style="height: 47px">
                                                    &nbsp;
                                                </td>
                                                <td style="height: 47px">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 124px">
                                                    分类标题：
                                                </td>
                                                <td colspan="6">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <dxe:ASPxTextBox ID="txtTitle" runat="server" Width="170px">
                                                                </dxe:ASPxTextBox>
                                                            </td>
                                                            <td>
                                                                <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_txtTitle_ITip">
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 34px; width: 124px;">
                                                    分类编码：
                                                </td>
                                                <td colspan="6" style="height: 34px">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <dxe:ASPxTextBox ID="txtCode" Enabled="false" runat="server" Width="170px">
                                                                </dxe:ASPxTextBox>
                                                            </td>
                                                            <td>
                                                                <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_txtCode_ITip">
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="height: 34px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 34px; width: 124px;">
                                                    是否推荐：
                                                </td>
                                                <td colspan="3" style="height: 34px">
                                                    <dxe:ASPxRadioButtonList RepeatDirection="Horizontal" SelectedIndex="0" runat="server"
                                                        ID="rbtType" ClientInstanceName="rbtTypec" Width="200px">
                                                        <Items>
                                                            <dxe:ListEditItem Text="否" Value="0" />
                                                            <dxe:ListEditItem Text="是" Value="1" />
                                                        </Items>
                                                    </dxe:ASPxRadioButtonList>
                                                </td>
                                                <td style="height: 34px; text-align: left;">
                                                    (仅对目的地有效)
                                                </td>
                                            </tr>
                                            <tr id="trImgList" runat="server">
                                                <td style="width: 124px">
                                                    已上传图片：
                                                </td>
                                                <td colspan="7" style="text-align: center">
                                                    <table>
                                                        <tr id="uploadImages">
                                                            <asp:Repeater ID="rptImgs" runat="server">
                                                                <ItemTemplate>
                                                                    <td id='img_<%#Eval("id") %>'>
                                                                        <img src='../../uploads/<%#Eval("imgPath") %>' width="100" height="80" /><br />
                                                                        <a href='javascript:' onclick='DeleteTourImg(<%#Eval("id") %>)'>删除</a>
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 124px">
                                                    栏目图片(3张)：
                                                </td>
                                                <td colspan="7">
                                                    <input type="file" id="fileUpload" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 124px" valign="top">
                                                    内容：
                                                </td>
                                                <td style="text-align: left; margin: 0px; padding: 0px;" colspan="6">
                                                    <dxtc:ASPxPageControl ID="carTabPage" runat="server" ActiveTabIndex="0" EnableHierarchyRecreation="True">
                                                        <TabPages>
                                                            <dxtc:TabPage Text="描述">
                                                                <ContentCollection>
                                                                    <dxw:ContentControl ID="ContentControl1" runat="server">
                                                                        <textarea id="txtContent" runat="server" style="height: 300px; width: 620px; visibility: hidden;"></textarea></dxw:ContentControl>
                                                                </ContentCollection>
                                                            </dxtc:TabPage>
                                                            <dxtc:TabPage Text="温馨提示">
                                                                <ContentCollection>
                                                                    <dxw:ContentControl ID="ContentControl2" runat="server">
                                                                        <textarea id="txtContent_wxts" runat="server" style="height: 300px; width: 620px;
                                                                            visibility: hidden;"></textarea>
                                                                    </dxw:ContentControl>
                                                                </ContentCollection>
                                                            </dxtc:TabPage>
                                                            <dxtc:TabPage Text="行前问答">
                                                                <ContentCollection>
                                                                    <dxw:ContentControl ID="ContentControl3" runat="server">
                                                                        <textarea id="txtContent_xqwd" runat="server" style="height: 300px; width: 620px;
                                                                            visibility: hidden;"></textarea>
                                                                    </dxw:ContentControl>
                                                                </ContentCollection>
                                                            </dxtc:TabPage>
                                                            <dxtc:TabPage Text="游记攻略">
                                                                <ContentCollection>
                                                                    <dxw:ContentControl ID="ContentControl4" runat="server">
                                                                        <textarea id="txtContent_yjgl" runat="server" style="height: 300px; width: 620px;
                                                                            visibility: hidden;"></textarea></dxw:ContentControl>
                                                                </ContentCollection>
                                                            </dxtc:TabPage>
                                                        </TabPages>
                                                    </dxtc:ASPxPageControl>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 124px;">
                                                    自助游链接：
                                                </td>
                                                <td colspan="2">
                                                    <dxe:ASPxTextBox ID="txtLinkUrl" Width="200" runat="server"></dxe:ASPxTextBox>
                                                </td>
                                                <td colspan="5">
                                                   若此景点包含自助游 请填写相应链接地址
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 124px;">
                                                    跟团游链接：
                                                </td>
                                                <td colspan="2">
                                                    <dxe:ASPxTextBox ID="txtGTLink" Width="200" runat="server"></dxe:ASPxTextBox>
                                                </td>
                                                <td colspan="5">
                                                   若此景点包含 跟团游 请填写相应链接地址
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 124px;">
                                                    游轮链接：
                                                </td>
                                                <td colspan="2">
                                                    <dxe:ASPxTextBox ID="txtYLLink" Width="200" runat="server"></dxe:ASPxTextBox>
                                                </td>
                                                <td colspan="5">
                                                   若此景点包含游轮 请填写相应链接地址
                                                </td>
                                            </tr>
                                              <tr>
                                                <td style="width: 124px;">
                                                    排序号：
                                                </td>
                                                <td colspan="2">
                                                    <dxe:ASPxTextBox ID="hdforderID" Width="200" runat="server"></dxe:ASPxTextBox>
                                                </td>
                                                <td colspan="5">
                                                   若此景点包含游轮 请填写相应链接地址
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td style="width: 124px;">
                                                    是否启用：
                                                </td>
                                                <td colspan="2">
                                                    <dxe:ASPxComboBox runat="server" SelectedIndex="1" ValueType="System.String" ID="ddlState">
                                                        <Items>
                                                            <dxe:ListEditItem Text="未启用" Value="0"></dxe:ListEditItem>
                                                            <dxe:ListEditItem Text="已启用" Value="1" Selected="True"></dxe:ListEditItem>
                                                        </Items>
                                                    </dxe:ASPxComboBox>
                                                </td>
                                                <td colspan="5">
                                                    若此分类状态为[已启用],则此栏目将在前台页面显示
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 124px">
                                                </td>
                                                <td colspan="7">
                                                    <dxe:ASPxButton ID="btnSave" runat="server" AutoPostBack="False" Text="确 定" OnClick="ibtnAdd_Click"
                                                        Width="66px">
                                                        <ClientSideEvents Click="function validate(s, e) {      
                                             e.processOnServer =  jQuery.formValidator.PageIsValid('1'); 
                           }    " />
                                                    </dxe:ASPxButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </dxrp:PanelContent>
                                </PanelCollection>
                            </dxrp:ASPxRoundPanel>
                        </td>
                    </tr>
                </table>
            </dxrp:PanelContent>
        </PanelCollection>
    </dxrp:ASPxRoundPanel>
    <asp:DropDownList ID="DropDownList1" Visible="false" runat="server">
    </asp:DropDownList>

    <script language="javascript" type="text/javascript">
$(document).ready(function(){
$.formValidator.initConfig({onError:function(msg){alert(msg)}});
     $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_txtTitle_I").formValidator({onshow:"请输入",onfocus:"不能为空",oncorrect:"合法"}).InputValidator({min:1,onerror:"不能为空,请确认"});
      $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_txtCode_I").formValidator({onshow:"网站唯一标识!请输入类别名字母缩写",onfocus:"标识不能为空,请输入类别名字母缩写",oncorrect:"合法"}).InputValidator({min:1,onerror:"不能为空,请确认"});
});
    </script>

</asp:Content>
