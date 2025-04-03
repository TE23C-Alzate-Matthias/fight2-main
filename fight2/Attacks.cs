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
            playerSpeed = generator.Next(1, 101) + (player.Spd * 5);

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
                    Console.WriteLine("ENTER to continue");
                    enemy.Exh = 0;
                }
                else
                {
                    (player, enemy) = EnemyAttack(player, enemy);
                }

                if (player.Exh == 1)
                {
                    Console.WriteLine("You are to exhuasted to do an action this round");
                    Console.WriteLine("ENTER to continue");
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
                    Console.WriteLine("ENTER to continue");
                }
                else
                {
                    (player, enemy) = PlayerAttack(player, enemy);
                }

                if (enemy.Exh == 1)
                {
                    Console.WriteLine("The enemy is to exhausted to do an action this round");
                    Console.WriteLine("ENTER to continue");
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
        // code reuses elements from fight1 but is expanded
        Random generator = new Random();
        string attackChoice;
        int accuracy;
        int critChance;
        int healing;
        string[] acceptable = ["1", "2", "3", "4"];

        // lets the user choose what action they want to do
        Console.WriteLine("--- Choose Action ---");
        Console.WriteLine($"1) Light Attack: {5 + player.Atk - enemy.Def}-{20 + player.Atk - enemy.Def}, {80 + player.Acc - enemy.Dex - enemy.ExtraDodge}% Accuracy, Crit {20 + player.Prc}%");
        Console.WriteLine($"2) Heavy Attack: {10 + player.Atk}-{40 + (player.Atk * 2)}, {30 + player.Acc - enemy.Dex - enemy.ExtraDodge}% Accuracy, Crit {5 + player.Prc}%");
        Console.WriteLine($"3) Dodge: {player.Dex}% removed to opponents accuracy check");
        Console.WriteLine($"4) Rest: {player.MaxHp / 8}-{player.MaxHp / 5} healing");
        attackChoice = Console.ReadLine();

        // if the answer is not one of the options in the array "acceptable" it asks you to try again
        while (!acceptable.Contains(attackChoice))
        {
            Console.WriteLine("Unknown answer, please try again\n");
            attackChoice = Console.ReadLine();
        }


        // ==================== Player ATTACK =====================
        accuracy = generator.Next(1, 101);
        critChance = generator.Next(1, 101);
        player.ExtraDodge = 0;

        // if you choose 1 or a the user tries a light attack
        if (attackChoice == "1")
        {
            if (accuracy < 20 - player.Acc + enemy.Dex + enemy.ExtraDodge)
            {
                Console.WriteLine($"{player.Name} missed their attack\n");
            }
            else
            {
                // add crit chance check
                // calculates the dmg
                player.Dmg = generator.Next(5 + player.Atk, 21 + player.Atk) - enemy.Def;
                // makes sure the dmg isnt bellow 0
                player.Dmg = Math.Max(0, player.Dmg);
                enemy.Hp -= player.Dmg;
                // makes sure the health isnt bellow 0
                enemy.Hp = Math.Max(0, enemy.Hp);
                Console.WriteLine($"{player.Name} uses light attack!");
                Console.WriteLine($"{player.Name} does {player.Dmg} damage to {enemy.Name}\n");
            }
        }
        // if you chhose 2 or b the user tries a heavy attack
        else if (attackChoice == "2")
        {
            if (accuracy < 70 - player.Acc + enemy.Dex + enemy.ExtraDodge)
            {
                Console.WriteLine($"{player.Name} missed their attack and loses their next turn\n");
                player.Exh++;
            }
            else
            {
                // calculates the dmg
                player.Dmg = generator.Next(10 + player.Atk, 41 + (player.Atk * 2)) - enemy.Def;
                // makes sure the dmg isnt bellow 0
                player.Dmg = Math.Max(0, player.Dmg);
                enemy.Hp -= player.Dmg;
                // makes sure the health isnt bellow 0
                enemy.Hp = Math.Max(0, enemy.Hp);
                Console.WriteLine($"{player.Name} uses heavy attack!");
                Console.WriteLine($"{player.Name} does {player.Dmg} damage to {enemy.Name}\n");
            }
        }
        // if you choose 3 or c the user gets extra dodge chance
        else if (attackChoice == "3")
        {
            player.ExtraDodge = player.Dex;
            Console.WriteLine($"{player.Name} prepares to dodge {enemy.Name} next action");
        }
        // if you choose 4 or d the user heals an amout of hp
        else if (attackChoice == "4")
        {
            // heals you between 1/8 or 1/5 of your hp
            healing = generator.Next(player.MaxHp / 8, player.MaxHp / 5 + 1);
            player.Hp += healing;
            Console.WriteLine($"{player.Name} healed {healing} Hp");
            player.Hp = Math.Min(player.Hp, player.MaxHp);
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
        Random generator = new Random();
        int accuracy = generator.Next(1, 101);
        int randomChoice;
        int healing;
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

        // enemy using light attack
        if (randomChoice == 0)
        {
            if (accuracy < 20 - enemy.Acc + player.Dex + player.ExtraDodge)
            {
                Console.WriteLine($"{enemy.Name} missed their attack\n");
            }
            else
            {
                enemy.Dmg = generator.Next(5 + enemy.Atk, 21 + enemy.Atk) - player.Def;
                enemy.Dmg = Math.Max(0, enemy.Dmg);
                player.Hp -= enemy.Dmg;
                player.Hp = Math.Max(0, player.Hp);
                Console.WriteLine($"{enemy.Name} uses light attack!");
                Console.WriteLine($"{enemy.Name} does {enemy.Dmg} damage to {player.Name}\n");
            }
        }
        // enemy using heavy attack
        else if (randomChoice == 1)
        {
            if (accuracy < 70 - enemy.Acc + player.Dex + player.ExtraDodge)
            {
                Console.WriteLine($"{enemy.Name} missed their attack and loses their next turn\n");
                enemy.Exh++;
            }
            else
            {
                enemy.Dmg = generator.Next(10 + player.Atk, 41 + (player.Atk * 2)) - player.Def;
                enemy.Dmg = Math.Max(0, enemy.Dmg);
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
            healing = generator.Next(enemy.MaxHp / 8, enemy.MaxHp / 5 + 1);
            enemy.Hp += healing;
            Console.WriteLine($"{enemy.Name} healed {healing} Hp");
            enemy.Hp = Math.Min(enemy.Hp, enemy.MaxHp);
        }
        Console.WriteLine("ENTER to continue");
        Console.ReadLine();

        return (player, enemy);
    }
}
