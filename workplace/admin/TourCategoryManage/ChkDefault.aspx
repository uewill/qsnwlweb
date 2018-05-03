<%@ Page Language="C#" MasterPageFile="~/admin/MainPage/ItemMasterPage.master" AutoEventWireup="true"
    CodeFile="ChkDefault.aspx.cs" Inherits="admin_TourCategoryManage_ChkDefault"
    ValidateRequest="false" Title="Untitled Page" %>

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

    <script language='javascript' type='text/javascript'> 
function OnTreeNodeChecked() 
{ 
var getAllValue ="";
var getAllText ="";
 var tree = document.getElementById("ctl00_ContentPlaceHolder1_ASPxRoundPanel1_treeNav").getElementsByTagName("input");
    for (var i = 0; i < tree.length; i++) {
        if (tree[i].type == "checkbox" && tree[i].checked) {
              getAllValue+= $(tree[i]).val()+",";
              getAllText +=$(tree[i]).attr("title")+",";
        }
    }
    $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_lblSelName").html(getAllText);
    $("#ctl00_ContentPlaceHolder1_ASPxRoundPanel1_txtSelID").val(getAllValue);
} 

function dothis(obj){
   OnTreeNodeChecked();
}


    </script>

    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" ShowHeader="False" runat="server" Width="400px">
        <PanelCollection>
            <dxrp:PanelContent runat="server">
                <table style="height: 300px;">
                    <tr style="height: 40px;">
                        <td style="height: 40px;">
                            已选择：<asp:Label ID="lblSelName" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtSelID" runat="server"></asp:HiddenField>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 350px; vertical-align: top;">
                            <asp:TreeView ID="treeNav" runat="server" ExpandDepth="1" NodeIndent="10">
                            </asp:TreeView>
                        </td>
                    </tr>
                </table>
            </dxrp:PanelContent>
        </PanelCollection>
    </dxrp:ASPxRoundPanel>
</asp:Content>
