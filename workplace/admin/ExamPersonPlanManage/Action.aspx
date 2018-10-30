<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="Action.aspx.cs" Inherits="admin_ExamPersonPlanManage_Action " ValidateRequest="false"
    Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="JavaScript" type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>
    <script src="../../Kinde/kindeditor.js" type="text/javascript"></script>

    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtContent', {
                cssPath: '../../kinde/plugins/code/prettify.css',
                uploadJson: '../../kinde/asp.net/upload_json.ashx',
                fileManagerJson: '../../kinde/asp.net/file_manager_json.ashx',
                allowFileManager: true,
            });
        });

        function checkAll(id) {
            if ($("#chkAll" + id).attr("checked")) {
                $("input[tag='" + id + "']").attr("checked", true);
            } else {
                $("input[tag='" + id + "']").attr("checked", false);
            }
        }
    </script>

    <br />
    <input type="hidden" id="hdfAction" runat="server" />
    <input type="hidden" id="hdfPid" runat="server" />
    <input type="hidden" id="hdfTid" runat="server" />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="100%">
        <PanelCollection>
            <dxrp:PanelContent runat="server">
                <table width="100%" align="center" style="line-height: 25px;">
                    <tr>
                        <td style="width: 100px; text-align: right;">标题：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtTitle" Width="300px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>
                                        <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtTitle_ITip" style="width: 250px; display: inline;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px; vertical-align: top">考级专业：
                        </td>
                        <td style="text-align: left;">
                            <table style="border: solid 1px #CCC; padding: 0px; margin: 0px;" border="1" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="rptClass" runat="server">
                                    <ItemTemplate>
                                        <tr style="border: solid 1px #CCC;">
                                            <td style="width: 100px; height: 32px; font-weight: bold; text-align: right; border: solid 1px #CCC;"><%#Eval("title") %>：</td>
                                            <td style="height: 32px; border: solid 1px #CCC;">
                                                <label>
                                                    <input type="checkbox" id='chkAll<%#Eval("id") %>' onchange="checkAll(<%#Eval("id") %>)" title='全选' />全选</label>&nbsp;&nbsp;
                                                <asp:Repeater ID="rptCheckList" runat="server" DataSource='<%# GetSubClass(Eval("codeNo")+"") %>'>
                                                    <ItemTemplate>
                                                        <label>
                                                            <input type="checkbox" tag='<%#Eval("parentid") %>' id="chkSubClass" title='<%#Eval("title") %>' value='<%#Eval("id") %>' checked='<%# getSubChecked(Eval("id")) %>' runat="server" /><%#Eval("title") %></label>&nbsp;&nbsp;
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:Repeater>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">报考名额：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtTotalCount" Width="100px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">考号前缀：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtNumberPrefx" Width="100px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>（固定，如：CD0282018）</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">考号后缀：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtNumberEnd" Width="100px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td>（数字自增，如：000001）</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">报名时间：
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <input type="text" id="txtCheckStartTime" runat="server" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" />至
                                    </td>
                                    <td>
                                        <input type="text" id="txtCheckEndTime" runat="server" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">考试时间：
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <input type="text" id="txtStartTime" runat="server" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" />至
                                    </td>
                                    <td>
                                        <input type="text" id="txtEndTime" runat="server" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">考级地点：
                        </td>
                        <td style="text-align: left;">
                            <table>
                                <tr>
                                    <td>
                                        <dxe:ASPxTextBox ID="txtAddress" Width="400px" runat="server">
                                        </dxe:ASPxTextBox>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 100px; text-align: right" valign="top">备注：
                        </td>
                        <td style="text-align: left; margin: 0px; padding: 0px;">
                            <textarea id="txtContent" runat="server" style="height: 300px; width: 700px; visibility: hidden;"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 37px;">发布时间：
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <input type="text" id="txtCreateTime" runat="server" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" />
                                    </td>
                        </td>
                        <td>
                            <div id="ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txt_pubDate_ITip" style="width: 250px; display: inline;">
                            </div>
                        </td>
                    </tr>
                </table>
                </td>
                </tr>
                    <tr>
                        <td style="width: 100px; text-align: right; height: 48px;">审核状态：
                        </td>
                        <td style="text-align: left; height: 48px;">
                            <asp:DropDownList ID="ddlState" runat="server">
                                <asp:ListItem Value="0" Text="未审核"></asp:ListItem>
                                <asp:ListItem Value="1" Selected="True" Text="已审核"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                <tr>
                    <td style="width: 100px; text-align: right; height: 37px;">排序编号：
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <dxe:ASPxSpinEdit ID="txtOrderby" runat="server" Height="21px" Number="0" MinValue="0" AllowNull="False">
                                    </dxe:ASPxSpinEdit>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: right"></td>
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
        $(document).ready(function () {
            $.formValidator.initConfig({ onError: function (msg) { alert(msg) } });
            $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtTitle_I").formValidator({ onshow: "请输入", onfocus: "不能为空", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "不能为空,请确认" });

        });
    </script>

</asp:Content>
