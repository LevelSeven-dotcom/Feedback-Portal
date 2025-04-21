using Microsoft.EntityFrameworkCore;
using FeedbackModel.Domain.Entities;
using System.Collections.Generic;

namespace FeedbackModel.Data
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options) { }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}