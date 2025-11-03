using Todo_List.Models;

namespace Todo_List.Repositories
{
    public interface ITodoListRepo
    {
        public bool AddNewListItem(TodoListItem todoListItem); 
        public List<TodoListItem> GetAllListItems();
        public bool DeleteItem(int todoListItemId);
        public bool ToggleItem(int todoListItemId);
    }
}
