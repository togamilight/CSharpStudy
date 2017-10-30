using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.ViewModels {
    public class FileUploadViewModel : BaseViewModel{
        //HttpPostedFileBase 将通过客户端提供上传文件的访问入口。
        public HttpPostedFileBase FileUpload { get; set; }
    }
}