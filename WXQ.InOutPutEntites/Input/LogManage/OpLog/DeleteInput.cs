using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.LogManage.OpLog
{
    public class DeleteInput
    {

        public string methodName { get; set; }
        public int opUserId { get; set; }
        public DateTime bgDt { get; set; } = DateTime.Now.AddDays(2);
        public DateTime endDt { get; set; } = DateTime.Now;

        public string Ip { get; set; }








    }



    public class  DeleteInputModelValidation : AbstractValidator<DeleteInput>
    {
        public DeleteInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;



        }

    }
}
