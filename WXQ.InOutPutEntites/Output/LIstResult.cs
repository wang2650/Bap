using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Output
{
 public   class LIstResult <T> where T : class, new()
    {
        public LIstResult(List<T> t , PageModel p)
        {
            this.List = t;
            this.Page = p;
        }


        public List<T> List { get; set; }


        public SqlSugar.PageModel Page { get; set; }




    }
}
