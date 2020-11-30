using System;
using System.Collections.Generic;

namespace RPProject
{
    public class Program
    {
        public List<Char_Info> char_info = new List<Char_Info>(); // Contains characters' paremeters
        public List<Rel_Info> rel_info = new List<Rel_Info>(); // Contains players' relations with NPCs
        public List<Item> items = new List<Item>(); // Contains all items in game
        public List<Weapon> weapons = new List<Weapon>(); // Lower list abstract level for weapons
        public List<Inventory> inventory = new List<Inventory>(); // Contains players or NPCs items 

        string readData;

        static public void Main()
        {
            Program prog = new Program();

            prog.Intro();

            prog.FirstDay();

            prog.Leave_Meth();
        }

        #region Intro

        // Main method with scenario
        public void Intro()
        {
            add_char_info("Nameless", 100, 100, 100, 100);
            add_rel_info("Crim", 0);

            get_name_dialog();
            work_dialog();
            bye_dialog();

            Console.WriteLine("(You can write \"Char info\" or \"Relations\" for getting info)");

            while (commands_check())
            {
                Console.Clear();

                Console.WriteLine("(You can write \"Char info\" or \"Relations\" for getting info)");
            }
        }

        #region Scenario modules
        // Dialogs
        void get_name_dialog()
        {
            Console.Clear();

            // Intro dialog and setting characters name
            Console.WriteLine(" - Welcome, newcomer! " +
                "\n He points at two men in gray coaps. You don't see their faces, but they don't look like someone dangerous." +
                "\n - My guys picked you up and brought here. You were roaming along a road, looking like homeless, and then this found you. This place now your new home. But in first I want to know your name...");
            Console.WriteLine();

            // Setting chars' name or opening characters information
            Console.WriteLine("\n You tell them your name. ");
            Console.WriteLine("( Type your name or one of the commands. Write \"Char info\" for character info and \"Relations\" for relations list\n");

            while (commands_check()) 
            {
                Console.Clear();

                // Intro dialog and setting characters name
                Console.WriteLine(" - Welcome, newcomer! " +
                    "\n He points at two men in gray coaps. You don't see their faces, but they don't look like someone dangerous." +
                    "\n - My guys picked you up and brought here. You were roaming along a road, looking like homeless, and then this found you. This place now your new home. But in first I want to know your name...");
                Console.WriteLine();

                // Setting chars' name or opening characters information
                Console.WriteLine("\n You tell them your name. ");
                Console.WriteLine("( Type your name or one of the commands. Write \"Char info\" for character info and \"Relations\" for relations list\n");
            }

            // Reading input info
            char_info[0].name = readData;
        }

        void work_dialog()
        {
            Console.Clear();

            Console.WriteLine("\n - Well, " + char_info[0].name + ", you in Westborn, the city of tradors and adventurists. Here you can find some work for yourself, whatever it would be." +
                              "Today is a good day for ya. We got some work yesterdays' night. So.. You could help us for your saving from starving on Wastelands. \n");


            Console.WriteLine("1) - What kind of job? \n" +
                                "2) - Alright, what I must to do? \n" +
                                "3) - I'm not interested, sorry \n");

            var key = Console.ReadKey();
            if (key.KeyChar == '1')
            {
                Console.Clear();

                Console.WriteLine("\n - What kind of job?");
                Console.WriteLine(" - Not hard ones. You just need to kill some walkers around, help our guys. \n");
                change_rel_parameter(0, true, 1);
            }

            else if (key.KeyChar == '2')
            {
                Console.Clear();

                Console.WriteLine("\n - Alright, what I must to do?");
                Console.WriteLine(" - You just need to kill some walkers around, help our guys. \n");
                change_rel_parameter(0, true, 1);
            }

            else if (key.KeyChar == '3')
            {
                Console.Clear();

                Console.WriteLine("\n - I'm not interested, sorry");
                Console.WriteLine(" - Oh, man, that is wrong answer. I helped you not to die. Maybe you will change your mind? \n");
                change_rel_parameter(0, false, 1);
                work_dialog();
            }
            else
            {
                Console.Clear();

                Console.WriteLine("\n (System error: this variant doesn't exist) \n");
                work_dialog();
            }

        }

        void bye_dialog()
        {
            Console.Clear();

            Console.WriteLine(" - Well, you're in, yeah? We want to do this later. Get some rest for now. \n");
            Console.WriteLine("1) - Okey, thanks. \n" +
                                "2) - When we will go outside? \n" +
                                "3) - This bodies will be here, ha? \n");

            var key = Console.ReadKey();
            if (key.KeyChar == '1')
            {
                Console.Clear();

                Console.WriteLine("\n - Okey, thanks.");
                Console.WriteLine(" He and his guys leave you alone. Laying down on a couch you fell in asleep few minutes later. \n");
            }

            else if (key.KeyChar == '2')
            {
                Console.Clear();

                Console.WriteLine("\n - When we will go outside?");
                Console.WriteLine(" - Questions tommorow, okey? I need to go. \n");
                Console.WriteLine(" He and his guys leave you alone. Laying down on a couch you fell in asleep few minutes later. \n");
            }

            else if (key.KeyChar == '3')
            {
                Console.Clear();

                Console.WriteLine("\n - This bodies will be here?");
                Console.WriteLine(" - They will come with, don't worry. And.. we need to go. \n");
                Console.WriteLine(" He and his guys leave you alone. Laying down on a couch you fell in asleep few minutes later. \n");
            }
            else
            {
                Console.Clear();

                bye_dialog();
            }
        }
        #endregion
        #endregion






        #region Firts day
        // For adding changes in Rel_Info
        Rel_Info add = new Rel_Info();
        // For adding chars' parameter changes
        Char_Info par = new Char_Info();

        // Main scenario method
        public void FirstDay()
        {
            Console.Clear();

            Console.WriteLine("\n Today is a nice sunny day. You can see how the sun's rays get through the curtains of the windows. " +
                              "The air is a little heavy with dust, but you're used to it.");
            Console.WriteLine("\n Few minutes later since you woke up, you hear steps outside the only one door un your room.");
            Console.WriteLine("\n The man, that was talking to you yestarday, walks in your room");
            Console.ReadKey();

            wake_up_dialog();

            Console.Clear();
            Console.WriteLine(" Warm air and little bit cold wind give you a sense of live, that you needed to. " +
                              "Now you feeiling yourself not like grabage, but some kinda of man, that people needs");
            Console.WriteLine("\n - Good weather today, isn't it? Here. It's ours weapons storage. Here you can get a gun for some hunt. " +
                              "Well, let's get in there, and Sam will give you your pistol.");
            Console.WriteLine(" You see a big hosue in front of you. There is some rusty metal sheets around foundation, " +
                              "other part of building made from stone." +
                              "From there you hear some noise and people talking.");
            Console.WriteLine(" When you get inside one man catch his eyes on you.");
            Console.WriteLine();

            weaponer_dialog();
            

            while (commands_check()) { }

        }

        void wake_up_dialog()
        {
            Console.Clear();

            Console.WriteLine("\n - Well, new day has come. Have you got a good rest? \n");

            Console.WriteLine("1) - Yeah. I'm ready. \n" +
                                "2) - When we will get to work? \n");

            var key = Console.ReadKey();
            if (key.KeyChar == '1')
            {
                Console.Clear();

                Console.WriteLine("\n - Yeah. I'm ready.");
                Console.WriteLine(" - Alright. Follow me, I'll show you all around. \n");
            }

            else if (key.KeyChar == '2')
            {
                Console.Clear();

                Console.WriteLine("\n - When we will get to work?");
                Console.WriteLine(" - You haven't got up yet, but got a good attitude for work. Not bad. Follow me, I'll show you all around. \n");
            }
            else
            {
                Console.Clear();

                Console.WriteLine("\n (System error: this variant doesn't exist) \n");
                wake_up_dialog();
            }

            Console.WriteLine("\n You get up from couch and follow this man. When you get out to outside, suns punches it's rays into your eyes.");
            Console.ReadKey();

        }

        void weaponer_dialog()
        {
            Console.WriteLine(" - Good morning, Crim. Is this that newbee, ha? Gonna get to work, donchya? " +
                              "So, I prepared some guns for you and other guys from your team. You will get a 9-mm pistol. " +
                              "Not so much, but we can't trust you so much, ya know.");

            weapons.Add(new Weapon { Name = "AMBX 9-mm", Damage = 25, Accuracy = 80 });
            items.Add(new Item { Name = weapons[0].Name, Type = "Weapon", Weight = 1.6 });
            inventory.Add(new Inventory { Slot = "Secondary", Type = items[0].Type });

            Console.WriteLine("\n You take a gun from table in front of weaponer.");
            Console.WriteLine("\n 1) Thanks." +
                              "\n 2) Just this, uhh..." +
                              "\n 3) Better than nothing.");

            var key = Console.ReadKey(true);
            if (key.KeyChar == '1')
            {
                Console.WriteLine("\n Thanks.");
                Console.WriteLine(" - Yeah. You're welcome. \n");
            }

            else if (key.KeyChar == '2')
            {
                Console.WriteLine("\n Just this, uhh...");
                Console.WriteLine(" - Later, maybe, you could get sometheing better. But for now - only this. \n");
            }
            else if (key.KeyChar == '3')
            {
                Console.WriteLine("\n Better than nothing.");
                Console.WriteLine(" - Later you could get some cooler guns, don't worry.");
            }
            else
            {
                Console.Clear();

                Console.WriteLine("\n (System error: this variant doesn't exist) \n");
                weaponer_dialog();
            }
        }

        #endregion








        #region Commands

        #region Relationship methods
        public void add_rel_info(string name, int rel)
        {
            rel_info.Add(new Rel_Info { name = name, rel = rel });
        }

        public void change_rel_parameter(int index, bool wth, int value)
        {
            if (wth == true)
            {
                rel_info[index].rel += value;
            }
            else
            {
                rel_info[index].rel += -value;
            }
        }

        public void write_char_info_list(List<Rel_Info> list)
        {
            foreach (Rel_Info person in list)
            {
                Console.WriteLine("{0}: Relation({1})", person.name, person.rel);
            }
        }
        #endregion

        #region Characters parameters methods
        public void add_char_info(string N, int mH, int H, int mS, int S)
        {
            char_info.Add(new Char_Info { name = N, max_health = mH, health = H, max_stamina = mS, stamina = S });
        }

        public void change_char_parameter(string type, string happen, int value)
        {
            if (type == "maxHealth")
            {
                if (happen == "decrease")
                {
                    char_info[0].max_health = -value;
                }
                else
                {
                    char_info[0].max_health = +value;
                }
            }

            if (type == "health")
            {
                if (happen == "decrease")
                {
                    char_info[0].health = -value;
                }
                else
                {
                    char_info[0].health = +value;
                }
            }

            if (type == "maxStamina")
            {
                if (happen == "decrease")
                {
                    char_info[0].max_stamina = -value;
                }
                else
                {
                    char_info[0].max_stamina = +value;
                }
            }

            if (type == "stamina")
            {
                if (happen == "decrease")
                {
                    char_info[0].stamina = -value;
                }
                else
                {
                    char_info[0].stamina = +value;
                }
            }

        }

        public void get_char_parameters(List<Char_Info> list)
        {
            foreach (Char_Info person in list)
            {
                Console.WriteLine();
                Console.WriteLine("Name: {0}", person.name);
                Console.WriteLine("Health: {0}", person.health);
                Console.WriteLine("Stamina {0}", person.stamina);
            }
        }

        public void get_char_parameters(List<Char_Info> list, string name)
        {
            if (name.ToLower() == "me")
            {
                Console.WriteLine();
                Console.WriteLine("Name: {0}", char_info[0].name);
                Console.WriteLine("Max health: {0}", char_info[0].max_health);
                Console.WriteLine("Health: {0}", char_info[0].health);
                Console.WriteLine("Max stamina: {0}", char_info[0].max_stamina);
                Console.WriteLine("Stamina {0}", char_info[0].stamina);
            }
        }
        #endregion

        #region Scenarios commands
        // Check commands in input read
        public bool commands_check()
        {
            readData = Console.ReadLine();

            if (readData.ToLower() == "char info")
            {
                Console.Clear();

                Console.WriteLine(" Whom information you want to see about? \n");
                get_char_parameters(char_info, Console.ReadLine());

                Console.WriteLine("\n Press any key to exit character info menu");
                Console.ReadKey();

                return true;
            }

            else if(readData.ToLower() == "relations")
            {
                Console.Clear();

                write_char_info_list(rel_info);

                Console.WriteLine("\n Press any key to exit relations menu");
                Console.ReadKey();

                return true;
            }

            else if (readData.ToLower() == "help")
            {
                Console.WriteLine("\n Type \"my info\" for getting your characters information");

                return true;
            }

            return false;
        }

        // Beautiful exite
        void Leave_Meth()
        {
            Console.WriteLine();
            Console.WriteLine("Scenario is over. Press any \"Escape\" to leave");
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
            Environment.Exit(0);
        }
        #endregion

        #endregion
    }
}
