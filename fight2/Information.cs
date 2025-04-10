public class Information
{
    //    _____            __             __  __          _     _                   _ 
    //   |_   _|          / _|           |  \/  |        | |   | |                 | |
    //     | |    _ __   | |_    ___     | \  / |   ___  | |_  | |__     ___     __| |
    //     | |   | '_ \  |  _|  / _ \    | |\/| |  / _ \ | __| | '_ \   / _ \   / _` |
    //    _| |_  | | | | | |   | (_) |   | |  | | |  __/ | |_  | | | | | (_) | | (_| |
    //   |_____| |_| |_| |_|    \___/    |_|  |_|  \___|  \__| |_| |_|  \___/   \__,_|
    //                                                                                
    //     
    public static void Info()
    {
        string choice;
        int num = 0;
        bool success;

        while (num != 6)
        {
            success = false;
            Console.WriteLine("===== What do you want to know? =====\n");
            Console.WriteLine("5) Stats");
            Console.WriteLine("1) Combat");
            Console.WriteLine("2) Enemies");
            Console.WriteLine("3) Shop (nothing yet)");
            Console.WriteLine("4) Inventory (nothing yet)");
            Console.WriteLine("5) Exit");
            while (success == false) 
            {
                choice = Console.ReadLine();
                success = int.TryParse(choice, out num);
                if (success == false)
                {
                    Console.WriteLine("Unknown answer, please try again");
                }
            }

            if (num >= 1 && num <= 5)
            {
                switch(num)
                {
                    case 1:
                        StatsInfo();
                        break;
                    case 2:
                        CombatInfo();
                        break;
                    case 3:
                        EnemiesInfo();
                        break;
                    case 4:
                        ShopInfo();
                        break;
                    case 5:
                        InvInfo();
                        break;
                }
            }
        }
    }

    static void StatsInfo()
    {
        Console.WriteLine("Nothing right now here just proof of concept for me");
        Console.WriteLine("ENTER to continue");
        Console.ReadLine();
    }

    static void CombatInfo()
    {
        Console.WriteLine("Nothing right now here just proof of concept for me");
        Console.WriteLine("ENTER to continue");
        Console.ReadLine();
    }

    static void EnemiesInfo()
    {
        Console.WriteLine("Nothing right now here just proof of concept for me");
        Console.WriteLine("ENTER to continue");
        Console.ReadLine();
    }

    static void ShopInfo()
    {
        Console.WriteLine("Nothing right now here just proof of concept for me");
        Console.WriteLine("ENTER to continue");
        Console.ReadLine();
    }

    static void InvInfo()
    {
        Console.WriteLine("Nothing right now here just proof of concept for me");
        Console.WriteLine("ENTER to continue");
        Console.ReadLine();
    }
}
