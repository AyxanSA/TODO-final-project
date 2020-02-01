using System.Linq;
using System.Web.Mvc;
using ToDoFinal.MyData;
using ToDoFinal.Models;
using ToDoList.Helpers;

namespace ToDoFinal.Controllers
{

    [TodoAuth]
    public class HomeController : Controller
    {
        public int? findCategor;


        public readonly DBaza db;
        public HomeController()
        {
            db = new DBaza();
        }
        public ActionResult Index()
        {
            var userId = (int)Session["UserId"];
           
            return View(db.Categories.Where(u => u.UserId == userId).ToList());
        }


        [HttpPost]
        public ActionResult Index(string name)
        {
            var userId = (int)Session["UserId"];
            if (ModelState.IsValid)
            {
                Category ct = new Category()
                {
                    Name = name,
                    UserId = userId
                };
                db.Categories.Add(ct);
                db.SaveChanges();
                return PartialView("~/Views/Partial/AddList.cshtml", ct);
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddNewTask(string taskName, int? cid)
        {

            ToDos td = new ToDos()
            {
                CategoryId = (int)cid,
                Tittle = taskName
            };

            db.ToDos.Add(td);
            db.SaveChanges();

             return PartialView("~/Views/Partial/AddTask.cshtml", td);
        }
       
        public ActionResult DeleteToDos(int? tid)
        {
            if (tid != null)
            {
                var findToDo = db.ToDos.Find(tid);
                findToDo.IsDeleted = true;
                db.SaveChanges();
                return PartialView("~/Views/Partial/DeletedTask.cshtml", findToDo);
            }

            return View("Index");
        }
        public ActionResult RemoveToDos(int? tid)
        {
            var findCategory = db.Categories.Find(tid);
            var findToDos = db.ToDos.Where(e => e.CategoryId == tid).ToList();
            if (findCategory.isDeleted == true)
            {
                foreach (var Todo in findToDos)
                {
                    db.ToDos.Remove(Todo);
                    db.SaveChanges();
                }
              
            };
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteCategory(int? cid)
        {
            if(cid != null)
            {
                var findCategory = db.Categories.Find(cid);
                findCategory.isDeleted = true;
                db.SaveChanges();
                
            }
            findCategor = cid;
            return RedirectToAction("Index", "Home");
        }

    }
}