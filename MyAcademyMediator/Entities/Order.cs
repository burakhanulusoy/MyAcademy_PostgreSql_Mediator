using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyAcademyMediator.Entities.Common;

namespace MyAcademyMediator.Entities
{
    public class Order : BaseEntity
    {
        public string OrderResult { get; set; }
        public decimal OrderPrice { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }


    }
}
