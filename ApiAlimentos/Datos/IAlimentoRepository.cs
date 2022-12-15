using Datos.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public interface IAlimentoRepository : IDisposable
    {
        Task<List<Alimento>> ObtenerAlimentos();
        Task<Alimento> ObtenerAlimentoId(int IdAlimento);
        Task RegistrarAlimento(Alimento alimento);
        Task ActualizarAlimento(Alimento alimento);
        Task EliminarAlimento(int IdAlimento);
        

    }
}
