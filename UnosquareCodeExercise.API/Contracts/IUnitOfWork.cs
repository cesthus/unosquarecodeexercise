using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnosquareCodeExerciseAPI.Models;

namespace UnosquareCodeExerciseAPI.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> Products { get; }
        Task Save();
    }
}
