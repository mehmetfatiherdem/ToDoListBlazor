using ToDoList.DTO;
using ToDoList.model;

namespace ToDoList.Services.DoneServices
{
    public interface IDoneService
    {
        public List<DoneItemDto> DoneItemDtos { get; set; }
        Task GetDoneItems();
        Task <DoneItemDto> GetDoneItem(int id);

        Task CreateDoneItem(DoneItemDto item);
        Task UpdateDoneItem(ItemDto doneItem);
        Task DeleteDoneItem(int id);
    }
}
