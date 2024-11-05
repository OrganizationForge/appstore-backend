namespace Application.Common.Interfaces
{
    public interface IExcelWriterService
    {
        Stream WriteToStream<T>(IList<T> data);
    }
}
