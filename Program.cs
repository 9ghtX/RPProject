using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;
using RPProject.Scripts;

namespace RPProject
{
    public class Program
    {
        public class JSget
        {
            public string MyProperty1 { get; set; }
            public int MyProperty2 { get; set; }
        }

        public class Char_Info
        {
            public string el_name { get; set; }
            public string el_str_val { get; set; }
            public int    el_int_val { get; set; }
        }
        
        /*
        public void Make_Char_Info_List()
        {
            var char_info = new List<Char_Info>();

            char_info.Add(new Char_Info()
            {
                el_name = "Name",
                el_str_val = char_name,
            });

            char_info.Add(new Char_Info()
            {
                el_name = "Health",
                el_int_val = 100,
            });

            char_info.Add(new Char_Info()
            {
                el_name = "Stamina",
                el_int_val = 100,
            });
        }
        */

        public string get_from_console = "";
        public string char_name = "";
        public int char_hlth;
        public int char_stmn;
        public int char_max_hlth;
        public int char_max_stmn;

        public void write_char_array(object[][] array)
        {
            Console.WriteLine("");
            for (int k = 0; k < array[0].Length; k++)
            {
                Console.WriteLine(array[0][k].ToString() + " " + array[1][k].ToString());
            }
            Console.WriteLine();
        }

        static public void Main()
        {
            Intro intro = new Intro();

            intro.start();
        }
    }
}
