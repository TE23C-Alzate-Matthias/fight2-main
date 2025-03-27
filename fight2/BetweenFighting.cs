public class BetweenFighting
{
//    _____           _                               _               _                     __  __          _     _                   _ 
//   |_   _|         | |                             (_)             (_)                   |  \/  |        | |   | |                 | |
//     | |    _ __   | |_    ___   _ __   _ __ ___    _   ___   ___   _    ___    _ __     | \  / |   ___  | |_  | |__     ___     __| |
//     | |   | '_ \  | __|  / _ \ | '__| | '_ ` _ \  | | / __| / __| | |  / _ \  | '_ \    | |\/| |  / _ \ | __| | '_ \   / _ \   / _` |
//    _| |_  | | | | | |_  |  __/ | |    | | | | | | | | \__ \ \__ \ | | | (_) | | | | |   | |  | | |  __/ | |_  | | | | | (_) | | (_| |
//   |_____| |_| |_|  \__|  \___| |_|    |_| |_| |_| |_| |___/ |___/ |_|  \___/  |_| |_|   |_|  |_|  \___|  \__| |_| |_|  \___/   \__,_|
//                                                                                                                                      
//                                                                                                                                      
    public static Entity.Characters Intermission(Entity.Characters player, Entity.Characters enemy)
    {
        int choice = 0;
        string option;
        string[] acceptable = ["1", "2", "3", "4", "5", "6", "7", "8"];

        while (choice != 3)
        {
            Console.Write("1) Check Stats ");
            if (player.Stat != 0)
            {
                Console.Write($"(YOU HAVE {player.Stat} STAT POINTS TO USE)");
            }
            // i will probably make the start fight number 5 later
            Console.WriteLine("\n2) Next Enemy");
            Console.WriteLine("3) Start Next Fight");
            Console.WriteLine("4) Shop (Not implemented yet)");
            Console.WriteLine("5) Inventory (Not implemented yet)");
            Console.WriteLine("6) Info (Not implemented yet)");
            Console.WriteLine("7) Quit");

            option = Console.ReadLine();
            int.TryParse(option, out choice);

            // if your answer does not contain 1, 2, 3, 4, 5, 6, 7 or 8
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
                // impliment shop
            }
            else if (choice == 6)
            {
                // gonna impliment stuff here that gives some needed info about some stuff
            }
            else if (choice == 7)
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
            else if (choice == 8)
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
