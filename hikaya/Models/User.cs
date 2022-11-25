namespace hikaya.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            FeaturedMessages = new HashSet<FeaturedMessage>();
            SavedStories = new HashSet<SavedStory>();
            Stories = new HashSet<Story>();
        }

        public int id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage ="*")]
        public string name { get; set; }

        [StringLength(80)]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }

        [StringLength(80)]
        [Required(ErrorMessage = "*")]
        public string password { get; set; }
        [NotMapped]
        [StringLength(80)]
        [Required(ErrorMessage = "*")]
        [Compare("password",ErrorMessage ="password not match")]
        public string confirm_password { get; set; }
        public virtual Admin Admin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeaturedMessage> FeaturedMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SavedStory> SavedStories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Story> Stories { get; set; }
    }
}
