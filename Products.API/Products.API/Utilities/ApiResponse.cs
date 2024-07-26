namespace Products.API.Utilities
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
    }
}
