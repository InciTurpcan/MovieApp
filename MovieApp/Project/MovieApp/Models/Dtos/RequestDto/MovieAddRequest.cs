using Models.Entities;

namespace Models.Dtos.RequestDto;

public record MovieAddRequest(Guid Id,string Name, int Imdb, int Year, int PlatformId, int CategoryId)
{
    public static Movie ConvertToEntity(MovieAddRequest request)
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
