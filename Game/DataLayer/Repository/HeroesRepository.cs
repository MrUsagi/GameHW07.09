using Game.DataLayer.Context;
using Game.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.DataLayer.Repository
{
    public class HeroesRepository:BaseRepository<Hero>
    {
        public HeroesRepository(GameContext context) : base(context) { }
    }
}
