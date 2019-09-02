using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Common.YouMeng.Enums;
using Common.YouMeng.ViewModel;

namespace Common.YouMeng
{
    public class UMengAndroidPush
    {
        private readonly static string AppAndroidKey = CommonLib.Tools.ConfigHelper.GetJsonConfig().GetSection("YuMeng").GetSection("YMAndroidKey").Value.ToString().Trim();

        /// <summary>
        /// 初始化安卓通知实体
        /// </summary>
        /// <param name="reqModel"></param>
        /// <returns></returns>
        private static UMengPushModel AndroidModelInit(UMengSendMsgModel reqModel)
        {
            UMengPushModel androidModel = new UMengPushModel
            {
                appkey = AppAndroidKey,
                description = reqModel.Description,
                payload = new UMengPushAndroidContentModel
                {
                    display_type = UMengPushContentTypeEnum.notification.ToString(),
                    extra = new ExtraBody(),
                    body = new UMengPushAndroidBodyModel
                    {
                        ticker = "小壹在线",
                        title = reqModel.Title,
                        text = reqModel.Title,
                        after_open = reqModel.AfterOpen.ToString(),
                        activity = reqModel.Activity,
                        url = reqModel.Url,
                        custom = reqModel.Custom
                    }
                }
            };
            return androidModel;
        }

        /// <summary>
        /// 通过多个设备号发送安卓推送
        /// </summary>
        /// <param name="reqModel"></param>
        /// <returns></returns>
        public static bool PushNotoficationByDeviceTokens(UMengSendMsgModel reqModel)
        {
            UMengPushModel androidModel = AndroidModelInit(reqModel);
            UMengTools.InitPushModelByDeviceTokens(androidModel, reqModel.DeviceTokens, EquipmentTypeEnum.Android);
            UMengResponseModel model = UMengTools.UMengPostRequest(UMengUrlList.ApiSend, EquipmentTypeEnum.Android, androidModel);
            return model != null && model.ret.Equals("SUCCESS");
        }

        /// <summary>
        /// 通过多个用户发送安卓推送
        /// </summary>
        /// <param name="reqModel"></param>
        /// <returns></returns>
        public static bool PushNotoficationByUsers(UMengSendMsgModel reqModel)
        {
            UMengPushModel androidModel = AndroidModelInit(reqModel);
            UMengTools.InitPushModelByUsers(androidModel, reqModel.DeviceTokens, EquipmentTypeEnum.Android);
            UMengResponseModel model = UMengTools.UMengPostRequest(UMengUrlList.ApiSend, EquipmentTypeEnum.Android, androidModel);
            return model != null && model.ret.Equals("SUCCESS");
        }

    }
}
