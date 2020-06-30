namespace WXQ.Enties.CommonObj
{
    /// <summary>
    /// 常用结果返回 code和message定义
    /// </summary>
    public class ResponseResultMessageDefine
    {
        /// <summary>
        ///
        /// </summary>
        public const int Ok = 0;

        /// <summary>
        ///
        /// </summary>
        public const string OkMessage = "成功";

        /// <summary>
        ///
        /// </summary>
        public const int ParaError = 1;

        /// <summary>
        ///
        /// </summary>
        public const string ParaErrorMessage = "参数错误";

        /// <summary>
        ///
        /// </summary>
        public const int Exception = 2;

        /// <summary>
        ///
        /// </summary>
        public const string ExceptionMessage = "异常";

        /// <summary>
        ///
        /// </summary>
        public const int OpLost = 3;

        /// <summary>
        ///
        /// </summary>
        public const string OpLostMessage = "业务操作失败";

        /// <summary>
        ///
        /// </summary>
        public const string NoLoginOrUserIdError = "用户未登录或者用户id错误";


        public const string NoExistFile = "无此文件";


    }
}