using ToDoList.model;

namespace ToDoList.Services.DoingServices
{
    public interface IDoingService
    {
        public List<DoingItem> DoingItems { get; set; }

        Task GetDoingItems();
        Task<DoingItem> GetDoingItem(int id);

        Task CreateDoingItem(DoingItem item);
        Task UpdateDoingItem(DoingItem doingItem);
        Task DeleteDoingItem(int id);
    }
}
