namespace hikaya.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SavedStory")]
    public partial class SavedStory
    {
        public SavedStory()
        {
            date = DateTime.Now;
        }
        public int id { get; set; }

        public int? storyid { get; set; }

        public int? userid { get; set; }

        public DateTime? date { get; set; }

        public virtual Story Story { get; set; }

        public virtual User User { get; set; }
    }
}
