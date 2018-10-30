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
    <div class="col-xs-12" style="border: solid 1px #CCC; margin-top: 10px; margin-bottom: 10px; padding-bottom: 10px;">
        <h3>联系我们</h3>
        <b style="font-size: 15px; line-height: 16px;">四川省成都市武侯区武侯大道双楠段389号交大易家616室</b>
        <div class="list-group leftnav" style="margin-top: 10px;">
            <table>
                <tr>
                    <td style="vertical-align: top; width: 40px;">
                        <img src="./images/call.png" /></td>
                    <td style="color: red; font-size: 18px; font-weight: bold;">028-83949120</br>
                        18982292333 (陈老师) </br>
                        17345865586 (郭老师)</br>
                        18280433301 (张老师)</td>
                </tr>

            </table>

        </div>
        <div class="col-xs-6" style="padding-right: 5px;"><a href="about.aspx?code=gywmitem" style="display: block; font-weight: bold; text-align: center; line-height: 14px; color: #FFF; padding: 10px; background-color: red">关于我们</a></div>
        <div class="col-xs-6" style="padding-left: 5px;"><a href="about.aspx?code=lxwm" style="display: block; font-weight: bold; text-align: center; line-height: 14px; color: #FFF; padding: 10px; background-color: red">联系我们</a></div>
    </div>
</div>


<div class="row">
    <div class="col-xs-12" style="padding: 0px; margin: 0px;">
        <asp:Repeater ID="rptAdList" runat="server">
            <ItemTemplate>
                <a href="<%#Eval("outLinkPath") %>" title="<%#Eval("title") %>" target="_blank">
                    <img src="/uploads/<%#Eval("imgPath") %>" title="<%#Eval("title") %>" class="img-responsive" style="margin-top: 10px" alt="Responsive image" />
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
