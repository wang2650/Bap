using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Role
{

    public class AddUserForRoleInput
    {
        public int RoleId { get; set; }

        public List<int> UserIds { get; set; }


    }



    public class AddUserForRoleInputModelValidation : AbstractValidator<AddUserForRoleInput>
    {
        public AddUserForRoleInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("角色id不能为空").GreaterThanOrEqualTo(0).WithMessage("角色id大于等于0");
            RuleFor(x => x.UserIds.Count).GreaterThan(0).WithMessage("用户id不可为空");


        }

    }

}
