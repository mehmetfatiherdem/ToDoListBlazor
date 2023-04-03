using AutoMapper;
using ToDoList.DTO;
using ToDoList.model;

namespace ToDoList.Services.DoingServices
{
    public class DoingService : IDoingService
    {
        private readonly HttpClient _http;
        private readonly IMapper _mapper;
        public DoingService(HttpClient http, IMapper mapper)
        {
            this._http = http;
            _mapper = mapper;
        }

        public List<DoingItemDto> DoingItemDtos { get; set; } = new List<DoingItemDto>();

        public async Task GetDoingItems()
        {
            var res = await _http.GetFromJsonAsync<List<DoingItem>>("api/doing");
            if (res != null) DoingItemDtos = _mapper.Map<List<DoingItemDto>>(res);
        }

        public async Task<DoingItemDto> GetDoingItem(int id)
        {
            var res = await _http.GetFromJsonAsync<DoingItem>($"api/doing/{id}");
            if(res != null) return _mapper.Map<DoingItemDto>(res);
            throw new Exception("No doing item found.");
        }

        public async Task CreateDoingItem(DoingItemDto item)
        {
            var _item = _mapper.Map<DoingItem>(item);
            var result = await _http.PostAsJsonAsync("api/doing", _item);
            var res = await result.Content.ReadFromJsonAsync<List<DoingItem>>();
            if (res != null) DoingItemDtos = _mapper.Map<List<DoingItemDto>>(res);
        }

        public async Task UpdateDoingItem(ItemDto doingItem)
        {
            var result = await _http.PutAsJsonAsync($"api/doing/{doingItem.Id}", doingItem);
            var res = await result.Content.ReadFromJsonAsync<List<DoingItem>>();
            if (res != null) DoingItemDtos = _mapper.Map<List<DoingItemDto>>(res);
        }

        public async Task DeleteDoingItem(int id)
        {
            var result = await _http.DeleteAsync($"api/doing/{id}");
            var res = await result.Content.ReadFromJsonAsync<List<DoingItem>>();
            if (res != null) DoingItemDtos = _mapper.Map<List<DoingItemDto>>(res);
        }
    }
}
