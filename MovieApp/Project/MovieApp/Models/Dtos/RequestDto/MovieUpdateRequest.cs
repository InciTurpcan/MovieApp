using Models.Entities;

namespace Models.Dtos.RequestDto;

public record MovieUpdateRequest(Guid Id, string Name, int Imdb, int Year, int PlatformId, int CategoryId)
{
    public static Movie ConvertToEntity(MovieUpdateRequest request)
    {
        return new Movie
        {
            Id = request.Id,
            Name = request.Name,
            Imdb = request.Imdb,
            Year = request.Year,
            PlatformId = request.PlatformId,
            CategoryId = request.CategoryId
        };
    }
}
