using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.LogManage.Metrics
{
    public class DeleteInput
    {
        public string MethodName { get; set; } = "";
        public int CostTime { get; set; } = 0;
        public DateTime BgDt { get; set; } = DateTime.Now.AddDays(2);
        public DateTime EndDt { get; set; } = DateTime.Now;

    }



    public class DeleteInputModelValidation : AbstractValidator<DeleteInput>
    {
        public DeleteInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

        }

    }
}
