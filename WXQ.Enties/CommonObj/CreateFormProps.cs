using System;
using System.Linq;
using System.Text;
using SqlSugar;
namespace WXQ.Enties.CommonObj
{
   
  public  class CreateFormProps 
    {


        public CreateFormProps()
        {


        }

        /// <summary>
        ///说明:
        /// </summary>           
     public string Remark { get; set; } = string.Empty;

        /// <summary>
        /// 参数
        /// </summary>           
        public string Para { get; set; } = string.Empty;

        /// <summary>
        /// 类型
        /// </summary>           
  public string ParaType { get; set; } = string.Empty;



        /// <summary>
        /// 可选值
        /// </summary>           
   public string CanSelectValue { get; set; } = string.Empty;



        /// <summary>
        /// 默认值
        /// </summary>           
      public string DefaultValue { get; set; } = string.Empty;




    }
}
