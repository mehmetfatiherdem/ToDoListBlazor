using ToDoList.model;

namespace ToDoList.Services.ToDoServices
{
    public class ToDoService : IToDoService
    {
        private readonly HttpClient _http;

        public ToDoService(HttpClient http) 
        {
            this._http = http;   
        }

        public List<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
 
        public async Task GetToDoItems()
        {
            var res = await _http.GetFromJsonAsync<List<ToDoItem>>("api/todo");
            if (res != null) ToDoItems = res;
        }

        public async Task<ToDoItem> GetToDoItem(int id)
        {
            var res = await _http.GetFromJsonAsync<ToDoItem>($"api/todo/{id}");
            if(res != null) return res;
            throw new Exception("No todo item found.");
        }

        public async Task CreateToDoItem(ToDoItem item)
        {
            var result = await _http.PostAsJsonAsync("api/todo", item);
            //TODO: move these to a common method to avoid duplication
            var res = await result.Content.ReadFromJsonAsync<List<ToDoItem>>();
            if (res != null) ToDoItems = res;
        }

        public async Task UpdateToDoItem(ToDoItem toDoItem)
        {
            var result = await _http.PutAsJsonAsync($"api/todo/{toDoItem.Id}", toDoItem);
            var res = await result.Content.ReadFromJsonAsync<List<ToDoItem>>();
            if (res != null) ToDoItems = res;
        }

        public async Task DeleteToDoItem(int id)
        {
            var result = await _http.DeleteAsync($"api/todo/{id}");
            var res = await result.Content.ReadFromJsonAsync<List<ToDoItem>>();
            if (res != null) ToDoItems = res;
        }
    }
}
