using CorePersistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Models.Entities;

namespace DataAccess.Repositories.Concreate;

public class PlatformRepository : EfRepositoryBase<BaseDbContext, Platform, int>, IPlatformRepository
{
    public PlatformRepository(BaseDbContext context) : base(context)
    {
    }
}
