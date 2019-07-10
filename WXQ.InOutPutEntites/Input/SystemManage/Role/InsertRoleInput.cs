using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Role
{
   public class InsertRoleInput
    {
        public string RoleName { get; set; }

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
        public int DepartmentId { get; set; }

    }
    public class InsertRoleInputModelValidation : AbstractValidator<InsertRoleInput>
    {
        public InsertRoleInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("部门id不能为空");
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("角色名不能为空").Length(2, 20).WithMessage("角色名长度要大于1位");



        }

    }

}




