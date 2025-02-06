// allows me to use Regex to know if an answer has numbers in it
using System.Text.RegularExpressions;

Characters p1 = new();
p1.Hp = 100;
p1.Vt = 0;
p1.Atk = 0;
p1.Def = 0;
p1.Spd = 0;
p1.Acc = 0;
p1.Dex = 0;
p1.Stat = 20;

Characters e1 = new();
e1.Name = "Jax";
e1.Vt = 2;
e1.Atk = 3;
e1.Def = 0;
e1.Spd = 8;
e1.Acc = 3;
e1.Dex = 0;
e1.Hp = 100 + (10 * e1.Vt);
e1.MaxHp = e1.Hp;

Characters e2 = new();
Characters e3 = new();

// int randomChoice;
int storyPoint = 0;

string keepPlaying = "yes";


Random generator = new Random();

// checks if the given text has numbers in it, if it has its on true, if not its on false
bool ContainsNumbers(string input)
{
    return Regex.IsMatch(input, @"\d");
}



// ==================== MAIN ====================

while (keepPlaying == "yes")
{
    // just happens when you start the program or decide to reset
    if (storyPoint == 0)
    {
        // lets you choose your name
        Console.WriteLine("Choose your characters name (3-14 characters long, no numbers)");
        p1.Name = Console.ReadLine();

        while (p1.Name.Length < 3 || p1.Name.Length > 15 || ContainsNumbers(p1.Name))
        {
            // if the name is shorter than 3 it tells me to try again
            if (p1.Name.Length < 3)
            {
                Console.WriteLine("Name is to short, please try again");
                p1.Name = Console.ReadLine();
            }
            // same thing but if longer than 15
            else if (p1.Name.Length > 15)
            {
                Console.WriteLine("Namn is to long, please try again");
                p1.Name = Console.ReadLine();
            }
            // same thing but if it has numbers in it
            else if (ContainsNumbers(p1.Name))
            {
                Console.WriteLine("Namn has numbers in it, please try again");
                p1.Name = Console.ReadLine();
            }
        }
        story(storyPoint);
        p1 = FirstStats(p1);
    }

    if (storyPoint == 0)
    {
        p1 = betweenFight(p1, e1);
        (p1, e1, storyPoint) = fight(p1, e1, storyPoint);
    }
    else if (storyPoint == 1)
    {
        p1 = betweenFight(p1, e2);
        (p1, e2, storyPoint) = fight(p1, e2, storyPoint);
    }
    else if (storyPoint == 2)
    {
        p1 = betweenFight(p1, e3);
        (p1, e3, storyPoint) = fight(p1, e3, storyPoint);
    }

    // when you finish the game (3) or lose one fight (4) you get here
    if (storyPoint == 4 || storyPoint == 3)
    {
        story(storyPoint);
        Console.WriteLine("Write yes to restart from the beginning, leave it empty to exit");
        keepPlaying = Console.ReadLine();
        storyPoint = 0;
    }
    else
    {
        story(storyPoint);
    }
    Console.Clear();
}

// ==================== METODER ====================

// STORY PROGRESSION
static int story(int story)
{

    if (story == 0)
    {
        Console.WriteLine("placeholder start story\n");
        Console.ReadLine();
    }
    else if (story == 1)
    {
        Console.WriteLine("placeholder win first fight");
        Console.ReadLine();
    }
    else if (story == 2)
    {
        Console.WriteLine("placeholder win second fight");
        Console.ReadLine();
    }
    else if (story == 3)
    {
        Console.WriteLine("placeholder win last fight");
        Console.ReadLine();
    }
    else if (story == 4)
    {
        Console.WriteLine("Placeholder losing anytime");
        Console.ReadLine();
    }
    return story;
}

// STUFF YOU CAN DO BETWEEN FIGHTS
static Characters betweenFight(Characters hero, Characters enemy)
{
    int choice = 0;
    string option;
    string[] acceptable = ["1", "2", "3", "4"];

    while (choice != 3)
    {
        Console.WriteLine("1) Check Stats");
        Console.WriteLine("2) Next Enemy");
        Console.WriteLine("3) Start Next Fight");
        Console.WriteLine("4) Quit");

        option = Console.ReadLine();
        int.TryParse(option, out choice);

        // if your answer does not contain 1, 2, 3 or 4 
        while (!acceptable.Contains(option))
        {
            Console.WriteLine("Unknown option, please try again");
            option = Console.ReadLine();
            int.TryParse(option, out choice);
        }

        if (choice == 1)
        {
            // stats option
            StatPoints(hero);
        }
        else if (choice == 2)
        {
            Console.Clear();
            Console.WriteLine($"Next enemy: {enemy.Name}");
            Console.WriteLine($"Hp: {enemy.Hp}");
            Console.WriteLine($"Vitality: {enemy.Vt}");
            Console.WriteLine($"Attack: {enemy.Atk}");
            Console.WriteLine($"Defence: {enemy.Def}");
            Console.WriteLine($"Speed: {enemy.Spd}");
            Console.WriteLine($"Accuracy: {enemy.Acc}");
            Console.WriteLine($"Dexterity: {enemy.Dex}");
            Console.WriteLine($"Press enter to get back");
            Console.ReadLine();
        }
        else if (choice == 4)
        {
            // if you want to exit program
            Console.WriteLine("Are you sure you want to quit? (Write yes if you want to quit)");
            option = Console.ReadLine();
            if (option == "yes")
            {
                // exits the program and closes it
                Environment.Exit(0);
            }
        }
        Console.Clear();
    }
    hero.MaxHp = hero.Hp;
    return hero;
}

// FIRST TIME YOU WILL ADD STATPOINTS
static Characters FirstStats(Characters hero)
{
    int choice;
    string option;
    string[] acceptable = ["1", "2", "3", "4", "5", "6", "7", "8"];

    while (hero.Stat > 0)
    {
        Console.WriteLine($"Total Stat Points left: {hero.Stat}");
        Console.WriteLine("Add Statpoints to your character:\n");
        Console.WriteLine($"1) Vitality: {hero.Vt}");
        Console.WriteLine($"2) Attack: {hero.Atk}");
        Console.WriteLine($"3) Defence: {hero.Def}");
        Console.WriteLine($"4) Speed: {hero.Spd}");
        Console.WriteLine($"5) Accuracy: {hero.Acc}");
        Console.WriteLine($"6) Dexterity: {hero.Dex}");
        Console.WriteLine($"7) Help");
        Console.WriteLine($"8) Reset Stat Points");

        option = Console.ReadLine();
        int.TryParse(option, out choice);

        // if your answer does not contain 1, 2, 3, 4, 5, 6, 7
        while (!acceptable.Contains(option))
        {
            Console.WriteLine("Unknown option, please try again");
            option = Console.ReadLine();
            int.TryParse(option, out choice);
        }

        // i feel like this can get more compacted but will leave it like this for now
        if (choice == 1)
        {
            hero.Vt++;
            hero.Stat--;
        }
        else if (choice == 2)
        {
            hero.Atk++;
            hero.Stat--;
        }
        else if (choice == 3)
        {
            hero.Def++;
            hero.Stat--;
        }
        else if (choice == 4)
        {
            hero.Spd++;
            hero.Stat--;
        }
        else if (choice == 5)
        {
            hero.Acc++;
            hero.Stat--;
        }
        else if (choice == 6)
        {
            hero.Dex++;
            hero.Stat--;
        }
        else if (choice == 7)
        {
            Console.WriteLine("\nVitality: +10 hp per point");
            Console.WriteLine("Attack:  Ups the damage cap by 1 (by 2 with heavy attack)");
            Console.WriteLine("Defence: -1 Damage taken when getting hit per point");
            Console.WriteLine("Speed: +5 on Speed Checks per point");
            Console.WriteLine("Accuracy: +1% Chance to hit an attack per point");
            Console.WriteLine("Dexterity: +1% Chance to dodge an attack per point");
            Console.WriteLine("(Click Enter to get back)");
            Console.ReadLine();
        }
        else if (choice == 8)
        {
            Console.WriteLine("Are you sure you want to reset your stats?");
            Console.WriteLine("Write 'yes' if you are sure");
            option = Console.ReadLine();

            if (option == "yes")
            {
                hero.Stat = hero.Stat + hero.Vt + hero.Atk + hero.Def + hero.Spd + hero.Acc + hero.Dex;
                hero.Vt = 0;
                hero.Atk = 0;
                hero.Def = 0;
                hero.Spd = 0;
                hero.Acc = 0;
                hero.Dex = 0;
            }
        }
        Console.Clear();
    }
    hero.Hp = 100 + (10 * hero.Vt);
    hero.MaxHp = hero.Hp;
    return hero;
}

// ALL OTHER TIMES YOU CHOOSE STATPOINTS AS AN OPTION
static Characters StatPoints(Characters hero)
{
    int choice = 0;
    string option;
    string[] acceptable = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];

    while (choice != 9)
    {
        Console.Clear();
        Console.WriteLine($"Total Stat Points left: {hero.Stat}");
        Console.WriteLine("Add Statpoints to your character:\n");
        Console.WriteLine($"Hp: {hero.Hp}");
        Console.WriteLine($"1) Vitality: {hero.Vt}");
        Console.WriteLine($"2) Attack: {hero.Atk}");
        Console.WriteLine($"3) Defence: {hero.Def}");
        Console.WriteLine($"4) Speed: {hero.Spd}");
        Console.WriteLine($"5) Accuracy: {hero.Acc}");
        Console.WriteLine($"6) Dexterity: {hero.Dex}");
        Console.WriteLine($"7) Help");
        Console.WriteLine($"8) Reset Stat Points");
        Console.WriteLine($"9) Exit");

        option = Console.ReadLine();
        int.TryParse(option, out choice);

        // if your answer does not contain 1, 2, 3, 4, 5, 6, 7
        while (!acceptable.Contains(option))
        {
            Console.WriteLine("Unknown option, please try again");
            option = Console.ReadLine();
            int.TryParse(option, out choice);
        }

        // i feel like this can get more compacted but will leave it like this for now
        if (choice == 7)
        {
            Console.WriteLine("\nVitality: +10 hp per point");
            Console.WriteLine("Attack: Ups the damage cap by 1 (by 2 with heavy attack)");
            Console.WriteLine("Defence: -1 Damage taken when getting hit per point");
            Console.WriteLine("Speed: +5 on Speed Checks per point");
            Console.WriteLine("Accuracy: +1% Chance to hit an attack per point");
            Console.WriteLine("Dexterity: +1% Chance to dodge an attack per point");
            Console.WriteLine("(Click Enter to get back)");
            Console.ReadLine();
        }
        else if (choice == 8)
        {
            Console.WriteLine("Are you sure you want to reset your stats?");
            Console.WriteLine("Write 'yes' if you are sure");
            option = Console.ReadLine();
            if (option == "yes")
            {

                hero.Stat = hero.Stat + hero.Vt + hero.Atk + hero.Def + hero.Spd + hero.Acc + hero.Dex;
                hero.Vt = 0;
                hero.Atk = 0;
                hero.Def = 0;
                hero.Spd = 0;
                hero.Acc = 0;
                hero.Dex = 0;
            }
        }
        else if (choice == 9)
        {
            // just checking if the user did type 9 so nothing happens
        }
        else if (hero.Stat == 0)
        {
            Console.WriteLine("No stat points left, please try again");
            Console.ReadLine();
        }
        else if (choice == 1)
        {
            hero.Vt++;
            hero.Stat--;
        }
        else if (choice == 2)
        {
            hero.Atk++;
            hero.Stat--;
        }
        else if (choice == 3)
        {
            hero.Def++;
            hero.Stat--;
        }
        else if (choice == 4)
        {
            hero.Spd++;
            hero.Stat--;
        }
        else if (choice == 5)
        {
            hero.Acc++;
            hero.Stat--;
        }
        else if (choice == 6)
        {
            hero.Dex++;
            hero.Stat--;
        }
        hero.Hp = 100 + (10 * hero.Vt);
    }
    hero.MaxHp = hero.Hp;
    return hero;
}

static (Characters hero, Characters enemy, int story) fight(Characters hero, Characters enemy, int story)
{
    Random generator = new Random();
    string attackChoice;
    int accuracy;
    int Dmg;
    int randomChoice;
    int extraDodgeHero = 0;
    int extraDodgeEnemy = 0;
    string[] acceptable = ["a", "b", "c", "d", "1", "2", "3", "4"];
    
    while (hero.Hp > 0 && enemy.Hp > 0)
    {
        // going to impliment speed check later
        // going to probably need to add everything bellow here in to methods to make it more readable

        Console.Clear();
        Console.WriteLine("======= NEW ROUND =======");
        Console.WriteLine($"{hero.Name}: {hero.Hp} Hp  |  {enemy.Name}: {enemy.Hp} Hp\n");

        // lets the user choose what action they want to do
        Console.WriteLine("--- Choose Action ---");
        Console.WriteLine($"1) Light Attack: {5+hero.Atk-enemy.Def}-{20+hero.Atk-enemy.Def}, {80+hero.Acc-enemy.Dex-extraDodgeEnemy}% Accuracy");
        Console.WriteLine($"2) Heavy Attack: {10+hero.Atk}-{40+(hero.Atk * 2)}, {30+hero.Acc-enemy.Dex-extraDodgeEnemy}% Accuracy");
        Console.WriteLine($"3) Dodge: +{hero.Dex}% to dodge");
        Console.WriteLine($"4) Rest: {hero.MaxHp/7}-{hero.MaxHp/3} healing");
        attackChoice = Console.ReadLine();

        // if the answe is not one of the options in the array "acceptable" it asks you to try again
         while (!acceptable.Contains(attackChoice))
        {
            Console.WriteLine("Okänt Svar, försök igen\n");
            attackChoice = Console.ReadLine();
        }


        // ==================== HERO ATTACK =====================
        accuracy = generator.Next(1, 101);
        extraDodgeHero = 0;

        // if you choose 1 or a the user tries a light attack
        if (attackChoice == "a" || attackChoice == "1")
        {
            if (accuracy > 80-hero.Acc+enemy.Dex+extraDodgeEnemy)
            {
                Console.WriteLine($"{hero.Name} missed their attack\n");
            }
            else
            {
                Dmg = generator.Next(5+hero.Atk-enemy.Def, 21+hero.Atk-enemy.Def);
                enemy.Hp -= Dmg;
                enemy.Hp = Math.Max(0, enemy.Hp);
                Console.WriteLine($"{hero.Name} uses light attack!");
                Console.WriteLine($"{hero.Name} does {Dmg} to {enemy.Name}\n");
            }
        }
        // if you chhose 2 or b the user tries a heavy attack
        else if (attackChoice == "b" || attackChoice == "2")
        {
            if (accuracy > 30-hero.Acc+enemy.Dex+extraDodgeEnemy)
            {
                Console.WriteLine($"{hero.Name} missed their attack\n");
            }
            else
            {
                Dmg = generator.Next(10+hero.Atk-enemy.Def, 40+(hero.Atk*2)-enemy.Def);
                enemy.Hp -= Dmg;
                enemy.Hp = Math.Max(0, enemy.Hp);
                Console.WriteLine($"{hero.Name} uses heavy attack!");
                Console.WriteLine($"{hero.Name} does {Dmg} to {enemy.Name}\n");
            }
        }


        //  ==================== ENEMY ATTACK ========================

        // gives the enemy a randon choice
        


    }
    hero.Hp = 100 + (10 * hero.Vt);
    return (hero, enemy, story);
}

// ==================== CLASS ====================

// Hp - hitpoint
// Vt - Vitality
// Atk - Attack
// Def - Defense
// Spd - Speed
// Acc - Accuracy
// Dex - Dexterity
// Stat - Stat Points

class Characters
{
    public string Name;
    public int Hp;
    public int MaxHp;
    public int Vt;
    public int Atk;
    public int Def;
    public int Spd;
    public int Acc;
    public int Dex;
    public int Stat;
}