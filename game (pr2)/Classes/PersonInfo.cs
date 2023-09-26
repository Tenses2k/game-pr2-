using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game__pr2_.Classes
{
    public class PersonInfo
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Level { get; set; }
        public int Glasses { get; set; }
        public int Money { get; set; }
        public float Damage { get; set; }

        public PersonInfo(string name, int health, int armor, int level, int glasses, int money, float damage)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Level = level;
            Glasses = glasses;
            Money = money;
            Damage = damage;
        }
    }
}