using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace MVCDemo.Logger {
    public class FileLogger {
        public void LogException(Exception e) {
            //string filePath1 = AppDomain.CurrentDomain.BaseDirectory + "ErrorLog/" + 
                //DateTime.Now.ToString("dd-MM-yy mm hh ss") + ".txt";
            string filePath2 = HttpContext.Current.Server.MapPath("~/ErrorLog/" + DateTime.Now.ToString("dd-MM-yy mm hh ss") + ".txt");
            //string filePath3 = HostingEnvironment.MapPath
                //(@"~/ErrorLog/" + DateTime.Now.ToString("dd-MM-yy mm hh ss") + ".txt");
            File.WriteAllLines(filePath2, new string[] {
                "Message : " + e.Message,
                "Stacktrace" + e.StackTrace
            });
        }
    }
}