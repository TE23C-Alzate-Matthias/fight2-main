﻿// allows me to use Regex to know if an answer has numbers in it
using System.Text.RegularExpressions;

int randomChoice;
int storyProgression = 0;

string attackChoice;
string heroName;
string villanName;
string keepPlaying = "yes";

string[] acceptable = ["1", "2", "3", "4"];

Random generator = new Random();

// checks if the given text has numbers in it, if it has its on true, if not its on false
bool ContainsNumbers(string input)
{
    return Regex.IsMatch(input, @"\d");
}



// ==================== MAIN ====================

while (keepPlaying == "yes")
{

    if (storyProgression == 0)
    {
        story();
    }

    // when you finish the game or lose one fight you get here
    if (storyProgression == 4 || storyProgression == 3)
    {

        story();
        Console.WriteLine("Write yes to restart from the beginning, leave it empty to exit");
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

}

void betweenFight() 
{

    

}

void heroAction() 
{



}

void enemyAction()
{

    

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