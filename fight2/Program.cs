// bundle everything into one exe file with .NET runtime (do it in Terminal (Ctrl + Shift + Ö))
// dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true


// allows me to use Regex to know if an answer has numbers in it
using System.Text.RegularExpressions;

Entity.Characters p1 = new();
p1.Hp = 100;
p1.Vt = 0;
p1.Atk = 0;
p1.Def = 0;
p1.Spd = 0;
p1.Acc = 0;
p1.Dex = 0;
p1.Stat = 20;

// more precise and has easier time to attack first
Entity.Characters e1 = new();
e1.Name = "Kayn";
e1.Vt = 1;
e1.Atk = 6;
e1.Def = 1;
e1.Spd = 7;
e1.Acc = 5;
e1.Dex = 0;
e1.Hp = 100 + (10 * e1.Vt);
e1.MaxHp = e1.Hp;

// tanky enemy with high hp and defence
Entity.Characters e2 = new();
e2.Name = "Jackie";
e2.Vt = 20;
e2.Atk = 5;
e2.Def = 10;
e2.Spd = 0;
e2.Acc = 5;
e2.Dex = 0;
e2.Hp = 100 + (10 * e2.Vt);
e2.MaxHp = e2.Hp;

// hard to hit enemy which deals a lot damage when hitting, has low hp
Entity.Characters e3 = new();
e3.Name = "Evelynn";
e3.Vt = 2;
e3.Atk = 15;
e3.Def = 0;
e3.Spd = 5;
e3.Acc = 0;
e3.Dex = 20;
e3.Hp = 100 + (10 * e3.Vt);
e3.MaxHp = e3.Hp;

int storyPoint = 0;
int gold = 100;

string keepPlaying = "yes";

Random generator = new Random();

// checks if the given text has numbers in it, if it has its on true, if not its on false
bool ContainsNumbers(string input)
{
    return Regex.IsMatch(input, @"\d");
}


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
        // lets you choose your name
        Console.WriteLine("Choose your Entity.Characters name (3-14 Entity.Characters long, no numbers)");
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
                Console.WriteLine("Name has numbers in it, please try again");
                p1.Name = Console.ReadLine();
            }
        }
        Stat_Story.Story(storyPoint);
        p1 = Stat_Story.StatPoints(p1);
    }

    // ------- BEFORE AND DURING FIGHT -------
    // just checks where you are in the story and makes you fight the correct person
    if (storyPoint == 0)
    {
        p1 = BetweenFighting.Intermission(p1, e1);
        (p1, e1, storyPoint) = Attacks.Fight(p1, e1, storyPoint);
        p1.Stat += 10;
    }
    else if (storyPoint == 1)
    {
        p1 = BetweenFighting.Intermission(p1, e2);
        (p1, e2, storyPoint) = Attacks.Fight(p1, e2, storyPoint);
        p1.Stat += 10;
    }
    else if (storyPoint == 2)
    {
        p1 = BetweenFighting.Intermission(p1, e3);
        (p1, e3, storyPoint) = Attacks.Fight(p1, e3, storyPoint);
    }

    // ------- STORY PROGRESSION CHECK -------
    // when you finish the game (3) or lose one fight (4) you get here
    if (storyPoint == 4 || storyPoint == 3)
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
        p1.Dex = 0;
    }
    else
    {
        Stat_Story.Story(storyPoint);
    }
    Console.Clear();
}