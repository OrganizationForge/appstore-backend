using Application.Common.Parameters;

namespace Application.Features.Language.Queries.GetAllLanguages
{
    public class PaginationIdiomParameters : RequestParameters
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
