using System;
using System.Text.RegularExpressions;

namespace CommonLib.Helpers
{
    public class ValidateHelper
    {
        private static Regex _emailregex = new Regex(@"^[a-z]([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_]?[a-z0-9]+)+[\.][a-z]{2,3}([\.][a-z]{2})?$", RegexOptions.IgnoreCase);

        //手机号正则表达式

        private static Regex _mobileregex = new Regex("^(13|14|15|16|18|17|19)[0-9]{9}$");

        //固话号正则表达式

        private static Regex _phoneregex = new Regex(@"^(\d{3,4}-?)?\d{7,8}$");

        //IP正则表达式

        private static Regex _ipregex = new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");

        //日期正则表达式

        private static Regex _dateregex = new Regex(@"(\d{4})-(\d{1,2})-(\d{1,2})");

        //数值(包括整数和小数)正则表达式

        private static Regex _numericregex = new Regex(@"^[-]?[0-9]+(\.[0-9]+)?$");

        //邮政编码正则表达式

        private static Regex _zipcoderegex = new Regex(@"^\d{6}$");


        //手机浏览器
        private static  Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        private static  Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);

        /// <summary>
        /// 是否手机浏览器
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        public static bool IsMobileBrowser( string userAgent)
        {
           
            if ((b.IsMatch(userAgent) || v.IsMatch(userAgent.Substring(0, 4))))
            {
                return true;
            }

            return false;
        }

        /// <summary>

        /// 是否为邮箱名

        /// </summary>

        public static bool IsEmail(string s)

        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            return _emailregex.IsMatch(s);
        }

        /// <summary>

        /// 是否为手机号

        /// </summary>

        public static bool IsMobile(string s)

        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            return _mobileregex.IsMatch(s);
        }

        /// <summary>

        /// 是否为固话号

        /// </summary>

        public static bool IsPhone(string s)

        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            return _phoneregex.IsMatch(s);
        }

        /// <summary>

        /// 是否为IP

        /// </summary>

        public static bool IsIP(string s)

        {
            return _ipregex.IsMatch(s);
        }

        /// <summary>

        /// 是否是身份证号

        /// </summary>

        public static bool IsIdCard(string id)

        {
            if (string.IsNullOrEmpty(id))
            {
                return true;
            }

            if (id.Length == 18)
            {
                return CheckIDCard18(id);
            }
            else if (id.Length == 15)
            {
                return CheckIDCard15(id);
            }
            else
            {
                return false;
            }
        }

        /// <summary>

        /// 是否为18位身份证号

        /// </summary>

        private static bool CheckIDCard18(string Id)

        {
            if (long.TryParse(Id.Remove(17), out long n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }

            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";

            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }

            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");

            DateTime time = new DateTime();

            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }

            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');

            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');

            char[] Ai = Id.Remove(17).ToCharArray();

            int sum = 0;

            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }

            int y = -1;

            Math.DivRem(sum, 11, out y);

            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }

            return true;//符合GB11643-1999标准
        }

        /// <summary>

        /// 是否为15位身份证号

        /// </summary>

        private static bool CheckIDCard15(string Id)

        {
            if (long.TryParse(Id, out long n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }

            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";

            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }

            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");

            DateTime time = new DateTime();

            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }

            return true;//符合15位身份证标准
        }

        /// <summary>

        /// 是否为日期

        /// </summary>

        public static bool IsDate(string s)

        {
            return _dateregex.IsMatch(s);
        }

        /// <summary>

        /// 是否是数值(包括整数和小数)

        /// </summary>

        public static bool IsNumeric(string numericStr)

        {
            return _numericregex.IsMatch(numericStr);
        }

        /// <summary>

        /// 是否为邮政编码

        /// </summary>

        public static bool IsZipCode(string s)

        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            return _zipcoderegex.IsMatch(s);
        }

        /// <summary>

        /// 是否是图片文件名

        /// </summary>

        /// <returns> </returns>

        public static bool IsImgFileName(string fileName)

        {
            if (fileName.IndexOf(".") == -1)
            {
                return false;
            }

            string tempFileName = fileName.Trim().ToLower();

            string extension = tempFileName.Substring(tempFileName.LastIndexOf("."));

            return extension == ".png" || extension == ".bmp" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif";
        }

        /// <summary>

        /// 判断一个ip是否在另一个ip内

        /// </summary>

        /// <param name="sourceIP">检测ip</param>

        /// <param name="targetIP">匹配ip</param>

        /// <returns></returns>

        public static bool InIP(string sourceIP, string targetIP)

        {
            if (string.IsNullOrEmpty(sourceIP) || string.IsNullOrEmpty(targetIP))
            {
                return false;
            }

            string[] sourceIPBlockList = sourceIP.Split(@".");

            string[] targetIPBlockList = targetIP.Split(@".");

            int sourceIPBlockListLength = sourceIPBlockList.Length;

            for (int i = 0; i < sourceIPBlockListLength; i++)

            {
                if (targetIPBlockList[i] == "*")
                {
                    return true;
                }

                if (sourceIPBlockList[i] != targetIPBlockList[i])

                {
                    return false;
                }
                else

                {
                    if (i == 3)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>

        /// 判断一个ip是否在另一个ip内

        /// </summary>

        /// <param name="sourceIP">检测ip</param>

        /// <param name="targetIPList">匹配ip列表</param>

        /// <returns></returns>

        public static bool InIPList(string sourceIP, string[] targetIPList)

        {
            if (targetIPList != null && targetIPList.Length > 0)

            {
                foreach (string targetIP in targetIPList)

                {
                    if (InIP(sourceIP, targetIP))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>

        /// 是否是数值(包括整数和小数)

        /// </summary>

        public static bool IsNumericArray(string[] numericStrList)

        {
            if (numericStrList != null && numericStrList.Length > 0)

            {
                foreach (string numberStr in numericStrList)

                {
                    if (!IsNumeric(numberStr))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>

        /// 是否是数值(包括整数和小数)

        /// </summary>

        public static bool IsNumericRule(string numericRuleStr, string splitChar)

        {
            return IsNumericArray(numericRuleStr.Split(splitChar));
        }

        /// <summary>

        /// 是否是数值(包括整数和小数)

        /// </summary>

        public static bool IsNumericRule(string numericRuleStr)

        {
            return IsNumericRule(numericRuleStr, ",");
        }
    }
}