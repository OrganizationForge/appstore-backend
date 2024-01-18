using Domain.Common;

namespace Domain.Entities.Library
{
    public class Book : AuditableBaseEntity
    {
        public string? Title { get; set; }
        public int Publication { get; set; }
        public string? Description { get; set; }
        public int? Pages { get; set; }
        public float? AverageScore { get; set; }
        public long? Rating { get; set; }
        public string? Cover { get; set; }
        public bool? PdfAvailable { get; set; } = false;
        public string? PdfUrl { get; set; }
        //public List<Categoria> Categorias { get; } = new();
        //public List<Autor> Autores { get; } = new();
        //public List<Editorial> Editoriales { get; } = new();
        //public List<IdentificadorIndustrial> Identificadores { get; } = new();
        public int LanguageId { get; set; }
        public virtual Idiom? Language { get; set; }
    }
}
