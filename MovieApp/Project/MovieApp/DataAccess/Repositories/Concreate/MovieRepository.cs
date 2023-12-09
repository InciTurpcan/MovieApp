using CorePersistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Models.Dtos.ResponseDto;
using Models.Entities;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DataAccess.Repositories.Concreate;

public class MovieRepository : EfRepositoryBase<BaseDbContext, Movie, Guid>, IMovieRepository
{
    public MovieRepository(BaseDbContext context) : base(context)
    {

    }

    public List<MovieDetailDto> GetAllMovieDetails()
    {
        var details = Context.Movies.Join(
            Context.Categories,
            m => m.CategoryId,
            c => c.Id,
            (movie, category) => new MovieDetailDto
            {
                Id = movie.Id,
                Name = movie.Name,
                Imdb = movie.Imdb,
                Year = movie.Year,
                CategoryName = category.Name,
                PlatformName = movie.Platform.Name
            }).ToList();
        return details;
    }

    public List<MovieDetailDto> GetDetailsByPlatformId(int platformId)
    {
        var details = Context.Movies.Where(p => p.PlatformId == platformId).Join(
            Context.Platforms,
            m => m.PlatformId,
            p => p.Id,
            (movie, platform) => new MovieDetailDto
            {
                Id = movie.Id,
                Name = movie.Name,
                Imdb = movie.Imdb,
                Year = movie.Year,
                CategoryName = movie.Category.Name,
                PlatformName = platform.Name
            }).ToList();

        return details;
    }

    public List<MovieDetailDto> GetDetailsByCategoryId(int categoryId)
    {
        var details = Context.Movies.Where(c => c.CategoryId == categoryId).Join(
            Context.Categories,
            m => m.CategoryId,
            c => c.Id,
            (movie, category) => new MovieDetailDto
            {
                Id = movie.Id,
                Name = movie.Name,
                Imdb = movie.Imdb,
                Year = movie.Year,
                CategoryName = category.Name,
                PlatformName = movie.Platform.Name
            }).ToList();
        return details;
    }

    public MovieDetailDto GetMovieDetails(Guid Id)
    {
        var details = Context.Movies.Where(m => m.Id == Id).Select(
            movie => new MovieDetailDto
            {
                Id = movie.Id,
                Name = movie.Name,
                Imdb = movie.Imdb,
                Year = movie.Year,
                CategoryName = movie.Category.Name,
                PlatformName = movie.Platform.Name
            }).FirstOrDefault();
        return details;
    }

    public List<MovieDetailDto> GetDetailsByCategoryName(string categoryName)
    {
        var details = Context.Movies.Join(
            Context.Categories.Where(m => m.Name.Contains(categoryName)), //Filtre
            m => m.CategoryId,
            c => c.Id,
            (movie, category) => new MovieDetailDto
            {
                Id = movie.Id,
                Name = movie.Name,
                Imdb = movie.Imdb,
                Year = movie.Year,
                CategoryName = category.Name,
                PlatformName = movie.Platform.Name
            }).ToList();
        return details;

    }

    public List<MovieDetailDto> GetDetailsByPlatformName(string platformName)
    {
        var details = Context.Movies.Join(
            Context.Platforms.Where(m => m.Name.Contains(platformName)),
            m => m.PlatformId,
            p => p.Id,
            (movie, platform) => new MovieDetailDto
            {
                Id = movie.Id,
                Name = movie.Name,
                Imdb = movie.Imdb,
                Year = movie.Year,
                CategoryName = movie.Category.Name,
                PlatformName = platform.Name
            }).ToList();

        return details;
    }

}



