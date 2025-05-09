public class Attacks
{
    //    ______   _           _       _     _                     __  __          _     _                   _ 
    //   |  ____| (_)         | |     | |   (_)                   |  \/  |        | |   | |                 | |
    //   | |__     _    __ _  | |__   | |_   _   _ __     __ _    | \  / |   ___  | |_  | |__     ___     __| |
    //   |  __|   | |  / _` | | '_ \  | __| | | | '_ \   / _` |   | |\/| |  / _ \ | __| | '_ \   / _ \   / _` |
    //   | |      | | | (_| | | | | | | |_  | | | | | | | (_| |   | |  | | |  __/ | |_  | | | | | (_) | | (_| |
    //   |_|      |_|  \__, | |_| |_|  \__| |_| |_| |_|  \__, |   |_|  |_|  \___|  \__| |_| |_|  \___/   \__,_|
    //                  __/ |                             __/ |                                                
    //                 |___/                             |___/                                                 
    public static (Entity.Characters player, Entity.Characters enemy, int story) Fight(Entity.Characters player, Entity.Characters enemy, int story)
    {
        Random generator = new Random();
        int enemySpeed;
        int playerSpeed;
        int round = 0;

        while (player.Hp > 0 && enemy.Hp > 0)
        {
            round++;
            Console.Clear();
            Console.WriteLine($"======= ROUND {round} =======");
            Console.WriteLine($"{player.Name}: {player.Hp} Hp  |  {enemy.Name}: {enemy.Hp} Hp");
            Console.WriteLine($"{player.Name}: {player.UStm} Stamina  |  {enemy.Name}: {enemy.UStm} Stamina\n");

            enemySpeed = generator.Next(1, 101) + (enemy.Spd * 5);
            playerSpeed = generator.Next(1, 101) + ((player.Spd + player.BonusSpd) * 5);

            // writes out what both rolled for speed
            Console.WriteLine("------- Speed Roll -------");
            Console.WriteLine($"{player.Name} got {playerSpeed}");
            Console.WriteLine($"{enemy.Name} got {enemySpeed}");

            // if enemy speed is higher than player speed, the enemy attacks first
            if (enemySpeed > playerSpeed)
            {
                Console.WriteLine($"The enemy attacks first");
                Console.WriteLine("ENTER to continue");
                Console.ReadLine();
                if (enemy.Exh == 1)
                {
                    Console.WriteLine("The enemy is to exhausted to do an action this round");
                    enemy.Exh = 0;
                }
                else
                {
                    (player, enemy) = EnemyAttack(player, enemy);
                }

                if (player.Exh == 1)
                {
                    Console.WriteLine("You are to exhuasted to do an action this round");
                }
                else
                {
                    (player, enemy) = PlayerAttack(player, enemy);
                }
            }
            else
            {
                Console.WriteLine($"you attacks first");
                Console.WriteLine("ENTER to continue");
                Console.ReadLine();
                if (player.Exh == 1)
                {
                    Console.WriteLine("You are to exhuasted to do an action this round");
                }
                else
                {
                    (player, enemy) = PlayerAttack(player, enemy);
                }

                if (enemy.Exh == 1)
                {
                    Console.WriteLine("The enemy is to exhausted to do an action this round");
                    enemy.Exh = 0;
                }
                else
                {
                    (player, enemy) = EnemyAttack(player, enemy);
                }
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
            story = 6;
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

    //    _____    _                                              _     _                    _        __  __          _     _                   _ 
    //   |  __ \  | |                                     /\     | |   | |                  | |      |  \/  |        | |   | |                 | |
    //   | |__) | | |   __ _   _   _    ___   _ __       /  \    | |_  | |_    __ _    ___  | | __   | \  / |   ___  | |_  | |__     ___     __| |
    //   |  ___/  | |  / _` | | | | |  / _ \ | '__|     / /\ \   | __| | __|  / _` |  / __| | |/ /   | |\/| |  / _ \ | __| | '_ \   / _ \   / _` |
    //   | |      | | | (_| | | |_| | |  __/ | |       / ____ \  | |_  | |_  | (_| | | (__  |   <    | |  | | |  __/ | |_  | | | | | (_) | | (_| |
    //   |_|      |_|  \__,_|  \__, |  \___| |_|      /_/    \_\  \__|  \__|  \__,_|  \___| |_|\_\   |_|  |_|  \___|  \__| |_| |_|  \___/   \__,_|
    //                          __/ |                                                                                                             
    //                         |___/                                                                                                              
    public static (Entity.Characters player, Entity.Characters enemy) PlayerAttack(Entity.Characters player, Entity.Characters enemy)
    {   
        Console.Clear();
        // code reuses elements from fight1 but is expanded
        Random generator = new Random();
        string attackChoice;
        int accuracy;
        int critChance;
        int healing;
        int recovering;
        string[] acceptable = ["1", "2", "3", "4", "5", "6"];

        // lets the user choose what action they want to do
        Console.WriteLine("--- Choose Action ---");
        Console.WriteLine($"1) Light Attack: {5 + player.Atk + player.BonusAtk - enemy.Def}-{20 + player.Atk + player.BonusAtk - enemy.Def}, {80 + player.Acc + player.BonusAcc - enemy.Dex - enemy.ExtraDodge}% Accuracy, Crit {20 + player.Prc}%, -10 Stamina");
        Console.WriteLine($"2) Heavy Attack: {10 + player.Atk + player.BonusAtk}-{40 + (player.Atk + player.BonusAtk) * 2}, {30 + player.Acc + player.BonusAcc - enemy.Dex - enemy.ExtraDodge}% Accuracy, Crit: {5 + player.Prc}%, -30 Stamina");
        Console.WriteLine($"3) Multi Attack: {10 + player.Atk + player.BonusAtk - enemy.Def}-{25 + player.Atk + player.BonusAtk - enemy.Def}, {50 + player.Acc + player.BonusAcc - enemy.Dex - enemy.ExtraDodge}% Accuracy, Crit: {50 + player.Prc}, Attacks 3 times, -20 Stamina");
        Console.WriteLine($"4) Dodge: {player.Dex + player.BonusDex}% removed to opponents accuracy check");
        Console.WriteLine($"5) Rest: {player.MaxHp / 10}-{player.MaxHp / 8} healing. {player.MaxStm / 7}-{player.MaxStm / 3} Stamina Recovering");
        attackChoice = Console.ReadLine();

        while (!acceptable.Contains(attackChoice) || attackChoice == "1" && player.UStm < 10 || attackChoice == "2" && player.UStm < 30)
        {
            // if the answer is not one of the options in the array "acceptable" it asks you to try again
            if (!acceptable.Contains(attackChoice))
            {
                Console.WriteLine("Unknown answer, please try again\n");
            }
            else if (attackChoice == "1" && player.UStm < 10 || attackChoice == "2" && player.UStm < 30 || attackChoice == "3" && player.UStm < 20)
            {
                Console.WriteLine("You dont have enougt stamina to do your action, please try again");
            }
            attackChoice = Console.ReadLine();
        }

        // ==================== Player ATTACK =====================
        accuracy = generator.Next(1, 101);
        critChance = generator.Next(1, 101);
        player.ExtraDodge = 0;

        // if you choose 1 the user tries a light attack
        if (attackChoice == "1")
        {   
            Console.WriteLine($"{player.Name} uses light attack!");
            Console.WriteLine("ENTER to continue");
            Console.ReadLine();
            if (accuracy < 20 - player.Acc - player.BonusAcc + enemy.Dex + enemy.ExtraDodge)
            {
                Console.WriteLine($"{player.Name} missed their attack\n");
            }
            else
            {
                // add crit chance check
                if (critChance < 80 - player.Prc)
                {
                    // calculates damage with cirt
                    Console.WriteLine($"{player.Name} hit a critical hit!");
                    player.Dmg = generator.Next(5 + player.Atk + player.BonusAtk, 21 + player.Atk + player.BonusAtk) + 15 - enemy.Def;
                }
                else
                {
                    // calculates damage without crit
                    player.Dmg = generator.Next(5 + player.Atk + player.BonusAtk, 21 + player.Atk + player.BonusAtk) - enemy.Def;
                }
                // makes sure the dmg isnt bellow 0
                player.Dmg = Math.Max(0, player.Dmg);
                enemy.Hp -= player.Dmg;
                // makes sure the health isnt bellow 0
                enemy.Hp = Math.Max(0, enemy.Hp);
                player.UStm -= 10;

                Console.WriteLine($"{player.Name} does {player.Dmg} damage to {enemy.Name}\n");
            }
        }
        // if you chhose 2 the user tries a heavy attack
        else if (attackChoice == "2")
        {
            Console.WriteLine($"{player.Name} uses heavy attack!");
            Console.WriteLine("ENTER to continue");
            Console.ReadLine();
            if (accuracy < 70 - player.Acc - player.BonusAcc + enemy.Dex + enemy.ExtraDodge)
            {
                Console.WriteLine($"{player.Name} missed their attack and loses their next turn\n");
                player.Exh++;
            }
            else
            {
                // add crit chance check
                if (critChance < 95 - player.Prc)
                {
                    // calculates damage with cirt
                    player.Dmg = generator.Next(10 + player.Atk + player.BonusAtk, 41 + (player.Atk + player.BonusAtk) * 2) + 30 - enemy.Def;
                }
                else
                {
                    // calculates damage without crit
                    player.Dmg = generator.Next(10 + player.Atk, 41 + (player.Atk + player.BonusAtk) * 2) - enemy.Def;
                }
                // makes sure the dmg isnt bellow 0
                player.Dmg = Math.Max(0, player.Dmg);
                enemy.Hp -= player.Dmg;
                // makes sure the health isnt bellow 0
                enemy.Hp = Math.Max(0, enemy.Hp);
                player.UStm -= 30;

                Console.WriteLine($"{player.Name} does {player.Dmg} damage to {enemy.Name}\n");
            }
        }
        // if you choose 3 the user tries a multi attack
        else if (attackChoice == "3")
        {   
            int total = 0;
            Console.WriteLine($"{player.Name} uses multi attack!");
            Console.WriteLine("ENTER to continue");
            Console.ReadLine();
            // makes 3 attack attempts
            for (int i = 0; i < 3; i++)
            {
                accuracy = generator.Next(1, 101);
                critChance = generator.Next(1, 101);
                player.ExtraDodge = 0;

                if (accuracy < 50 - player.Acc - player.BonusAcc + enemy.Dex + enemy.ExtraDodge)
                {
                    Console.WriteLine($"{player.Name} missed their attack\n");
                }
                else
                {
                    // add crit chance check
                    if (critChance < 50 - player.Prc)
                    {
                        // calculates damage with cirt
                        Console.WriteLine($"{player.Name} hit a critical hit!");
                        player.Dmg = generator.Next(10 + player.Atk + player.BonusAtk, 26 + player.Atk + player.BonusAtk) + 20 - enemy.Def;
                    }
                    else
                    {
                        // calculates damage without crit
                        player.Dmg = generator.Next(10 + player.Atk + player.BonusAtk, 26 + player.Atk + player.BonusAtk) - enemy.Def;
                    }
                    // makes sure the dmg isnt bellow 0
                    player.Dmg = Math.Max(0, player.Dmg);
                    enemy.Hp -= player.Dmg;
                    // makes sure the health isnt bellow 0
                    enemy.Hp = Math.Max(0, enemy.Hp);
                    total += player.Dmg;

                    Console.WriteLine($"{player.Name} does {player.Dmg} damage to {enemy.Name}\n");
                }
            }
            player.UStm -= 20;
            Console.WriteLine($"Did a total of {total} damage");
        }
        // if you choose 4 the user gets extra dodge chance
        else if (attackChoice == "4")
        {
            player.ExtraDodge = player.Dex + player.BonusDex;
            Console.WriteLine($"{player.Name} prepares to dodge {enemy.Name} next action");
        }
        // if you choose 5 the user heals an amout of hp
        else if (attackChoice == "5")
        {
            // heals you between 1/10 or 1/7 of your hp
            healing = generator.Next(player.MaxHp / 10, player.MaxHp / 7 + 1);
            recovering = generator.Next(player.MaxStm / 7, player.MaxStm / 3 + 1);
            player.UStm += recovering;
            player.Hp += healing;
            Console.WriteLine($"{player.Name} healed {healing} Hp and recovered {recovering} Stamina");
            player.Hp = Math.Min(player.Hp, player.MaxHp);
            player.UStm = Math.Min(player.UStm, player.MaxStm);
        }
        // choosing 6 kills the enemy
        else if (attackChoice == "6")
        {
            Console.WriteLine("Setting Enemies Hp to 0");
            enemy.Hp = 0;
        }
        Console.WriteLine("ENTER to continue");
        Console.ReadLine();

        return (player, enemy);

    }

    //    ______                                                   _     _                    _        __  __          _     _                   _ 
    //   |  ____|                                          /\     | |   | |                  | |      |  \/  |        | |   | |                 | |
    //   | |__     _ __     ___   _ __ ___    _   _       /  \    | |_  | |_    __ _    ___  | | __   | \  / |   ___  | |_  | |__     ___     __| |
    //   |  __|   | '_ \   / _ \ | '_ ` _ \  | | | |     / /\ \   | __| | __|  / _` |  / __| | |/ /   | |\/| |  / _ \ | __| | '_ \   / _ \   / _` |
    //   | |____  | | | | |  __/ | | | | | | | |_| |    / ____ \  | |_  | |_  | (_| | | (__  |   <    | |  | | |  __/ | |_  | | | | | (_) | | (_| |
    //   |______| |_| |_|  \___| |_| |_| |_|  \__, |   /_/    \_\  \__|  \__|  \__,_|  \___| |_|\_\   |_|  |_|  \___|  \__| |_| |_|  \___/   \__,_|
    //                                         __/ |                                                                                               
    //                                        |___/                                                                                                                                                                                      
    public static (Entity.Characters player, Entity.Characters enemy) EnemyAttack(Entity.Characters player, Entity.Characters enemy)
    {   
        Console.Clear();
        Random generator = new Random();
        int accuracy = generator.Next(1, 101);
        int critChance = generator.Next(1, 101);
        int randomChoice;
        int healing;
        int recovering;
        enemy.ExtraDodge = 0;

        if (enemy.Hp < enemy.MaxHp / 3) // if hp is bellow 1/3 of max hp it can do one of the 4 actions
        {
            randomChoice = generator.Next(4);
        }
        else if (enemy.Hp < enemy.MaxHp / 3 * 2) // if hp is bellow 2/3 it can do 3 actions
        {
            randomChoice = generator.Next(3);
        }
        else // otherwise it has only 2 actions to do
        {
            randomChoice = generator.Next(2);
        }

        // makes sure the enemy has enough stamina to do their attacks
        if (enemy.UStm < 30 && randomChoice == 1)
        {
            randomChoice = 0;
            // if the enemy does not have enoug stamina to do any attacks it will rest
            if (enemy.UStm < 10)
            {
                randomChoice = 3;
            }
        }

        // enemy using light attack
        if (randomChoice == 0)
        {   
            Console.WriteLine($"{enemy.Name} uses light attack!");
            Console.WriteLine("ENTER to continue");
            Console.ReadLine();
            if (accuracy < 20 - enemy.Acc + player.Dex + player.BonusDex + player.ExtraDodge)
            {
                Console.WriteLine($"{enemy.Name} missed their attack\n");
            }
            else
            {
                // add crit chance check
                if (critChance < 80 - enemy.Prc)
                {
                    // calculates damage with cirt
                    Console.WriteLine($"{enemy.Name} hit a critical hit!");
                    enemy.Dmg = generator.Next(5 + enemy.Atk, 21 + enemy.Atk) + 15 - player.Def - player.BonusDef;
                }
                else
                {
                    // calculates damage without crit
                    enemy.Dmg = generator.Next(5 + enemy.Atk, 21 + enemy.Atk) - player.Def - player.BonusDef;
                }
                enemy.Dmg = Math.Max(0, enemy.Dmg);
                player.Hp -= enemy.Dmg;
                player.Hp = Math.Max(0, player.Hp);
                Console.WriteLine($"{enemy.Name} does {enemy.Dmg} damage to {player.Name}\n");
                enemy.UStm =- 10;
            }
        }
        // enemy using heavy attack
        else if (randomChoice == 1)
        {   
            Console.WriteLine($"{enemy.Name} uses heavy attack!");
            Console.WriteLine("ENTER to continue");
            Console.ReadLine();
            if (accuracy < 70 - enemy.Acc + player.Dex + player.BonusDex + player.ExtraDodge)
            {
                Console.WriteLine($"{enemy.Name} missed their attack and loses their next turn\n");
                enemy.Exh++;
            }
            else
            {
                // add crit chance check
                if (critChance < 95 - enemy.Prc)
                {   
                    // calculates damage with cirt
                    Console.WriteLine($"{enemy.Name} hit a critical hit!");
                    enemy.Dmg = generator.Next(10 + enemy.Atk, 41 + (enemy.Atk * 2)) + 30 - player.Def - player.BonusDef;
                }
                else
                {
                    // calculates damage without crit
                    enemy.Dmg = generator.Next(10 + enemy.Atk, 41 + (enemy.Atk * 2)) - player.Def - player.BonusDef;
                }
                enemy.Dmg = Math.Max(0, enemy.Dmg);
                player.Hp -= enemy.Dmg;
                player.Hp = Math.Max(0, player.Hp);
                Console.WriteLine($"{enemy.Name} does {enemy.Dmg} damage to {player.Name}\n");
                enemy.UStm =- 30;
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
            healing = generator.Next(enemy.MaxHp / 8, enemy.MaxHp / 5 + 1);
            recovering = generator.Next(enemy.MaxStm / 7, enemy.MaxStm / 3 + 1);
            enemy.Hp += healing;
            enemy.UStm += recovering;
            Console.WriteLine($"{enemy.Name} healed {healing} Hp and recovered {recovering} Stamina");
            enemy.Hp = Math.Min(enemy.Hp, enemy.MaxHp);
            enemy.UStm = Math.Min(enemy.UStm, enemy.MaxStm);
        }
        Console.WriteLine("ENTER to continue");
        Console.ReadLine();

        return (player, enemy);
    }
}
