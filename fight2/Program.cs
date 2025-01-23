// allows me to use Regex to know if an answer has numbers in it
using System.Text.RegularExpressions;

int randomChoice;
int storyProgression = 0;

string attackChoice;
string heroName;
string villanName;
string keepPlaying = "ja";

List<string> acceptable = ["1", "2", "3", "4"];

Random generator = new Random();

// checks if the given text has numbers in it, if it has its on true, if not its on false
bool ContainsNumbers(string input)
{
    return Regex.IsMatch(input, @"\d");
}



// ==================== MAIN ====================

while (keepPlaying == "ja")
{

    story();
    storyProgression++;
    Console.ReadLine();

    if (storyProgression == 4 || storyProgression == 3)
    {

        story();
        Console.WriteLine("Skriv ja om du vill försöka om igen, lämna det tomt om du vill stänga programmet");
        keepPlaying = Console.ReadLine();
        storyProgression = 0;

    }

}

// ==================== METODER ====================
void story()
{

    if (storyProgression == 0)
    {
        Console.WriteLine("Choose your characters name (3-14 characters long, no numbers)");
        heroName = Console.ReadLine();

        while (heroName.Length < 3 || heroName.Length > 15 || ContainsNumbers(heroName))
        {
            // if the name is shorter than 3 it tells me to try again
            if (heroName.Length < 3)
            {
                Console.WriteLine("Namnet är för kort, försök igen");
                heroName = Console.ReadLine();
            }
            // same thing but if longer than 15
            else if (heroName.Length > 15)
            {
                Console.WriteLine("Namnet är för långt, försök igen");
                heroName = Console.ReadLine();
            }
            // same thing but if it has numbers in it
            else if (ContainsNumbers(heroName))
            {
                Console.WriteLine("Namnet har nummer i sig, försök igen");
                heroName = Console.ReadLine();
            }
        }


        Console.WriteLine("test\n");


    }
    else if (storyProgression == 1)
    {

        Console.WriteLine("testing this shit");

    }
    else if (storyProgression == 2)
    {

        Console.WriteLine("placeholder");

    }
    else if (storyProgression == 3)
    {

        Console.WriteLine("placeholder winning");

    }
    else if (storyProgression == 4)
    {

        Console.WriteLine("Placeholder losing");

    }

}

void heroAction() 
{



}

void enemyAction()
{

    

}


// ==================== CLASS ====================

// will maybe just not use class but have it here just in case
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
