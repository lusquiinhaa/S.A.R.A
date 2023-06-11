using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARA
{
    public class GrammarRules
    {
        public static IList<string> WhatTimeIs = new List<string>()
          {
              "Que horas São",
              "Me diga as horas",
              "Poderia me dizer que horas são",
              "horas",
              "Estou atrasado que horas são",

          };

        public static IList<string> WhatsDateIs = new List<string>()
        {
            "Data de hoje",
            "Qual é a data de hoje",
            "Você sabe me dizer a data de hoje",
            "que dia e hoje",
            
        };

        public static IList<string> SaraStartListening = new List<string>()
        {
            "Sara",
            "Sara você está ai?",
            "Olá Sara",
            "Oi Sara", 

        };

        public static IList<string> SaraStopListening = new List<string>()
        {
            "Pare de ouvir",
            "Pare de me ouvir",
            "Fique surdo",
            "Não escute",
        };


        public static IList<string> ChangeVoice = new List<string>()
        {
            "Altere a voz",
            "Alterar voz",
        };

        public static IList<string> OpenProgram = new List<string>()
        {
            "Navegador",
        }; 

    }
}
