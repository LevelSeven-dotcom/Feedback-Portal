using FeedbackModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedbackModel.Domain.Repositories
{
    public class FeedbackRepository
    {
        // Static list to store feedback temporarily
        public static List<Feedback> _feedbacks = new List<Feedback>
        {
            new Feedback { Id = 1, StudentName = "John", Course = "Math", Rating = 5, DateSubmitted = DateTime.Now },
            new Feedback { Id = 2, StudentName = "Alice", Course = "Science", Rating = 4, DateSubmitted = DateTime.Now }
        };

        // Get all feedbacks
        public List<Feedback> GetAll()
        {
            return _feedbacks;
        }

        // Get feedback by ID
        public Feedback GetById(int id)
        {
            return _feedbacks.FirstOrDefault(f => f.Id == id);
        }

        //add new feedback
        public void Add(Feedback feedback)
        {
            feedback.Id = _feedbacks.Count > 0 ? _feedbacks.Max(f => f.Id) + 1 : 1;
            feedback.DateSubmitted = DateTime.Now;
            _feedbacks.Add(feedback);

            // Log the list of all feedbacks to confirm the new feedback is added
            Console.WriteLine("All Feedbacks after add:");
            foreach (var f in _feedbacks)
            {
                Console.WriteLine($"{f.StudentName} - {f.Course}");
            }
        }


        // Update existing feedback
        public void Update(Feedback feedback)
        {
            var existingFeedback = _feedbacks.FirstOrDefault(f => f.Id == feedback.Id);
            if (existingFeedback != null)
            {
                existingFeedback.StudentName = feedback.StudentName;
                existingFeedback.Course = feedback.Course;
                existingFeedback.Rating = feedback.Rating;
                existingFeedback.Feedbacks= feedback.Feedbacks;
            }
        }

        // Delete feedback by ID
        public void Delete(int id)
        {
            var feedback = _feedbacks.FirstOrDefault(f => f.Id == id);
            if (feedback != null)
            {
                _feedbacks.Remove(feedback);
            }
        }
    }
}
