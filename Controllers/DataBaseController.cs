using Microsoft.EntityFrameworkCore;
using ToDoList.Controllers;
using ToDoList.Models;

namespace TODOList.Controllers
{
    public class DataBaseController
    {
        DataBaseContext context;
        DbSet<ToDo> dbSet;

        public DataBaseController()
        {
            context = new();
            dbSet = context.Set<ToDo>();
        }

        public void Save(ToDo toDo)
        {
            dbSet.Add(toDo);
            context.SaveChanges();
        }

        public List<ToDo> Load()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public void Remove(int id)
        {
            dbSet.Remove(Find(id));
            context.SaveChanges();
        }

        public ToDo Find(int Id)
        {
            return dbSet.Find(Id);
        }

        public void Update(ToDo toDo)
        {
            dbSet.Update(toDo);
            context.SaveChanges();
        }
    }
}
