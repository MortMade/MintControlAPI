using System;
using Microsoft.EntityFrameworkCore;
using MintControlAPI.Models;

namespace MintControlAPI 
{
    public class MintContext : DbContext
    {
        public MintContext(DbContextOptions<MintContext> options) : base(options)

        { }


        public DbSet<FunctionModel> Functions { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
