using Microsoft.AspNetCore.Mvc;
using StudentHub.Models;

namespace StudentHub.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                StudentId = 1,
                FirstName = "John",
                LastName = "Smith",
                EnrollmentDate = new DateTime(2026, 1, 15),
                AcceptedCodeOfConduct = true
            },

            new Student
            {
                StudentId = 2,
                FirstName = "Sarah",
                LastName = "Jones",
                EnrollmentDate = new DateTime(2026, 1, 20),
                AcceptedCodeOfConduct = true
            },

            new Student
            {
                StudentId = 3,
                FirstName = "David",
                LastName = "Brown",
                EnrollmentDate = new DateTime(2026, 2, 3),
                AcceptedCodeOfConduct = false
            }
        };

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

       

        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            student.StudentId = students.Max(s => s.StudentId) + 1;

            students.Add(student);

             TempData["SuccessMessage"] =
                 $"{student.FirstName} {student.LastName} was added successfully.";

            return RedirectToAction("Index");
        }

        public IActionResult PlainText()
        {
            return Content("Just some text, no view involved.");
        }

        public IActionResult AsJson()
        {
            return Json(students);
        }

        public IActionResult ForceNotFound()
        {
            return NotFound();
        }

        public IActionResult ForceBadRequest()
        {
            return BadRequest("Something about this request was invalid.");
        }

        public IActionResult GoToIndex()
        {
            return RedirectToAction("Index");
        }

        public IActionResult GoToGoogle()
        {
            return Redirect("https://www.google.com");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            var existing = students.FirstOrDefault(
                s => s.StudentId == student.StudentId);

            if (existing == null)
            {
                return NotFound();
            }

            existing.FirstName = student.FirstName;
            existing.LastName = student.LastName;
            existing.EnrollmentDate = student.EnrollmentDate;
            existing.AcceptedCodeOfConduct = student.AcceptedCodeOfConduct;

            TempData["SuccessMessage"] =
                $"{existing.FirstName} {existing.LastName} was updated.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);

            if (student != null)
            {
                students.Remove(student);

                TempData["SuccessMessage"] = "Student deleted.";
            }

            return RedirectToAction("Index");
        }
    }
}