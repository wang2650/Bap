using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.User
{


    public class InsertInput
    {


        public string UserName { get; set; }

        public string PassWord { get; set; }

        /// <summary>
        /// Desc:介绍
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Introduction { get; set; }

        /// <summary>
        /// Desc:昵称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string NickName { get; set; }

        /// <summary>
        /// Desc:头像
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string HeadImage { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string TelePhone { get; set; } = "";

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string RelationPerson { get; set; } = "";

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Url { get; set; } = "";

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public byte UserKey { get; set; } = 0;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public byte Sex { get; set; } = 0;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short Sequence { get; set; } = 0;



        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public byte IsMustUseKey { get; set; } = 0;

    }


    public class InsertInputModelValidation : AbstractValidator<InsertInput>
    {
        public InsertInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserName).NotEmpty().WithMessage("用户名不能为空").Length(6, 20).WithMessage("用户名长度必须在6-20位之间");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("密码不能为空").Length(8, 32).WithMessage("密码长度必须8-32位之间");

            RuleFor(x => x.NickName).NotEmpty().WithMessage("昵称不能为空").Length(2, 10).WithMessage("昵称长度必须2-10位之间");
        }

    }




}
