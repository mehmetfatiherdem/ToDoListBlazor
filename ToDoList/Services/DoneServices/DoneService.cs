using AutoMapper;
using ToDoList.DTO;
using ToDoList.model;
using static System.Net.WebRequestMethods;

namespace ToDoList.Services.DoneServices
{
    public class DoneService : IDoneService
    {
        private readonly HttpClient _http;
        private readonly IMapper _mapper;
        public DoneService(HttpClient http, IMapper mapper)
        {
            this._http = http;
            _mapper = mapper;
        }
        public List<DoneItemDto> DoneItemDtos { get; set; } = new List<DoneItemDto>();
        public async Task GetDoneItems()
        {
            var res = await _http.GetFromJsonAsync<List<DoneItem>>("api/done");
            if (res != null) DoneItemDtos = _mapper.Map<List<DoneItemDto>>(res);
        }

        public async Task<DoneItemDto> GetDoneItem(int id)
        {
            var res = await _http.GetFromJsonAsync<DoneItem>($"api/done/{id}");
            if (res != null) return _mapper.Map<DoneItemDto>(res);
            throw new Exception("No done item found.");
        }

        public async Task CreateDoneItem(DoneItemDto item)
        {
            var result = await _http.PostAsJsonAsync("api/done", item);
            //TODO: move these to a common method to avoid duplication
            var res = await result.Content.ReadFromJsonAsync<List<DoneItem>>();
            if (res != null) DoneItemDtos = _mapper.Map<List<DoneItemDto>>(res);
        }

        public async Task UpdateDoneItem(ItemDto doneItem)
        {
            var result = await _http.PutAsJsonAsync($"api/done/{doneItem.Id}", doneItem);
            var res = await result.Content.ReadFromJsonAsync<List<DoneItem>>();
            if (res != null) DoneItemDtos = _mapper.Map<List<DoneItemDto>>(res);
        }

        public async Task DeleteDoneItem(int id)
        {
            var result = await _http.DeleteAsync($"api/done/{id}");
            var res = await result.Content.ReadFromJsonAsync<List<DoneItem>>();
            if (res != null) DoneItemDtos = _mapper.Map<List<DoneItemDto>>(res);
        }
    }
}
