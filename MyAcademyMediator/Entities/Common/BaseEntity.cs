namespace MyAcademyMediator.Entities.Common
{
    public abstract class BaseEntity
    {


        public Guid Id { get; set; } //guid değer benzerisiz ıd saat ve tarııhı gore anlık
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }




    }
}
