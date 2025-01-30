﻿// allows me to use Regex to know if an answer has numbers in it
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

Characters p1 = new();
p1.Hp = 100;
p1.Vt = 0;
p1.Atk = 0;
p1.Def = 0;
p1.Spd = 0;
p1.Acc = 0;
p1.Dex = 0;

Characters e1 = new();
e1.Name = "Jax";
e1.Hp = 100;

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
        Console.WriteLine("This is your name as long you are inside the program");
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

    Console.WriteLine(p1.Name);
    p1 = betweenFight(p1);
    storyPoint++;

    while (p1.Hp > 0 && e1.Hp > 0) 
    {



    }


        // when you finish the game or lose one fight you get here
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
static Characters betweenFight(Characters hero)
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

            // check next enemy option

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
    int startPoints = 20;

    int choice = 0;
    string option;
    string[] acceptable = ["1", "2", "3", "4", "5", "6", "7"];

    while (startPoints > 0)
    {

        Console.WriteLine($"Total Stat Points left: {startPoints}");
        Console.WriteLine("Add Statpoints to your character:\n");
        Console.WriteLine($"1) Vitality: {hero.Vt}");
        Console.WriteLine($"2) Attack: {hero.Atk}");
        Console.WriteLine($"3) Defence: {hero.Def}");
        Console.WriteLine($"4) Speed: {hero.Spd}");
        Console.WriteLine($"5) Accuracy: {hero.Acc}");
        Console.WriteLine($"6) Dexterity: {hero.Dex}");
        Console.WriteLine($"7) Help");

        option = Console.ReadLine();
        int.TryParse(option, out choice);

        // if your answer does not contain 1, 2, 3, 4, 5, 6, 7
        while (!acceptable.Contains(option))
        {

            Console.WriteLine("Unknown option, please try again");
            option = Console.ReadLine();
            int.TryParse(option, out choice);

        }  

        // i feel like this can get more compacted but will leave it like thos for now
        if (choice == 1)
        {

            hero.Vt++;
            startPoints--;

        }
        else if (choice == 2)
        {

            hero.Atk++;
            startPoints--;

        }
        else if (choice == 3)
        {

            hero.Def++;
            startPoints--;

        }
        else if (choice == 4)
        {

            hero.Spd++;
            startPoints--;

        }
        else if (choice == 5)
        {

            hero.Acc++;
            startPoints--;

        }
        else if (choice == 6)
        {

            hero.Dex++;
            startPoints--;

        }
        else if (choice == 7)
        {

            Console.WriteLine("Vitality: +10 hp per point");
            Console.WriteLine("Attack: +2 Damage when hitting an attack on someone per point");
            Console.WriteLine("Defence: -1 Damage when getting hit by an attack per point");
            Console.WriteLine("Speed: +5 on Speed Checks per point");
            Console.WriteLine("Accuracy: +1% Chance to hit an attack per point");
            Console.WriteLine("Dexterity: +1% Chance to dodge an attack per point");
            Console.WriteLine("(Click Anything to get back)");
            Console.ReadLine();

        }

        Console.Clear();

    }

    return hero;
}

// ALL OTHER TIMES YOU CHOOSE STATPOINTS AS AN OPTION
static Characters StatPoints(Characters hero)
{

    return hero;

}

// ==================== CLASS ====================

// Hp - hitpoint
// Vt - Vitality
// Atk - Attack
// Def - Defense
// Spd - Speed
// Acc - Accuracy
// Dex - Dexterity
// Stm - Stamina

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

}