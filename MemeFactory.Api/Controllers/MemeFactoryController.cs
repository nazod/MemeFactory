using MemeFactory.Api.Interfaces;
using MemeFactory.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemeFactory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemeFactoryController : ControllerBase
    {

        private readonly ILogger<MemeFactoryController> _logger;
        private readonly IMemeFactoryService _memeFactoryService;

        public MemeFactoryController(ILogger<MemeFactoryController> logger, IMemeFactoryService memeFactoryService)
        {
            _logger = logger;
            _memeFactoryService = memeFactoryService;
        }

        [HttpPost("[action]/{text}")]
        public ActionResult Generate(IFormFile file, string text)
        {
            var result = _memeFactoryService.AddText(file, text);
            return File(result, "image/jpeg");
        }
    }
}