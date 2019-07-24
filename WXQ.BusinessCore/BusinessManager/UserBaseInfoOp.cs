using WXQ.BusinessCore.BaseCore;

namespace WXQ.BusinessCore.BusinessManager
{
    public class UserBaseInfoOp : OpBase
    {
        public UserBaseInfoOp(int opUserId = 0) : base(opUserId)
        {
            base.OpUserId = opUserId;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertUserBaseInfo(WXQ.Enties.DbModels.UserBaseInfo model)
        {

            UserBaseInfoManager baseUserInfoManager = new UserBaseInfoManager();

            return baseUserInfoManager.Insert(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public bool UpdateUserBaseInfo(WXQ.Enties.DbModels.UserBaseInfo model)
        {

            UserBaseInfoManager baseUserInfoManager = new UserBaseInfoManager();

            return baseUserInfoManager.Update(model);
        }
        /// <summary>
        /// 通过全局唯一标识 删除
        /// </summary>
        /// <param name="uniquenessId"></param>
        /// <returns></returns>
        public bool DeleteBaseUserInfoByUniquenessId(string uniquenessId)
        {

            UserBaseInfoManager baseUserInfoManager = new UserBaseInfoManager();

            return baseUserInfoManager.Delete(d=>d.UniquenessId== uniquenessId);
        }
        /// <summary>
        /// 通过人员标识符删除
        /// </summary>
        /// <param name="userSn"></param>
        /// <returns></returns>

        public bool DeleteBaseUserInfoByUserSn(string userSn)
        {

            UserBaseInfoManager baseUserInfoManager = new UserBaseInfoManager();

            return baseUserInfoManager.Delete(d => d.UserSn == userSn);
        }
        /// <summary>
        /// 搜索客户信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.DbModels.UserBaseInfo> GetRoleListByUserId(WXQ.Enties.DbModels.UserBaseInfo model, int pageIndex, int pageSize)
        {
            ListResult<WXQ.Enties.DbModels.UserBaseInfo> result = new ListResult<WXQ.Enties.DbModels.UserBaseInfo>();

            int totalRs = 0;

            RoleManager roleManager = new RoleManager();
            result.Result = roleManager.Db.Queryable<WXQ.Enties.DbModels.UserBaseInfo>()
                   // .Where((ur, r) => ur.UserId == userId)
                  .Select((u) => u).ToPageList(pageIndex, pageSize, ref totalRs);
            result.PageSize = pageSize;
            result.PageIndex = pageIndex;
            result.Total = totalRs;
            return result;
        }







    }
}