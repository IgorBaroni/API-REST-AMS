using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_LIVROS.Domain;
using Microsoft.EntityFrameworkCore;

namespace API_LIVROS.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Livro> Livro {get;set;}
       
    }
}