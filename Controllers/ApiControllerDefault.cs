using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using TODOList.Controllers;

namespace ToDoList.Controllers
{
    public class ApiControllerDefault : ControllerBase
    {
        [AcceptVerbs("GET")]
        [Route("GET/{Username}")]
        public IEnumerable<ToDo> GET(string Username)
        {
            var DbController = new DataBaseController();
            return DbController.Load().Where(x => x.Username == Username);
        }

        [HttpPost]
        public ToDo POST([FromBody]ToDo toDo) 
        {
            var dbController = new DataBaseController();

            dbController.Save(toDo);
            return toDo;
        }

        [Route("DELETE/{Id}")]
        public bool DELETE(int Id)
        {
            var DbController = new DataBaseController();
            DbController.Remove(Id);

            if (DbController.Find(Id) == null)
            {
                return true;
            }
            else
                return false;
        }

        [Route("Done/{Id}")]
        public bool Done(int Id)
        {            
            var DBController = new DataBaseController();
            var toDo = DBController.Find(Id);

            if (toDo.isDone)
            {
                toDo.isDone = false;
                toDo.DateOfModification = DateTime.Now;
            }
            else if (!toDo.isDone)
            {
                toDo.isDone = true;
                toDo.DateOfDone = DateTime.Now;
            }

            DBController.Update(toDo);
            return toDo.isDone;
        }

        [Route("Archivate/{Id}")]
        public bool Archivate(int Id)
        {
            var DBController = new DataBaseController();
            var toDo = DBController.Find(Id);

            toDo.isArchived = true;
            DBController.Update(toDo);
            return toDo.isArchived;
        }
    }
}
