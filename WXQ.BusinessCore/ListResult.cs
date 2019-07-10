using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace WXQ.BusinessCore
{
    public class ListResult<T> where T : class, new()
    {


        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int Total{get;set;}=0;


        public List<T> Result  { get; set; } =null;




    }
}
