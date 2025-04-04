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
        public string Name;
        public int Hp;
        public int Vt;
        public int Atk;
        public int Def;
        public int Spd;
        public int Acc;
        public int Prc; // new
        public int Dex;
        public int Stat;
        public int ExtraDodge;
        public int MaxHp;
        public int Dmg;
        public int Stm; // new
        public int UStm; // new
        public int MaxStm; // new
        public int Bonus; // new
        public int Exh; // new
        public int Gold; // new
        public List<string> Inventory; // new
        public List<string> Attacks; // new
    }

    // 1 - Weops
    // 2 - Helmet
    // 3 - BreastPlate
    // 4 - Leggings
    // 5 - Boots
    // 6 - Ring
    public class Wepons
    {
        public string Name;
        public string Description;
        public int Type;
        public int Price;
        public int Vt;
        public int Atk;
        public int Def;
        public int Spd;
        public int Acc;
        public int Dex;
        public int Stm;
    }

}
