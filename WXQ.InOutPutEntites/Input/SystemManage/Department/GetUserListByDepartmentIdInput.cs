using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Department
{
    public class GetUserListByDepartmentIdInput
    {
        public int DepartmentId { get; set; }

        public PageInput Page { get; set; }
    }



    public class GetUserListByDepartmentIdInputModelValidation : AbstractValidator<GetUserListByDepartmentIdInput>
    {
        public GetUserListByDepartmentIdInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("部门id不能为空").GreaterThanOrEqualTo(0).WithMessage("部门id大于等于0");
            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
