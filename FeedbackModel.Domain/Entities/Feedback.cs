using System;
using System.ComponentModel.DataAnnotations;

namespace FeedbackModel.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string Course { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string Feedbacks { get; set; }
    }
}
