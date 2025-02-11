﻿// allows me to use Regex to know if an answer has numbers in it
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

// all enemies stats are the same for now
Characters e1 = new();
e1.Name = "Kayn";
e1.Vt = 2;
e1.Atk = 3;
e1.Def = 0;
e1.Spd = 8;
e1.Acc = 3;
e1.Dex = 0;
e1.Hp = 100 + (10 * e1.Vt);
e1.MaxHp = e1.Hp;

Characters e2 = new();
e2.Name = "Jackie";
e2.Vt = 2;
e2.Atk = 3;
e2.Def = 0;
e2.Spd = 8;
e2.Acc = 3;
e2.Dex = 0;
e2.Hp = 100 + (10 * e2.Vt);
e2.MaxHp = e2.Hp;

Characters e3 = new();
e3.Name = "Evelynn";
e3.Vt = 2;
e3.Atk = 3;
e3.Def = 0;
e3.Spd = 8;
e3.Acc = 3;
e3.Dex = 0;
e3.Hp = 100 + (10 * e3.Vt);
e3.MaxHp = e3.Hp;


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
    // ------- NAME CHECK -------
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

    // ------- BEFORE AND DURING FIGHT -------
    // just checks where you are in the story and makes you fight the correct one
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

    // ------- STORY PROGRESSION CHECK -------
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

// ==================== METHODS ====================


// STORY PROGRESSION
static int story(int story)
{

    if (story == 0)
    {
        Console.WriteLine("you got thrown into prison and to get free you have to win 3 fights. first fight is against Kayn\n");
        Console.ReadLine();
    }
    else if (story == 1)
    {
        Console.WriteLine("you won your first fight against Kayn, now you have to fight Jackie ");
        Console.ReadLine();
    }
    else if (story == 2)
    {
        Console.WriteLine("you won your second fight against Jackie, now you have to fight Evelynn");
        Console.ReadLine();
    }
    else if (story == 3)
    {
        Console.WriteLine("You won your last fight against Evelynn and are now free to go! CONGRATS!");
        Console.ReadLine();
    }
    else if (story == 4)
    {
        Console.WriteLine("You win some, you lose some. this time you lost your life. Game over.");
        Console.ReadLine();
    }
    return story;
}


// STUFF YOU CAN DO BETWEEN FIGHTS
static Characters betweenFight(Characters player, Characters enemy)
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
            StatPoints(player);
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
    player.MaxHp = player.Hp;
    return player;
}


// FIRST TIME YOU WILL ADD STATPOINTS
static Characters FirstStats(Characters player)
{
    int choice;
    string option;
    string[] acceptable = ["1", "2", "3", "4", "5", "6", "7", "8"];

    while (player.Stat > 0)
    {
        Console.WriteLine($"Total Stat Points left: {player.Stat}");
        Console.WriteLine("Add Statpoints to your character:\n");
        Console.WriteLine($"1) Vitality: {player.Vt}");
        Console.WriteLine($"2) Attack: {player.Atk}");
        Console.WriteLine($"3) Defence: {player.Def}");
        Console.WriteLine($"4) Speed: {player.Spd}");
        Console.WriteLine($"5) Accuracy: {player.Acc}");
        Console.WriteLine($"6) Dexterity: {player.Dex}");
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
            player.Vt++;
            player.Stat--;
        }
        else if (choice == 2)
        {
            player.Atk++;
            player.Stat--;
        }
        else if (choice == 3)
        {
            player.Def++;
            player.Stat--;
        }
        else if (choice == 4)
        {
            player.Spd++;
            player.Stat--;
        }
        else if (choice == 5)
        {
            player.Acc++;
            player.Stat--;
        }
        else if (choice == 6)
        {
            player.Dex++;
            player.Stat--;
        }
        else if (choice == 7)
        {
            Console.WriteLine("\nVitality: +10 hp per point");
            Console.WriteLine("Attack:  1+ Minimun and Maximun damage when hitting an attack (+2 maximun damage on heavy attack)");
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
                player.Stat = player.Stat + player.Vt + player.Atk + player.Def + player.Spd + player.Acc + player.Dex;
                player.Vt = 0;
                player.Atk = 0;
                player.Def = 0;
                player.Spd = 0;
                player.Acc = 0;
                player.Dex = 0;
            }
        }
        Console.Clear();
    }
    player.Hp = 100 + (10 * player.Vt);
    player.MaxHp = player.Hp;
    return player;
}


// ALL OTHER TIMES YOU CHOOSE STATPOINTS AS AN OPTION
static Characters StatPoints(Characters player)
{
    int choice = 0;
    string option;
    string[] acceptable = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];

    while (choice != 9)
    {
        Console.Clear();
        Console.WriteLine($"Total Stat Points left: {player.Stat}");
        Console.WriteLine("Add Statpoints to your character:\n");
        Console.WriteLine($"Hp: {player.Hp}");
        Console.WriteLine($"1) Vitality: {player.Vt}");
        Console.WriteLine($"2) Attack: {player.Atk}");
        Console.WriteLine($"3) Defence: {player.Def}");
        Console.WriteLine($"4) Speed: {player.Spd}");
        Console.WriteLine($"5) Accuracy: {player.Acc}");
        Console.WriteLine($"6) Dexterity: {player.Dex}");
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
            Console.WriteLine("Attack: 1+ Minimun and Maximun damage when hitting an attack (+2 maximun damage on heavy attack)");
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

                player.Stat = player.Stat + player.Vt + player.Atk + player.Def + player.Spd + player.Acc + player.Dex;
                player.Vt = 0;
                player.Atk = 0;
                player.Def = 0;
                player.Spd = 0;
                player.Acc = 0;
                player.Dex = 0;
            }
        }
        else if (choice == 9)
        {
            // just checking if the user did type 9 so nothing happens
        }
        else if (player.Stat == 0)
        {
            Console.WriteLine("No stat points left, please try again");
            Console.ReadLine();
        }
        else if (choice == 1)
        {
            player.Vt++;
            player.Stat--;
        }
        else if (choice == 2)
        {
            player.Atk++;
            player.Stat--;
        }
        else if (choice == 3)
        {
            player.Def++;
            player.Stat--;
        }
        else if (choice == 4)
        {
            player.Spd++;
            player.Stat--;
        }
        else if (choice == 5)
        {
            player.Acc++;
            player.Stat--;
        }
        else if (choice == 6)
        {
            player.Dex++;
            player.Stat--;
        }
        player.Hp = 100 + (10 * player.Vt);
    }
    player.MaxHp = player.Hp;
    return player;
}


// FIGHT METHOD
// possible to move some stuff from this method to the main, will check on later

static (Characters player, Characters enemy, int story) fight(Characters player, Characters enemy, int story)
{
    Random generator = new Random();
    int enemySpeed;
    int playerSpeed;

    while (player.Hp > 0 && enemy.Hp > 0)
    {
        Console.Clear();
        Console.WriteLine("======= NEW ROUND =======");
        Console.WriteLine($"{player.Name}: {player.Hp} Hp  |  {enemy.Name}: {enemy.Hp} Hp\n");

        enemySpeed = generator.Next(1, 101) + (enemy.Spd * 5);
        playerSpeed = generator.Next(1, 101) + (player.Spd * 5);

        // if enemy speed is higher than player speed, the enemy attacks first
        if (enemySpeed > playerSpeed)
        {
            Console.WriteLine($"The enemy attacks first");
            Console.WriteLine("ENTER to continue");
            Console.ReadLine();
            (player, enemy) = enemyAttack(player, enemy);
            (player, enemy) = playerAttack(player, enemy);
        }
        else
        {
            Console.WriteLine($"you attacks first");
            Console.WriteLine("ENTER to continue");
            Console.ReadLine();
            (player, enemy) = playerAttack(player, enemy);
            (player, enemy) = enemyAttack(player, enemy);
        }
    }

    // ------- WHO WIN FIGHT CHECK -------
    Console.WriteLine("\n======== THE FIGHT IS OVER ========");

    if (player.Hp == 0 && enemy.Hp == 0)
    {
        Console.WriteLine("BOTH DIED\n");
        story = 4;
    }
    else if (player.Hp == 0)
    {
        Console.WriteLine($"{player.Name} died, {enemy.Name} won!\n");
        story = 4;
    }
    else
    {
        Console.WriteLine($"{enemy.Name} died, {player.Name} won!\n");
        story++;
    }
    Console.WriteLine("ENTER to continue");
    Console.ReadLine();
    player.Hp = player.MaxHp;

    return (player, enemy, story);
}


// PLAYER ATTACK METHOD
static (Characters player, Characters enemy) playerAttack(Characters player, Characters enemy)
{

    Random generator = new Random();
    string attackChoice;
    int accuracy;
    int healing;
    string[] acceptable = ["a", "b", "c", "d", "1", "2", "3", "4"];

    // lets the user choose what action they want to do
    Console.WriteLine("--- Choose Action ---");
    Console.WriteLine($"1) Light Attack: {5 + player.Atk - enemy.Def}-{20 + player.Atk - enemy.Def}, {80 + player.Acc - enemy.Dex - enemy.ExtraDodge}% Accuracy");
    Console.WriteLine($"2) Heavy Attack: {10 + player.Atk}-{40 + (player.Atk * 2)}, {30 + player.Acc - enemy.Dex - enemy.ExtraDodge}% Accuracy");
    Console.WriteLine($"3) Dodge: +{player.Dex}% added to opponents accuracy check");
    Console.WriteLine($"4) Rest: {player.MaxHp / 7}-{player.MaxHp / 4} healing");
    attackChoice = Console.ReadLine();

    // if the answer is not one of the options in the array "acceptable" it asks you to try again
    while (!acceptable.Contains(attackChoice))
    {
        Console.WriteLine("Unknown answer, please try again\n");
        attackChoice = Console.ReadLine();
    }


    // ==================== Player ATTACK =====================
    accuracy = generator.Next(1, 101);
    player.ExtraDodge = 0;

    // if you choose 1 or a the user tries a light attack
    if (attackChoice == "a" || attackChoice == "1")
    {
        if (accuracy > 80 - player.Acc + enemy.Dex + enemy.ExtraDodge)
        {
            Console.WriteLine($"{player.Name} missed their attack\n");
        }
        else
        {
            player.Dmg = generator.Next(5 + player.Atk - enemy.Def, 21 + player.Atk - enemy.Def);
            enemy.Hp -= player.Dmg;
            enemy.Hp = Math.Max(0, enemy.Hp);
            Console.WriteLine($"{player.Name} uses light attack!");
            Console.WriteLine($"{player.Name} does {player.Dmg} damage to {enemy.Name}\n");
        }
    }
    // if you chhose 2 or b the user tries a heavy attack
    else if (attackChoice == "b" || attackChoice == "2")
    {
        if (accuracy > 30 - player.Acc + enemy.Dex + enemy.ExtraDodge)
        {
            Console.WriteLine($"{player.Name} missed their attack\n");
        }
        else
        {
            player.Dmg = generator.Next(10 + player.Atk - enemy.Def, 41 + (player.Atk * 2) - enemy.Def);
            enemy.Hp -= player.Dmg;
            enemy.Hp = Math.Max(0, enemy.Hp);
            Console.WriteLine($"{player.Name} uses heavy attack!");
            Console.WriteLine($"{player.Name} does {player.Dmg} damage to {enemy.Name}\n");
        }
    }
    // if you choose 3 or c the user gets extra dodge chance
    else if (attackChoice == "c" || attackChoice == "3")
    {
        player.ExtraDodge = player.Dex;
        Console.WriteLine($"{player.Name} prepares to dodge {enemy.Name} next action");
    }
    // if you choose 4 or d the user heals an amout of hp
    else if (attackChoice == "d" || attackChoice == "4")
    {
        healing = generator.Next(player.MaxHp / 7, player.MaxHp / 4 + 1);
        player.Hp += healing;
        Console.WriteLine($"{player.Name} healed {healing} Hp");
    }
    Console.WriteLine("ENTER to continue");
    Console.ReadLine();

    return (player, enemy);

}

// 
static (Characters player, Characters enemy) enemyAttack(Characters player, Characters enemy)
{
    Random generator = new Random();
    int accuracy = generator.Next(1, 101);
    int randomChoice;
    int healing;
    enemy.ExtraDodge = 0;

    if (enemy.Hp < enemy.MaxHp / 3) // when hp is 
    {
        randomChoice = generator.Next(4);
    }
    else if (enemy.Hp < enemy.MaxHp / 3 * 2)
    {
        randomChoice = generator.Next(3);
    }
    else
    {
        randomChoice = generator.Next(2);
    }

    // enemy using light attack
    if (randomChoice == 0)
    {
        if (accuracy > 80 - enemy.Acc + player.Dex + player.ExtraDodge)
        {
            Console.WriteLine($"{player.Name} missed their attack\n");
        }
        else
        {
            enemy.Dmg = generator.Next(5 + player.Atk - enemy.Def, 21 + player.Atk - player.Def);
            player.Hp -= enemy.Dmg;
            player.Hp = Math.Max(0, player.Hp);
            Console.WriteLine($"{enemy.Name} uses light attack!");
            Console.WriteLine($"{enemy.Name} does {enemy.Dmg} damage to {player.Name}\n");
        }
    }
    // enemy using heavy attack
    else if (randomChoice == 1)
    {
        if (accuracy > 30 - enemy.Acc + player.Dex + player.ExtraDodge)
        {
            Console.WriteLine($"{enemy.Name} missed their attack\n");
        }
        else
        {
            enemy.Dmg = generator.Next(10 + player.Atk - enemy.Def, 41 + (player.Atk * 2) - player.Def);
            player.Hp -= enemy.Dmg;
            player.Hp = Math.Max(0, player.Hp);
            Console.WriteLine($"{enemy.Name} uses light attack!");
            Console.WriteLine($"{enemy.Name} does {enemy.Dmg} damage to {player.Name}\n");
        }
    }
    // enemy using dodge
    else if (randomChoice == 2)
    {
        enemy.ExtraDodge = enemy.Dex;
        Console.WriteLine($"{enemy.Name} prepares to dodge {player.Name} next action");
    }
    // enemy using rest
    else if (randomChoice == 3)
    {
        healing = generator.Next(enemy.MaxHp / 7, enemy.MaxHp / 4 + 1);
        enemy.Hp += healing;
        Console.WriteLine($"{enemy.Name} healed {healing} Hp");
    }
    Console.WriteLine("ENTER to continue");
    Console.ReadLine();

    return (player, enemy);
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
// Dmg - Damage

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
    public int ExtraDodge;
    public int MaxHp;
    public int Dmg;
}