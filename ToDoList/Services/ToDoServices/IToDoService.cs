using ToDoList.model;

namespace ToDoList.Services.ToDoServices
{
    public interface IToDoService
    {
        public List<ToDoItem> ToDoItems { get; set; }
        Task GetToDoItems();
        Task<ToDoItem> GetToDoItem(int id);
        Task CreateToDoItem(ToDoItem item);
        Task UpdateToDoItem(ToDoItem toDoItem);
        Task DeleteToDoItem(int id);

    }
}
