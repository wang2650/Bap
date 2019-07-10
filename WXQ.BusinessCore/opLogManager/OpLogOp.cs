using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.BusinessCore.opLogManager
{
   public class OpLogOp
    {



        public static bool InsertOplog(WXQ.Enties.OpLog m)
        {
            OpLogManager oplogManager = new OpLogManager();


            return oplogManager.Insert(m);
        }
        /// <summary>
        /// 操作日志列表
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="opUserId"></param>
        /// <param name="bgDt"></param>
        /// <param name="endDt"></param>
        /// <param name="Ip"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.OpLog> GetOpLogList(string methodName,int opUserId,DateTime bgDt,DateTime endDt,string Ip,   PageModel pageModel)
        {
            OpLogManager oplogManager = new OpLogManager();

            ListResult<WXQ.Enties.OpLog> result = new ListResult<Enties.OpLog>();


            System.Linq.Expressions.Expression<Func<Enties.OpLog, bool>> express = Expressionable.Create<WXQ.Enties.OpLog>()
                          .AndIF(!string.IsNullOrEmpty(methodName), m => SqlFunc.Contains(m.MethodName, methodName))
                          .AndIF(bgDt<DateTime.Now, m => m.CreateDateTime>=bgDt)
                          .AndIF(endDt >= bgDt, m => m.CreateDateTime <= endDt)
                          .AndIF(!string.IsNullOrEmpty(Ip), m => SqlFunc.Contains(m.Ip, Ip))
                          .AndIF(opUserId > -1, it => it.OpUser == opUserId).ToExpression();//拼接表达式
            result.Result = oplogManager.GetPageList(express, pageModel);
    
            result.PageSize = pageModel.PageSize;
            result.PageIndex = pageModel.PageIndex;
            result.Total = pageModel.PageCount;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="opUserId"></param>
        /// <param name="bgDt"></param>
        /// <param name="endDt"></param>
        /// <param name="Ip"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public bool Delete(string methodName, int opUserId, DateTime bgDt, DateTime endDt, string Ip)
        {
            OpLogManager oplogManager = new OpLogManager();


            System.Linq.Expressions.Expression<Func<Enties.OpLog, bool>> express = Expressionable.Create<WXQ.Enties.OpLog>()
                          .AndIF(!string.IsNullOrEmpty(methodName), m => SqlFunc.Contains(m.MethodName, methodName))
                          .AndIF(bgDt < DateTime.Now, m => m.CreateDateTime >= bgDt)
                          .AndIF(endDt >= bgDt, m => m.CreateDateTime <= endDt)
                          .AndIF(!string.IsNullOrEmpty(Ip), m => SqlFunc.Contains(m.Ip, Ip))
                          .AndIF(opUserId > -1, it => it.OpUser == opUserId).ToExpression();//拼接表达式
            return oplogManager.Delete(express);


        }



    }
}
