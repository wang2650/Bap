using CommonLib.Extensions.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WXQ.Enties.CommonObj;
using WXQ.InOutPutEntites.Output;

namespace WebApi.Controllers.FileHandle
{
    /// <summary>
    /// 文件控制
    /// </summary>

    [Route("Api/FileHandle/FileHandle")]
    [ApiController]
    public class FileHandleController : Controller
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
            string targetDirectory = "wwwroot\\uploadfiles";
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

        /// <summary>
        /// 保存excel文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveExcel")]
        [WebApi.Common.Log]
        public JsonResult SaveExcel([FromQuery] string filename, Microsoft.AspNetCore.Http.IFormFile excelFile)
        {
            ResponseResult result = new ResponseResult();
            string targetDirectory = "\\wwwroot\\uploadfiles";
            //检查相应目录
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            int bufferThreshold = 5120000;//500k  bufferThreshold 设置的是 Request.Body 最大缓存字节数（默认是30K） 超出这个阈值的字节会被写入磁盘
            int bufferLimit = 10240000;//1m 设置的是 Request.Body 允许的最大字节数（默认值是null），超出这个限制，就会抛出异常 System.IO.IOException

            HttpContext.Request.Body.Position = 0;
            if (this.Request.ContentLength > 0 && this.Request.Body != null && this.Request.Body.CanRead)
            {
                Encoding encoding = System.Text.UTF8Encoding.Default;
                using (var buffer = new MemoryStream())
                {
                    HttpContext.Request.Body.CopyTo(buffer);
                    buffer.Flush();
                    buffer.Position = 0;
                    buffer.ToFile(Path.Combine(targetDirectory, "a.jpg"));
                }
            }

            return Json(result);
        }

        private void saveTofle(MemoryStream file, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] buffer = file.ToArray();//转化为byte格式存储
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
                buffer = null;
            }//使用using可以最后不用关闭fs 比较方便
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="caseId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DownloadFile")]
        [WebApi.Common.Log]
        public async Task<IActionResult> DownloadFile(string fileName, string caseId)
        {
            string directoryPath = AppContext.BaseDirectory;
            string filePath = directoryPath + "/a.jpg";
             var memoryStream = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 65536, FileOptions.Asynchronous | FileOptions.SequentialScan))
            {
                await stream.CopyToAsync(memoryStream);
            }
            memoryStream.Seek(0, SeekOrigin.Begin);

            return File(memoryStream, "application/octet-stream", fileName);
        }

        public async Task<IActionResult> Download(string id)
        {
            string filename = "a.txt";
            string filePath = "/downlfile/"+ filename;
            if (!System.IO.File.Exists(filePath))
            {
                ResponseResult result = new ResponseResult();
                result.Code = ResponseResultMessageDefine.OpLost;
                result.Errors.Add(ResponseResultMessageDefine.NoExistFile);

                return Ok(result);
            }

            else
            {
                var memoryStream = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 65536, FileOptions.Asynchronous | FileOptions.SequentialScan))
                {
                    await stream.CopyToAsync(memoryStream);
                }
                var ext = "." + filename.Split('.')[1];
                memoryStream.Seek(0, SeekOrigin.Begin);
                new FileExtensionContentTypeProvider().Mappings.TryGetValue(ext, out var contenttype);
                return new FileStreamResult(memoryStream, contenttype);
            }


        }


    }
}