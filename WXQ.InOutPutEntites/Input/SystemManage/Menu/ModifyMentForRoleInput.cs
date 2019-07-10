using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Menu
{
    public class ModifyMentForRoleInput
    {
        public int RoleId { get; set; }
        public List<int> MenuIds { get; set; } = new List<int>();
    }



    public class ModifyMentForRoleInputModelValidation : AbstractValidator<ModifyMentForRoleInput>
    {
        public ModifyMentForRoleInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
     
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("角色id不能为空").GreaterThanOrEqualTo(0).WithMessage("角色id大于0");



        }

    }
}
