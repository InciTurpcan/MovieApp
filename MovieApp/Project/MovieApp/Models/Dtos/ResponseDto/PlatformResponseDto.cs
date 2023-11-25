using Models.Entities;

namespace Models.Dtos.ResponseDto;

public record PlatformResponseDto(int Id, string Name)
{
    public static implicit operator PlatformResponseDto(Platform platform)
    {
        return new PlatformResponseDto(Id: platform.Id, Name: platform.Name);

    }
}
