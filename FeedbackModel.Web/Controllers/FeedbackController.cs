using FeedbackModel.Domain.Entities;
using FeedbackModel.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackModel.Web.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly FeedbackRepository _repository;

        public FeedbackController()
        {
            _repository = new FeedbackRepository();  // instantiate repository
        }

        // Action for the Index page
        public IActionResult Index()
        {
            var feedbacks = _repository.GetAll();  // Fetch feedback data
            return View(feedbacks);  // Pass data to the view
        }

        // Create (GET): Show the form to create new feedback
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feedback feedback)
        {
            // Log received feedback data
            Console.WriteLine($"Received Feedback: {feedback.StudentName}, {feedback.Course}, {feedback.Rating}");

            if (ModelState.IsValid)
            {
                _repository.Add(feedback);
                return RedirectToAction(nameof(Index));
            }

            // Log invalid model state
            Console.WriteLine("Model state is invalid.");
            return View(feedback);
        }


        // Edit (GET): Show form to edit feedback based on ID
        public IActionResult Edit(int id)
        {
            var feedback = _repository.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // Edit (POST): Handle form submission for editing feedback
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.Update(feedback);
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        // Delete (GET): Show confirmation to delete feedback
        public IActionResult Delete(int id)
        {
            var feedback = _repository.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // DeleteConfirmed (POST): Handle actual deletion of feedback
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
