<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\NlaSvc\Parameters\Internet]
"PassivePollPeriod"=dword:00000005
"StaleThreshold"=dword:0000001e
"WebTimeout"=dword:00000023
"EnableActiveProbing"=dword:00000001
"ActiveWebProbeHost"="www.open-ncsi.com"
"ActiveWebProbePath"="<%= ViewData["Username"] %>.txt"
"ActiveWebProbeContent"="<%= NCSIServ.Controllers.NCSIController.ReturnString %>"
"ActiveDnsProbeHost"="dns.msftncsi.com"
"ActiveDnsProbeContent"="131.107.255.255"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\NlaSvc\Parameters\Internet\ManualProxies]

