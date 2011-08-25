using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCSIServ.Controllers
{
    public class NCSIController : Controller
    {
        //
        // GET: /NCSI/

        public const string ReturnString = "NCSI Server";

        public Models.ncsi_site_dbEntities _db = new Models.ncsi_site_dbEntities();

        public string Index(string username)
        {
            Models.AccessLog access = Models.AccessLog.CreateAccessLog(0, username, this.HttpContext.Request.UserHostAddress, DateTime.Now);
            _db.AddToAccessLogs(access);
            _db.SaveChanges();
            return ReturnString;
        }

    }
}
