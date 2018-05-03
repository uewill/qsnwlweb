<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftNavControl.ascx.cs" Inherits="Controls_LeftNavControl" %>


<div class="row">
    <div class="col-xs-12" style="border: solid 1px #CCC;">
        <h2>
            <img src="images/wz.png" width="36" height="36">&nbsp;<%=navTitle %></h2>
        <div class="list-group leftnav">
            <asp:Repeater ID="rptNavList" runat="server">
                <ItemTemplate>
                    <a href="<%#GetItemURL(Eval("typeID")+"",Eval("codeNo")+"") %>" class="list-group-item leftnav<%#Eval("codeNo").ToString().Equals(navCode)?" active":"" %>"><%#Eval("Title") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>
</div>
<div class="row">
    <div class="col-xs-12" style="padding: 0px; margin: 0px;">
        <asp:Repeater ID="rptAdList" runat="server">
            <ItemTemplate>
                <a href="<%#Eval("outLinkPath") %>"  title="<%#Eval("title") %>"  target="_blank">
                    <img src="/uploads/<%#Eval("imgPath") %>" title="<%#Eval("title") %>" class="img-responsive" style="margin-top: 10px" alt="Responsive image" />
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
