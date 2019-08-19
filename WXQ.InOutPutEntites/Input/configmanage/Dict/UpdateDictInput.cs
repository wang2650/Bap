using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.configmanager.Dict
{
    public class UpdateDictInput
    {
        public int DictId { get; set; }
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


    public class UpdateDictInputModelValidation : AbstractValidator<UpdateDictInput>
    {
        public UpdateDictInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.DictId).NotEmpty().WithMessage("id不能为空").GreaterThanOrEqualTo(1).WithMessage("id要大于0"); ;
            RuleFor(x => x.DictKey).NotEmpty().WithMessage("key不能为空");
         
            RuleFor(x => x.GroupName).NotEmpty().WithMessage("组名不能为空");


        }

    }
}
