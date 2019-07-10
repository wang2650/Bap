using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.SystemManage.Menu
{
    public class GetMenuListInput
    {
        public string MenuName { get; set; } = "";
        public string Url { get; set; } = "";

        public int ParentId { get; set; } = -1;

        public PageInput Page { get; set; }
    }
    public class GetMenuListInputModelValidation : AbstractValidator<GetMenuListInput>
    {
        public GetMenuListInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
