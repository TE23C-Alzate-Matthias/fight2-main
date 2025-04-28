public class Entity
{
    // ==================== CLASS ====================

    // Hp - hitpoint
    // Vt - Vitality
    // Atk - Attack
    // Def - Defense
    // Spd - Speed
    // Acc - Accuracy
    // Prc - Precision (new for version 2)
    // Dex - Dexterity
    // Stat - Stat Points
    // Dmg - Damage
    // Stm - Stamina (new for version 2)
    // UStm - Usable Stamina (new for version 2)
    // Exh - Exhaustion (new for version 2)


    public class Characters
    {
        // gonna work to make the addition of new characters easier
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Vt { get; set; }
        public int BonusVt; // new
        public int Atk { get; set; }
        public int BonusAtk; // new
        public int Def { get; set; }
        public int BonusDef; // new
        public int Spd { get; set; }
        public int BonusSpd; // new
        public int Acc { get; set; }
        public int BonusAcc; // new
        public int Prc { get; set; } // new
        public int Dex { get; set; }
        public int BonusDex; // new
        public int Stm { get; set; } // new
        public int Stat { get; set; }
        public int ExtraDodge { get; set; }
        public int MaxHp { get; set; }
        public int Dmg;
        public int UStm { get; set; } // new
        public int MaxStm { get; set; } // new
        public int Exh { get; set; } // new
        public int Gold { get; set; } // new
        public List<Items> Inventory = new List<Items>();
        public List<Items> Equipments = new List<Items>();
        // public List<string> Attacks; // new
    }

    // 1 - Wepons
    // 2 - Helmet
    // 3 - BreastPlate
    // 4 - Leggings
    // 5 - Boots
    // 6 - Ring
    public class Items
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int Price { get; set; }
        public int Vt { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Spd { get; set; }
        public int Acc { get; set; }
        public int Dex { get; set; }
        public int Stm { get; set; }

        // much help with ai to know what the fuck to do for the shop to be viable and working, pretty sure this will work
        public Items(string name, string description, int type, int price, int vt, int atk, int def, int spd, int acc, int dex)
        {
            Name = name;
            Description = description;
            Type = type;
            Price = price;
            Vt = vt;
            Atk = atk;
            Def = def;
            Spd = spd;
            Acc = acc;
            Dex = dex;
        }
    }

}
