using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDto;
using Service.Abstract;
using Service.Concreate;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : BaseController
    {
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] PlatformAddRequest platformAddRequest)
        {
            var result = _platformService.Add(platformAddRequest);
            return ActionResultInstance(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] PlatformUpdateRequest platformUpdateRequest)
        {
            var result = _platformService.Update(platformUpdateRequest);
            return ActionResultInstance(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int Id)
        {
            var result = _platformService.Delete(Id);
            return ActionResultInstance(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            var result = _platformService.GetById(id);
            return ActionResultInstance(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _platformService.GetAll();
            return ActionResultInstance(result);
        }
    }
}
