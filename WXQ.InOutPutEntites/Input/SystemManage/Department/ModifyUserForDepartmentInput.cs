using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Department
{
    public class ModifyUserForDepartmentInput
    {
        public int DepartmentId { get; set; }

        public List<int> UserIds { get; set; }


    }



    public class ModifyUserForDepartmentInputModelValidation : AbstractValidator<ModifyUserForDepartmentInput>
    {
        public ModifyUserForDepartmentInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("部门id不能为空").GreaterThanOrEqualTo(0).WithMessage("部门id大于等于0");
            RuleFor(x => x.UserIds.Count).GreaterThan(0).WithMessage("用户id不可为空");


        }

    }




}
