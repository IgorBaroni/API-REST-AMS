using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_LIVROS.Context;
using API_LIVROS.Interface;
using Microsoft.EntityFrameworkCore;

namespace API_LIVROS.Repository
{
    public class IRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _context;
        public IRepository(DataContext context)
        {
          _context = context;
        }
        public void Add(T entity)
        {
           _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update (entity);
        }
    }
}