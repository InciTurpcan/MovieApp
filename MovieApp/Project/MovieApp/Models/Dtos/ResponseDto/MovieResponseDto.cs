using Models.Entities;

namespace Models.Dtos.ResponseDto;

public record MovieResponseDto(Guid Id,string Name, int Imdb, int Year, int platformId,int categoryId)
{
    public static MovieResponseDto ConvertToResponse(Movie movie)
    {
        return new MovieResponseDto(
            Id: movie.Id,
            Name: movie.Name,
            Imdb: movie.Imdb,
            Year: movie.Year,
            platformId: movie.PlatformId,
            categoryId: movie.CategoryId
            ); 
    }

}
