using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class DataBaseContext : DbContext
    {
        public DbSet<ToDo> ToDO => Set<ToDo>();

        public DataBaseContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source =ToDo.db");
    }
}
