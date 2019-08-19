using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Role
{
    public class UpdateRoleInput
    {

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Description { get; set; }



    }
    public class UpdateRoleInputModelValidation : AbstractValidator<UpdateRoleInput>
    {
        public UpdateRoleInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("角色id不能为空");
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("角色名不能为空").Length(2, 20).WithMessage("角色名长度要大于1位");



        }

    }
}
