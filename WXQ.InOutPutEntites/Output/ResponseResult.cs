using System;
using System.Collections.Generic;

namespace WXQ.InOutPutEntites.Output
{
    /// <summary>
    /// 输出结果对象
    /// </summary>
    public class ResponseResult
    {
        public ResponseResult()
        {

            this.Code = 0;
            this.Guid = CommonLib.Helpers.Id.Guid();
        }



        /// <summary>
        /// 输出结果对象
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ResponseResult(int code, string message = "")
        {

            this.Code = code;
            this.Errors.Add(message);
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 标识id
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; } 

        /// <summary>
        /// 错误信息
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();

        /// <summary>
        /// 返回的数据结果
        /// </summary>
        public object Data { get; set; }
    }
}