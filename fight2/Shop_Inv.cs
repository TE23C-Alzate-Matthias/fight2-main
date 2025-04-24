using System.Reflection.PortableExecutable;

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
        int price;
        int num = 0;

        bool success;


        while (num != weapons.Count)
        {
            Console.Clear();
            success = false;

            Console.WriteLine($"Gold: {player.Gold}");
            Console.WriteLine("What do you want to buy?");
            for (i = 0; i < weapons.Count; i++)
            {
                Entity.Weapons w = weapons[i];
                Console.WriteLine($"{i}) {w.Name}, Price: {w.Price}");
            }
            Console.WriteLine($"{weapons.Count}) Exit");

            while (success == false || num < 0 || num >= weapons.Count)
            {
                choice = Console.ReadLine();
                success = int.TryParse(choice, out num);
                if (success == false)
                {
                    Console.WriteLine("This is not a number, please try again");
                }
                else if (num == weapons.Count)
                {
                    break;
                }
                else if (num < 0 || num >= weapons.Count)
                {
                    Console.WriteLine("Invalid index, please try again");
                }
            }

            if (num == weapons.Count)
            {
                break;
            }

            Entity.Weapons selectedWeapon = weapons[num];
            Console.Clear();
            Console.WriteLine($"You selected: {selectedWeapon.Name}");
            Console.WriteLine($"Description: {selectedWeapon.Description}");
            Console.WriteLine($"Price: {selectedWeapon.Price}");

            if (selectedWeapon.Vt > 0)
            {
                Console.WriteLine($"Vt: {selectedWeapon.Vt}");
            }
            if (selectedWeapon.Atk > 0)
            {
                Console.WriteLine($"Atk: {selectedWeapon.Atk}");
            }
            if (selectedWeapon.Def > 0)
            {
                Console.WriteLine($"Def: {selectedWeapon.Def}");
            }
            if (selectedWeapon.Spd > 0)
            {
                Console.WriteLine($"Spd: {selectedWeapon.Spd}");
            }
            if (selectedWeapon.Acc > 0)
            {
                Console.WriteLine($"Acc: {selectedWeapon.Acc}");
            }
            if (selectedWeapon.Dex > 0)
            {
                Console.WriteLine($"Dex: {selectedWeapon.Dex}");
            }
            Console.WriteLine("Do you want to buy this item? (yes/no)");
            choice = Console.ReadLine().ToLower();
            if (choice == "yes")
            {
                if (player.Gold >= selectedWeapon.Price)
                {
                    player.Gold -= selectedWeapon.Price;
                    player.Inventory.Add(selectedWeapon);
                    weapons.RemoveAt(num);
                    Console.WriteLine("Item purchased and added to your inventory!");
                }
                else
                {
                    Console.WriteLine("Not enough gold to buy this item.");
                }
            }
            else
            {
                Console.WriteLine("Purchase canceled.");
            }
            Console.ReadLine();

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
    public static Entity.Characters Inventory(Entity.Characters player)
    {   
        string choice;

        int num = 0;

        bool success;
        while (num != player.Inventory.Count)
        {   
            success = false;
            Console.Clear();
            Console.WriteLine("Your Inventory:");
            if (player.Inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
            }
            else
            {
                for (int i = 0; i < player.Inventory.Count; i++)
                {
                    var item = player.Inventory[i];
                    Console.WriteLine($"{i}) {item.Name}");
                }
                Console.WriteLine($"{player.Inventory.Count}) Exit");
            }

            while (success == false || num < 0 || num >= player.Inventory.Count)
            {
                choice = Console.ReadLine();
                success = int.TryParse(choice, out num);
                if (success == false)
                {
                    Console.WriteLine("This is not a number, please try again");
                }
                else if (num == player.Inventory.Count)
                {
                    break;
                }
                else if (num < 0 || num >= player.Inventory.Count)
                {
                    Console.WriteLine("Invalid index, please try again");
                }
            }

            if (num == player.Inventory.Count)
            {
                break;
            }

            var selectedItem = player.Inventory[num];
            Console.Clear();
            Console.WriteLine($"You selected: {selectedItem.Name}");
            Console.ReadLine();
        }

        return player;
    }
}
