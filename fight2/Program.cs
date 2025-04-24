// bundle everything into one exe file with .NET runtime (do it in Terminal (Ctrl + Shift + Ö))
// dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

Entity.Characters p1 = new();
p1.Hp = 100;
p1.Gold = 10000;
p1.UStm = 100;
p1.Stat = 20;
p1.MaxHp = p1.Hp;

// more precise and has easier time to attack first
Entity.Characters e1 = new();
e1.Name = "Kayn";
e1.Vt = 1;
e1.Atk = 6;
e1.Def = 1;
e1.Spd = 7;
e1.Acc = 5;
e1.Prc = 0;
e1.Dex = 0;
e1.Stm = 0;
e1.Hp = 100 + (10 * e1.Vt);
e1.UStm = 100 + (5 * e1.Stm);
e1.MaxHp = e1.Hp;
e1.MaxStm = e1.UStm;

// tanky enemy with high hp and defence
Entity.Characters e2 = new();
e2.Name = "Jackie";
e2.Vt = 20;
e2.Atk = 5;
e2.Def = 10;
e2.Spd = 0;
e2.Acc = 5;
e2.Prc = 0;
e2.Dex = 0;
e2.Stm = 0;
e2.Hp = 100 + (10 * e2.Vt);
e2.UStm = 100 + (5 * e2.Stm);
e2.MaxHp = e2.Hp;
e2.MaxStm = e2.UStm;

// hard to hit enemy which deals a lot damage when hitting, has low hp
Entity.Characters e3 = new();
e3.Name = "Evelynn";
e3.Vt = 2;
e3.Atk = 15;
e3.Def = 0;
e3.Spd = 5;
e3.Acc = 0;
e2.Prc = 0;
e3.Dex = 20;
e3.Stm = 0;
e3.Hp = 100 + (10 * e3.Vt);
e3.UStm = 100 + (5 * e3.Stm);
e3.MaxHp = e3.Hp;
e3.MaxStm = e3.UStm;

// enemy 4, just same stats as e1
Entity.Characters e4 = new();
e4.Name = "Enemy 4";
e4.Vt = 1;
e4.Atk = 6;
e4.Def = 1;
e4.Spd = 7;
e4.Acc = 5;
e4.Prc = 0;
e4.Dex = 0;
e4.Stm = 0;
e4.Hp = 100 + (10 * e4.Vt);
e4.UStm = 100 + (5 * e4.Stm);
e4.MaxHp = e4.Hp;
e4.MaxStm = e4.UStm;

// enemy 5, just same stats as e1
Entity.Characters e5 = new();
e5.Name = "Enemy 5";
e5.Vt = 1;
e5.Atk = 6;
e5.Def = 1;
e5.Spd = 7;
e5.Acc = 5;
e5.Prc = 0;
e5.Dex = 0;
e5.Stm = 0;
e5.Hp = 100 + (10 * e5.Vt);
e5.UStm = 100 + (5 * e5.Stm);
e5.MaxHp = e5.Hp;
e5.MaxStm = e5.UStm;

List<Entity.Weapons> inventory = new List<Entity.Weapons>();

    // 1 - Wepons
    // 2 - Helmet
    // 3 - BreastPlate
    // 4 - Leggings
    // 5 - Boots
    // 6 - Ring

// creates a list to store wepons objects for the shop
List<Entity.Weapons> weapons = new List<Entity.Weapons>();
// add wepons to the list
weapons.Add(new Entity.Weapons("Basic Sword", "A Sword made out of cheap metal", 1, 10, 0, 5, 0, 0, 0, 0));
weapons.Add(new Entity.Weapons("Iron Sword", "A sword made of higher metal which deals more damage", 1, 50, 0, 10, 0, 0, 0, 0));
weapons.Add(new Entity.Weapons("Steel Sword", "The best sword you can buy", 1, 100, 0, 15, 0, 0, 0, 0));
weapons.Add(new Entity.Weapons("Basic Helmet", "A Helmet made out cheap material", 2, 10, 3, 0, 2, 0, 0, 0));

// creates a list to store object in the players inventory


int storyPoint = 0;

string keepPlaying = "yes";

Random generator = new Random();

// ==================== MAIN ====================
Console.WriteLine("Version 2.0");
Console.WriteLine("ENTER to continue");
Console.ReadLine();


while (keepPlaying == "yes")
{
    // ------- NAME CHECK -------
    // just happens when you start the program or decide to reset
    if (storyPoint == 0)
    {
        p1 = BetweenFighting.NameCheck(p1, storyPoint);
    }

    // ------- BEFORE AND DURING FIGHT -------
    // just checks where you are in the story and makes you fight the correct person
    if (storyPoint == 0) // first enemy
    {
        (p1, weapons) = BetweenFighting.Intermission(p1, e1, weapons);
        (p1, e1, storyPoint) = Attacks.Fight(p1, e1, storyPoint);
        p1.Stat += 10;
    }
    else if (storyPoint == 1) // second enemy
    {
        (p1, weapons)  = BetweenFighting.Intermission(p1, e2, weapons);
        (p1, e2, storyPoint) = Attacks.Fight(p1, e2, storyPoint);
        p1.Stat += 10;
    }
    else if (storyPoint == 2) // third enemy
    {
        (p1, weapons)  = BetweenFighting.Intermission(p1, e3, weapons);
        (p1, e3, storyPoint) = Attacks.Fight(p1, e3, storyPoint);
        p1.Stat += 20;
    }
    else if (storyPoint == 3) // fourth enemy
    {
        (p1, weapons)  = BetweenFighting.Intermission(p1, e4, weapons);
        (p1, e4, storyPoint) = Attacks.Fight(p1, e4, storyPoint);
        p1.Stat += 5;
    }
    else if (storyPoint == 4) // fifth enemy
    {
        (p1, weapons)  = BetweenFighting.Intermission(p1, e5, weapons);
        (p1, e5, storyPoint) = Attacks.Fight(p1, e5, storyPoint);

    }

    // ------- STORY PROGRESSION CHECK -------
    // when you finish the game (5) or lose one fight (6) you get here
    if (storyPoint == 5 || storyPoint == 6)
    {
        Stat_Story.Story(storyPoint);
        Console.WriteLine("Write yes to restart from the beginning, leave it empty to exit");
        keepPlaying = Console.ReadLine();
        storyPoint = 0;
        e1.Hp = e1.MaxHp;
        e2.Hp = e2.MaxHp;
        e3.Hp = e3.MaxHp;
        p1.Stat = 20;
        p1.Vt = 0;
        p1.Atk = 0;
        p1.Def = 0;
        p1.Spd = 0;
        p1.Acc = 0;
        p1.Prc = 0;
        p1.Dex = 0;
        p1.Stm = 0;
    }
    else
    {
        Stat_Story.Story(storyPoint);
    }
    Console.Clear();
}