using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.User
{




   public class LoginInput
    {


        public string UserName { get; set; }

        public string PassWord { get; set; }

    }


    public class LoginInputModelValidation : AbstractValidator<LoginInput>
    {
        public LoginInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
  
            RuleFor(x => x.UserName).NotEmpty().WithMessage("用户名不能为空").Length(6, 20).WithMessage("用户名长度必须在6-20位之间");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("密码不能为空").Length(8, 32).WithMessage("密码长度必须8-32位之间");
   

        }

    }




}
