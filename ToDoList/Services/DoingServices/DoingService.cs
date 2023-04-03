using ToDoList.model;

namespace ToDoList.Services.DoingServices
{
    public class DoingService : IDoingService
    {
        private readonly HttpClient _http;
        
        public DoingService(HttpClient http)
        {
            this._http = http;   
        }

        public List<DoingItem> DoingItems { get; set; } = new List<DoingItem>();

        public async Task GetDoingItems()
        {
            var res = await _http.GetFromJsonAsync<List<DoingItem>>("api/doing");
            if (res != null) DoingItems = res;
        }

        public async Task<DoingItem> GetDoingItem(int id)
        {
            var res = await _http.GetFromJsonAsync<DoingItem>($"api/doing/{id}");
            if(res != null) return res;
            throw new Exception("No doing item found.");
        }

        public async Task CreateDoingItem(DoingItem item)
        {
            var result = await _http.PostAsJsonAsync("api/doing", item);
            //TODO: move these to a common method to avoid duplication
            var res = await result.Content.ReadFromJsonAsync<List<DoingItem>>();
            if (res != null) DoingItems = res;
        }

        public async Task UpdateDoingItem(DoingItem doingItem)
        {
            var result = await _http.PutAsJsonAsync($"api/doing/{doingItem.Id}", doingItem);
            var res = await result.Content.ReadFromJsonAsync<List<DoingItem>>();
            if (res != null) DoingItems = res;
        }

        public async Task DeleteDoingItem(int id)
        {
            var result = await _http.DeleteAsync($"api/doing/{id}");
            var res = await result.Content.ReadFromJsonAsync<List<DoingItem>>();
            if (res != null) DoingItems = res;
        }
    }
}
