using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.User
{
   public class ResetPasswordInput
    {

    public  int UserId { get; set; }

}


public class ResetPasswordInputModelValidation : AbstractValidator<ResetPasswordInput>
{
    public ResetPasswordInputModelValidation()
    {
        CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.UserId).NotEmpty().WithMessage("用户名Id不能为空");



    }

}

}
