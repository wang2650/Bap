using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.LogManage.NLog
{
    public class GetNLogListInput
    {
        public string application { get; set; }

        public string level { get; set; }
        public string message { get; set; }
        public DateTime bgDt { get; set; } = DateTime.Now.AddDays(2);
        public DateTime endDt { get; set; } = DateTime.Now;
        public string Logger { get; set; }
        public string CallSite { get; set; }




        public PageInput Page { get; set; }
    }



    public class GetNLogListInputModelValidation : AbstractValidator<GetNLogListInput>
    {
        public GetNLogListInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
