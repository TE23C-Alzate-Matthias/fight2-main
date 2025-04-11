public class Shop_Inv
{
    //     _____   _                         __  __          _     _                   _ 
    //    / ____| | |                       |  \/  |        | |   | |                 | |
    //   | (___   | |__     ___    _ __     | \  / |   ___  | |_  | |__     ___     __| |
    //    \___ \  | '_ \   / _ \  | '_ \    | |\/| |  / _ \ | __| | '_ \   / _ \   / _` |
    //    ____) | | | | | | (_) | | |_) |   | |  | | |  __/ | |_  | | | | | (_) | | (_| |
    //   |_____/  |_| |_|  \___/  | .__/    |_|  |_|  \___|  \__| |_| |_|  \___/   \__,_|
    //                            | |                                                    
    //                            |_|   
    public static (List<Entity.Weapons>, Entity.Characters) Shop(List<Entity.Weapons> weapons, Entity.Characters player)
    {
        string choice;

        int i;
        int num = 0;

        bool success;


        while (num != 7)
        {
            Console.Clear();
            success = false;

            Console.WriteLine($"Gold: {player.Gold}");
            Console.WriteLine("What do you want to buy?");
            Console.WriteLine("1) Weapons");
            Console.WriteLine("2) Helmets");
            Console.WriteLine("3) Chestplates");
            Console.WriteLine("4) Leggings");
            Console.WriteLine("5) Boots");
            Console.WriteLine("6) Rings");
            Console.WriteLine("7) Exit");

            while (success == false)
            {
                choice = Console.ReadLine();
                success = int.TryParse(choice, out num);
                if (success == false)
                {
                    Console.WriteLine("Unknown answer, please try again");
                }
            }

            Console.Clear();
            if (num == 1)
            {   
                for (i = 0; i < weapons.Count; i++)
                {
                    Entity.Weapons w = weapons[i];
                    Console.WriteLine($"{i}) {w.Name}, Price: {w.Price}");
                    if (i == weapons.Count - 1)
                    {
                        Console.WriteLine($"{i + 1}) Exit");
                    }

                }
                Console.ReadLine();
            }
        }

        return (weapons, player);
    }


    //    _____                                  _                              __  __          _     _                   _ 
    //   |_   _|                                | |                            |  \/  |        | |   | |                 | |
    //     | |    _ __   __   __   ___   _ __   | |_    ___    _ __   _   _    | \  / |   ___  | |_  | |__     ___     __| |
    //     | |   | '_ \  \ \ / /  / _ \ | '_ \  | __|  / _ \  | '__| | | | |   | |\/| |  / _ \ | __| | '_ \   / _ \   / _` |
    //    _| |_  | | | |  \ V /  |  __/ | | | | | |_  | (_) | | |    | |_| |   | |  | | |  __/ | |_  | | | | | (_) | | (_| |
    //   |_____| |_| |_|   \_/    \___| |_| |_|  \__|  \___/  |_|     \__, |   |_|  |_|  \___|  \__| |_| |_|  \___/   \__,_|
    //                                                                 __/ |                                                
    //                                                                |___/                                                 
    public static int Inventory(int Inventory)
    {


        return Inventory;
    }
}
