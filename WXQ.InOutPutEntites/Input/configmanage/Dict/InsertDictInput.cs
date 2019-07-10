using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.configmanager.Dict
{
   public class InsertDictInput
    {

        public string DictKey { get; set; }

        /// <summary>
        /// Desc:字典的值
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DictValue { get; set; }

        /// <summary>
        /// Desc:字典类型
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DictType { get; set; }

        /// <summary>
        /// Desc:排序
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public short OrderBy { get; set; } = 0;


        /// <summary>
        /// Desc:描述
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Description { get; set; }

        /// <summary>
        /// Desc:分组组名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string GroupName { get; set; }


    }


    public class InsertDictInputModelValidation : AbstractValidator<InsertDictInput>
    {
        public InsertDictInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.DictKey).NotEmpty().WithMessage("key不能为空");
            RuleFor(x => x.DictValue).NotEmpty().WithMessage("value不能为空");
            RuleFor(x => x.OrderBy).NotEmpty().WithMessage("排序不能为空");
            RuleFor(x => x.GroupName).NotEmpty().WithMessage("描述不能为空");


        }

    }



}
