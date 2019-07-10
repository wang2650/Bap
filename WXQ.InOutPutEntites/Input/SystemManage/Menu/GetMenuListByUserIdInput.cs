﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Menu
{
    public class GetMenuListByUserIdInput
    {
        public int UserId { get; set; } = 0;

        public PageInput Page { get; set; }
    }
    public class GetMenuListByUserIdInputModelValidation : AbstractValidator<GetMenuListByUserIdInput>
    {
        public GetMenuListByUserIdInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.UserId).NotEmpty().WithMessage("用户id不能为空").GreaterThanOrEqualTo(0).WithMessage("用户id大于0");
            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
