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

        public async Task<IQueryable<Hero>> GetHeroesAsync()
        {
            return await heroRepository.GetAll();
        }

        public async Task<Hero> GetHeroAsync(long id)
        {
            return await heroRepository.GetById(id);
        }

        public async Task InsertHeroAsync(Hero hero)
        {
            await heroRepository.Insert(hero);
        }

        public async Task UpdateHeroAsync(Hero hero)
        {
            await heroRepository.Update(hero);
        }

        public async Task DeleteHeroAsync(Hero hero)
        {
            await heroRepository.Delete(hero);
        }

    }
}
