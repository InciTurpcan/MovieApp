using CoreCrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusinessRules;

public class PlatformRules
{
    private readonly IPlatformRepository _platformRepository;

    public PlatformRules(IPlatformRepository platformRepository)
    {
        _platformRepository = platformRepository;
    }

    public void PlatformNameMustBeUniqe(string platformName)
    {
        var platform = _platformRepository.GetByFilter(x=>x.Name==platformName);
        if (platform is not null)
        {
            throw new BusinessException("Platform adı benzersiz olmalı");
        }
    }

    public void PlatformIsPresent(int Id)
    {
        var platform = _platformRepository.GetById(Id);
        if (platform is null)
        {
            throw new BusinessException($"Id: {Id} olan platform bulunamadı.");
        }
    }
}
