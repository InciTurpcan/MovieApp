using CoreShared;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;

namespace Service.Abstract;

public interface IMovieService
{
    Response<MovieResponseDto> Add(MovieAddRequest MovieAddrequest);
    Response<MovieResponseDto> Update(MovieUpdateRequest request);
    Response<MovieResponseDto> Delete(Guid Id);

    Response<MovieResponseDto> GetById(Guid Id);
    Response<List<MovieResponseDto>> GetAll();
    Response<List<MovieResponseDto>> GetAllByYearRange(int min, int max);

    Response<MovieDetailDto> GetByDetailId(Guid Id);

    Response<List<MovieDetailDto>> GetAllDetails();
    Response<List<MovieDetailDto>> GetAllDetailsByPlatformId(int platformId);
    Response<List<MovieDetailDto>> GetAllDetailsByCategoryId(int categoryId);
}
