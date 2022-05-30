using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaTecnica3.Models;

namespace ProvaTecnica3.Data
{
    public class ProvaTecnica3Context : DbContext
    {
        public ProvaTecnica3Context (DbContextOptions<ProvaTecnica3Context> options)
            : base(options)
        {
        }

        public DbSet<ProvaTecnica3.Models.Cliente>? Cliente { get; set; }

        public DbSet<ProvaTecnica3.Models.Emprestimo>? Emprestimo { get; set; }

        public DbSet<ProvaTecnica3.Models.Pagamento>? Pagamento { get; set; }
    }
}
