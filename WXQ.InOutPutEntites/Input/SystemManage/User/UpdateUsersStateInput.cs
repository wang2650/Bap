using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.User
{






    public class UpdateUsersStateInput
    {
        public int ID { get; set; }

        /// <summary>
        /// Desc:版本号
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int RowVersion { get; set; }

        public byte RsState { get; set; }

    }


    public class UpdateUsersStateInputModelValidation : AbstractValidator<UpdateUsersStateInput>
    {
        public UpdateUsersStateInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.ID).NotEmpty().WithMessage("用户id不能为空");
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("版本号不能为空");
            RuleFor(x => x.RsState).NotEmpty().WithMessage("状态值不能为空");

        }

    }

}
