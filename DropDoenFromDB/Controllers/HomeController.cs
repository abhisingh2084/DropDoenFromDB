using DropDoenFromDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DropDoenFromDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly CodeFirstDbContext context;

        public HomeController(CodeFirstDbContext context)
        {
            this.context = context;
        }

        private StudentModel BindDDL()
        {
            StudentModel stdModel = new StudentModel();
            stdModel.StudentList = new List<SelectListItem>();

            stdModel.StudentList.Add(new SelectListItem
            {
                Text = "Select Name",
                Value = ""
            });

            var data = context.Students.ToList();
            foreach (var item in data)
            {
                stdModel.StudentList.Add(new SelectListItem
                {
                    Text = item.StudentName,
                    Value = item.Id.ToString()
                });
            }
            return stdModel;
        }

        public IActionResult Index()
        {
            var std = BindDDL();
            return View(std);
        }
        [HttpPost]
        public IActionResult Index(StudentModel std)
        {
            
            var student = context.Students.Where(x => x.Id == std.Id).FirstOrDefault();
            if(student != null)
            {
                ViewBag.Selectedvalue = student.StudentName;
            }
            var mystudent = BindDDL();
            return View(mystudent);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
