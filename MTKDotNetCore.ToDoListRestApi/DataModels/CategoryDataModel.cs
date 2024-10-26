namespace MTKDotNetCore.ToDoListRestApi.DataModels
{
    public class CategoryDataModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsDelete { get; set; }
    }
}
