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

    p1 = betweenFight(p1, e1);
    storyPoint++;

    //while (p1.Hp > 0 && e1.Hp > 0)
    //{



    //}



    // ======================== FIGHT END ========================

    Console.WriteLine("\n======== FIGHT IS OVER ========");

    if (p1.Hp == 0 && p1.Hp == 0)
    {

        Console.WriteLine("Both died, no one won\n");
        storyPoint = 4;

    }
    else if (p1.Hp == 0)
    {

        Console.WriteLine($"{p1.Name} died, {e1.Name} Won!\n");
        storyPoint = 4;

    }
    // change this to else if (e1.Hp == 0)
    else
    {

        Console.WriteLine($"{e1.Name} died, {p1.Name} won!\n");
        storyPoint++;

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
    int storyProgression = story;

    if (storyProgression == 0)
    {

        Console.WriteLine("placeholder start story\n");
        Console.ReadLine();

    }
    else if (storyProgression == 1)
    {

        Console.WriteLine("placeholder win first fight");
        Console.ReadLine();

    }
    else if (storyProgression == 2)
    {

        Console.WriteLine("placeholder win second fight");
        Console.ReadLine();

    }
    else if (storyProgression == 3)
    {

        Console.WriteLine("placeholder win last fight");
        Console.ReadLine();

    }
    else if (storyProgression == 4)
    {

        Console.WriteLine("Placeholder losing anytime");
        Console.ReadLine();

    }
    return storyProgression;

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

                // exits the enviroment
                Environment.Exit(0);

            }

        }

        Console.Clear();

    }

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
            Console.WriteLine("Attack: +2 Damage when hitting an attack on someone per point");
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
            Console.WriteLine("Attack: +2 Damage when hitting an attack on someone per point");
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

    }

    hero.Hp = 100 + (10 * hero.Vt);
    return hero;

}

static Characters fight(Characters hero, Characters enemy)
{
    Random generator = new Random();
    int accuracy;
    

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
    public int Vt;
    public int Atk;
    public int Def;
    public int Spd;
    public int Acc;
    public int Dex;
    public int Stat;

}