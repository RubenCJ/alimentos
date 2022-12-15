using Datos;
using Datos.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAlimentos.Controllers
{
    [Route("api/ingredientes")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {

        private readonly IIngredienteRepository _repository;

        public IngredientesController(IIngredienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<Ingrediente>>> Get(string nombre)
        {
            return await _repository.ObtenerIngredientes(nombre);
        }
    }
}
