using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyLangCsharp.Models;

namespace EasyLangCsharp.Data
{
    public class EasyLangCsharpContext : DbContext
    {
        public EasyLangCsharpContext (DbContextOptions<EasyLangCsharpContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;
    }
}
