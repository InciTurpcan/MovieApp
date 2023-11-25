using CoreShared;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;

namespace Service.Abstract;

public interface IPlatformService
{
    Response<PlatformResponseDto> Add(PlatformAddRequest platformAddRequest);
    Response<PlatformResponseDto> Update(PlatformUpdateRequest platformUpdateRequest);
    Response<PlatformResponseDto> Delete(int id);

    Response<PlatformResponseDto> GetById(int id);

    Response<List<PlatformResponseDto>> GetAll();


}
