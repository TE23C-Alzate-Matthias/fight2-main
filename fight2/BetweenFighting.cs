// allows me to use Regex to know if an answer has numbers in it
using System.Text.RegularExpressions;

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
    public static (Entity.Characters, List<Entity.Weapons>) Intermission(Entity.Characters player, Entity.Characters enemy, List<Entity.Weapons> weapons)
    {   

        int choice = 0;
        string option;
        string[] acceptable = ["1", "2", "3", "4", "5", "6", "7", "8"];

        while (choice != 5)
        {
            Console.Clear();
            Console.Write("1) Check Stats ");
            if (player.Stat != 0)
            {
                Console.Write($"(YOU HAVE {player.Stat} STAT POINTS TO USE)");
            }
            // i will probably make the start fight number 5 later
            Console.WriteLine("\n2) Shop");
            Console.WriteLine("3) Inventory (Not implemented yet)");
            Console.WriteLine("4) Next Enemy");
            Console.WriteLine("5) Start Next Fight");
            Console.WriteLine("6) Info");
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
                player = Stat_Story.StatPoints(player);
            }
            else if (choice == 2)
            {
                // shop option
                (weapons, player) = Shop_Inv.Shop(weapons, player);
            }
            else if (choice == 3)
            {
                // impliment inventory
            }
            else if (choice == 4)
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
            else if (choice == 6)
            {
                Information.Info();
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
        }
        player.MaxHp = player.Hp;
        return (player, weapons);
    }

    //    _   _                                 _____   _                     _        __  __          _     _                   _ 
    //   | \ | |                               / ____| | |                   | |      |  \/  |        | |   | |                 | |
    //   |  \| |   __ _   _ __ ___     ___    | |      | |__     ___    ___  | | __   | \  / |   ___  | |_  | |__     ___     __| |
    //   | . ` |  / _` | | '_ ` _ \   / _ \   | |      | '_ \   / _ \  / __| | |/ /   | |\/| |  / _ \ | __| | '_ \   / _ \   / _` |
    //   | |\  | | (_| | | | | | | | |  __/   | |____  | | | | |  __/ | (__  |   <    | |  | | |  __/ | |_  | | | | | (_) | | (_| |
    //   |_| \_|  \__,_| |_| |_| |_|  \___|    \_____| |_| |_|  \___|  \___| |_|\_\   |_|  |_|  \___|  \__| |_| |_|  \___/   \__,_|
    //                                                                                                                             
    //                                                                                                                             
    public static Entity.Characters NameCheck(Entity.Characters player, int story)
    {

        // checks if the given text has numbers in it, if it has its on true, if not its on false
        bool ContainsNumbers(string input)
        {
            return Regex.IsMatch(input, @"\d");
        }

        // lets you choose your name
        Console.WriteLine("Choose your Characters name (3-14 Characters long, no numbers)");
        player.Name = Console.ReadLine();

        while (player.Name.Length < 3 || player.Name.Length > 15 || ContainsNumbers(player.Name))
        {
            // if the name is shorter than 3 it tells me to try again
            if (player.Name.Length < 3)
            {
                Console.WriteLine("Name is to short, please try again");
                player.Name = Console.ReadLine();
            }
            // same thing but if longer than 15
            else if (player.Name.Length > 15)
            {
                Console.WriteLine("Namn is to long, please try again");
                player.Name = Console.ReadLine();
            }
            // same thing but if it has numbers in it
            else if (ContainsNumbers(player.Name))
            {
                Console.WriteLine("Name has numbers in it, please try again");
                player.Name = Console.ReadLine();
            }
        }
        Stat_Story.Story(story);
        player = Stat_Story.StatPoints(player);

        return player;
    }
}