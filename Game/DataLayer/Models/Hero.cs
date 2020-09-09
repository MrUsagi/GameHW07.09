using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Game.DataLayer.Models
{
    public class Hero
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double BasicDamage { get; set; }
        public double CritChance { get; set; }
        public double CritPower { get; set; }
        public double Vortex { get; set; }
        public double Hp { get; set; }
        public double Protection { get; set; }
    }
}
