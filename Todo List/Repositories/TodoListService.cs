using Todo_List.Models;

namespace Todo_List.Repositories
{
    public class TodoListService : ITodoListRepo
    {
        private static List<TodoListItem> TodoList = new List<TodoListItem>();
        private static int nextId = 1;
        public bool AddNewListItem(TodoListItem todoListItem)
        {
            if (todoListItem == null || string.IsNullOrWhiteSpace(todoListItem.Title))
                return false;

            todoListItem.Id = nextId++;
            TodoList.Add(todoListItem);
            return true;
        }

        public bool DeleteItem(int todoListItemId)
        {
            var item = TodoList.FirstOrDefault(x => x.Id == todoListItemId);
            if (item == null)
                return false;

            TodoList.Remove(item);
            return true;
        } 
        public bool ToggleItem(int todoListItemId)
        {
            var item = TodoList.FirstOrDefault(x => x.Id == todoListItemId);
            if (item == null)
                return false;

            item.IsCompleted = !item.IsCompleted;
            return true;
        }

        public List<TodoListItem> GetAllListItems()
        {
            return TodoList;
        }
    }
}
