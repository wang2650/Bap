using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Role
{
   public class GetRoleListInput
    {
        public string RoleName { get; set; } = "";

        public int DepartmentId { get; set; } = 0;

        public PageInput Page { get; set; }
    }
    public class GetRoleListInputModelValidation : AbstractValidator<GetRoleListInput>
    {
        public GetRoleListInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
