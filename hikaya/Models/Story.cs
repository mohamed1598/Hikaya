namespace hikaya.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Story")]
    public partial class Story
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Story()
        {
            FeaturedMessages = new HashSet<FeaturedMessage>();
            SavedStories = new HashSet<SavedStory>();
            StoryPlots = new HashSet<StoryPlot>();
            postDate = DateTime.Now;
        }

        public int id { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string tags { get; set; }

        public DateTime? postDate { get; set; }

        public bool? isPublished { get; set; }

        public int? userid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeaturedMessage> FeaturedMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SavedStory> SavedStories { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoryPlot> StoryPlots { get; set; }
    }
}
