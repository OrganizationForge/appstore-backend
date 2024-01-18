namespace Application.Common.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(T data, int pageNumer, int pageSize)
        {
            PageNumber = pageNumer;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Succeded = true;
            Errors = null;
        }
    }
}
