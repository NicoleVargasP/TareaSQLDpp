using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaDppController : ControllerBase
    {
        private readonly ITareaDppService _tareaService;

        public TareaDppController(ITareaDppService tareaService)
        {
            _tareaService = tareaService;
        }

        // 1 Usuarios activos que no han realizado ningún comentario
        [HttpGet("usuarios-sin-comentarios")]
        public async Task<IActionResult> GetUserNoComments()
        {
            var result = await _tareaService.GetUserNoCommentsAsync();
            return Ok(result);
        }

        // 2️  Comentarios realizados 3 meses atrás por usuarios mayores de 25 años
        [HttpGet("comentarios-recientes-mayores25")]
        public async Task<IActionResult> GetRecentComments25()
        {
            var result = await _tareaService.GetRecentComments25Async();
            return Ok(result);
        }

        // 3️  Posts sin comentarios de usuarios activos
        [HttpGet("posts-sin-comentarios-activos")]
        public async Task<IActionResult> GetPostNoActiveComments()
        {
            var result = await _tareaService.GetPostNoActiveCommentsAsync();
            return Ok(result);
        }

        // 4️ Usuarios que han comentado en posts de diferentes usuarios
        [HttpGet("usuarios-multiples-autores")]
        public async Task<IActionResult> GetUserMultiAuthors()
        {
            var result = await _tareaService.GetUserMultiAuthorsAsync();
            return Ok(result);
        }

        // 5️  Posts con comentarios de usuarios menores de edad
        [HttpGet("posts-comentarios-menores")]
        public async Task<IActionResult> GetPostMinorComments()
        {
            var result = await _tareaService.GetPostMinorCommentsAsync();
            return Ok(result);
        }
    }
}
