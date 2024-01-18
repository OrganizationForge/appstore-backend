using Domain.Common;

namespace Application.Common.Interfaces
{
    //Esta interfaz define UnitOfWork que nos permite guardar los cambios realizados por múltiples repositorios a la vez
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryAsync<T> Repository<T>() where T : AuditableBaseEntity;

        Task<int> Save(CancellationToken cancellationToken);

        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);

        Task Rollback();
    }
}
