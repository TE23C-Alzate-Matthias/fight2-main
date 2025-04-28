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
    public static (List<Entity.Items>, Entity.Characters) Shop(List<Entity.Items> items, Entity.Characters player)
    {
        // this method had help from AI to work on the way that i want it to work
        string choice;

        int i;
        int num = 0;

        bool success;


        while (num != items.Count)
        {
            Console.Clear();
            success = false;

            Console.WriteLine($"Gold: {player.Gold}");
            Console.WriteLine("What do you want to buy?");
            for (i = 0; i < items.Count; i++)
            {
                var w = items[i];
                Console.WriteLine($"{i}) {w.Name}, Price: {w.Price}");
            }
            Console.WriteLine($"{items.Count}) Exit");

            while (success == false || num < 0 || num >= items.Count)
            {
                choice = Console.ReadLine();
                success = int.TryParse(choice, out num);
                if (success == false)
                {
                    Console.WriteLine("This is not a number, please try again");
                }
                else if (num == items.Count)
                {
                    break;
                }
                else if (num < 0 || num >= items.Count)
                {
                    Console.WriteLine("Invalid index, please try again");
                }
            }

            if (num == items.Count)
            {
                break;
            }

            var selectedItem = items[num];
            Console.Clear();
            Console.WriteLine($"You selected: {selectedItem.Name}");
            Console.WriteLine($"Description: {selectedItem.Description}");
            Console.WriteLine($"Price: {selectedItem.Price}");

            if (selectedItem.Vt > 0)
            {
                Console.WriteLine($"Vt: {selectedItem.Vt}");
            }
            if (selectedItem.Atk > 0)
            {
                Console.WriteLine($"Atk: {selectedItem.Atk}");
            }
            if (selectedItem.Def > 0)
            {
                Console.WriteLine($"Def: {selectedItem.Def}");
            }
            if (selectedItem.Spd > 0)
            {
                Console.WriteLine($"Spd: {selectedItem.Spd}");
            }
            if (selectedItem.Acc > 0)
            {
                Console.WriteLine($"Acc: {selectedItem.Acc}");
            }
            if (selectedItem.Dex > 0)
            {
                Console.WriteLine($"Dex: {selectedItem.Dex}");
            }
            Console.WriteLine("Do you want to buy this item? (yes/no)");
            choice = Console.ReadLine().ToLower();
            if (choice == "yes")
            {
                if (player.Gold >= selectedItem.Price)
                {
                    player.Gold -= selectedItem.Price;
                    player.Inventory.Add(selectedItem);
                    items.RemoveAt(num);
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

        return (items, player);
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
                Console.ReadLine();
                break;
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
            if (selectedItem.Vt > 0)
            {
                Console.WriteLine($"Vt: {selectedItem.Vt}");
            }
            if (selectedItem.Atk > 0)
            {
                Console.WriteLine($"Atk: {selectedItem.Atk}");
            }
            if (selectedItem.Def > 0)
            {
                Console.WriteLine($"Def: {selectedItem.Def}");
            }
            if (selectedItem.Spd > 0)
            {
                Console.WriteLine($"Spd: {selectedItem.Spd}");
            }
            if (selectedItem.Acc > 0)
            {
                Console.WriteLine($"Acc: {selectedItem.Acc}");
            }
            if (selectedItem.Dex > 0)
            {
                Console.WriteLine($"Dex: {selectedItem.Dex}");
            }
            Console.WriteLine("Do you want to equip this item? (yes/no)");
            choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                int slot = selectedItem.Type - 1;
                var previous = player.Equipments[slot];

                // Unequip previous stats
                if (previous != null)
                {
                    player.BonusAtk -= previous.Atk;
                    player.BonusDef -= previous.Def;
                    player.BonusSpd -= previous.Spd;
                    player.BonusAcc -= previous.Acc;
                    player.BonusDex -= previous.Dex;
                }

                // Equip new item and add stats
                player.Equipments[slot] = selectedItem;
                player.BonusAtk += selectedItem.Atk;
                player.BonusDef += selectedItem.Def;
                player.BonusSpd += selectedItem.Spd;
                player.BonusAcc += selectedItem.Acc;
                player.BonusDex += selectedItem.Dex;

                Console.WriteLine($"Equipped {selectedItem.Name} in slot {slot + 1}.");
            }
        }
        return player;
    }
}
