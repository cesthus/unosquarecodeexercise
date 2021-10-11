using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnosquareCodeExerciseAPI.Contracts;
using UnosquareCodeExerciseAPI.Data;
using UnosquareCodeExerciseAPI.Models;

namespace UnosquareCodeExerciseAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Product> _products;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Product> Products => 
            _products ??= new GenericRepository<Product>(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
