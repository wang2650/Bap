using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Common;
using WXQ.InOutPutEntites.Output;

namespace WebApi.Controllers.Customer
{
    [Route("api/CustomerManager")]
    [ApiController]
    public class CustomerController : Controller
    {
        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [WebApi.Common.Log]
        [Route("UploadHeadImage")]
        public async Task<JsonResult> UploadHeadImage()
        {
            ResponseResult result = new ResponseResult();

            var boundary = this.Request.GetMultipartBoundary();
            string targetDirectory = "\\wwwroot\\uploadfiles";
            //检查相应目录
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            var result2 = this.Request.Headers.TryGetValue("wxq", out StringValues authStr);
            var filePath = string.Empty;
            var reader = new Microsoft.AspNetCore.WebUtilities.MultipartReader(boundary, this.Request.Body);
            try
            {
                CancellationToken cancellationToken = new System.Threading.CancellationToken();
                var section = await reader.ReadNextSectionAsync(cancellationToken);
         
                while (section != null)
                {
                    ContentDispositionHeaderValue header = section.GetContentDispositionHeader();
              
                    if (header.FileName.HasValue || header.FileNameStar.HasValue)
                    {
                        var fileSection = section.AsFileSection();
                     
                        var fileName = fileSection.FileName;
                        var mimeType = fileSection.Section.ContentType;
                        filePath = Path.Combine(targetDirectory, fileName);
                 
                        using (var writeStream = System.IO.File.Create(filePath))
                        {
                            const int bufferSize = 1024;
                            await fileSection.FileStream.CopyToAsync(writeStream, bufferSize, cancellationToken);
                        }
                    }
                    //else
                    //{
                    //  取formdata中的信息 
                    //    var formDataSection = section.AsFormDataSection();
                    //    var name = formDataSection.Name;
                    //    var value = await formDataSection.GetValueAsync();
                    //    uploadSectionInfo.Dicts.Add(new KV(name, value));
                      
                    //}
                    section = await reader.ReadNextSectionAsync(cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                //return (false, "用户取消操作", null);
            }
  

            return Json(result);
        }
    }
}