using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input.configmanager.Dict
{
  public  class GetDictListInput
    {


        public string GroupName { get; set; } = "";
        public PageInput Page { get; set; }
    }



    public class GetDictListInputModelValidation : AbstractValidator<GetDictListInput>
    {
        public GetDictListInputModelValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Page.PageIndex).NotEmpty().WithMessage("页索引不能为空");
            RuleFor(x => x.Page.PageSize).NotEmpty().WithMessage("页大小不能为空");


        }

    }
}
