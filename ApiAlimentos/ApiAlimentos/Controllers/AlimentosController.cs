using Datos;
using Datos.Context;
using Microsoft.AspNetCore.Mvc;


namespace ApiAlimentos.Controllers
{
    [Route("api/alimentos")]
    [ApiController]
    public class AlimentosController : ControllerBase
    {

        private readonly IAlimentoRepository _repository;

        public AlimentosController(IAlimentoRepository repository)
        { 
            _repository= repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alimento>>> ObtenerAlimentos()
        {
            return await _repository.ObtenerAlimentos();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Alimento>> ObtenerAlimentoId(int id)
        {
            return await _repository.ObtenerAlimentoId(id);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar([FromBody] Alimento alimento)
        {
            await _repository.RegistrarAlimento(alimento);
            
            return Ok();

        }

        [HttpPost("actualizar")]
        public async Task<ActionResult> Actualizar(Alimento alimento)
        {
            await _repository.ActualizarAlimento(alimento);

            return Ok();

        }


        [HttpPost("eliminar/{id:int}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            await _repository.EliminarAlimento(id);
            return Ok();
        }



    }
}
