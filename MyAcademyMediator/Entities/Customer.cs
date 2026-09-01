using MyAcademyMediator.Entities.Common;

namespace MyAcademyMediator.Entities
{
    public class Customer:BaseEntity
    {
        public string NameSurname { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public IList<Order> Orders { get; set; }


    }
}
