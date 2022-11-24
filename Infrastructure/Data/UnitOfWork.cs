using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		public Task<int> Complete()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
		{
			throw new NotImplementedException();
		}
	}
}