using CorePersistence.EntityBaseModel;

namespace Models.Entities;
public class Movie : Entity<Guid>
{
    public string Name { get; set; }
    public int Imdb { get; set; }
    public int Year { get; set; }
    public int PlatformId { get; set; }
    public Platform Platform { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string CategoryName => this.Category.Name;
   


}
