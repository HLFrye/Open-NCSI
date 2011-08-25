<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Account Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Account Toolbox</h2>
    <ul>
    <li><%= Html.ActionLink("View Activity Log", "Log", "Account", null, null) %></li>
    <li><%=Html.ActionLink("Delete Activity Log", "Delete", "Account", null, null) %></li>
    <li><%=Html.ActionLink("Download registry file", "Registry", "Account", null, null) %></li>
    </ul>
</asp:Content>
