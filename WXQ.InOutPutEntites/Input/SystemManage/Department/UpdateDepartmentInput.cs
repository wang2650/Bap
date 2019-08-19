using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Department
{
 public    class UpdateDepartmentInput
    {

        public int DepartmentId { get; set; }
        public int ParentId { get; set; }

        /// <summary>
        /// Desc:部门名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DepartmentName { get; set; }

        /// <summary>
        /// Desc:描述
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Description { get; set; }







    }




    public class UpdateDepartmentInputValidation : AbstractValidator<UpdateDepartmentInput>
    {
        public UpdateDepartmentInputValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage("部门名不能为空");

            RuleFor(x => x.ParentId).NotEmpty().WithMessage("上级id不能为空").GreaterThanOrEqualTo(0).WithMessage("上级id大于等于0");

            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("部门id不能为空").GreaterThanOrEqualTo(0).WithMessage("部门id大于等于0");

        }

    }









}
