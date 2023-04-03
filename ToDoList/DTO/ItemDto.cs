namespace ToDoList.DTO
{
    abstract public class ItemDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public ItemDto()
        {

        }

        public ItemDto(string text)
        {
            Text = text;
        }

        public ItemDto(string text, int id)
        {
            Text = text;
            Id = id;
        }
    }
}
