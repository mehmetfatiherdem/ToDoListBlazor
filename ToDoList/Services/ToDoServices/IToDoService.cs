using ToDoList.DTO;

namespace ToDoList.Services.ToDoServices
{
    public interface IToDoService
    {
        public List<ToDoItemDto> ToDoItemDtos { get; set; }
        Task GetToDoItems();
        Task<ToDoItemDto> GetToDoItem(int id);
        Task CreateToDoItem(ToDoItemDto item);
        Task UpdateToDoItem(ItemDto toDoItem);
        Task DeleteToDoItem(int id);

    }
}
