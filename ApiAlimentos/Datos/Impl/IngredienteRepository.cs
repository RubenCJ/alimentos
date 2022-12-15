using Dapper;
using Datos.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Impl
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly AlimentosContext _context;
        public IngredienteRepository(AlimentosContext context) 
        {
            _context = context;
        }

        public Task ActualizarIngrediente(Ingrediente ingrediente)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task EliminarIngrediente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Ingrediente> ObtenerIngredienteId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ingrediente>> ObtenerIngredientes(string nombre)
        {
            List<Ingrediente> ingredientes = await _context.Ingredientes.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
          
            return ingredientes;
        }

        public Task RegistrarIngrediente(Ingrediente ingrediente)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
