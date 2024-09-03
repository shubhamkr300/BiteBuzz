using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FoodDeliveryApplication.Models
{
    public class LoadDataModel
    {
        public static string SaveImage(HttpPostedFileBase getfile)
        {
            var filename= Path.GetFileNameWithoutExtension(getfile.FileName);
            var ext = Path.GetExtension(getfile.FileName);  
            string fullfilename = Guid.NewGuid()+ext;
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/user_images/"),fullfilename);
            getfile.SaveAs(path);
            return fullfilename;
        }
    }
}