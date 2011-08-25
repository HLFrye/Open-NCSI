<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Open-NCSI.com - Track your Windows 7 computer without any additional software!
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome!</h2>
    <p>
        Have you ever wondered how Windows 7 knows if you're connected to the internet or not?  It has a built in tool called the Network Connectivity Status Indicator service, which automatically connects to a site Microsoft runs when you first connect to a network.  Determining whether or not your computer can access this site is how Windows determine if you're connected to a local network, or a network with full internet connectivity.  Though this may sound like "phoning home", there's no real privacy loss here; the only information Microsoft could glean from this tool is that a Windows 7 based machine has connected to the internet at a given ip address. 
    </p><p>
        This tool is not hardcoded to connect to Microsoft's servers, however.  Registry values control which server it connects to, which file it will attempt to request from that service, and what the expected response is, and many other settings for this service.  Read more about it at <a href="http://blog.superuser.com/2011/05/16/windows-7-network-awareness/">this fantastic blog post.</a>  Since this service starts automatically, and will attempt to connect to the service as soon as networking is established, it occurred to me that this could be a fantastic tool for laptop tracking and/or theft detection.  While an IP address may not give you a perfect lead on a stolen or misplaced laptop, it can certain provide a starting point.
    </p><p>
        Thus, this service was born.  Sign up and we'll provide you a registry file that will cause Windows 7 NCSI to connect to our servers rather than Microsoft's.  We'll log each connection, and allow you to view the date/time and ip address of each connection. Don't worry, you can delete your logs at any time, and you can also revert to using Microsoft's servers at any time as well.  While this registry file does require Administrator access to run (since it's under HKEY_LOCAL_MACHINE), no additional software will be installed on your computer.
    </p>
</asp:Content>
