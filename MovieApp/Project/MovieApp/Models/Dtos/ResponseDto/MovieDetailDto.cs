namespace Models.Dtos.ResponseDto;

public record MovieDetailDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Imdb { get; init; }
    public int Year { get; init; }
    public string PlatformName { get; init; }
    public string CategoryName { get; init; }
}
