<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LocationControl.ascx.cs" Inherits="Controls_LocationControl" %>
<div class="row">
    <div class="col-md-12" style="border-bottom: solid 1px #CCC;">
        <div style="float: right; display: inline">
            <ol class="breadcrumb" style="background: none; border: none;">
                <li><a href="/Default.aspx">首页</a></li>
                <%if (parentCategory != null)
                    { %>
                <li class="active"><%=parentCategory.title %></li>
                <%} %>

                <li class="active"><%=currentCategory.title %></li>
            </ol>
        </div>
        <h3><%=currentCategory.title %></h3>
    </div>
</div>
