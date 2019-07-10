using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using CommonLib.Json;
using Newtonsoft.Json;
using CommonLib.Extensions;
using RestSharp;

namespace CommonLib.Sms.LuoSiMao {
    /// <summary>
    /// 短信服务
    /// </summary>
    public class SmsService : ISmsService {
        /// <summary>
        /// 短信配置提供器
        /// </summary>
        private readonly ISmsConfigProvider _configProvider;

        /// <summary>
        /// 初始化短信服务
        /// </summary>
        /// <param name="configProvider">短信配置提供器</param>
        public SmsService( ISmsConfigProvider configProvider ) {
            configProvider.CheckNull( nameof( configProvider ) );
            _configProvider = configProvider;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="content">内容</param>
        public async Task<SmsResult> SendAsync( string mobileStr, string content ) {

            var client = new RestSharp.RestClient("https://sms-api.luosimao.com");
            var request = new RestRequest("v1/send.json", Method.POST);
            request.AddHeader("Authorization", await GetAuthorization());
            var postdata = new
            {
                mobile = mobileStr,
                message = content

            };
            var json = request.JsonSerializer.Serialize(postdata);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var resultContent = response.Content;
            return CreateResult(resultContent);
        }

        /// <summary>
        /// 获取授权头信息
        /// </summary>
        private async Task<string> GetAuthorization() {
            var config = await _configProvider.GetConfigAsync();
            return $"Basic {System.Convert.ToBase64String( Encoding.UTF8.GetBytes( $"api:{config.Key}" ) )}";
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        private SmsResult CreateResult( string message ) {
            var result = JsonConvert.DeserializeObject<LuoSiMaoResult>( message );
            result.CheckNull( nameof( result ) );
            if( result.error == "0" )
                return SmsResult.Ok;
            if( result.msg == "WRONG_MOBILE" )
                return new SmsResult( false, message, SmsErrorCode.MobileError );
            return new SmsResult( false, message );
        }
    }
}
