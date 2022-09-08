using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToDo_Client.Pages.ToDo_Pages
{
    public class ToDoItemsPageModel : PageModel
    {
        [BindProperty]
        public Todo TodoItem { get; set; } = new();
        public List<Todo> ListOfToDoItems { get; set; } = new();

        public async Task OnGet()
        {
            await LoadToDoItems();
        }
        private async Task LoadToDoItems()
        {
            HttpResponseMessage response = 
                await Services.Client.GetAsync("https://localhost:7199/todoitems");
            if (response.IsSuccessStatusCode)
            {
                ListOfToDoItems = await response.Content.ReadFromJsonAsync<List<Todo>>();
            }
        }
        private async Task CreateNewTast_Clicked(Object sender, EventArgs e)
        {
            HttpResponseMessage response = 
                await Services.Client.PostAsJsonAsync("https://localhost:7199/todoitems", TodoItem);
            response.EnsureSuccessStatusCode();

            TodoItem = new();// To make sure nothing remains of the old item.
        }
    }
}
