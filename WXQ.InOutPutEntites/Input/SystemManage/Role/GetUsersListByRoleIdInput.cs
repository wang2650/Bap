using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Role
{
    public class GetUsersListByRoleIdInput
    {
        public int RoleId { get; set; } = 0;

        public PageInput Page { get; set; }
    }
    public class GetUsersListByRoleIdInputModelValidation : AbstractValidator<GetUsersListByRoleIdInput>
    {
        public GetUsersListByRoleIdInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("角色id不能为空").GreaterThan(0).WithMessage("角色id必须大于0");
            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
