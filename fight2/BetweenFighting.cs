public class BetweenFighting
{
    // STUFF YOU CAN DO BETWEEN FIGHTS
    public static Entity.Characters Intermission(Entity.Characters player, Entity.Characters enemy)
    {
        int choice = 0;
        string option;
        string[] acceptable = ["1", "2", "3", "4", "5", "6"];

        while (choice != 3)
        {
            Console.Write("1) Check Stats ");
            if (player.Stat != 0)
            {
                Console.Write($"(YOU HAVE {player.Stat} STAT POINTS TO USE)");
            }
            Console.WriteLine("\n2) Next Enemy");
            Console.WriteLine("3) Start Next Fight");
            Console.WriteLine("4) Info (Not implemented yet)");
            Console.WriteLine("5) Quit");

            option = Console.ReadLine();
            int.TryParse(option, out choice);

            // if your answer does not contain 1, 2, 3, 4, 5 or 6
            while (!acceptable.Contains(option))
            {
                Console.WriteLine("Unknown option, please try again");
                option = Console.ReadLine();
                int.TryParse(option, out choice);
            }

            if (choice == 1)
            {
                // stats option
                Stat_Story.StatPoints(player);
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
                // gonna impliment stuff here that gives some needed info about some stuff
            }
            else if (choice == 5)
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
            else if (choice == 6)
            {
                // insta end fight when it starts
                Console.WriteLine("Enemy will start wtih 0 hp next fight");
                enemy.Hp = 0;
                Console.ReadLine();
            }
            Console.Clear();
        }
        player.MaxHp = player.Hp;
        return player;
    }
}
