using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Topic { get; set; }
        public bool isModify { get; set; } = false;
        public bool isDone { get; set; } = false;
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public DateTime DateOfModification { get; set; } = DateTime.Now;
        public DateTime DateOfDone { get; set; }
        public bool isArchived { get; set; }

        public ToDo()
        {

        }

        public ToDo(string username, string topic)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException($"\"{nameof(username)}\" не может быть неопределенным или пустым.", nameof(username));
            }

            if (string.IsNullOrEmpty(topic))
            {
                throw new ArgumentException($"\"{nameof(topic)}\" не может быть неопределенным или пустым.", nameof(topic));
            }

            Username = username;
            Topic = topic;
        }

        override public string ToString()
        {
            return $"{Id} {Username} {Topic} {isDone} {DateOfCreation} {DateOfModification} {DateOfDone}";
        }
    }
}
