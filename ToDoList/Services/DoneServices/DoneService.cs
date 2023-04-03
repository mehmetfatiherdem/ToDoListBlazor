using ToDoList.model;
using static System.Net.WebRequestMethods;

namespace ToDoList.Services.DoneServices
{
    public class DoneService : IDoneService
    {
        private readonly HttpClient _http;

        public DoneService(HttpClient http)
        {
            this._http = http;
        }
        public List<DoneItem> DoneItems { get; set; } = new List<DoneItem>();
        public async Task GetDoneItems()
        {
            var res = await _http.GetFromJsonAsync<List<DoneItem>>("api/done");
            if (res != null) DoneItems = res;
        }

        public async Task<DoneItem> GetDoneItem(int id)
        {
            var res = await _http.GetFromJsonAsync<DoneItem>($"api/done/{id}");
            if (res != null) return res;
            throw new Exception("No done item found.");
        }

        public async Task CreateDoneItem(DoneItem item)
        {
            var result = await _http.PostAsJsonAsync("api/done", item);
            //TODO: move these to a common method to avoid duplication
            var res = await result.Content.ReadFromJsonAsync<List<DoneItem>>();
            if (res != null) DoneItems = res;
        }

        public async Task UpdateDoneItem(DoneItem doneItem)
        {
            var result = await _http.PutAsJsonAsync($"api/done/{doneItem.Id}", doneItem);
            var res = await result.Content.ReadFromJsonAsync<List<DoneItem>>();
            if (res != null) DoneItems = res;
        }

        public async Task DeleteDoneItem(int id)
        {
            var result = await _http.DeleteAsync($"api/done/{id}");
            var res = await result.Content.ReadFromJsonAsync<List<DoneItem>>();
            if (res != null) DoneItems = res;
        }
    }
}
