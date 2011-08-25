<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Log
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Activity Log</h2>
    <% if ((ViewData["Accesses"] as IQueryable<NCSIServ.Controllers.AccountController.AccessData>).Count() > 0)
       {%>
    Here is your activity log:
    <table>
    <% foreach (var access_data in (ViewData["Accesses"] as IQueryable<NCSIServ.Controllers.AccountController.AccessData>))
       { %>
    <tr><td><%=access_data.Address%></td><td><%=access_data.Time%></td></tr>
    <% } %>
    </table>
    <% }
       else
       { %>
       No log entries yet.  Did you install the <%=Html.ActionLink("registry file", "Registry", "Account", null, null) %>?
    <% } %>
</asp:Content>
