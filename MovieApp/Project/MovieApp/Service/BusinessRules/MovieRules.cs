using CoreCrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusinessRules;

public class MovieRules
{
    private readonly IMovieRepository _movieRepository;

    public MovieRules(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public void MovieNameMustBeUniqe(string movieName)
    {
        var movie = _movieRepository.GetByFilter(x=>x.Name==movieName);
        if (movie is not null)
        {
            throw new BusinessException("Film ismi benzersiz olmalı");
        }
    }

    public void MovieIsPresent(Guid Id) 
    {
        var movie=_movieRepository.GetById(Id);
        if (movie is  null) 
        {
            throw new BusinessException($"Id si :{Id} olan film bulunamadı.");
        }
    }
}
