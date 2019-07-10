using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.BusinessCore
{
  public  class OpBase
    {
        public OpBase(int userId)
        {
            this.OpUserId = userId;
        }

        public int OpUserId { get; set; } = 0;

    }
}
