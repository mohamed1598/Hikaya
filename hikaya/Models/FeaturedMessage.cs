namespace hikaya.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeaturedMessage")]
    public partial class FeaturedMessage
    {
        public FeaturedMessage()
        {
            date = DateTime.Now;
        }
        public int id { get; set; }

        [StringLength(300)]
        public string text { get; set; }

        public DateTime? date { get; set; }

        public int? storyid { get; set; }

        public int? userid { get; set; }

        public virtual Story Story { get; set; }

        public virtual User User { get; set; }
    }
}
