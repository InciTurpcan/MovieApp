using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDto;
using Service.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] MovieAddRequest movieAddRequest)
        {
            var result = _movieService.Add(movieAddRequest);
            return ActionResultInstance(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] MovieUpdateRequest movieUpdateRequest)
        {
            var result = _movieService.Update(movieUpdateRequest);
            return ActionResultInstance(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] Guid id)
        {
            var result = _movieService.Delete(id);
            return ActionResultInstance(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById([FromQuery] Guid id)
        {
            var result = _movieService.GetById(id);
            return ActionResultInstance(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _movieService.GetAll();
            return ActionResultInstance(result);
        }

        [HttpGet("getbypricerange")]
        public IActionResult GetAllByYearRange([FromQuery] int min, [FromQuery] int max)
        {
            var result = _movieService.GetAllByYearRange(min, max);
            return ActionResultInstance(result);
        }

        [HttpGet("getbydetailid")]
        public IActionResult GetByDetailId([FromQuery] Guid id)
        {
            var result = _movieService.GetByDetailId(id);
            return ActionResultInstance(result);
        }

        [HttpGet("details")]
        public IActionResult GetAllDetails()
        {
            var result = _movieService.GetAllDetails();
            return ActionResultInstance(result);
        }

        [HttpGet("getalldetailsbycategory")]
        public IActionResult GetAllDetailsByCategoryId([FromQuery] int categoryId)
        {
            var result = _movieService.GetAllDetailsByCategoryId(categoryId);
            return ActionResultInstance(result);
        }

        [HttpGet("getalldetailsbyplatform")]
        public IActionResult GetAllDetailsByPlatformId([FromQuery] int platformId)
        {
            var result = _movieService.GetAllDetailsByPlatformId(platformId);
            return ActionResultInstance(result);
        }
    }
}

