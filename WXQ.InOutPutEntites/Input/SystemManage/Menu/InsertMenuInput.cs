using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Menu
{
    public class InsertMenuInput
    {

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string MenuName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Description { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int ParentId { get; set; }


        /// <summary>
        /// Desc:菜单类型
        /// Default:1
        /// Nullable:True
        /// </summary>           
        public byte MenuType { get; set; }

        /// <summary>
        /// Desc:链接地址
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Url { get; set; }

    }

    public class InsertMenuInputModelValidation : AbstractValidator<InsertMenuInput>
    {
        public InsertMenuInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.MenuName).NotEmpty().WithMessage("菜单名不能为空");
            RuleFor(x => x.Url).NotEmpty().WithMessage("链接地址不能为空");
            RuleFor(x => x.MenuType).NotEmpty().WithMessage("菜单类型不能为空");
            RuleFor(x => x.ParentId).NotEmpty().WithMessage("上级id不能为空").GreaterThanOrEqualTo(0).WithMessage("上级id大于0");



        }

    }
}
