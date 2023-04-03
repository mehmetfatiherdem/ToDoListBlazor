namespace ToDoList.DTO
{
    public class ToDoItemDto : ItemDto
    {
        public ToDoItemDto(string text) : base(text)
        {

        }

        public ToDoItemDto(string text, int id) : base(text, id)
        {
        }

    }
}
