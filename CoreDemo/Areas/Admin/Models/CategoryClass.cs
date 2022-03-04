using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Models
{
    public class CategoryClass
    {
        //Her bir kategoride kaç tane blog var bu bilgiyi tutan class
        public int categoryCount { get; set; }//Kategorinin kaç tane blog değeri olduğunu tutsun
        public string categoryName { get; set; }

    }
}
