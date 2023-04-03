using AutoMapper;
using ToDoList.DTO;
using ToDoList.model;

namespace ToDoList.Services.ToDoServices
{
    public class ToDoService : IToDoService
    {
        private readonly HttpClient _http;
        private readonly IMapper _mapper;
        public ToDoService(HttpClient http, IMapper mapper)
        {
            this._http = http;
            _mapper = mapper;
        }

        public List<ToDoItemDto> ToDoItemDtos { get; set; } = new List<ToDoItemDto>();
 
        public async Task GetToDoItems()
        {
            var res = await _http.GetFromJsonAsync<List<ToDoItem>>("api/todo");
            if (res != null) ToDoItemDtos = _mapper.Map<List<ToDoItemDto>>(res);
        }

        public async Task<ToDoItemDto> GetToDoItem(int id)
        {
            var res = await _http.GetFromJsonAsync<ToDoItem>($"api/todo/{id}");
            if(res != null) return _mapper.Map<ToDoItemDto>(res);
            throw new Exception("No todo item found.");
        }

        public async Task CreateToDoItem(ToDoItemDto item)
        {
            var _item = _mapper.Map<ToDoItem>(item);
            var result = await _http.PostAsJsonAsync("api/todo", _item);
            //TODO: move these to a common method to avoid duplication
            var res = await result.Content.ReadFromJsonAsync<List<ToDoItem>>();
            if (res != null) ToDoItemDtos = _mapper.Map<List<ToDoItemDto>>(res); 
        }

        public async Task UpdateToDoItem(ItemDto toDoItem)
        {
            var result = await _http.PutAsJsonAsync($"api/todo/{toDoItem.Id}", toDoItem);
            var res = await result.Content.ReadFromJsonAsync<List<ToDoItem>>();
            if (res != null) ToDoItemDtos = _mapper.Map<List<ToDoItemDto>>(res);
        }

        public async Task DeleteToDoItem(int id)
        {
            var result = await _http.DeleteAsync($"api/todo/{id}");
            var res = await result.Content.ReadFromJsonAsync<List<ToDoItem>>();
            if (res != null) ToDoItemDtos = _mapper.Map<List<ToDoItemDto>>(res);
        }
    }
}
