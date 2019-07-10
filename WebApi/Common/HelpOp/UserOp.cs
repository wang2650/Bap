using System.Security.Claims;

namespace WebApi.Common.HelpOp
{
    public class UserOp
    {
        /// <summary>
        /// 获取用户的id
        /// </summary>
        /// <param name="claimsPrincipal"></param>
        /// <returns></returns>
        public static int GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            int userId = 0;
            if (claimsPrincipal != null && claimsPrincipal.Identity != null && !string.IsNullOrEmpty(claimsPrincipal.Identity.Name))
            {
                int.TryParse(claimsPrincipal.Identity.Name, out userId);
            }

            return userId;
        }
    }
}