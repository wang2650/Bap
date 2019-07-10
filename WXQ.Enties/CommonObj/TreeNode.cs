using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.CommonObj
{
   public class TreeNode
    {

        public int id { get; set; }


        public string label { get; set; }


        public List<TreeNode> children { get; set; }

        public int ParentId { get; set; }

    }
}
