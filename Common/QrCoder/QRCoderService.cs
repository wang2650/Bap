

using Common.QrCoder;
using CommonLib.Extensions.Common;
using CommonLib.QrCoder.QrCode;
using QRCoder;
using System;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace CommonLib.QrCoder.QrCoder {
    /// <summary>
    /// QRCoder二维码服务
    /// </summary>
    public class QrCoderService : IQrCodeService {
        /// <summary>
        /// 二维码尺寸
        /// </summary>
        private int _size;
        /// <summary>
        /// 容错级别
        /// </summary>
        private QRCodeGenerator.ECCLevel _level;

        /// <summary>
        /// 初始化QRCoder组件二维码服务
        /// </summary>
        public QrCoderService() {
            _size = 10;
            _level = QRCodeGenerator.ECCLevel.L;
        }

        /// <summary>
        /// 设置二维码尺寸
        /// </summary>
        /// <param name="size">二维码尺寸</param>
        public IQrCodeService Size( QrSize size ) {
            return Size( size.Value() );
        }

        /// <summary>
        /// 设置二维码尺寸
        /// </summary>
        /// <param name="size">二维码尺寸</param>
        public IQrCodeService Size( int size ) {
            _size = size;
            return this;
        }

        /// <summary>
        /// 容错处理
        /// </summary>
        /// <param name="level">容错级别</param>
        public IQrCodeService Correction( ErrorCorrectionLevel level ) {
            switch( level ) {
                case ErrorCorrectionLevel.L:
                    _level = QRCodeGenerator.ECCLevel.L;
                    break;
                case ErrorCorrectionLevel.M:
                    _level = QRCodeGenerator.ECCLevel.M;
                    break;
                case ErrorCorrectionLevel.Q:
                    _level = QRCodeGenerator.ECCLevel.Q;
                    break;
                case ErrorCorrectionLevel.H:
                    _level = QRCodeGenerator.ECCLevel.H;
                    break;
            }
            return this;
        }

        /// <summary>
        /// 创建二维码
        /// </summary>
        /// <param name="content">内容</param>
        public byte[] CreateQrCode( string content ) {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData data = generator.CreateQrCode( content, _level );
            BitmapByteQRCode qrCode = new BitmapByteQRCode( data );
            return qrCode.GetGraphic( _size );
        }

        #region  使用 ThoughtWorks.QRCode.Codec

        /// <summary>
        /// 定义参数,生成二维码
        /// </summary>
        public static QrResult Create(string text, string path)
        {
            QrResult result = new QrResult();
            try
            {
                if (string.IsNullOrEmpty(text) ||string.IsNullOrEmpty(path))
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "二维码内容和二维码图片路径不可为空";
                }
                else
                {
                    var image = Encode(text);
                    if (image == null)
                    {
                        result.IsSuccess = false;
                        result.ReturnMessage = "图片生成失败";
                    }
                    else
                    {
                        image.Save(path);
                    }
                }

          
              
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ReturnMessage = ex.Message;
            }
            return result;
        }






        /// <summary>
        /// 返回二维码图片
        /// </summary>
        public static Bitmap Encode(string text)
        {
            try
            {
                var qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeVersion = 5;
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                qrCodeEncoder.QRCodeScale = 4;
                return qrCodeEncoder.Encode(text);
            }
            catch (Exception ex)
            {
             
                return null;
            }
        }








        /// <summary>
        /// 获取二维码内容
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static QrResult Decode(Bitmap image)
        {
            QrResult result = new QrResult();
            try
            {
          
                var qrCodeBitmapImage = new QRCodeBitmapImage(image);
                var qrCodeDecoder = new QRCodeDecoder();
                result.ReturnMessage= qrCodeDecoder.decode(qrCodeBitmapImage); 
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.ReturnMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 解析图片的的内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public  static QrResult Decode(string filePath)
        {
            QrResult result = new QrResult();
            try
            {

                if (string.IsNullOrEmpty(filePath))
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "路径为空";
                }
                else
                {
                    try{
                        var pic = new Bitmap(filePath);
                        if (pic!=null)
                        {
                            result= Decode(new Bitmap(filePath));
                        }
                        else
                        {
                            result.IsSuccess = false;
                            result.ReturnMessage = "图片不存在或者非图片格式";
                           

                        }
                    }
                    catch (Exception ex)
                    {
                        result.IsSuccess = false;
                        result.ReturnMessage = ex.Message;
                        return result;
                    }
                 
                  


                }
                 
            }
            catch(Exception ex)
            { 
                
              
                result.IsSuccess = false;
                result.ReturnMessage = ex.Message;
                return result;

            }
            return result;



        }

            #endregion





        }
}
