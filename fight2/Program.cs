// allows me to use Regex to know if an answer has numbers in it
using System.Text.RegularExpressions;

Characters p1 = new();
Characters e1 = new();
Characters e2 = new();
Characters e3 = new();

int randomChoice;
int storyPoint = 0;
int statPoints = 20;

string keepPlaying = "yes";

List<string> enemy = [e1.Name, e2.Name, e3.Name];

Random generator = new Random();

// checks if the given text has numbers in it, if it has its on true, if not its on false
bool ContainsNumbers(string input)
{
    return Regex.IsMatch(input, @"\d");
}



// ==================== MAIN ====================

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

while (keepPlaying == "yes")
{
    // just happens when you start the program or decide to reset
    if (storyPoint == 0)
    {
        story(storyPoint);
    }

    Console.WriteLine(p1.Name);
    betweenFight(p1);
    storyPoint++;

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
        if (!acceptable.Contains(option))
        {

            Console.WriteLine("Unknown option, please try again");

        }
        else if (choice == 1)
        {

            // stats option
            

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



// ==================== CLASS ====================

// Hp - Vitality
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
    public int Atk;
    public int Def;
    public int Spd;
    public int Acc;
    public int Dex;
    public int Stm;

}