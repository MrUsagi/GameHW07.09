using Game.DataLayer.Models;
using Game.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.BuisnessLogic
{
    public class CharactersSelectionService
    {
        private HeroesRepository _repository;
        public CharactersSelectionService() { }
        public CharactersSelectionService(HeroesRepository repository)
        {
            _repository = repository;
        }
        public async Task LoadHeroes(WrapPanel mainPanel)
        {
            mainPanel.Children.Clear();
            var collection = await _repository.GetAllAsync();
            foreach (var item in collection)
            {
                mainPanel.Children.Add(
                    new Button()
                    {
                        Width = 300,
                        Height = 300,
                        Content = new Image() { Source = (ImageSource)new ImageSourceConverter().ConvertFrom(item.ImageURL) },

                    });
            }

        }

        public async Task<Hero> PickHero(object content)
        {
            var hero = await _repository.FindByConditionAsync(x => x.ImageURL == (content as Image).Source.ToString());
            return hero.FirstOrDefault();
        }
    }
}
