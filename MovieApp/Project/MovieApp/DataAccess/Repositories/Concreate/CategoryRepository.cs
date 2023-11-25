using CorePersistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using Models.Entities;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Concreate;

public class CategoryRepository : EfRepositoryBase<BaseDbContext, Category, int>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }
}
