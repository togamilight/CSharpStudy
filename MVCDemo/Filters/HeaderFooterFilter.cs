using MVCDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Filters {
    public class HeaderFooterFilter : ActionFilterAttribute{
        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            ViewResult v = filterContext.Result as ViewResult;
            if(v != null) {
                BaseViewModel bvm = v.Model as BaseViewModel;
                if(bvm != null) {
                    bvm.FooterData = new FooterViewModel() {
                        CompanyName = "ABCompany",
                        Year = DateTime.Now.Year.ToString()
                    };
                    //bvm.UserName = filterContext.HttpContext.User.Identity.Name;
                    bvm.UserName = HttpContext.Current.User.Identity.Name;
                }
            }
        }
    }
}