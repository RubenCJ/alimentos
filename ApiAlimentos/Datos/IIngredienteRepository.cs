using Datos.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public interface IIngredienteRepository : IDisposable
    {
        Task<List<Ingrediente>> ObtenerIngredientes(string nombre);
        Task<Ingrediente> ObtenerIngredienteId(int id);
        Task RegistrarIngrediente(Ingrediente ingrediente);
        Task ActualizarIngrediente(Ingrediente ingrediente);
        Task EliminarIngrediente(int id);
    }
}
