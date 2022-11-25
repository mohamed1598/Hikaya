using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hikaya.Models;
namespace hikaya.Models
{
    public class SavedStoriesAndUsers
    {
        public List<SavedStory> saveds { get; set; }
        public List<Story> stories { get; set; }
        public List<User> users { get; set; }
    }
}