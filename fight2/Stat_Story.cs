
public class Stat_Story
{
    //     _____   _             _       _____            _           _             __  __          _     _                   _ 
    //    / ____| | |           | |     |  __ \          (_)         | |           |  \/  |        | |   | |                 | |
    //   | (___   | |_    __ _  | |_    | |__) |   ___    _   _ __   | |_   ___    | \  / |   ___  | |_  | |__     ___     __| |
    //    \___ \  | __|  / _` | | __|   |  ___/   / _ \  | | | '_ \  | __| / __|   | |\/| |  / _ \ | __| | '_ \   / _ \   / _` |
    //    ____) | | |_  | (_| | | |_    | |      | (_) | | | | | | | | |_  \__ \   | |  | | |  __/ | |_  | | | | | (_) | | (_| |
    //   |_____/   \__|  \__,_|  \__|   |_|       \___/  |_| |_| |_|  \__| |___/   |_|  |_|  \___|  \__| |_| |_|  \___/   \__,_|
    //                                                                                                                          
    //                                                                                                                          
    public static Entity.Characters StatPoints(Entity.Characters player)
    {
        int choice = 0;
        string option;
        string[] acceptable = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"];

        while (choice != 9)
        {
            Console.Clear();
            // options on what you can do
            Console.WriteLine($"Total Stat Points left: {player.Stat}");
            Console.WriteLine("Add Statpoints to your character:\n");
            Console.WriteLine($"Hp: {player.Hp}");
            Console.WriteLine($"Max Stamina: {player.UStm}");
            Console.WriteLine($"1) Vitality: {player.Vt}");
            Console.WriteLine($"2) Attack: {player.Atk}");
            Console.WriteLine($"3) Defence: {player.Def}");
            Console.WriteLine($"4) Speed: {player.Spd}");
            Console.WriteLine($"5) Accuracy: {player.Acc}");
            Console.WriteLine($"6) Precision: {player.Prc}");
            Console.WriteLine($"7) Dexterity: {player.Dex}");
            Console.WriteLine($"8) Stamina: {player.Stm}");
            Console.WriteLine($"9) Help");
            Console.WriteLine($"10) Reset Stat Points");
            Console.WriteLine($"11) Exit");

            option = Console.ReadLine();
            int.TryParse(option, out choice);

            // if your answer does not contain 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
            while (!acceptable.Contains(option))
            {
                Console.WriteLine("Unknown option, please try again");
                option = Console.ReadLine();
                int.TryParse(option, out choice);
            }

            if (choice == 9)
            {
                // shows what each stat does
                Console.WriteLine("\nVitality: +10 hp per point");
                Console.WriteLine("Attack: 1+ Minimun and Maximun damage when hitting an attack (+2 maximun damage on heavy attack)");
                Console.WriteLine("Defence: -1 Damage taken when getting hit per point");
                Console.WriteLine("Speed: +5 on Speed Checks per point");
                Console.WriteLine("Accuracy: +1% Chance to hit an attack per point");
                Console.WriteLine("Precision: +1% Chance to critical hit (1.5X damage)");
                Console.WriteLine("Dexterity: +1% Chance to dodge an attack per point");
                Console.WriteLine("Stamina: +5 Stamina Points");
                Console.WriteLine("(Click Enter to get back)");
                Console.ReadLine();
            }
            else if (choice == 10)
            {
                Console.WriteLine("Are you sure you want to reset your stats?");
                Console.WriteLine("Write 'yes' if you are sure");
                option = Console.ReadLine();
                if (option == "yes")
                {

                    player.Stat += player.Vt + player.Atk + player.Def + player.Spd + player.Acc + player.Prc + player.Dex + player.Stm;
                    player.Vt = 0;
                    player.Atk = 0;
                    player.Def = 0;
                    player.Spd = 0;
                    player.Acc = 0;
                    player.Prc = 0;
                    player.Dex = 0;
                    player.Stm = 0;
                }
            }
            else if (choice == 11)
            { 
                break;
            }
            else if (player.Stat == 0)
            {
                Console.WriteLine("No stat points left, please try again");
                Console.ReadLine();

            }
            // got help with chatGPT to make this more compact
            else if (choice >= 1 && choice <= 8)
            {
                // deduct one stat point and increase the chosen stat
                player.Stat--;
                switch (choice)
                {
                    case 1:
                        player.Vt++;
                        break;
                    case 2:
                        player.Atk++;
                        break;
                    case 3:
                        player.Def++;
                        break;
                    case 4:
                        player.Spd++;
                        break;
                    case 5:
                        player.Acc++;
                        break;
                    case 6:
                        player.Prc++;
                        break;
                    case 7:
                        player.Dex++;
                        break;
                    case 8:
                        player.Stm++;
                        break;
                }
            }
            player.Hp = 100 + (10 * player.Vt);
            player.UStm = 100 + (5 * player.Stm);
            Console.Clear();
        }
        player.MaxHp = player.Hp;
        player.MaxStm = player.UStm;
        return player;
    }

    //     _____   _______    ____    _____   __     __    __  __   ______   _______   _    _    ____    _____  
    //    / ____| |__   __|  / __ \  |  __ \  \ \   / /   |  \/  | |  ____| |__   __| | |  | |  / __ \  |  __ \ 
    //   | (___      | |    | |  | | | |__) |  \ \_/ /    | \  / | | |__       | |    | |__| | | |  | | | |  | |
    //    \___ \     | |    | |  | | |  _  /    \   /     | |\/| | |  __|      | |    |  __  | | |  | | | |  | |
    //    ____) |    | |    | |__| | | | \ \     | |      | |  | | | |____     | |    | |  | | | |__| | | |__| |
    //   |_____/     |_|     \____/  |_|  \_\    |_|      |_|  |_| |______|    |_|    |_|  |_|  \____/  |_____/ 
    //                                                                                                          
    //                                                                                                          
    public static int Story(int story)
    {
        // checks what point you are in the story
        // story is also AI generated
        if (story == 0)
        {
            Console.WriteLine("\nThrown into prison for a crime you didn't commit, you soon learn that freedom can only be earned by surviving a brutal series of fights. Your first opponent is Kayn a fighter whose speed and precision make every move a challenge. As you face him in the dimly lit arena, you realize that quick, decisive actions are your only way out.\n");
            Console.ReadLine();
        }
        else if (story == 1)
        {
            Console.WriteLine("\nAfter narrowly overcoming Kayn, you feel the rush of victory and gain a boost that sharpens your resolve (+10 stat points). But there’s no time to celebrate, as your next opponent, Jackie, steps into the ring. Known for his unwavering resilience and relentless defense, Jackie turns the fight into a grueling test of endurance. Every punch and block feels like a battle for survival.");
            Console.ReadLine();
        }
        else if (story == 2)
        {
            Console.WriteLine("\nWith newfound strength from your previous victory (+10 stat points), you prepare for your third test: Evelynn. Her fighting style is a blend of fluid grace and lethal precision. Though she may seem unpredictable, every movement is calculated to strike fear into the hearts of her opponents. In this high-stakes encounter, every dodge and counterattack could be the difference between life and death.");
            Console.ReadLine();
        }
        else if (story == 3)
        {
            Console.WriteLine("\nIn an epic showdown with Evelynn, your perseverance is rewarded as you triumph against all odds (+20 stat points). next fight against (insert name here)");
            Console.ReadLine();
        }
        else if (story == 4)
        {
            Console.WriteLine("\n win fourth fight (+5 stat points). next fight against (insert name here)");
            Console.ReadLine();
        }
        else if (story == 5)
        {
            Console.WriteLine("\nThe roar of the crowd drowns out the clamor of the arena as the chains of your imprisonment break away. With each battle having pushed you to your limits, you step through the gates to freedom, forever changed by the trials you endured.");
            Console.ReadLine();
        }
        else if (story == 6)
        {
            Console.WriteLine("\nNot every fight ends in victory. Sometimes, despite your courage and skill, fate deals you a harsh blow. In this somber twist, your journey comes to an abrupt end on the battlefield—a stark reminder that every fight is a gamble, and sometimes the odds just aren’t in your favor.");
            Console.ReadLine();
        }
        return story;
    }

}
