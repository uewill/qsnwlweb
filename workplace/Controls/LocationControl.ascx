﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LocationControl.ascx.cs" Inherits="Controls_LocationControl" %>
<div class="row">
    <div class="col-xs-12" style="border-bottom: solid 1px #CCC;">
        <div class="col-xs-6">
            <h3><%=currentCategory.title %></h3>
        </div>
        <div class="col-xs-6" style="margin-top: 15px;">

            <div style="float: right; display: inline">
                <ol class="breadcrumb" style="background: none; border: none; margin-bottom: 10px;">
                    <li><a href="/Default.aspx">首页</a></li>
                    <%if (parentCategory != null)
                        { %>
                    <li><%= GetParentLink() %></li>
                    <%} %>

                    <li class="active"><%=currentCategory.title %></li>
                </ol>
            </div>
        </div>
    </div>
</div>
