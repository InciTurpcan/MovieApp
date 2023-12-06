using CorePersistence.Repositories;
using Models.Dtos.ResponseDto;
using Models.Entities;

namespace DataAccess.Repositories.Abstract;

public interface IMovieRepository : IEntityRepository<Movie,Guid>
{
    List<MovieDetailDto> GetAllMovieDetails();
    List<MovieDetailDto> GetDeatailsByCategoryName(string categoryName);
    List<MovieDetailDto> GetDeatailsByPlatformName(string platformName);
    List<MovieDetailDto> GetDetailsByPlatformId(int platformId);
    List<MovieDetailDto> GetDetailsByCategoryId(int categoryId);
    MovieDetailDto GetMovieDetails(Guid Id);
}
