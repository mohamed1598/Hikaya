namespace hikaya.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StoryPlot")]
    public partial class StoryPlot
    {
        public int id { get; set; }

        public int? storyid { get; set; }

        [StringLength(50)]
        public string imageUrl { get; set; }

        public string text { get; set; }

        public int? sort { get; set; }

        public virtual Story Story { get; set; }
    }
}
