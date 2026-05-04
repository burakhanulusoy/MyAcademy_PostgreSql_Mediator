namespace MyAcademyMediator.UOW
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();

    }
}
