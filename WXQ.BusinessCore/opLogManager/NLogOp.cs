using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.BusinessCore.opLogManager
{
 public   class NLogOp
    {

        /// <summary>
        /// 记录调试 错误 系统日志
        /// </summary>
        /// <param name="application"></param>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="bgDt"></param>
        /// <param name="endDt"></param>
        /// <param name="Logger"></param>
        /// <param name="CallSite"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.nlog> GetNLogList(  string application, string level, string message, DateTime bgDt, DateTime endDt, string Logger, string CallSite,  PageModel pageModel)
        {
            nlogManager nlogManager = new nlogManager();
            ListResult<WXQ.Enties.nlog> result = new ListResult<Enties.nlog>();

       
            System.Linq.Expressions.Expression<Func<Enties.nlog, bool>> express = Expressionable.Create<WXQ.Enties.nlog>()
                          .AndIF(!string.IsNullOrEmpty(application), r => r.Application == application)
                          .AndIF(!string.IsNullOrEmpty(level), r => r.Level == level)
                           .AndIF(!string.IsNullOrEmpty(Logger), r => r.Logger == Logger)
                            .AndIF(!string.IsNullOrEmpty(message), r => r.Message.Contains(message))
                            .AndIF(!string.IsNullOrEmpty(CallSite), r => r.CallSite.Contains(CallSite))
                          .AndIF(bgDt<=DateTime.Now, r => r.Logged>= bgDt)
                          .AndIF(endDt >= bgDt, r => r.Logged <=endDt).ToExpression();//拼接表达式

            result.Result = nlogManager.GetPageList(express, pageModel);

            result.PageSize = pageModel.PageSize;
            result.PageIndex = pageModel.PageIndex;
            result.Total = pageModel.PageCount;
            return result;
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="application"></param>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="bgDt"></param>
        /// <param name="endDt"></param>
        /// <param name="Logger"></param>
        /// <param name="CallSite"></param>
        /// <returns></returns>
        public bool Delete  (string application, string level, string message, DateTime bgDt, DateTime endDt, string Logger, string CallSite)
        {
            nlogManager nlogManager = new nlogManager();

            System.Linq.Expressions.Expression<Func<Enties.nlog, bool>> express = Expressionable.Create<WXQ.Enties.nlog>()
                          .AndIF(!string.IsNullOrEmpty(application), r => r.Application == application)
                          .AndIF(!string.IsNullOrEmpty(level), r => r.Level == level)
                           .AndIF(!string.IsNullOrEmpty(Logger), r => r.Logger == Logger)
                            .AndIF(!string.IsNullOrEmpty(message), r => r.Message.Contains(message))
                            .AndIF(!string.IsNullOrEmpty(CallSite), r => r.CallSite.Contains(CallSite))
                          .AndIF(bgDt <= DateTime.Now, r => r.Logged >= bgDt)
                          .AndIF(endDt >= bgDt, r => r.Logged <= endDt).ToExpression();//拼接表达式

            return nlogManager.Delete(express);
        }



    }
}
