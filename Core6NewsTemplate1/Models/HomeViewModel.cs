using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebOS.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Course> Courses { get; set; } 
        public IEnumerable<CoursePackage> CoursePackages { get; set; } 
        public IEnumerable<Testimonial> Testimonials { get; set; } 
        public IEnumerable<BlogPost> BlogPosts { get; set; } 
        public IEnumerable<BlogPost> MostReadPosts { get; set; } 
        public SystemSettings SystemSettings { get; set; } 
    }
}
