using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WXQ.BusinessCore;
using WXQ.Enties.CommonObj;
using WXQ.InOutPutEntites.Output;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using System.Text;
using CommonLib.Extensions.IO;
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
        /// 保存excel文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveExcel")]
        [WebApi.Common.Log]
        public JsonResult SaveExcel([FromQuery] string  filename, Microsoft.AspNetCore.Http.IFormFile excelFile)
        {
            ResponseResult result = new ResponseResult();
            int bufferThreshold = 5120000;//500k  bufferThreshold 设置的是 Request.Body 最大缓存字节数（默认是30K） 超出这个阈值的字节会被写入磁盘
            int bufferLimit = 10240000;//1m 设置的是 Request.Body 允许的最大字节数（默认值是null），超出这个限制，就会抛出异常 System.IO.IOException
            HttpContext.Request.EnableRewind(bufferThreshold, bufferLimit);
            HttpContext.Request.Body.Position = 0;
            if (this.Request.ContentLength > 0 && this.Request.Body != null && this.Request.Body.CanRead)
            {
                Encoding encoding = System.Text.UTF8Encoding.Default;
                using (var buffer = new MemoryStream())
                {
                    HttpContext.Request.Body.CopyTo(buffer);
                    buffer.Flush();
                    buffer.Position = 0;
                    buffer.ToFile("//a.txt" );
                

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





    }
}