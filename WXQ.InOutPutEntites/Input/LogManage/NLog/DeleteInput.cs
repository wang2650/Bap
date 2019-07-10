using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.LogManage.NLog
{
  public  class DeleteInput
    {
        public string application { get; set; }

        public string level { get; set; }
        public string message { get; set; }
        public DateTime bgDt { get; set; } = DateTime.Now.AddDays(2);
        public DateTime endDt { get; set; } = DateTime.Now;
        public string Logger { get; set; }
        public string CallSite { get; set; }

    }



    public class DeleteInputModelValidation : AbstractValidator<DeleteInput>
    {
        public DeleteInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

   


        }

    }
}
