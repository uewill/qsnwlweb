<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="admin_CategoryManage_Default" ValidateRequest="false"
    Title="Untitled Page" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="Stylesheet" href="../js/uploadify.css" />

    <script type="text/javascript" src="../js/swfobject.js"></script>

    <script type="text/javascript" src="../js/jquery.uploadify.min.js"></script>

    <script type="text/javascript">
$(document).ready(function(){
$("#fileUpload").uploadify({
		'uploader'       : '../js/uploadify.swf',
		'script'         : '../ImageHadder/UploadHandler.ashx',
		'scriptData'     :{'imgPaths':$("#ctl00_ContentPlaceHolder1_hdfImg").attr("value")},
		'cancelImg'      : '../js/cancel.png',
		'folder'         : '../../uploads',
		'fileDesc'       : '图片文件' , //出现在上传对话框中的文件类型描述 
        'fileExt'        : '*.jpg;*.bmp;*.png;*.gif',      //控制可上传文件的扩展名，启用本项时需同时声明fileDesc 
		'auto'           : true,
		'method'         :'GET',
		'multi'          : false,
		'onComplete': function(event,queueId, fileObj,response,data) {
		$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_newsImg").attr("src","../../uploads/"+response.toString());
		$("#ctl00_ContentPlaceHolder1_hdfImg").attr("value",response.toString());
		$("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_newsImg").css("display","block");
		//动态设置参数
		$("#fileUpload").uploadifySettings('scriptData',{'imgPaths':$("#ctl00_ContentPlaceHolder1_hdfImg").attr("value")});
		}
	});
});


    </script>

    <input type="hidden" runat="server" id="hdfnodeID" />
    <input type="hidden" runat="server" id="hdfparentID" />
    <input type="hidden" runat="server" id="hdforderID" />
    <input type="hidden" runat="server" id="hdfImg" />   
     <input type="hidden" runat="server" id="hdfDes" />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="100%">
        <PanelCollection>
            <dxrp:PanelContent runat="server">
                <table style="height: 400px;">
                    <tr>
                        <td valign="top" style="width: 350px; vertical-align: top;">
                            <dxrp:ASPxRoundPanel ID="ASPxRoundPanel3" HeaderText="树形分类" runat="server" Width="100%"
                                Height="400px">
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
                                Width="600px" Height="400px">
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
                                                    栏目类型：
                                                </td>
                                                <td colspan="4" style="height: 34px">
                                                    <dxe:ASPxRadioButtonList RepeatDirection="Horizontal" SelectedIndex="0" runat="server"
                                                        ID="rbtType" ClientInstanceName="rbtTypec" Width="337px">
                                                        <Items>
                                                            <dxe:ListEditItem Text="单页介绍" Value="0" />
                                                            <dxe:ListEditItem Text="文章列表" Value="1" />
                                                            <dxe:ListEditItem Text="图片展示" Value="2" />
                                                          <%--  <dxe:ListEditItem Text="栏目外链" Value="3" />--%>
                                                        </Items>
                                                        <ClientSideEvents SelectedIndexChanged="function(s,e){
                                                        var index = rbtTypec.GetValue();
                                                        if(index==3){
                                                         document.getElementById('ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_divLink').style.display ='block';
                                                        }else{
                                                        document.getElementById('ctl00_ContentPlaceHolder1_ASPxRoundPanel1_ASPxRoundPanel2_divLink').style.display ='none';
                                                        }
                                                        }" />
                                                    </dxe:ASPxRadioButtonList>
                                                    <table id="divLink" runat="server">
                                                        <tr>
                                                            <td>
                                                                链接地址：
                                                            </td>
                                                            <td>
                                                                <dxe:ASPxTextBox ID="txtLink" runat="server" Width="274px">
                                                                </dxe:ASPxTextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="height: 34px" colspan="2">
                                                    仅对展示栏目有效
                                                </td>
                                                <td style="height: 34px">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 124px">
                                                    栏目图片：
                                                </td>
                                                <td colspan="7">
                                                    <img id='newsImg' runat="server" width="100" height="80" style="border: dashed 1px #ccc;
                                                        padding-left: 2px; display: none;" />
                                                    <input type="file" id="fileUpload" />
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
