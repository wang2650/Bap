using SqlSugar;
using System;
using System.Collections.Generic;

namespace WXQ.BusinessCore.CommonManager
{
    public class DictOp: OpBase
    {
        public DictOp(int opUserId=0):base(opUserId)
        {
            base.OpUserId = opUserId;

        }

        /// <summary>
        /// 添加字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertDict(WXQ.Enties.Dict model)
        {
            DictManager DictManager = new DictManager();
            model.AddUser = this.OpUserId.ToString();
            return DictManager.Insert(model);
        }

        /// <summary>
        /// 修改字典
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool UpdateDict(WXQ.Enties.Dict model)
        {
            DictManager DictManager = new DictManager();
            model.UpdateUser = this.OpUserId.ToString();
            return DictManager.Db.Updateable(model).Where(m => m.DictId == model.DictId).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 删除字典根据主键
        /// </summary>
        /// <param name="dictId"></param>
        /// <returns></returns>
        public bool DeleteDictByDictId(int dictId)
        {
            DictManager DictManager = new DictManager();
            return DictManager.DeleteById(dictId);
        }

        public bool DeleteDictByGroupName(string groupName)
        {
            DictManager DictManager = new DictManager();
            return DictManager.Delete(d=>d.GroupName==groupName);
        }

        /// <summary>
        /// 根据主键批量删除字典
        /// </summary>
        /// <param name="dictIds"></param>
        /// <returns></returns>
        public bool DeleteDicts(List<int> dictIds)
        {
            DictManager DictManager = new DictManager();
            List<dynamic> ids = new List<dynamic>();
            foreach (int id in dictIds)
            {
                ids.Add(id);
            }

            return DictManager.DeleteByIds(ids.ToArray());
        }

        /// <summary>
        /// 字典列表
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="opUserId"></param>
        /// <param name="bgDt"></param>
        /// <param name="endDt"></param>
        /// <param name="Ip"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.Dict> GetDictList(string GroupName,  PageModel pageModel)
        {
            DictManager DictManager = new DictManager();
            ListResult<WXQ.Enties.Dict> result = new ListResult<Enties.Dict>();
            System.Linq.Expressions.Expression<Func<Enties.Dict, bool>> express = Expressionable.Create<WXQ.Enties.Dict>()
                          .AndIF(!string.IsNullOrEmpty(GroupName), m => SqlFunc.Contains(m.GroupName, GroupName)).ToExpression();//拼接表达式

             result.Result=   string.IsNullOrEmpty(GroupName) ? DictManager.GetPageList(express, pageModel, d => d.GroupName, OrderByType.Asc) : DictManager.GetPageList(express, pageModel, d => d.OrderBy, OrderByType.Asc);


            result.PageSize = pageModel.PageSize;
            result.PageIndex = pageModel.PageIndex;
            result.Total = pageModel.PageCount;
            return result;
       

        }
        /// <summary>
        /// 获取字典的分组列表
        /// </summary>
        /// <param name="pageModel"></param>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.Dict> GetDictGroup( PageModel pageModel, string GroupName)
        {

            return GetDictList(GroupName,pageModel);

        }
        }
}