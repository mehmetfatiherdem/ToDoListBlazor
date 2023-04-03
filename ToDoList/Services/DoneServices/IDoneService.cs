using ToDoList.model;

namespace ToDoList.Services.DoneServices
{
    public interface IDoneService
    {
        public List<DoneItem> DoneItems { get; set; }
        Task GetDoneItems();
        Task <DoneItem> GetDoneItem(int id);

        Task CreateDoneItem(DoneItem item);
        Task UpdateDoneItem(DoneItem doneItem);
        Task DeleteDoneItem(int id);
    }
}
