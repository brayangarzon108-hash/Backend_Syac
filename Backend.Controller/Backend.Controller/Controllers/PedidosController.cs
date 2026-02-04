using API.DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using TestInterRapidisimo.Domain.Model.Response;

namespace Backend.Controller.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly IPedidosCore _pedidoService;

        public PedidosController(ILogger<PedidosController> logger, IPedidosCore pedidoServices)
        {
            _logger = logger;
            _pedidoService = pedidoServices;
        }

        /// <summary>
        /// Método que consulta pedidos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pedidos = await _pedidoService.ObtenerPedidosAsync();
            return Ok(pedidos);
        }

        /// <summary>
        /// Método que crea pedidos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PedidoCreateDto pedido)
        {
            var id = await _pedidoService.CrearPedidoAsync(pedido);
            return CreatedAtAction(nameof(Get), new { id }, pedido);
        }

        /// <summary>
        /// Método que confirma pedidos
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}/confirmar")]
        public async Task<IActionResult> Confirmar(int id)
        {
            await _pedidoService.ConfirmarPedidoAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Método que anula pedidos
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}/anular")]
        public async Task<IActionResult> Anular(int id)
        {
            await _pedidoService.AnularPedidoAsync(id);
            return NoContent();
        }
    }
}
