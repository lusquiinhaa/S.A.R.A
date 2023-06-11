using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARA
{
    public class Runner
    {
        //Fala que horas são
        public static void WhatTimeIs()
        {
            Speaker.Speak(DateTime.Now.ToShortTimeString());
        }

        public static void WhatDateIs()
        {
            Speaker.Speak(DateTime.Now.ToShortDateString());
        }
    }
}
