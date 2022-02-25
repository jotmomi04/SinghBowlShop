using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SinghBowlShop.Models
{
    public class BowlTypeViewModel
    {
        public List<BowlMaker> BowlMakers { get; set; }
        public SelectList Type { get; set; }
        public string BowlType { get; set; }
        public string SearchString { get; set; }


    }
}