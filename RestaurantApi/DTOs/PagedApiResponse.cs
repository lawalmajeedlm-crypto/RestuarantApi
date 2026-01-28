namespace RestaurantApi.Common
{
    public class PagedApiResponse<T> : ApiResponse<IEnumerable<T>>

    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);

        public PagedApiResponse(IEnumerable<T> data, int pageNumber, int pageSize, int totalRecords, string message = "Request successful")
            : base(true, message, data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
        }
    }
}
