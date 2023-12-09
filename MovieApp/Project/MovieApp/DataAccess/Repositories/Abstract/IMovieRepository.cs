using CorePersistence.Repositories;
using Models.Dtos.ResponseDto;
using Models.Entities;

namespace DataAccess.Repositories.Abstract;

public interface IMovieRepository : IEntityRepository<Movie,Guid>
{
    List<MovieDetailDto> GetAllMovieDetails();
    List<MovieDetailDto> GetDetailsByCategoryName(string categoryName);
    List<MovieDetailDto> GetDetailsByPlatformName(string platformName);
    List<MovieDetailDto> GetDetailsByPlatformId(int platformId);
    List<MovieDetailDto> GetDetailsByCategoryId(int categoryId);
    MovieDetailDto GetMovieDetails(Guid Id);
}
