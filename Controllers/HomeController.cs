using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace TODOList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult ToDoPage()
        {
            return View(new List<ToDo>());
        }

        [HttpPost]
        public IActionResult ToDoPage(string Username, string ToDoTopic, string action)
        {
            if (action == "Add")
            {
                if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(ToDoTopic))
                {
                    new DataBaseController().Save(new ToDo(Username, ToDoTopic));
                    return View(Load(Username));

                }
                return View(Load(Username));
            }
            else if (action == "Synchronize")
            {
                if (!string.IsNullOrWhiteSpace(Username))
                {
                    return View(Load(Username));
                }
            }

            return View("ToDoPage", new List<ToDo>());
        }

        public IActionResult Archivate(int Id)
        {
            var DBController = new DataBaseController();
            var toDo = DBController.Find(Id);

            toDo.isArchived = true;
            DBController.Update(toDo);
            return View("ToDoPage", Load(toDo.Username));
        }

        public IActionResult Done(int Id)
        {
            var DBController = new DataBaseController();
            var toDo = DBController.Find(Id);

            if (toDo.isDone)
            {
                toDo.isDone = false;
                toDo.DateOfModification = DateTime.Now;
                toDo.isModify = true;
            }
            else if(!toDo.isDone)
            {
                toDo.isDone = true;
                toDo.DateOfDone = DateTime.Now;

            }

            toDo.DateOfDone = DateTime.Now;
            DBController.Update(toDo);
            return View("ToDoPage", Load(toDo.Username));
        }

        public IActionResult Delete(int Id)
        {
            var DBController = new DataBaseController();

            var toDo = DBController.Find(Id).Username;
            DBController.Remove(Id);
            return View("ToDoPage", Load(toDo));
        }

        private List<ToDo> Load(string Username)
        {
            return new DataBaseController().Load().Where(toDo => toDo.Username == Username).ToList();
        }
    }
}