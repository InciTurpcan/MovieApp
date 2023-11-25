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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concreate;

public class PlatformService : IPlatformService
{
    private readonly IPlatformRepository _platformRepository;
    private readonly PlatformRules _platformRules;

    public PlatformService(IPlatformRepository platformRepository, PlatformRules platformRules)
    {
        _platformRepository = platformRepository;
        _platformRules = platformRules;
    }

    public Response<PlatformResponseDto> Add(PlatformAddRequest platformAddRequest)
    {
        try
        {
            Platform platform = platformAddRequest;
            _platformRules.PlatformNameMustBeUniqe(platform.Name);
            _platformRepository.Add(platform);
            PlatformResponseDto response = platform;
            return new Response<PlatformResponseDto>
            {
                Data = response,
                Message = "Platform eklendi",
                StatusCode = System.Net.HttpStatusCode.Created
            };

        }
        catch (BusinessException ex)
        {

            return new Response<PlatformResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public Response<PlatformResponseDto> Delete(int id)
    {
        try
        {
            _platformRules.PlatformIsPresent(id);
            Platform platform=_platformRepository.GetById(id);
            _platformRepository.Delete(platform);
            PlatformResponseDto response = platform;

            return new Response<PlatformResponseDto>
            {
                Data = response,
                Message = "Platform silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };

        }
        catch (BusinessException ex)
        {
            return new Response<PlatformResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public Response<List<PlatformResponseDto>> GetAll()
    {
        List<Platform> platforms = _platformRepository.GetAll();
        List<PlatformResponseDto> response = platforms.Select(x=> (PlatformResponseDto)x).ToList();
        return new Response<List<PlatformResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<PlatformResponseDto> GetById(int id)
    {
        try
        {
            _platformRules.PlatformIsPresent(id);
            Platform platform = _platformRepository.GetById(id);
            PlatformResponseDto response = platform;
            return new Response<PlatformResponseDto>
            {
                Data = response,
                StatusCode= System.Net.HttpStatusCode.OK
            };

        }
        catch (BusinessException ex)
        {
            return new Response<PlatformResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public Response<PlatformResponseDto> Update(PlatformUpdateRequest platformUpdateRequest)
    {
        try
        {
            Platform platform = platformUpdateRequest;
            _platformRepository.Update(platform);
            PlatformResponseDto response = platform;

            _platformRules.PlatformNameMustBeUniqe(platform.Name);
            return new Response<PlatformResponseDto>
            {
                Data = response,
                Message = "Platform güncellendi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
            
        }
        catch (BusinessException ex)
        {
            return new Response<PlatformResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }
}
