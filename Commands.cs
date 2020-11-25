using System;
using System.Collections.Generic;
using System.Text;

namespace RPProject
{
    public class Commands
    {
        public class Char : Program
        {
            object[][] tst = new object[2][];

            public object[][] get_char_info()
            {
                tst[0] = new string[5] { "name", "max health", "health", "max stamina", "stamina" };
                tst[1] = new object[5] { char_name, char_max_hlth, char_hlth, char_max_stmn, char_stmn };

                return tst;
            }
        }
    }
}
