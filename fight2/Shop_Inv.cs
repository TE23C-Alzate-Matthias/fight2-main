
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
        // this method had asistance from AI to work on the way that i want it to work
        string choice;

        int i;
        int num = 0;

        bool success;

        // stays inside the loop for ever
        while (true)
        {
            Console.Clear();
            success = false;

            Console.WriteLine($"Gold: {player.Gold}");
            Console.WriteLine("What do you want to buy?");
            // writes out all the items that are in the shop
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

            // gets you out of the shop method
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
            // if yes it tries to allow you to buy the item
            if (choice == "yes")
            {   
                // looks that the player has enough gold to be able to buy the item
                if (player.Gold >= selectedItem.Price)
                {
                    player.Gold -= selectedItem.Price;
                    // adds the item to the players inventory
                    player.Inventory.Add(selectedItem);
                    // and removes it from shops inventory
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
        int slot;

        bool success;
        // stays in the loop forever
        while (true)
        {
            success = false;
            Console.Clear();
            Console.WriteLine("Your Inventory:");
            if (player.Inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                Console.ReadLine();
                // gets you out of the loop if your inventory is empty
                break;
            }
            else
            {
                // writes out all the items that you have in your inventory
                for (int i = 0; i < player.Inventory.Count; i++)
                {
                    var item = player.Inventory[i];
                    Console.Write($"{i}) {item.Name}");
                    // checks if the item is equiped, not working right now
                    for (int j = 0; j < 6; j++)
                    {   
                        // goes through all if a item in your inventory matches with
                        if (player.Inventory[i] == player.Equipments[j])
                        {
                            Console.Write(" (Equiped)");
                        }
                    }
                    Console.Write("\n");
                }
                // at last writes out how to exit
                Console.Write($"{player.Inventory.Count}) Exit\n");
            }

            Console.WriteLine("Total Added Stats:");
            Console.WriteLine($"Vt: {player.BonusVt}");
            Console.WriteLine($"Atk: {player.BonusAtk}");
            Console.WriteLine($"Def: {player.BonusDef}");
            Console.WriteLine($"Spd: {player.BonusSpd}");
            Console.WriteLine($"Acc: {player.BonusAcc}");
            Console.WriteLine($"Dex: {player.BonusDex}");

            // if you didnt write only numbers, its lower than 0 or it is equal to the number of items in the invetory
            // it goes into this loop
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
                    // gets you out of the loop
                    break;
                }
                else if (num < 0 || num >= player.Inventory.Count)
                {
                    Console.WriteLine("Invalid index, please try again");
                }
            }

            // instantly gets you out of the loop
            if (num == player.Inventory.Count)
            {
                break;
            }

            // puts the item you selected into a variable to be used
            var selectedItem = player.Inventory[num];
            Console.Clear();
            // writes out the stats that the item has
            Console.WriteLine($"You selected: {selectedItem.Name}");
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

            // chosing yes makes the process of equiping the item
            if (choice == "yes")
            {
                slot = selectedItem.Type - 1;
                var previous = player.Equipments[slot];

                // if there was already an previous item equiped it removed the stats from it
                if (previous != null)
                {
                    player.BonusAtk -= previous.Atk;
                    player.BonusDef -= previous.Def;
                    player.BonusSpd -= previous.Spd;
                    player.BonusAcc -= previous.Acc;
                    player.BonusDex -= previous.Dex;
                }

                // Equip/replaces ne item and add stats
                player.Equipments[slot] = selectedItem;
                player.BonusAtk += selectedItem.Atk;
                player.BonusDef += selectedItem.Def;
                player.BonusSpd += selectedItem.Spd;
                player.BonusAcc += selectedItem.Acc;
                player.BonusDex += selectedItem.Dex;

                Console.WriteLine($"Equipped {selectedItem.Name} in slot {slot + 1}.");
                Console.ReadLine();
            }
        }
        return player;
    }
}
