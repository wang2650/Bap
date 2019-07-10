using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.User
{
    public class GetUsersRefRoleInput
    {
        public int RoleId { get; set; } = 0;


        public string Name { get; set; } = "";

        public PageInput Page { get; set; }
    }
    public class GetUsersRefRoleInputModelValidation : AbstractValidator<GetUsersRefRoleInput>
    {
        public  GetUsersRefRoleInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("角色id不可为空").GreaterThan(0).WithMessage("角色id必须大于0");
            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
