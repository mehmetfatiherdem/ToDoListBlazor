using ToDoList.DTO;
using ToDoList.model;

namespace ToDoList.Services.DoingServices
{
    public interface IDoingService
    {
        public List<DoingItemDto> DoingItemDtos { get; set; }

        Task GetDoingItems();
        Task<DoingItemDto> GetDoingItem(int id);

        Task CreateDoingItem(DoingItemDto item);
        Task UpdateDoingItem(ItemDto doingItem);
        Task DeleteDoingItem(int id);
    }
}
