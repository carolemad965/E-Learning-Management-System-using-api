using E_Learning_Management_System.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Management_System.Models
{
    public class Content : IDeletable
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string videoPathURL { get; set; }
        public string content { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        [ForeignKey("Learner")]
        public int? LearnerId { get; set; }
        public Learner? Learner { get; set; }
        [ForeignKey("Adminstrator")]
        public int? AdminstratorId { get; set; }
        public Adminstrator? Adminstrator { get; set; }
    }
}