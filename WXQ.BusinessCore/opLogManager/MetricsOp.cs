using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.BusinessCore.opLogManager
{
   public class MetricsOp
    {





        public static bool InsertMetricsLog(WXQ.Enties.Metrics m)
        {
            MetricsManager metricsManager = new MetricsManager();


            return metricsManager.Insert(m);
        }
        /// <summary>
        /// 度量日志
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="CostTime"></param>
        /// <param name="bgDt"></param>
        /// <param name="endDt"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.Metrics> GetMetricsList(string methodName, int CostTime, DateTime bgDt, DateTime endDt,   PageModel pageModel)
        {
            MetricsManager metricsManager = new MetricsManager();
            ListResult<WXQ.Enties.Metrics> result = new ListResult<Enties.Metrics>();

            System.Linq.Expressions.Expression<Func<Enties.Metrics, bool>> express = Expressionable.Create<WXQ.Enties.Metrics>()
                          .AndIF(!string.IsNullOrEmpty(methodName), m => SqlFunc.Contains(m.MethodName, methodName))
                          .AndIF(bgDt < DateTime.Now, m => m.CreateDateTIme >= bgDt)
                          .AndIF(endDt >= bgDt, m => m.CreateDateTIme <= endDt)
                           .AndIF(CostTime > 0, m => m.CostTime > CostTime)
                          .ToExpression();//拼接表达式
            result.Result= metricsManager.GetPageList(express, pageModel);


            result.PageSize = pageModel.PageSize;
            result.PageIndex = pageModel.PageIndex;
            result.Total = pageModel.PageCount;
            return result;
        }
        /// <summary>
        /// 删除度量日志
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="CostTime"></param>
        /// <param name="bgDt"></param>
        /// <param name="endDt"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public bool Delete(string methodName, int CostTime, DateTime bgDt, DateTime endDt)
        {
            MetricsManager metricsManager = new MetricsManager();


            System.Linq.Expressions.Expression<Func<Enties.Metrics, bool>> express = Expressionable.Create<WXQ.Enties.Metrics>()
                          .AndIF(!string.IsNullOrEmpty(methodName), m => SqlFunc.Contains(m.MethodName, methodName))
                          .AndIF(bgDt < DateTime.Now, m => m.CreateDateTIme >= bgDt)
                          .AndIF(endDt >= bgDt, m => m.CreateDateTIme <= endDt)
                           .AndIF(CostTime > 0, m => m.CostTime > CostTime)
                          .ToExpression();//拼接表达式
         return   metricsManager.Delete(express);

        }











    }
}
