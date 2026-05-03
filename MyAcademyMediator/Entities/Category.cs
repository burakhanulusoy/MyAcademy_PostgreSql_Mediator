using MyAcademyMediator.Entities.Common;

namespace MyAcademyMediator.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public IList<Product> Products { get; set; }
    }
}
