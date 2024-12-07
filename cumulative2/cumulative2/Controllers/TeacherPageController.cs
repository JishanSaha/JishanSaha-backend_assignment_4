using Microsoft.AspNetCore.Mvc;
using cumulative2.Models;
namespace cumulative2.Controllers
{
    public class TeacherPageController : Controller
    {
        private readonly TeacherAPIController _api;

        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }

        //GET : TeacherPage/List/SearchKey={SearchKey}
        [HttpGet]
        public IActionResult List(string SearchKey)
        {
            List<Teacher> Teachers = _api.ListTeachers(SearchKey);
            return View(Teachers);
        }

        //GET : AuthorPage/Show/{id}
        [HttpGet]
        public IActionResult Show(int id)
        {
            Teacher SelectedAuthor = _api.FindTeacher(id);
            return View(SelectedAuthor);
        }
        // GET : TeacherPage/New
        [HttpGet]
        public IActionResult New(int id)
        {
            return View();
        }
        public IActionResult Create(Teacher NewTeacher)
        {
            int TeacherId = _api.AddTeacher(NewTeacher);

            // redirects to "Show" action on "Teacher" cotroller with id parameter supplied
            return RedirectToAction("Show", new { id = TeacherId });
        }
        // GET : TeacherPage/Delete/{id}
        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            Teacher SelectedAuthor = _api.FindTeacher(id);
            return View(SelectedAuthor);
        }

        // POST: AuthorPage/Delete/{id}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            int AuthorId = _api.DeleteTeacher(id);
            // redirects to list action
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Del()
        {
            return View();
        }
    }
}
