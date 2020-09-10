using Game.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.DataLayer.Context.Initializers
{
    public static class GameInitializer
    {
        public static void Initialize(GameContext context)
        {
            context.Database.EnsureCreated();
            if (context.Heroes.Any()) return;
            context.Heroes.Add(
                new Hero()
                {
                    BasicDamage = 10,
                    CritChance = 25,
                    CritPower = 110,
                    Hp = 150,
                    Name = "Gayman",
                    Protection = 35,
                    Vortex = 10,
                    ImageURL = " https://images-cdn.9gag.com/photo/aB0gVY1_700b.jpg"
                }
            );
            context.Heroes.Add(
                new Hero()
                {
                    BasicDamage = 15,
                    CritChance = 50,
                    CritPower = 230,
                    Hp = 80,
                    Name = "Vovaman",
                    Protection = 10,
                    Vortex = 25,
                    ImageURL = " https://a.d-cd.net/a01a086s-200.jpg"
                }
            );
            context.Heroes.Add(
                new Hero()
                {
                    BasicDamage = 13,
                    CritChance = 60,
                    CritPower = 170,
                    Hp = 110,
                    Name = "Kekman",
                    Protection = 20,
                    Vortex = 20,
                    ImageURL = "https://i1.sndcdn.com/avatars-000473440284-8b06pd-t500x500.jpg"
                }
            );
            context.Heroes.Add(
                new Hero()
                {
                    BasicDamage = 20,
                    CritChance = 40,
                    CritPower = 300,
                    Hp = 80,
                    Name = "Lelman",
                    Protection = 8,
                    Vortex = 30,
                    ImageURL = " https://pbs.twimg.com/profile_images/612368131630231552/8sbTgP56.jpg"
                }
            );
            context.Heroes.Add(
                new Hero()
                {
                    BasicDamage = 5,
                    CritChance = 90,
                    CritPower = 200,
                    Hp = 130,
                    Name = "Howman",
                    Protection = 30,
                    Vortex = 10,
                    ImageURL = "https://image.shutterstock.com/image-vector/why-man-looks-sad-600w-734313991.jpg"
                }
            );
            context.Heroes.Add(
                new Hero()
                {
                    BasicDamage = 40,
                    CritChance = 10,
                    CritPower = 200,
                    Hp = 80,
                    Name = "Townman",
                    Protection = 8,
                    Vortex = 40,
                    ImageURL = "https://upload.wikimedia.org/wikipedia/ru/thumb/1/1e/Gorojanin.jpg/235px-Gorojanin.jpg"
                }
            );

            context.SaveChanges();
        }
    }
}
