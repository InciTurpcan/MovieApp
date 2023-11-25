using CorePersistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Models.Dtos.ResponseDto;
using Models.Entities;

namespace DataAccess.Repositories.Concreate;

public class MovieRepository : EfRepositoryBase<BaseDbContext, Movie, Guid>, IMovieRepository
{
    public MovieRepository(BaseDbContext context) : base(context)
    {

    }

    public List<MovieDetailDto> GetAllMovieDetails()
    {
        throw new NotImplementedException();
    }

    public List<MovieDetailDto> GetDetailsByPlatformId(int platformId)
    {
        throw new NotImplementedException();
    }

    public List<MovieDetailDto> GetDetailsByCategoryId(int categoryId)
    {
        throw new NotImplementedException();
    }

    public MovieDetailDto GetMovieDetails(Guid Id)
    {
        throw new NotImplementedException();
    }
}
