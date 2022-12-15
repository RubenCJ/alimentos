using Datos.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Impl
{
    public class AlimentoRepository : IAlimentoRepository
    {

        private readonly AlimentosContext _context;

        public AlimentoRepository(AlimentosContext context)
        {
            _context = context;
        }

        public async Task<Alimento> ObtenerAlimentoId(int id)
        {
            return await _context.Alimentos.Include(a => a.IdIngredientes).FirstOrDefaultAsync(x => x.IdAlimento == id);
        }

        public async Task<List<Alimento>> ObtenerAlimentos()
        {
            return await _context.Alimentos.Where(b => b.Activo ==true).ToListAsync();
        }

        public async Task RegistrarAlimento(Alimento alimento)
        {
            alimento.Activo = true;
            alimento.FechaRegistro = DateTime.Now;
            _context.Alimentos.Add(alimento);
            await Save();
            
        }

        public async Task ActualizarAlimento(Alimento alimento)
        {
            alimento.FechaActualizacion = DateTime.Now;
            _context.Alimentos.Update(alimento);
            await Save();

        }

        public async Task EliminarAlimento(int IdAlimento)
        {
            Alimento alimento = await _context.Alimentos.FindAsync(IdAlimento);
            alimento.FechaActualizacion = DateTime.Now;
            alimento.Activo = false;
            _context.Alimentos.Update(alimento);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }      

        public void Dispose()
        {
            _context.Dispose();
        }

       
    }
}
