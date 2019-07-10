using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Department
{
    public class GetDepartmentListInput
    {
        public int ParentId { get; set; }
        public string DepartmentName { get; set; } = "";
        public PageInput Page { get; set; }
    }



    public class GetDepartmentListInputModelValidation : AbstractValidator<GetDepartmentListInput>
    {
        public GetDepartmentListInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
