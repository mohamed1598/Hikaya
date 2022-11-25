using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hikaya.Models;
namespace hikaya.Models
{
    public class StoryAndPlots
    {
        public Story story { get; set; }
        public List<StoryPlot> plots { get; set; }
    }
}