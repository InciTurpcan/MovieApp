using CorePersistence.EntityBaseModel;
using Models.Dtos.RequestDto;

namespace Models.Entities;

public class Platform : Entity<int> 
{
    public string Name { get; set; }
    public List<Movie> Movies { get; set; }

    public static implicit operator Platform(PlatformAddRequest platformAddRequest) =>
      new Platform { Name = platformAddRequest.Name };

    public static implicit operator Platform(PlatformUpdateRequest platformUpdateRequest) =>
        new Platform { Id = platformUpdateRequest.Id, Name = platformUpdateRequest.Name };


}
