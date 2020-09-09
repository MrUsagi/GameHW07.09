using Game.DataLayer.Context.Initializers;
using Game.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.DataLayer.Context
{
    public class GameContext:DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
            GameInitializer.Initialize(this);
        }
        public DbSet<Hero> Heroes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .HasKey(x => x.Id);
        }
    }
}
