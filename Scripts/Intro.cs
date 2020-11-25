using System;
using System.Collections.Generic;
using System.Text;

namespace RPProject.Scripts
{
    public class Intro : Program
    {
        Commands.Char commands = new Commands.Char();
        string command_name = "";
        public void start()
        {
            // Set full characters health and stamina
            char_name = "Nameless";
            char_hlth = 100;
            char_stmn = 100;
            char_max_hlth = 100;
            char_max_stmn = 100;

            // Intro dialog and setting characters name
            Console.WriteLine(" - Welcome, newcomer! " +
                "\n He points at two men in gray coaps. You don't see their faces, but they don't look like someone dangerous." +
                "\n - My guys picked you up and brought here. You were roaming along a road, looking like homeless, and then this found you. This place now your new home. But in first I want to know your name...");

            // Setting chars' name or opening characters information
            Console.WriteLine("\n You tell them your name: " +
                              "(Type your name or \"char info\" (in any registor) to get character information)");
            // Reading input info
            get_from_console = Console.ReadLine();
            // Checking for coincidence input with any commands
            if (commands_check(get_from_console) == true)
            {
                
            }
            char_name = get_from_console;


            Console.WriteLine("\n - Well, " + char_name + ", you in Westborn, the city of tradors and adventurists. Here you can find some work for yourself, whatever it would be." +
                "Today is a good day for ya. We got some work yesterdays' night. So.. You could help us for your saving from starving on Wastelands.");


            get_from_console = Console.ReadLine();
            if (commands_check(get_from_console) == true)
            {

            }

            Leave_Meth();
        }

        void Leave_Meth()
        {
            Console.WriteLine();
            Console.WriteLine("Press \"Escape\" to leave");
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
        }

        bool commands_check(string get)
        {
            if (get.ToLower() == "char info")
            {
                commands.get_char_info();
                write_char_array(commands.get_char_info());
                Console.WriteLine("Press \"Enter\" to leave the character info");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                command_name = "get_char_info";
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
