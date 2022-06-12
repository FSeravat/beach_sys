using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using beach_sys.Models;

    public class BeachSysContext : DbContext
    {
        public BeachSysContext (DbContextOptions<BeachSysContext> options)
            : base(options)
        {
        }

        public DbSet<beach_sys.Models.Armario> Armario { get; set; }

        public DbSet<beach_sys.Models.Compartimento> Compartimento { get; set; }

        public DbSet<beach_sys.Models.Usuario> Usuario { get; set; }
    }
