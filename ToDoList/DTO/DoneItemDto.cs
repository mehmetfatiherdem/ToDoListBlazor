﻿namespace ToDoList.DTO
{
    public class DoneItemDto : ItemDto
    {
        public DoneItemDto(string text) : base(text)
        {
        }

        public DoneItemDto(string text, int id) : base(text, id)
        {
        }
    }
}
