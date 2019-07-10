using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.User
{
    public class GetUserListInput
    {

        public byte RsState { get; set; } = 0;

        public string UserName { get; set; } = "";

        public PageInput Page { get; set; }



    }







    public class GetUserListInputModelValidation : AbstractValidator<GetUserListInput>
    {
        public GetUserListInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
