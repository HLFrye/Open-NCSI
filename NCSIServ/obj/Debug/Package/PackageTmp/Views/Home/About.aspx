<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Open-NCSI.com
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>About this site</h2>
    <p>
        I got the idea for this site after reading <a href="http://blog.superuser.com/2011/05/16/windows-7-network-awareness/">this blog post</a> linked off of <a href="http://news.ycombinator.com">Hacker News</a> a couple months ago.  I thought it'd be cool to have a way to log of my computer's NCSI connections, partly just for curiosity, and partly as a way to find out where it had gone if it should ever be lost or stolen.  Then I figured if it was useful for me, it might be useful for other people as well, so this site was born.  If you have any questions or comments, please contact me!
    </p>

    <h2>What's next?</h2>
    <p>
        Coming soon, I'll be adding features to this site to allow one account to have settings for multiple computers.  If you work for an IT department and would like the tracking features of this site, but don't want to create an account for each computer, then please check back in a couple of weeks.
    </p>

    <h2>About the developer</h2>
    <p>
        I'm a software developer based out of Fort Worth, TX.  In my day job I mostly do C++ MFC code for a Windows based CAD product, though I often spend time working on .NET applications (C#, C++/CLI, and recently a bit of F#).  In my spare time I've been working on a couple web development projects: this one, using ASP.Net, and another one which has not been released yet, using Django.  For source control at work I use AccuRev, while for my personal projects I prefer git.  
    </p>
</asp:Content>
