using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.LogManage.OpLog
{
    public class GetOpLogListInput
    {


        public string methodName { get; set; }
        public int opUserId { get; set; }
        public DateTime bgDt { get; set; } = DateTime.Now.AddDays(2);
        public DateTime endDt { get; set; } = DateTime.Now;

        public string Ip { get; set; }








        public PageInput Page { get; set; }
    }



    public class GetOpLogListInputModelValidation : AbstractValidator<GetOpLogListInput>
    {
        public GetOpLogListInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
