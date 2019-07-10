using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.LogManage.Metrics
{
    public class GetMetricsListInput
    {


        public string MethodName { get; set; } = "";
        public int CostTime { get; set; } = 0;
        public DateTime BgDt { get; set; } = DateTime.Now.AddDays(2);
        public DateTime EndDt { get; set; } = DateTime.Now;






        public PageInput Page { get; set; }
    }



    public class GetMetricsListInputModelValidation : AbstractValidator<GetMetricsListInput>
    {
        public GetMetricsListInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
