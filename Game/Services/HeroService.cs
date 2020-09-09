using Game.DataLayer.Models;
using Game.DataLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Services
{
    public class HeroService
    {
        private IRepository<Hero> heroRepository;

        public HeroService(IRepository<Hero> heroRepository)
        {
            this.heroRepository = heroRepository;
        }

        public async Task<IReadOnlyCollection<Hero>> GetHeroesAsync()
        {
            return await heroRepository.GetAllAsync();
        }

        public async Task<Hero> GetHeroAsync(int id)
        {
            var hero = await heroRepository.FindByConditionAsync(x => x.Id == id);
            return hero.FirstOrDefault();
        }

        /////////Comment because useless functional

        //public async Task InsertHeroAsync(Hero hero)
        //{
        //    await heroRepository.Insert(hero);
        //}

        //public async Task UpdateHeroAsync(Hero hero)
        //{
        //    await heroRepository.Update(hero);
        //}

        //public async Task DeleteHeroAsync(Hero hero)
        //{
        //    await heroRepository.Delete(hero);
        //}

        ////////////////End Comment

    }
}
