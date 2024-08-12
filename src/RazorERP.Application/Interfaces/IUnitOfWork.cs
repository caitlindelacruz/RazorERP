namespace RazorERP.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
