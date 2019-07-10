using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.User
{
    public class GetUsersRefDepartmentInput
    {


        public int departmentId { get; set; } =0;


        public string Name { get; set; } = "";

        public PageInput Page { get; set; }
    }


    public class GetUsersRefDepartmentInputModelValidation : AbstractValidator<GetUsersRefDepartmentInput>
    {
        public GetUsersRefDepartmentInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.departmentId).NotEmpty().WithMessage("部门id不可为空").GreaterThan(1).WithMessage("部门id必须大于0");
            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }











}
