namespace ToDoList.DTO
{
    public class DoingItemDto : ItemDto
    {
        public DoingItemDto(string text) : base(text)
        {
        }

        public DoingItemDto(string text, int id) : base(text, id)
        {
        }
    }

}
