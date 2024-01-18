using Ardalis.Specification;
using Domain.Entities.Library;

namespace Application.Features.Language.Queries.GetAllLanguages
{
    public class IdiomSpecification : Specification<Idiom>
    {
        public IdiomSpecification(int pageSize, int pageNumber, string code, string description)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(code))
                Query.Search(x => x.Code, "%" + code + "%");

            if (!string.IsNullOrEmpty(description))
                Query.Search(x => x.Description, "%" + description + "%");

            //Agregamos esto si queremos incluir en el resultado la relacion 
            //Query
            //    .Include(x => x.Books);
        }
    }
}
