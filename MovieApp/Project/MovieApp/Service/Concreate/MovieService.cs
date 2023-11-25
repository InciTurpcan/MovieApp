using CoreCrossCuttingConcerns.Exceptions;
using CoreShared;
using DataAccess.Repositories.Abstract;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;
using Models.Entities;
using Service.Abstract;
using Service.BusinessRules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concreate;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly MovieRules _movieRules;

    public MovieService(IMovieRepository movieRepository, MovieRules movieRules)
    {
        _movieRepository = movieRepository;
        _movieRules = movieRules;
    }

    public Response<MovieResponseDto> Add(MovieAddRequest MovieAddrequest)
    {
        try
        {
            Movie movie = MovieAddRequest.ConvertToEntity(MovieAddrequest);
            _movieRules.MovieNameMustBeUniqe(movie.Name);
            movie.Id = new Guid();
            _movieRepository.Add(movie);

            var response =MovieResponseDto.ConvertToResponse(movie);
            return new Response<MovieResponseDto>()
            {
                Data = response,
                Message = "Film eklendi",
                StatusCode = System.Net.HttpStatusCode.Created
            };

        }
        catch (BusinessException ex)
        {
            return new Response<MovieResponseDto>()
            {
                Message = ex.Message,
                StatusCode=System.Net.HttpStatusCode.BadRequest
            };

        }
    }

    public Response<MovieResponseDto> Delete(Guid Id)
    {
        try
        {
            _movieRules.MovieIsPresent(Id);

            var movie = _movieRepository.GetById(Id);
            _movieRepository.Delete(movie);

            var response = MovieResponseDto.ConvertToResponse(movie);
            return new Response<MovieResponseDto>()
            {
                Data = response,
                Message = "Film silindi.",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<MovieResponseDto>
            {
                Message = ex.Message,
                StatusCode= System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public Response<List<MovieResponseDto>> GetAll()
    {
        var movies = _movieRepository.GetAll();
        var response = movies.Select(x=> MovieResponseDto.ConvertToResponse(x)).ToList();
        return new Response<List<MovieResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<MovieResponseDto>> GetAllByYearRange(int min, int max)
    {
        var movies = _movieRepository.GetAll(x => x.Year <= max && x.Year >= max);
        var response = movies.Select(x => MovieResponseDto.ConvertToResponse(x)).ToList();

        return new Response<List<MovieResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<MovieDetailDto>> GetAllDetails()
    {
        var details = _movieRepository.GetAllMovieDetails();

        return new Response<List<MovieDetailDto>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<MovieDetailDto>> GetAllDetailsByCategoryId(int categoryId)
    {
        var details = _movieRepository.GetDetailsByCategoryId(categoryId);
        return new Response<List<MovieDetailDto>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<List<MovieDetailDto>> GetAllDetailsByPlatformId(int platformId)
    {
        var details = _movieRepository.GetDetailsByPlatformId(platformId);
        return new Response<List<MovieDetailDto>>()
        {
            Data = details,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<MovieDetailDto> GetByDetailId(Guid Id)
    {
        try
        {
            _movieRules.MovieIsPresent(Id);

            var details = _movieRepository.GetMovieDetails(Id);
            return new Response<MovieDetailDto>()
            {
                Data = details,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<MovieDetailDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public Response<MovieResponseDto> GetById(Guid Id)
    {
        try
        {
            _movieRules.MovieIsPresent(Id);

            var movie = _movieRepository.GetById(Id);
            var response = MovieResponseDto.ConvertToResponse(movie);
            return new Response<MovieResponseDto>()
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<MovieResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public Response<MovieResponseDto> Update(MovieUpdateRequest request)
    {
        try
        {
            Movie movie = MovieUpdateRequest.ConvertToEntity(request);

            _movieRules.MovieNameMustBeUniqe(movie.Name);
            _movieRepository.Update(movie);

            var response = MovieResponseDto.ConvertToResponse(movie);

            return new Response<MovieResponseDto>()
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<MovieResponseDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }
}
